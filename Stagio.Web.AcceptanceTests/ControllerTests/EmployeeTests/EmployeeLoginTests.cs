using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.TestUtilities.Database;
using Stagio.Web.Automation.Navigation;
using Stagio.Web.Automation.PageObjects;

using FluentAssertions;

namespace Stagio.Web.AcceptanceTests.ControllerTests.EmployeeTests
{
    [TestClass]
    public class EmployeeLoginTests : GlobalBaseTest
    {
        [TestInitialize]
        public void LoginTestsInitialize()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(TestData.Employee1);
        }

        [TestMethod]
        public void employee_can_log_in()
        {
            HomePage.IsEmployeeLogged.Should().BeTrue();
        }

        [TestMethod]
        public void employee_can_logout()
        {
            PageNavigator.AllUsers.Logout.Select();

            HomePage.IsEmployeeLogged.Should().BeFalse();
        }
    }
}
