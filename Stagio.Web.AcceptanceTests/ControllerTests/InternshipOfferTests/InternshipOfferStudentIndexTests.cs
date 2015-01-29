using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.TestUtilities.Database;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.InternshipOfferPages;
using FluentAssertions;

namespace Stagio.Web.AcceptanceTests.ControllerTests.InternshipOfferTests
{
    [TestClass]
    public class InternshipOfferStudentIndexTests : GlobalBaseTest
    {
        [TestInitialize]
        public void Initialize()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(TestData.SubscribedStudent2);
        }

        [TestMethod]
        public void student_can_visualize_internship_offers_associated_to_his_company()
        {
            //Arrange
            StudentIndexInternshipOfferPage.GoTo();

            //Assert
            //Todo YM: l'assertion ne permet pas de valider le test
            StudentIndexInternshipOfferPage.IsDisplayed.Should().BeTrue();
        }
    }
}
