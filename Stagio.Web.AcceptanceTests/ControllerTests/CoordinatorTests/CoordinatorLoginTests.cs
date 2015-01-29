using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.TestUtilities.Database;
using Stagio.Web.Automation.Navigation;
using Stagio.Web.Automation.PageObjects;
using FluentAssertions;

namespace Stagio.Web.AcceptanceTests.ControllerTests.CoordinatorTests
{
    [TestClass]
    public class CoordinatorLoginTests : GlobalBaseTest
    {
        [TestInitialize]
        public void LoginTestsInitialize()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(TestData.Coordinator1);
        }

        [TestMethod]
        public void coordinator_can_log_in()
        {
            HomePage.IsCoordinatorLogged.Should().BeTrue();
        }

        [TestMethod]
        public void coordinator_can_logout()
        {
            PageNavigator.AllUsers.Logout.Select();

            HomePage.IsCoordinatorLogged.Should().BeFalse();
        }
    }
}
