using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.Ajax.Utilities;
using Stagio.DataLayer;
using Stagio.Domain.Application;
using Stagio.Domain.Entities;
using Stagio.Web.Services;
using Stagio.Web.ViewModels.InternshipApplication;

namespace Stagio.Web.Controllers
{
    [OutputCacheAttribute(VaryByParam = "*", Duration = 0, NoStore = true)]
    public partial class InternshipApplicationController : Controller
    {
        private readonly IEntityRepository<InternshipApplication> _applicationRepository;
        private readonly IEntityRepository<InternshipOffer> _offerRepository;
        private readonly IEntityRepository<Student> _studentRepository;
        private readonly IHttpContextService _httpContext;
        private readonly IFileSaveService _fileService;

        public InternshipApplicationController(
            IEntityRepository<InternshipApplication> applicationRepository,
            IEntityRepository<InternshipOffer> offerRepository,
            IEntityRepository<Student> studentRepository, 
            IFileSaveService fileSaveService,
            IHttpContextService httpContext)
        {
            DependencyService.VerifyDependencies(applicationRepository, offerRepository, studentRepository, fileSaveService, httpContext);
            
            _applicationRepository = applicationRepository;
            _offerRepository = offerRepository;
            _studentRepository = studentRepository;
            _fileService = fileSaveService;
            _httpContext = httpContext;
        }

        [Authorize(Roles = RoleNames.Student)]
        public virtual ActionResult StudentApplicationIndex()
        {
            var studentId = _httpContext.GetUserId();

            return this.GetApplicationsForSpecificStudent(studentId);
        }

        [Authorize(Roles = RoleNames.Coordinator)]
        public virtual ActionResult GetApplicationsForSpecificStudent(int studentId)
        {
            if (_studentRepository.GetById(studentId) == null)
            {
                return HttpNotFound();
            }

            var applications = _applicationRepository.GetAll().AsQueryable().Where(x => x.ApplyingStudent.Id == studentId);

            var internshipApplicationIndexViewModels = Mapper.Map<IEnumerable<StudentIndex>>(applications);

            foreach (StudentIndex application in internshipApplicationIndexViewModels)
            {
                this.SetInternshipApplicationViewModelContent(application);
            }

            return View(MVC.InternshipApplication.Views.StudentIndex, internshipApplicationIndexViewModels);
        }

        [Authorize(Roles = RoleNames.Employee + "," + RoleNames.Coordinator)]
        public virtual ActionResult EmployeeApplicationIndex(int offerId)
        {
            var applicationsForOffer = _applicationRepository.GetAll().AsEnumerable().Where(x => x.InternshipOfferId == offerId).ToList<InternshipApplication>();

            var internshipApplicationsIndexViewModels = Mapper.Map<IEnumerable<ViewModels.InternshipApplication.EmployeeIndex>>(applicationsForOffer);
            
            var internshipApplications = internshipApplicationsIndexViewModels.ToList();
            for (int i = 0; i < internshipApplications.Count(); i++)
            {
                var student = _studentRepository.GetById(internshipApplications.ElementAt(i).StudentId);
                internshipApplications.ElementAt(i).StudentName = student.FirstName + " " + student.LastName;
                internshipApplications.ElementAt(i).InternshipTitle = internshipApplications.ElementAt(i).InternshipOffer.Title;
                internshipApplications.ElementAt(i).OfferPublicationDate = internshipApplications.ElementAt(i).InternshipOffer.PublicationDate;
                internshipApplications.ElementAt(i).Email = _studentRepository.GetById(internshipApplications.ElementAt(i).StudentId).Identifier;
                internshipApplications.ElementAt(i).PhoneNumber = _studentRepository.GetById(internshipApplications.ElementAt(i).StudentId).PhoneNumber;
            }
            internshipApplicationsIndexViewModels = internshipApplications;

            return View(MVC.InternshipApplication.Views.EmployeeIndex, internshipApplicationsIndexViewModels);
        }

