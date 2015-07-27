using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.Ajax.Utilities;
using Stagio.DataLayer;
using Stagio.Domain.Application;
using Stagio.Domain.Entities;
using Stagio.Domain.SecurityUtilities;
using Stagio.Web.Controllers.Utilities;
using Stagio.Web.Services;
using Stagio.Web.ViewModels.Employee;
using System;

namespace Stagio.Web.Controllers
{
    [OutputCacheAttribute(VaryByParam = "*", Duration = 0, NoStore = true)]
    public partial class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IEntityRepository<Employee> _employeeRepository;
        private readonly IHttpContextService _httpContextService;
        private readonly IAccountService _accountService;


        public EmployeeController(
            IEmployeeService employeeService,
            IEntityRepository<Employee> employeeRepository,
            IHttpContextService httpContextService,
            IAccountService accountService)
        {
            DependencyService.VerifyDependencies(employeeService, employeeRepository, httpContextService, accountService);

            _employeeService = employeeService;
            _employeeRepository = employeeRepository;
            _httpContextService = httpContextService;
            _accountService = accountService;
        }

        // GET: Employee
        [Authorize(Roles = RoleNames.Employee)]
        public virtual ActionResult Index()
        {
            var user = _employeeRepository.GetById(_httpContextService.GetUserId());

            var userModel = new Index()
            {
                TotalApplicationsCount = _employeeService.FetchTotalNumberOfApplications(user.Id),
                RefusedOffersCount = _employeeService.FetchTotalNumberOfRefusedOffers(user.Id),
                OnValidationOffersCount = _employeeService.FetchTotalNumberOfOnValidationOffers(user.Id),
                PublishedOffersCount = _employeeService.FetchTotalNumberOfPublishedOffers(user.Id)
            };

            return View(MVC.Employee.Views.ViewNames.Index, userModel);
        }

        public virtual ActionResult Create(int selectedCompanyId)
        {
            var employe = new ViewModels.Employee.Create
            {
                CompanyId = selectedCompanyId
            };

            return View(employe);
        }

        [HttpPost]
        public virtual ActionResult Create(Create employeeVm)
        {

            if (!ModelState.IsValid)
            {
                return View(employeeVm);
            }
            if (_accountService.UserIdentifierExist(employeeVm.Identifier))
            {
                ModelState.AddModelError("Identifiant", WebMessage.EmployeeMessage.IDENTIFIER_ALREADY_USED);
                return View();
            }

            var employee = Mapper.Map<Employee>(employeeVm);
            employee.Password = _accountService.HashPassword(employeeVm.Password);
            employee.Roles = new List<UserRole>
                {
                    new UserRole {RoleName = RoleNames.Employee},
                };

            _employeeRepository.Add(employee);

            const string feedbackMessage = WebMessage.EmployeeMessage.ACCOUNT_CREATE_SUCCESS;

            return RedirectToAction(MVC.Home.Index().Success(feedbackMessage));

        }

        // GET: Employee/Edit/5
        [Authorize(Roles = RoleNames.Employee)]
        public virtual ActionResult Edit()
        {
            var employee = _employeeRepository.GetById(_httpContextService.GetUserId());

            if (employee == null)
            {
                return HttpNotFound();
            }

            var viewModel = Mapper.Map<Edit>(employee);

            return View(viewModel);
        }

        // POST: Employee/EditProfile
        [HttpPost]
        [ActionName("Edit")]
        [MultipleButton(Name = "action", Argument = "EditProfile")]
        [Authorize(Roles = RoleNames.Employee)]
        public virtual ActionResult EditProfile(Edit _employeeViewModel)
        {
            var employee = _employeeRepository.GetById(_httpContextService.GetUserId());

            if (employee == null)
            {
                return HttpNotFound();
            }

            bool emailIsAlreadyUsed = _accountService.UserIdentifierExist(_employeeViewModel.Identifier);
            bool newEmailIsTheSame = _employeeViewModel.Identifier == employee.Identifier;

            if(_employeeViewModel.Identifier.IsNullOrWhiteSpace())
            {
                ModelState.AddModelError("Email", WebMessage.GlobalMessage.EMPTY_EMAIL);
            }                                                

            if (emailIsAlreadyUsed && !newEmailIsTheSame)
            {
                ModelState.AddModelError("Email", WebMessage.GlobalMessage.EMAIL_ALREADY_USED);
            }

            if (!ModelState.IsValid)
            {
                return View(MVC.Employee.Views.ViewNames.Edit, _employeeViewModel);
            }

            Mapper.Map(_employeeViewModel, employee);
            _employeeRepository.Update(employee);

            const string feedbackMessage = WebMessage.GlobalMessage.PROFILE_EDIT_SUCCESS;

            return RedirectToAction(MVC.Employee.Index().Success(feedbackMessage));
        }

        // POST: Employee/EditPassword
        [HttpPost]
        [ActionName("Edit")]
        [MultipleButton(Name = "action", Argument = "EditPassword")]
        [Authorize(Roles = RoleNames.Employee)]
        public virtual ActionResult EditPassword(Edit _employeeViewModel)
        {
            var employee = _employeeRepository.GetById(_httpContextService.GetUserId());

            if (employee == null)
            {
                return HttpNotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(MVC.Employee.Views.ViewNames.Edit);
            }

            #region Validate Password

            if (_employeeViewModel.NewPassword != null)
            {
                if (AccountService.VerifyPassword(employee.Password, _employeeViewModel.Password))
                {
                    employee.Password = Cryptography.Encrypt(_employeeViewModel.NewPassword);
                }
                else
                {
                    ModelState.AddModelError("Password", "Mot de passe invalide.");

                    return View(MVC.Employee.Views.ViewNames.Edit, _employeeViewModel);
                }

                _employeeRepository.Update(employee);
            }

            #endregion

            const string feedbackMessage = WebMessage.GlobalMessage.PASSWORD_EDIT_SUCCESS;

            return RedirectToAction(MVC.Employee.Index().Success(feedbackMessage));
        }
    }
}
