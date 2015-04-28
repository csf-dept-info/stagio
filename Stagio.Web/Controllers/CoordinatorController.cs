using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stagio.DataLayer;
using Stagio.Domain.Application;
using Stagio.Domain.Entities;
using Stagio.Web.Services;
using Stagio.Web.ViewModels.Coordinator;

using AutoMapper;

namespace Stagio.Web.Controllers
{
    [OutputCacheAttribute(VaryByParam = "*", Duration = 0, NoStore = true)]
    [Authorize(Roles = RoleNames.Coordinator)]
    public partial class CoordinatorController : Controller
    {
        private readonly IEntityRepository<Coordinator> _coordinatorRepository;
        private readonly IAccountService _accountService;
        private readonly IHttpContextService _httpContextService;
        private readonly IEntityRepository<Student> _studentRepository;
        private readonly IFileImportService _fileService;
        private readonly IInternshipPeriodService _internshipPeriodService;
        private readonly IArchivesService _archivesService; 

        public CoordinatorController(
            IEntityRepository<Coordinator> coordinatorRepository,
            IEntityRepository<Student> studentRepository,
            IAccountService accountService,
            IFileImportService fileService,
            IHttpContextService httpContextService,
            IInternshipPeriodService internshipPeriodService,
            IArchivesService archivesService)
        {
            DependencyService.VerifyDependencies(coordinatorRepository, studentRepository, accountService, fileService, httpContextService, internshipPeriodService, archivesService);

            _coordinatorRepository = coordinatorRepository;
            _studentRepository = studentRepository;
            _accountService = accountService;
            _httpContextService = httpContextService;
            _fileService = fileService;
            _internshipPeriodService = internshipPeriodService;
            _archivesService = archivesService;
        }

        public virtual ActionResult Index()
        {
            var user = _coordinatorRepository.GetById(_httpContextService.GetUserId());
            var userModel = Mapper.Map<ViewModels.Coordinator.Index>(user);
            return View(MVC.Coordinator.Views.ViewNames.Index, userModel);
        }

        public virtual ActionResult ImportStudent()
        {
            return View(MVC.Coordinator.Views.ImportStudent, new ImportStudent());
        }

        [HttpPost]
        public virtual ActionResult ImportStudent(HttpPostedFileBase file)
        {
            if (!_fileService.IsFileValid(".csv", file))
            {
                ModelState.AddModelError("file", _fileService.errorMessage);
                return View(MVC.Coordinator.Views.ViewNames.ImportStudent);
            }

            var importStudentsViewModel = _fileService.ImportStudentInformationsFromFile(file);

            if (importStudentsViewModel == null || importStudentsViewModel.Count() < 1)
            {
                ModelState.AddModelError("file", _fileService.errorMessage);
                return View(MVC.Coordinator.Views.ViewNames.ImportStudent);
            }

            return View(MVC.Coordinator.Views.ValidateImport, importStudentsViewModel);
        }

        [HttpPost]
        public virtual ActionResult ValidateImport(IEnumerable<ImportStudentViewModel> importStudents)
        {
            SubscribeStudentList(importStudents);

            const string feedbackMessage = WebMessage.CoordinatorMessage.STUDENT_ACCOUNTS_IMPORT_SUCCESS;

            return RedirectToAction(MVC.Coordinator.Index().Success(feedbackMessage));
        }

        public virtual ActionResult StudentsList()
        {
            var studentsList = _studentRepository.GetAll().ToList();
            var studentsListVm = new StudentsList
            {
                subscribedStudents = new List<ViewModels.Student.Index>(),
                notSubscribedStudents = new List<ViewModels.Student.Index>()
            };

            foreach (var student in studentsList)
            {
                var studentVm = Mapper.Map<ViewModels.Student.Index>(student);

                if (IsNumeric(student.Identifier))
                {
                    studentsListVm.notSubscribedStudents.Add(studentVm);
                }
                else
                {
                    studentsListVm.subscribedStudents.Add(studentVm);
                }
            }

            return View(MVC.Coordinator.Views.ViewNames.StudentsList, studentsListVm);
        }

