using System;
using System.Linq;
using System.Web.Mvc;
using Stagio.DataLayer;
using Stagio.Domain.Application;
using Stagio.Domain.Entities;
using Stagio.Web.Services;
using Stagio.Web.ViewModels.Coordinator;
using Stagio.Web.ViewModels.InviteCompanies;

namespace Stagio.Web.Controllers
{
    [OutputCacheAttribute(VaryByParam = "*", Duration = 0, NoStore = true)]
    [Authorize(Roles = RoleNames.Coordinator)]
    public partial class InviteCompaniesController : Controller
    {

        private readonly IEntityRepository<Employee> _employeeRepository;
        private readonly IEmailService _emailService;
        private readonly IHttpContextService _httpContextService;
        private readonly IEntityRepository<Coordinator> _coordinatorRepository;

        public InviteCompaniesController(
            IEntityRepository<Employee> employeeRepository,
            IEmailService emailService,
            IHttpContextService httpContextService,
            IEntityRepository<Coordinator> coordinatorRepository)
        {
            DependencyService.VerifyDependencies(employeeRepository, emailService, httpContextService, coordinatorRepository);
            _employeeRepository = employeeRepository;
            _emailService = emailService;
            _coordinatorRepository = coordinatorRepository;
            _httpContextService = httpContextService;
        }

        public virtual ViewResult InviteCompanies()
        {
            return View(MVC.InviteCompanies.Views.ViewNames.InviteCompanies);
        }

        [HttpPost]
        public virtual ActionResult InviteCompanies(InviteCompanies inviteCompaniesVm)
        {
            var coordinator = _coordinatorRepository.GetById(_httpContextService.GetUserId());

            var employees = _employeeRepository.GetAll().ToList();

            if (!ModelState.IsValid)
            {
                return View(MVC.InviteCompanies.Views.ViewNames.InviteCompanies);
            }

            foreach (var employee in employees)
            {
                try
                {
                    var mail = _emailService.BuildMail(employee.Identifier, coordinator.Identifier,
                                       inviteCompaniesVm.Subject, inviteCompaniesVm.Body);
                    _emailService.SendEmail(mail);
                }
                catch (Exception)
                {
                    var errorMessage = WebMessage.InviteCompaniesMessage.GENERIC_INVITE_COMPANIES_ERROR;
                    return View(MVC.InviteCompanies.Views.ViewNames.InviteCompanies).Error(errorMessage);
                }
            }

            return RedirectToAction(MVC.Coordinator.Views.ViewNames.Index, MVC.Coordinator.Name).Success(WebMessage.InviteCompaniesMessage.INVITE_COMPANIES_SUCCES);
        }

        public virtual ViewResult InviteCompaniesSubscribes()
        {
            return View(MVC.InviteCompanies.Views.ViewNames.InviteCompanies);
        }

        [HttpPost]
        public virtual ActionResult InviteCompaniesSubscribe(InviteCompanies inviteCompaniesVm)
        {
            var coordinator = _coordinatorRepository.GetById(_httpContextService.GetUserId());

            var employees = _employeeRepository.GetAll().ToList();

            if (!ModelState.IsValid)
            {
                return View(MVC.InviteCompanies.Views.ViewNames.InviteCompanies);
            }



            foreach (var employee in employees)
            {
                try
                {
                    var mail = _emailService.BuildMail(employee.Identifier, coordinator.Identifier,
                                       inviteCompaniesVm.Subject, inviteCompaniesVm.Body);
                    _emailService.SendEmail(mail);
                }
                catch (Exception)
                {
                    var errorMessage = WebMessage.InviteCompaniesMessage.GENERIC_INVITE_COMPANIES_ERROR;
                    return View(MVC.InviteCompanies.Views.ViewNames.InviteCompanies).Error(errorMessage);
                }
            }

            return RedirectToAction(MVC.Coordinator.Views.ViewNames.Index, MVC.Coordinator.Name).Success(WebMessage.InviteCompaniesMessage.INVITE_COMPANIES_SUCCES);
        }
    }
}