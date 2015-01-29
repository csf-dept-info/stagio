using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.TestUtilities.Database;
using Stagio.Web.Automation.Navigation;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.CoordinatorPages;
using Stagio.Web.Automation.PageObjects.InternshipOfferPages;

namespace Stagio.Web.AcceptanceTests.ControllerTests.CoordinatorTests
{
    [TestClass]
    public class CoordinatorCleanDatabaseTests : GlobalBaseTest   
    {
        [TestInitialize]
        public void LoginTestsInitialize()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(TestData.Coordinator1);
        }

        [TestMethod]
        public void coordinator_can_clean_database()
        {
            CleanDatabasePage.GoTo();
            CleanDatabasePage.ClickCleanDatabaseButton();
            CleanDatabasePage.FillPasswordValidation(TestData.Coordinator1.Password);
            CleanDatabasePage.ClickCleanDatabaseModalButton();

            StudentsListCoordinatorPage.GoTo();
            CountNumberOfNotSubscribedStudent();
            CountNumberOfSubscribedStudent();

            CoordinatorIndexInternshipOfferPage.GoTo();
            CoordinatorIndexInternshipOfferPage.GetTotalOffersCount().Should().Be(0);

        }
     
        private void CountNumberOfNotSubscribedStudent()
        {
            const int expectedAmountOfStudent = 0;
            PageNavigator.Coordinator.StudentsList.Select();
            StudentsListCoordinatorPage.GetStudentsCount("notSubscribed-count").Should().Be(expectedAmountOfStudent);
        }


        private void CountNumberOfSubscribedStudent()
        {
            const int expectedAmountOfStudent = 0;
            PageNavigator.Coordinator.StudentsList.Select();
            StudentsListCoordinatorPage.GetStudentsCount("subscribed-count").Should().Be(expectedAmountOfStudent);
        }
    }
}
