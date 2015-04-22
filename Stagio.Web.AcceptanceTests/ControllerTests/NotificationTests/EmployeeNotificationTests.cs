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
        public void intershipoffer_has_been_denied()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(TestData.SubscribedStudent1);
            StudentIndexInternshipOfferPage.GoTo();

            CreateInternshipApplicationPage.GoTo();
            CreateInternshipApplicationPage.UploadFile("TestFile.pdf");

            PageNavigator.AllUsers.Logout.Select();

            LoginPage.GoTo();
            LoginPage.LoginAs(TestData.Employee1);

            const int NOTIF_ID = 3;

            NotificationPartialPage.GoTo();
            NotificationPartialPage.ClickNotif(NOTIF_ID);
        }
    }
}
