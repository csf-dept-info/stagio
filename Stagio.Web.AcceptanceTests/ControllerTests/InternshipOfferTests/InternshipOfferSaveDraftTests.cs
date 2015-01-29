using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.TestUtilities.Database;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.EmployeePages;
using Stagio.Web.Automation.PageObjects.InternshipOfferPages;
using FluentAssertions;

namespace Stagio.Web.AcceptanceTests.ControllerTests.InternshipOfferTests
{
    [TestClass]
    public class InternshipOfferSaveDraftTests : GlobalBaseTest
    {
        [TestInitialize]
        public void Initialize()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(TestData.Employee1);
        }

        [TestMethod]
        public void employee_can_save_a_draft_of_an_internship_offer()
        {
            //Arrange
            EmployeeIndexInternshipOfferPage.GoTo();
            var initialDraftOffersCount = EmployeeIndexInternshipOfferPage.GetDraftOffersCount();
            IndexEmployeePage.GoTo();

            //Act
            CreateInternshipOfferPage.GoTo();
            CreateInternshipOfferPage.FillCreationFormWith(TestData.InternshipOfferDraft2);
            CreateInternshipOfferPage.SaveDraft();
            EmployeeIndexInternshipOfferPage.GoTo();

            //Assert
            EmployeeIndexInternshipOfferPage.GetDraftOffersCount().Should().BeGreaterThan(initialDraftOffersCount);

        }
    }
}
