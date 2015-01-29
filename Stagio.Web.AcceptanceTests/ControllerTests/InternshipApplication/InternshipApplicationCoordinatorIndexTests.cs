using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.TestUtilities.Database;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.InternshipApplicationPages;

namespace Stagio.Web.AcceptanceTests.ControllerTests.InternshipApplication
{
    [TestClass]
    public class InternshipApplicationCoordinatorIndexTests : GlobalBaseTest
    {
        [TestInitialize]
        public void Initialize()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(TestData.Coordinator1);
        }

        [TestMethod]
        public void coordinator_can_visualize_internship_applications_associated_to_an_offer()
        {
            //Arrange
            CoordinatorIndexInternshipApplicationPage.GoTo();

            //Assert
            CoordinatorIndexInternshipApplicationPage.IsDisplayed.Should().BeTrue();

            CoordinatorIndexInternshipApplicationPage.GetApplicationsCount().Should().BeGreaterThan(0);
        }
    }
}
