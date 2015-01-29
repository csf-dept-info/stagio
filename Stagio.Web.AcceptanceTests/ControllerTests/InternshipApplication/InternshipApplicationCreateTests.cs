using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.TestUtilities.Database;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.InternshipApplicationPages;
using Stagio.Web.Automation.PageObjects.InternshipOfferPages;

namespace Stagio.Web.AcceptanceTests.ControllerTests.InternshipApplication
{
    [TestClass]
    public class InternshipApplicationCreateTests : GlobalBaseTest
    {
        [TestInitialize]
        public void IndexTestsInitialize()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(TestData.SubscribedStudent1);
            StudentIndexInternshipOfferPage.GoTo();
        }

        [TestMethod]
        public void student_can_apply_to_an_offer()
        {
            CreateInternshipApplicationPage.GoTo();
            CreateInternshipApplicationPage.UploadFile("TestFile.pdf");

            HomePage.HasFeedBackMessage(WebMessage.InternshipApplicationMessage.APPLICATION_CREATE_SUCCESS).Should().BeTrue();
        }
    }
}
