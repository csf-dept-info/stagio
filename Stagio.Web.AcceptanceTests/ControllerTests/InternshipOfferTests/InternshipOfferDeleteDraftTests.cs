﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Stagio.Domain.Entities;
using Stagio.TestUtilities.Database;
using Stagio.Web.Automation.Selenium;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.EmployeePages;
using Stagio.Web.Automation.PageObjects.InternshipOfferPages;
using Stagio.Web.Automation.Navigation;

using OpenQA.Selenium;
using FluentAssertions;

namespace Stagio.Web.AcceptanceTests.ControllerTests.InternshipOfferTests
{
    [TestClass]
    public class InternshipOfferDeleteDraftTests : GlobalBaseTest
    {
        [TestInitialize]
        public void Initialize()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(TestData.Employee1);
            EmployeeIndexInternshipOfferPage.GoTo();
        }

        [TestMethod]
        public void employee_can_delete_internship_offer_draft()
        {
            const int firstOfferIndex = 1;
            int numberOfDraftBegin = EmployeeIndexInternshipOfferPage.GetDraftOffersCount();
            int numberOfDraftEnd = numberOfDraftBegin - 1;

            EmployeeIndexInternshipOfferPage.ClickDraft();
            EmployeeIndexInternshipOfferPage.EditDraft(firstOfferIndex);
            CreateInternshipOfferPage.ClickDeleteButton();
            CreateInternshipOfferPage.ClickModalDeleteButton();
            EmployeeIndexInternshipOfferPage.ClickDraft();
            EmployeeIndexInternshipOfferPage.GetDraftOffersCount().Should().Be(numberOfDraftEnd);

        }
    }
}