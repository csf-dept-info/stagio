using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.TestUtilities.Database;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.InternshipApplicationPages;

namespace Stagio.Web.AcceptanceTests.ControllerTests.InternshipApplication
{
    [TestClass]
    public class InternshipApplicationEmployeeIndexTests : GlobalBaseTest
    {
        [TestInitialize]
        public void Initialize()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(TestData.Employee1);
        }

        [TestMethod]
        public void employee_can_visualize_internship_applications_associated_to_his_offer()
        {
            //Arrange
            EmployeeIndexInternshipApplicationPage.GoTo();

            //Assert
            EmployeeIndexInternshipApplicationPage.IsDisplayed.Should().BeTrue();

            EmployeeIndexInternshipApplicationPage.GetApplicationsCount().Should().BeGreaterThan(0);
        }
    }
}
