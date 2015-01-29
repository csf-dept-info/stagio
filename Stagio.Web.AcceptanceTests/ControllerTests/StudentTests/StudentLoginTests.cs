using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.TestUtilities.Database;
using Stagio.Web.Automation.Navigation;
using Stagio.Web.Automation.PageObjects;

using FluentAssertions;

namespace Stagio.Web.AcceptanceTests.ControllerTests.StudentTests
{
    [TestClass]
    public class StudentLoginTests : GlobalBaseTest
    {
        [TestInitialize]
        public void LoginTestsInitialize()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(TestData.SubscribedStudent1);
        }

        [TestMethod]
        public void student_can_log_in()
        {
            HomePage.IsStudentLogged.Should().BeTrue();
        }

        [TestMethod]
        public void student_can_logout()
        {
            PageNavigator.AllUsers.Logout.Select();
            HomePage.IsStudentLogged.Should().BeFalse();
        }
    }
}
