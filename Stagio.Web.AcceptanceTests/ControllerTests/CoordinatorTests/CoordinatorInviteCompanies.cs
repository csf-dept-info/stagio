using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.TestUtilities.Database;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.CoordinatorPages;

namespace Stagio.Web.AcceptanceTests.ControllerTests.CoordinatorTests
{
    [TestClass]
    public class CoordinatorInviteCompaniesTests : GlobalBaseTest   
    {
        const string MESSAGE_OBJECT = "Ouverture de la session de stage";
        const string MESSAGE_BODY = "Bonjour, ce email est afin de vous aviser que vous pouvez maintenant acceder à notre site web Stagio afin d'envoyer des offres de stage à nos étudiants.";

        [TestInitialize]
        public void LoginTestsInitialize()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(TestData.Coordinator1);
        }

        [TestMethod]
        public void coordinator_can_send_email_to_companies()
        {
            InviteCompaniesPage.GoTo();

            InviteCompaniesPage.ClearEmailFields();
            InviteCompaniesPage.FillEmailFields(MESSAGE_OBJECT, MESSAGE_BODY);

            InviteCompaniesPage.Submit();
        }
    }
}
