using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Stagio.Web.Controllers;
using Stagio.Web.Services;

namespace Stagio.Web.UnitTests.Controllers.AccountTests
{
    [TestClass]
    public class AccountControllerBaseClassTests : AllControllersBaseClassTests
    {
        protected AccountController _accountController;
        protected IHttpContextService _httpContext;
        protected IAccountService _accountService;
        protected IInternshipPeriodService _internshipPeriodService;

        [TestInitialize]
        public void Initialize()
        {
            _httpContext = Substitute.For<IHttpContextService>();
            _accountService = Substitute.For<IAccountService>();
            _internshipPeriodService = Substitute.For<IInternshipPeriodService>();
            _accountController = new AccountController(_httpContext, _accountService, _internshipPeriodService);
        }
    }
}
