using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Stagio.Web.Controllers;
using Stagio.Web.Services;

namespace Stagio.Web.UnitTests.Controllers.HomeTests
{
    [TestClass]
    public class HomeControllerBaseClassTests : AllControllersBaseClassTests
    {
        protected HomeController _homeController;
        protected IInternshipPeriodService _internshipPeriodService;

        [TestInitialize]
        public void Initialize()
        {
            _internshipPeriodService = Substitute.For<IInternshipPeriodService>();

            _homeController = new HomeController(_internshipPeriodService);
        }
    }
}