        public virtual ActionResult ChooseInternshipPeriod()
        {
            var period = _internshipPeriodService.GetActualInternshipPeriod();

            if (period == null)
            {
                return View(MVC.Coordinator.Views.ChooseInternshipPeriod);
            }

            var vmPeriod = Mapper.Map<ViewModels.Coordinator.ChoosePeriod>(period);

            return View(MVC.Coordinator.Views.ChooseInternshipPeriod, vmPeriod);
        }

        [HttpPost]
        public virtual ActionResult ChooseInternshipPeriod(ViewModels.Coordinator.ChoosePeriod vmChoosePeriod)
        {
            if (vmChoosePeriod.StartDate >= vmChoosePeriod.EndDate)
            {
                ModelState.AddModelError("dateError", WebMessage.CoordinatorMessage.ChoosePeriod.INVALID_START_DATE);
                return View(MVC.Coordinator.Views.ChooseInternshipPeriod, vmChoosePeriod);
            }

            var period = Mapper.Map<InternshipPeriod>(vmChoosePeriod);

            _internshipPeriodService.AddToPeriodRepository(period);

            const string feedback = WebMessage.CoordinatorMessage.ChoosePeriod.CHOOSE_DATE_SUCCESS;
            return RedirectToAction(MVC.Coordinator.Index()).Success(feedback);
        }

        //Get
        public virtual ActionResult CleanDatabase()
        {
            return View();

        }

        [HttpPost]
        public virtual ActionResult CleanDatabase(Stagio.Web.ViewModels.Coordinator.CleanDatabase cleanDatabaseVm)
        {
            var user = _coordinatorRepository.GetById(_httpContextService.GetUserId());

            if (cleanDatabaseVm == null || !AccountService.VerifyPassword(user.Password, cleanDatabaseVm.Password))
            {
                return View(MVC.Coordinator.Views.ViewNames.CleanDatabase).Error(WebMessage.CoordinatorMessage.WRONG_PASSWORD_VALIDATION);
            }
            
            _archivesService.CreateArchive(_internshipPeriodService.GetActualInternshipPeriod());

            return RedirectToAction(MVC.Ci.CleanDatabase()).Success(WebMessage.CoordinatorMessage.CleanDatabase.CLEAN_DATABASE_SUCCESS);
        }

        public virtual ActionResult InternshipsPeriodsList()
        {
            var archivesList = _archivesService.GetArchives();
            var periodsListVm = new PeriodsList
            {
                periodsList = new List<ViewModels.Archives.Index>()
            };

            foreach (var archive in archivesList)
            {
                var periodVm = Mapper.Map<ViewModels.Archives.Index>(archive);

                periodsListVm.periodsList.Add(periodVm);
            }

            return View(MVC.Coordinator.Views.ViewNames.PeriodsList, periodsListVm);
        }

        public virtual ActionResult InternshipPeriodDetails(int id)
        {
            var archive = _archivesService.GetArchiveById(id);

            if (archive == null)
            {
                return HttpNotFound();
            }

            var periodDetails = Mapper.Map<ViewModels.Archives.Details>(archive);

            return View(MVC.Coordinator.Views.ViewNames.InternshipPeriodsDetails, periodDetails);
        }

        private void SubscribeStudentList(IEnumerable<ImportStudentViewModel> importStudents)
        {
            foreach (var student in importStudents)
            {
                ImportStudent(student);
            }
        }

        private void ImportStudent(ImportStudentViewModel importStudent)
        {
            if (_accountService.StudentExist(importStudent.Identifier))
            {
                _studentRepository.Update(RenewStudentMembership(importStudent));
            }
            else
            {
                _studentRepository.Add(CreateStudent(importStudent));
            }
        }


        private Student CreateStudent(ImportStudentViewModel importStudent)
        {
            var student = Mapper.Map<Student>(importStudent);
            student.Roles = new List<UserRole>
                    {
                    new UserRole {RoleName = RoleNames.Student}
                    };

            student.Active = true;
            student.Password = student.Identifier;
            return student;
        }

        private Student RenewStudentMembership(ImportStudentViewModel importStudent)
        {
            var students = _studentRepository.GetAll().ToList();
            var student = students.FirstOrDefault();
            student.Active = true;
            student.Identifier = importStudent.Identifier;
            return student;
        }

        private bool IsNumeric(string matricule)
        {
            int integerOut;
            return int.TryParse(matricule, out integerOut);
        }



    }
}