        [Authorize(Roles = RoleNames.Coordinator)]
        public virtual ActionResult CoordinatorApplicationIndex()
        {
            var allStudents = _studentRepository.GetAll().ToList();
            var allApplications = _applicationRepository.GetAll().ToList();
            var bestProgressionOfStudents = new List<CoordinatorProgressionIndex>();

            foreach (var student in allStudents)
            {
                var studentApplications = allApplications.Where(x => x.ApplyingStudent.Id == student.Id).ToList();
                InternshipApplication mostProgressedApp = null;

                if (studentApplications.Count() != 0)
                {
                    var bestProgressionStatus = studentApplications.Max(x => (InternshipApplication.ApplicationStatus?)x.Progression);
                    mostProgressedApp = studentApplications.First(x => x.Progression == bestProgressionStatus);
                }

                var newStudent = new CoordinatorProgressionIndex
                {
                    StudentId = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    BestProgression = Mapper.Map<StudentIndex>(mostProgressedApp)
                };

                if (newStudent.BestProgression != null)
                {
                    SetInternshipApplicationViewModelContent(newStudent.BestProgression);
                }
                else
                {
                    newStudent.BestProgression = new StudentIndex();

                    newStudent.BestProgression.ProgressionPercentage = 0;
                    newStudent.BestProgression.InternshipOfferTitle = WebMessage.GlobalMessage.NOT_APPLICABLE;
                    newStudent.BestProgression.ProgressionDescription = WebMessage.InternshipApplicationMessage.NO_APPLICATION_FOR_THIS_STUDENT;
                    newStudent.BestProgression.ProgessionUpdateHtmlContent = WebMessage.GlobalMessage.NOT_APPLICABLE;
                    newStudent.BestProgression.ProgessionUpdateHtmlTitle = WebMessage.GlobalMessage.NOT_APPLICABLE;
                    newStudent.BestProgression.LastProgressionUpdateDateText = WebMessage.GlobalMessage.NOT_APPLICABLE;
                }

                bestProgressionOfStudents.Add(newStudent);
            }

            return View(MVC.InternshipApplication.Views.ViewNames.CoordinatorIndex, bestProgressionOfStudents);
        }

        [Authorize(Roles = RoleNames.Student)]
        public virtual ActionResult Create(int internshipOfferId)
        {
            var internshipOffer = _offerRepository.GetById(internshipOfferId);
            var studentId = _httpContext.GetUserId();
            var internshipApplication = new InternshipApplication()
            {
                StudentId = studentId,
                InternshipOfferId = internshipOfferId,
                InternshipOffer = internshipOffer
            };
            var IAViewModel = Mapper.Map<Create>(internshipApplication);
            return View(IAViewModel);
        }

        [HttpPost]
        [Authorize(Roles = RoleNames.Student)]
        public virtual ActionResult Create(Create applicationViewModel)
        {
            if (!ModelState.IsValid)
            {
                applicationViewModel.InternshipOffer = _offerRepository.GetById(applicationViewModel.InternshipOfferId);
                return View(applicationViewModel);
            }

            var internshipApplication = Mapper.Map<InternshipApplication>(applicationViewModel);

            internshipApplication.ApplicationDate = DateTime.Now;

            //Setting default date values
            internshipApplication.InterviewDate = DateTime.Now;
            internshipApplication.CompanyAcceptedDate = DateTime.Now;
            internshipApplication.StudentAcceptedDate = DateTime.Now;

            internshipApplication.InternshipAgreement = null;

            internshipApplication.Progression = InternshipApplication.ApplicationStatus.StudentHasApplied;

            if (!FileFieldsAreEmpty(applicationViewModel))
            {
                var student = _studentRepository.GetById(applicationViewModel.StudentId);

                string pathEnding = _fileService.SaveStudentFiles(student, applicationViewModel);

                internshipApplication.PathToResume = pathEnding + "\\" + applicationViewModel.Resume.FileName;
                internshipApplication.PathToCoverLetter = pathEnding + "\\" + applicationViewModel.CoverLetter.FileName;
            }

            _applicationRepository.Add(internshipApplication);

            string feedbackMessage = WebMessage.InternshipApplicationMessage.APPLICATION_CREATE_SUCCESS;

            return RedirectToAction(MVC.InternshipApplication.StudentApplicationIndex().Success(feedbackMessage));
        }

        [HttpPost]
        [Authorize(Roles = RoleNames.Student)]
        public virtual ActionResult UpdateProgression(StudentIndex item)
        {
            var internshipApplication = _applicationRepository.GetById(item.Id);

            var currentStudent = _studentRepository.GetById(_httpContext.GetUserId());

            if (internshipApplication == null || currentStudent == null)
            {
                return HttpNotFound();
            }

            bool applicationIsAssociatedToCurrentStudent = (internshipApplication.StudentId == currentStudent.Id);

            bool nextProgressionWasSuccessfullySet = this.SetNextProgression(internshipApplication, item.LastProgressionUpdateDate);

            if (!applicationIsAssociatedToCurrentStudent || !nextProgressionWasSuccessfullySet)
            {
                return HttpNotFound();
            }

            _applicationRepository.Update(internshipApplication);

            const string feedbackMessage = WebMessage.InternshipApplicationMessage.APPLICATION_PROGRESSION_UPDATE_SUCCESS;

            return RedirectToAction(MVC.InternshipApplication.StudentApplicationIndex().Success(feedbackMessage));
        }

