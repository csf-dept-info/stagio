using Microsoft.VisualStudio.TestTools.UnitTesting;

using Stagio.Domain.Entities;
using Stagio.TestUtilities.Database;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.InternshipApplicationPages;
using FluentAssertions;

namespace Stagio.Web.AcceptanceTests.ControllerTests.InternshipApplication
{
    [TestClass]
    public class InternshipApplicationCoordinatorProgressionIndexTests : GlobalBaseTest
    {
        [TestInitialize]
        public void Initialize()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(TestData.Coordinator1);
        }

        [TestMethod]
        public void coordinator_can_visualize_the_progression_of_the_students()
        {
            //Act
            CoordinatorProgressionIndexInternshipApplicationPage.GoTo();

            //Assert
            CoordinatorProgressionIndexInternshipApplicationPage.IsDisplayed.Should().BeTrue();
            CoordinatorProgressionIndexInternshipApplicationPage.GetApplicationsCount().Should().BeGreaterThan(0);
        }

        [TestMethod]
        public void coordinator_can_visualize_all_the_progression_for_a_specific_student()
        {
            //Act
            CoordinatorProgressionIndexInternshipApplicationPage.GoTo();

            //Assert
            CoordinatorProgressionIndexInternshipApplicationPage.IsDisplayed.Should().BeTrue();
            CoordinatorProgressionIndexInternshipApplicationPage.SeeStudentApplications();
        }
    }
}
