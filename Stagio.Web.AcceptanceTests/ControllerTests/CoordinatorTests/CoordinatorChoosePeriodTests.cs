using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.TestUtilities.Database;
using Stagio.Web.Automation.Navigation;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.CoordinatorPages;

namespace Stagio.Web.AcceptanceTests.ControllerTests.CoordinatorTests
{
    [TestClass]
    public class CoordinatorChoosePeriodTests : GlobalBaseTest
    {
        [TestInitialize]
        public void ChoosePeriodTestsInitialize()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(TestData.Coordinator1);
            PageNavigator.Coordinator.ChoosePeriod.Select();
            ChoosePeriodCoordinatorPage.FillForm();
            PageNavigator.AllUsers.Logout.Select();
            LoginPage.GoTo();
        }

        [TestMethod]
        public void employee_cannot_log_in_when_internship_period_is_closed()
        {
            LoginPage.LoginAs(TestData.Employee1);
            HomePage.IsEmployeeLogged.Should().BeFalse();
        }

        [TestMethod]
        public void student_cannot_log_in_when_internship_period_is_closed()
        {
            LoginPage.LoginAs(TestData.SubscribedStudent2);
            HomePage.IsStudentLogged.Should().BeFalse();
        }

        
        [TestMethod]
        public void coordinator_can_still_log_in_when_internship_period_is_closed()
        {
            LoginPage.LoginAs(TestData.Coordinator1);
            HomePage.IsCoordinatorLogged.Should().BeTrue();
        }
    }
}
