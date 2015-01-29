using System.Linq;
using System.Web.Mvc;
using Stagio.Domain.Application;
using Stagio.Domain.Entities;
using Stagio.Web.Services;
using System;

namespace Stagio.Web.Controllers
{
    [OutputCacheAttribute(VaryByParam = "*", Duration = 0, NoStore = true)] 
    public partial class AccountController : Controller
    {
        private readonly IHttpContextService _httpContext;
        private static IAccountService _accountService;
        private readonly IInternshipPeriodService _internshipPeriodService;

        public AccountController(IHttpContextService httpContext,
                                 IAccountService accountService,
                                 IInternshipPeriodService internshipPeriodService)
        {
            DependencyService.VerifyDependencies(httpContext, accountService, internshipPeriodService);
           
            _httpContext = httpContext;
            _accountService = accountService;
            _internshipPeriodService = internshipPeriodService;
        }

        public virtual ActionResult Login()
        {
            return View(MVC.Account.Views.ViewNames.Login);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Login(ViewModels.Account.Login accountLoginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(MVC.Account.Views.ViewNames.Login);
            }

            var user = _accountService.ValidateUser(accountLoginViewModel.Identifier, accountLoginViewModel.Password);

            if (!user.Any())
            {
                ModelState.AddModelError("loginError", WebMessage.AccountMessage.INVALID_USERNAME_OR_PASSWORD);
                return View(MVC.Account.Views.ViewNames.Login);
            }

            if (!_internshipPeriodService.IsCurrentDateInInternshipPeriod() && user.First().Roles.First().RoleName != RoleNames.Coordinator)
            {
                ModelState.AddModelError("loginError", WebMessage.AccountMessage.SYSTEM_IS_NOT_OPEN);
                return View(MVC.Account.Views.ViewNames.Login);
            }

            _httpContext.AuthentificateUser(user.First());
           
            return RedirectToAction(RedirectByUserRole(user.First()));
        }

        public virtual ActionResult Logout()
        {
            _httpContext.AuthenticationSignOut();
            return RedirectToAction(MVC.Home.Index());
        }

        private static ActionResult RedirectByUserRole(ApplicationUser user)
        {
            var role = user.Roles.First();
            if (role.RoleName == RoleNames.Employee)
            {
                return (MVC.Employee.Index());
            }
            if (role.RoleName == RoleNames.Student)
            {
                return MVC.Student.Index();
            }
            return MVC.Coordinator.Index();
        }
    }
}

