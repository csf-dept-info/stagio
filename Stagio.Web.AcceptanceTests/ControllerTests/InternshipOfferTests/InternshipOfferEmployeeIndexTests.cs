using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.TestUtilities.Database;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.InternshipOfferPages;
using FluentAssertions;

namespace Stagio.Web.AcceptanceTests.ControllerTests.InternshipOfferTests
{
    [TestClass]
    public class InternshipOfferEmployeeIndexTests : GlobalBaseTest
    {
        [TestInitialize]
        public void Initialize()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(TestData.Employee1);
        }

        [TestMethod]
        public void employee_can_visualize_internship_offers_associated_to_his_company()
        {
            //Arrange
            EmployeeIndexInternshipOfferPage.GoTo();

            //Assert
            EmployeeIndexInternshipOfferPage.IsDisplayed.Should().BeTrue();
        }
    }
}
