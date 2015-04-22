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
using Stagio.Web.Automation.PageObjects.InternshipOfferPages;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.AcceptanceTests.ControllerTests.NotificationTests
{
    [TestClass]
    public class StudentIndexTests : GlobalBaseTest
    {
        
        [TestInitialize]
        public void Initialize()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(TestData.SubscribedStudent1);
        }

        [TestMethod]
        public void employee_can_visualize_internship_offers_associated_to_his_company()
        {
            const int NOTIF_ID = 1;

            NotificationPartialPage.GoTo();
            NotificationPartialPage.ClickNotif(NOTIF_ID);
        }
    }
}
