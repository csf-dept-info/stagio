using System.Web.Mvc;
using AutoMapper;
using Stagio.DataLayer;
using Stagio.Domain.Application;
using Stagio.Domain.Entities;
using Stagio.Domain.SecurityUtilities;
using Stagio.Web.Controllers.Utilities;
using Stagio.Web.Services;
using Stagio.Web.ViewModels.Student;
using System;

namespace Stagio.Web.Controllers
{
    [OutputCacheAttribute(VaryByParam = "*", Duration = 0, NoStore = true)]
    public partial class StudentController : Controller
    {
        private readonly IEntityRepository<Student> _studentRepository;
        private readonly IAccountService _accountService;
        private readonly IHttpContextService _httpContextService;

        public StudentController(
            IEntityRepository<Student> studentRepository,
            IAccountService accountService,
            IHttpContextService httpContextService)
        {
            DependencyService.VerifyDependencies(studentRepository, accountService, httpContextService);
            
            _studentRepository = studentRepository;
            _accountService = accountService;
            _httpContextService = httpContextService;
        }

        // GET: Student
        [Authorize(Roles = RoleNames.Student)]
        public virtual ActionResult Index()
        {
            var user = _studentRepository.GetById(_httpContextService.GetUserId());
            var userModel = Mapper.Map<Index>(user);
            return View(MVC.Student.Views.ViewNames.Index, userModel);
        }

        // GET: Student/Edit/5
        [Authorize(Roles = RoleNames.Student)]
        public virtual ActionResult Edit()
        {
            var student = _studentRepository.GetById(_httpContextService.GetUserId());
            if (student != null)
            {
                var viewModel = Mapper.Map<Edit>(student);
                return View(viewModel);
            }
            return HttpNotFound();
        }

        // POST: Student/Edit/5
        [HttpPost]
        [ActionName("Edit")]
        [MultipleButton(Name = "action", Argument = "EditProfile")]
        [Authorize(Roles = RoleNames.Student)]
        public virtual ActionResult EditProfile(Edit studentViewModel)
        {
            var student = _studentRepository.GetById(_httpContextService.GetUserId());
            if (student != null)
            {
                if (!ModelState.IsValid)
                {
                    return View(MVC.Student.Views.ViewNames.Edit);
                }
                Mapper.Map(studentViewModel, student);
                _studentRepository.Update(student);

                const string feedbackMessage = WebMessage.GlobalMessage.PROFILE_EDIT_SUCCESS;

                return RedirectToAction(MVC.Student.Index().Success(feedbackMessage));
            }
            return HttpNotFound();
        }

        // POST: Student/Edit/5
        [HttpPost]
        [ActionName("Edit")]
        [MultipleButton(Name = "action", Argument = "EditPassword")]
        [Authorize(Roles = RoleNames.Student)]
        public virtual ActionResult EditPassword(Edit studentViewModel)
        {
            var student = _studentRepository.GetById(_httpContextService.GetUserId());
            if (student != null)
            {
                if (!ModelState.IsValid)
                {
                    return View(MVC.Student.Views.ViewNames.Edit);
                }
                Mapper.Map(studentViewModel, student);

                #region Validate Password
                if (studentViewModel.NewPassword != null && studentViewModel.Password != null && studentViewModel.ConfirmPassword == studentViewModel.NewPassword)
                {
                    if (AccountService.VerifyPassword(student.Password, studentViewModel.Password))
                    {
                        student.Password = Cryptography.Encrypt(studentViewModel.NewPassword);
                        _studentRepository.Update(student);

                        const string feedbackMessage = WebMessage.GlobalMessage.PASSWORD_EDIT_SUCCESS;

                        return RedirectToAction(MVC.Student.Index().Success(feedbackMessage));
                    }
                }
                #endregion

                ModelState.AddModelError("Password", "Mot de passe invalide.");
                return View(MVC.Student.Views.ViewNames.Edit);
            }
            return HttpNotFound();
        }

        public virtual ActionResult SubscribeStudent()
        {
            return View(MVC.Student.Views.ViewNames.Subscribe);
        }

        [HttpPost]
        public virtual ActionResult SubscribeStudent(Subscribe subscriber)
        {
            if (!_accountService.UserIdentifierExist(subscriber.StudentId))
            {
                ModelState.AddModelError("StudentId", WebMessage.StudentMessage.SUBSCRIBE_IDENTIFIER_NOT_FOUND);
                return View(MVC.Student.Views.ViewNames.Subscribe);
            }
            if (!ModelState.IsValid)
            {
                return View(MVC.Student.Views.ViewNames.Subscribe);
            }

            return RedirectToAction(MVC.Student.CreateProfile(subscriber.StudentId));
        }

        public virtual ActionResult CreateProfile(string subscriber)
        {
            var student = _accountService.GetStudentByStudentId(subscriber);
            var createProfile = Mapper.Map<CreateProfile>(student);
            return View(MVC.Student.Views.ViewNames.CreateProfile, createProfile);
        }

        [HttpPost]
        public virtual ActionResult CreateProfile(CreateProfile createProfile)
        {
            if (!ModelState.IsValid)
            {
                return View(MVC.Student.Views.ViewNames.CreateProfile);
            }
            if (_accountService.UserIdentifierExist(createProfile.Identifier))
            {
                ModelState.AddModelError("Identifier", WebMessage.GlobalMessage.EMAIL_ALREADY_USED);
                return View(MVC.Student.Views.ViewNames.CreateProfile);
            }

            UpdateStudentProfile(createProfile);

            return AuthenticateStudent(createProfile.Id);
        }

        private ActionResult AuthenticateStudent(int id)
        {
            var student = _studentRepository.GetById(id);
            _httpContextService.AuthentificateUser(student);

            const string feedbackMessage = WebMessage.StudentMessage.ACCOUNT_CREATE_SUCCESS;

            return RedirectToAction(MVC.Student.Index().Success(feedbackMessage));
        }

        private void UpdateStudentProfile(CreateProfile createProfile)
        {
            var student = _studentRepository.GetById(createProfile.Id);

            student.Password = _accountService.HashPassword(createProfile.NewPassword);
            student.Identifier = createProfile.Identifier;
            student.PhoneNumber = createProfile.PhoneNumber;

            _studentRepository.Update(student);
        }
    }
}
