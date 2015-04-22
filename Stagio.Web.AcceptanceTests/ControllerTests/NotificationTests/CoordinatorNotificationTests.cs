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
using Stagio.Web.Automation.PageObjects.CompanyPages;
using Stagio.Web.Automation.PageObjects.EmployeePages;
using Stagio.Web.Automation.PageObjects.InternshipApplicationPages;
using Stagio.Web.Automation.PageObjects.InternshipOfferPages;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.AcceptanceTests.ControllerTests.NotificationTests
{
    [TestClass]
    public class CoordinatorNotificationTests : GlobalBaseTest
    {

        [TestMethod]
        public void new_intershipoffer_has_been_created()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(TestData.Employee1);

            CreateInternshipOfferPage.GoTo();
            CreateInternshipOfferPage.FillCreationFormWith(TestData.InternshipOfferPublicated1);
            CreateInternshipOfferPage.SubmitOffer();
            EmployeeIndexInternshipOfferPage.GoTo();

            PageNavigator.AllUsers.Logout.Select();

            LoginPage.GoTo();
            LoginPage.LoginAs(TestData.Coordinator1);

            const int NOTIF_ID = 1;

            NotificationPartialPage.GoTo();
            NotificationPartialPage.ClickNotif(NOTIF_ID);
        }

        [TestMethod]
        public void student_has_applied_on_an_intershipoffer()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(TestData.SubscribedStudent1);
            StudentIndexInternshipOfferPage.GoTo();

            CreateInternshipApplicationPage.GoTo();
            CreateInternshipApplicationPage.UploadFile("TestFile.pdf");

            PageNavigator.AllUsers.Logout.Select();

            LoginPage.GoTo();
            LoginPage.LoginAs(TestData.Coordinator1);

            const int NOTIF_ID = 1;

            NotificationPartialPage.GoTo();
            NotificationPartialPage.ClickNotif(NOTIF_ID);
        }

        [TestMethod]
        public void new_company_joined_stagio()
        {
            CreateEmployeePage.GoTo();

            CreateEmployeePage.SelectCreateNewCompany();
            CreateCompanyPage.FillCompanyFieldsWith(TestData.Company6);
            CreateEmployeePage.FillCreationFormWith(TestData.Employee3);

            LoginPage.GoTo();
            LoginPage.LoginAs(TestData.Coordinator1);

            const int NOTIF_ID = 1;

            NotificationPartialPage.GoTo();
            NotificationPartialPage.ClickNotif(NOTIF_ID);
        }
    }
}
