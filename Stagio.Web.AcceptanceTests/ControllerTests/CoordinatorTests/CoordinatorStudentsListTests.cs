using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.TestUtilities.Database;
using Stagio.Web.Automation.Navigation;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.CoordinatorPages;

namespace Stagio.Web.AcceptanceTests.ControllerTests.CoordinatorTests
{
    [TestClass]
    public class CoordinatorStudentsListTests : GlobalBaseTest
    {
        [TestInitialize]
        public void LoginTestsInitialize()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(TestData.Coordinator1);
        }

        [TestMethod]
        public void coordinator_can_see_students_list_with_not_subscribed_students()
        {
            PageNavigator.Coordinator.StudentsList.Select();
            StudentsListCoordinatorPage.GetStudentsCount("notSubscribed-count").Should().BeGreaterThan(0);
        }

        [TestMethod]
        public void coordinator_can_see_students_list_with_subscribed_students()
        {
            PageNavigator.Coordinator.StudentsList.Select();
            StudentsListCoordinatorPage.GetStudentsCount("subscribed-count").Should().BeGreaterThan(0);
        }
    }
}
