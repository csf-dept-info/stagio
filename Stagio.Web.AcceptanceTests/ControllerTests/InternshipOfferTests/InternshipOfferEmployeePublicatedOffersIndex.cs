using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Stagio.Domain.Entities;
using Stagio.TestUtilities.Database;
using Stagio.Web.Automation.Selenium;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.InternshipOfferPages;
using Stagio.Web.Automation.Navigation;

using OpenQA.Selenium;
using FluentAssertions;

namespace Stagio.Web.AcceptanceTests.ControllerTests.InternshipOfferTests
{
    [TestClass]
    public class InternshipOfferEmployeePublicatedOffersIndexTests : GlobalBaseTest
    {
        [TestInitialize]
        public void Initialize()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(TestData.Employee1);
        }

        [TestMethod]
        public void employee_can_visualize_internship_publicated_offers_associated_to_his_company()
        {
            //Arrange
            EmployeeIndexPublicatedInternshipOfferPage.GoTo();

            //Assert
            EmployeeIndexPublicatedInternshipOfferPage.IsDisplayed.Should().BeTrue();

            EmployeeIndexPublicatedInternshipOfferPage.GetOffersCount().Should().BeGreaterThan(0);
        }
    }
}
