using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.TestUtilities.Database;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.CoordinatorPages;

namespace Stagio.Web.AcceptanceTests.ControllerTests.CoordinatorTests
{
    [TestClass]
    public class CoordinatorPeriodDetailsTests : GlobalBaseTest
    {
        [TestInitialize]
        public void LoginTestsInitialize()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(TestData.Coordinator1);
        }

        [TestMethod]
        public void coordinator_can_see_statistics_for_a_past_internship_period()
        {
            InternshipPeriodDetailsPage.GoTo(TestData.Archive1.Id);
            InternshipPeriodDetailsPage.HasContent(String.Format(WebMessage.DataFormat.DATE_FORMAT, TestData.Archive1.InternshipPeriod.StartDate)).Should().BeTrue();
        }
    }
}
