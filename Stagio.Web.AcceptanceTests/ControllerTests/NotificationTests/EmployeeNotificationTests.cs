using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Stagio.TestUtilities.Database;
using Stagio.Web.Automation.Navigation;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.InternshipApplicationPages;
using Stagio.Web.Automation.PageObjects.InternshipOfferPages;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.AcceptanceTests.ControllerTests.NotificationTests
{
    [TestClass]
    public class EmployeeNotificationTests : GlobalBaseTest
    {
       
        [TestMethod]
        public void student_applied_to_one_of_your_offers()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(TestData.SubscribedStudent1);
            StudentIndexInternshipOfferPage.GoTo();

            CreateInternshipApplicationPage.GoTo();
            CreateInternshipApplicationPage.UploadFile("TestFile.pdf");

            PageNavigator.AllUsers.Logout.Select();

            LoginPage.GoTo();
            LoginPage.LoginAs(TestData.Employee1);

            var NOTIF_TEXT = WebMessage.NotificationMessage.A_STUDENT_HAS_APPLIED_ON_ONE_OF_YOUR_OFFERS;

            NotificationPartialPage.GoTo();
            NotificationPartialPage.ClickNotifByText(NOTIF_TEXT);

            EmployeeIndexInternshipOfferPage.IsDisplayed.Should().BeTrue();
        }
    }
}
