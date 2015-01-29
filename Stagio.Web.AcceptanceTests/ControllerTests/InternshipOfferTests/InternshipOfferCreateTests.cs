using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.TestUtilities.Database;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.EmployeePages;
using Stagio.Web.Automation.PageObjects.InternshipOfferPages;

namespace Stagio.Web.AcceptanceTests.ControllerTests.InternshipOfferTests
{
    [TestClass]
    public class InternshipOfferCreateTests : GlobalBaseTest
    {
        [TestInitialize]
        public void Initialize()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(TestData.Employee1);
        }

        [TestMethod]
        public void employee_can_visualize_internshipoffer_creation_form()
        {
            //Arrange

            //Act
            CreateInternshipOfferPage.GoTo();

            //Assert
            CreateInternshipOfferPage.IsDisplayed.Should().BeTrue();
        }

        [TestMethod]
        public void employee_can_create_internshipoffer()
        {
            //Arrange
            EmployeeIndexInternshipOfferPage.GoTo();

            int initialOnValidationOffersCount = EmployeeIndexInternshipOfferPage.GetOnValidationOffersCount();
            
            IndexEmployeePage.GoTo();

            //Act
            CreateInternshipOfferPage.GoTo();
            CreateInternshipOfferPage.FillCreationFormWith(TestData.InternshipOfferPublicated1);
            CreateInternshipOfferPage.SubmitOffer();
            EmployeeIndexInternshipOfferPage.GoTo();

            //Assert
            EmployeeIndexInternshipOfferPage.GetOnValidationOffersCount().Should().BeGreaterThan(initialOnValidationOffersCount);
        }
    }
}
