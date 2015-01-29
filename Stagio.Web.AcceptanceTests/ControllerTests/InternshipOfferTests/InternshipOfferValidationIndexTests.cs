using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.TestUtilities.Database;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.InternshipOfferPages;
using Stagio.Web.Automation.Navigation;

namespace Stagio.Web.AcceptanceTests.ControllerTests.InternshipOfferTests
{
    [TestClass]
    public class InternshipOfferCoordinatorIndexTests : GlobalBaseTest
    {
        [TestInitialize]
        public void IndexTestsInitialize()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(TestData.Coordinator1);
            CoordinatorIndexInternshipOfferPage.GoTo();
        }

        [TestMethod]
        public void coordinator_can_validate_an_offer()
        {
            PageNavigator.InternshipOffer.Details.Select(TestData.InternshipOfferOnValidation1.Id);

            CoordinatorIndexInternshipOfferPage.ValidateInternshipOffer();

            //TODO MAF on ne valide actuellement le succès de l'opération, sera ajouté avec la feature "brouillon"
        }

        [TestMethod]
        public void coordinator_can_deny_an_offer()
        {
            PageNavigator.InternshipOffer.Details.Select(TestData.InternshipOfferOnValidation1.Id);

            CoordinatorIndexInternshipOfferPage.DenyInternshipOffer();

            //TODO MAF on ne valide actuellement le succès de l'opération, sera ajouté avec la feature "brouillon"
        }
    }
}