        public virtual ActionResult DownloadFile(string path, int offerId)
        {
            string PathBeginning;
            try
            {
                PathBeginning = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
            }
            catch
            {
                PathBeginning = "";
            }
            string ExtraFilePath = PathBeginning + path;

            string fileName = path.Split('\\').Last();

            if (System.IO.File.Exists(ExtraFilePath))
            {
                return File(ExtraFilePath, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            }

            ModelState.AddModelError("pathToExtraFile", "Impossible de trouver le fichier, veuillez contacter l'administrateur.");
            TempData["ViewData"] = ViewData;
            return RedirectToAction(MVC.InternshipApplication.EmployeeApplicationIndex(offerId));
        }

        private bool FileFieldsAreEmpty(Create create)
        {
            return (create == null || create.CoverLetter == null || create.Resume == null);
        }

        private void SetInternshipApplicationViewModelContent(StudentIndex application)
        {
            switch (application.Progression)
            {
                case Stagio.Domain.Entities.InternshipApplication.ApplicationStatus.StudentHasApplied:
                    application.ProgressionPercentage = 25;
                    application.ProgressionDescription = WebMessage.InternshipApplicationMessage.StudentHasApplied.PROGRESSION_DESCRIPTION;
                    application.ProgessionUpdateHtmlContent = WebMessage.InternshipApplicationMessage.StudentHasApplied.PROGRESSION_UPDATE_HTML_CONTENT;
                    application.ProgessionUpdateHtmlTitle = WebMessage.InternshipApplicationMessage.StudentHasApplied.PROGRESSION_UPDATE_HTML_TITLE;
                    application.LastProgressionUpdateDateText = WebMessage.InternshipApplicationMessage.StudentHasApplied.PROGRESSION_UPDATE_DATE_TEXT;
                    break;
                case Stagio.Domain.Entities.InternshipApplication.ApplicationStatus.StudentHadInterview:
                    application.ProgressionPercentage = 50;
                    application.ProgressionDescription = WebMessage.InternshipApplicationMessage.StudentHadInterview.PROGRESSION_DESCRIPTION;
                    application.ProgessionUpdateHtmlContent = WebMessage.InternshipApplicationMessage.StudentHadInterview.PROGRESSION_UPDATE_HTML_CONTENT;
                    application.ProgessionUpdateHtmlTitle = WebMessage.InternshipApplicationMessage.StudentHadInterview.PROGRESSION_UPDATE_HTML_TITLE;
                    application.LastProgressionUpdateDateText = WebMessage.InternshipApplicationMessage.StudentHadInterview.PROGRESSION_UPDATE_DATE_TEXT;
                    break;
                case Stagio.Domain.Entities.InternshipApplication.ApplicationStatus.CompanyAcceptedStudent:
                    application.ProgressionPercentage = 75;
                    application.ProgressionDescription = WebMessage.InternshipApplicationMessage.CompanyAcceptedStudent.PROGRESSION_DESCRIPTION;
                    application.ProgessionUpdateHtmlContent = WebMessage.InternshipApplicationMessage.CompanyAcceptedStudent.PROGRESSION_UPDATE_HTML_CONTENT;
                    application.ProgessionUpdateHtmlTitle = WebMessage.InternshipApplicationMessage.CompanyAcceptedStudent.PROGRESSION_UPDATE_HTML_TITLE;
                    application.LastProgressionUpdateDateText = WebMessage.InternshipApplicationMessage.CompanyAcceptedStudent.PROGRESSION_UPDATE_DATE_TEXT;
                    break;
                case Stagio.Domain.Entities.InternshipApplication.ApplicationStatus.StudentAcceptedOffer:
                    application.ProgressionPercentage = 100;
                    application.ProgressionDescription = WebMessage.InternshipApplicationMessage.StudentAcceptedOffer.PROGRESSION_DESCRIPTION;
                    application.ProgessionUpdateHtmlContent = WebMessage.InternshipApplicationMessage.StudentAcceptedOffer.PROGRESSION_UPDATE_HTML_CONTENT;
                    application.ProgessionUpdateHtmlTitle = WebMessage.InternshipApplicationMessage.StudentAcceptedOffer.PROGRESSION_UPDATE_HTML_TITLE;
                    application.LastProgressionUpdateDateText = WebMessage.InternshipApplicationMessage.StudentAcceptedOffer.PROGRESSION_UPDATE_DATE_TEXT;
                    break;
                default:
                    break;
            }
        }

        private bool SetNextProgression(InternshipApplication application, DateTime lastUpdateDate)
        {
            switch (application.Progression)
            {
                case Stagio.Domain.Entities.InternshipApplication.ApplicationStatus.StudentHasApplied:
                    application.Progression = InternshipApplication.ApplicationStatus.StudentHadInterview;
                    application.InterviewDate = lastUpdateDate;
                    break;
                case Stagio.Domain.Entities.InternshipApplication.ApplicationStatus.StudentHadInterview:
                    application.Progression = InternshipApplication.ApplicationStatus.CompanyAcceptedStudent;
                    application.CompanyAcceptedDate = lastUpdateDate;
                    break;
                case Stagio.Domain.Entities.InternshipApplication.ApplicationStatus.CompanyAcceptedStudent:
                    application.Progression = InternshipApplication.ApplicationStatus.StudentAcceptedOffer;
                    application.StudentAcceptedDate = lastUpdateDate;
                    break;
                default:
                    return false;
            }
            return true;
        }
    }
}