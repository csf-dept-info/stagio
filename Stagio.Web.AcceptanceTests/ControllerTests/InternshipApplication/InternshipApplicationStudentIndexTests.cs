using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Stagio.Domain.Entities;
using Stagio.TestUtilities.Database;
using Stagio.Web.Automation.Selenium;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.InternshipApplicationPages;
using Stagio.Web.Automation.Navigation;

using OpenQA.Selenium;
using FluentAssertions;

namespace Stagio.Web.AcceptanceTests.ControllerTests.InternshipApplication
{
    [TestClass]
    public class InternshipApplicationStudentIndexTests : GlobalBaseTest
    {
        [TestInitialize]
        public void Initialize()
        {
            LoginPage.GoTo();
        }

        [TestMethod]
        public void student_can_visualize_his_internship_applications()
        {
            //Act
            LoginPage.LoginAs(TestData.SubscribedStudent2);
            StudentIndexInternshipApplicationPage.GoTo();

            //Assert
            StudentIndexInternshipApplicationPage.IsDisplayed.Should().BeTrue();
            StudentIndexInternshipApplicationPage.GetApplicationsCount().Should().BeGreaterThan(0); //Because TestData.Student2 has 2 internship applications
        }

        [TestMethod]
        public void student_can_confirm_he_had_an_interview()
        {
            //Act
            const int applicationIndex = 1;
            DateTime interviewDate = DateTime.Today.AddDays(-10);

            LoginPage.LoginAs(TestData.StudentWhoApplied);
            StudentIndexInternshipApplicationPage.GoTo();
            StudentIndexInternshipApplicationPage.UpdateProgression(applicationIndex, interviewDate);

            //Assert
            StudentIndexInternshipApplicationPage.HasFeedBackMessage(WebMessage.InternshipApplicationMessage.APPLICATION_PROGRESSION_UPDATE_SUCCESS);
            StudentIndexInternshipApplicationPage.HasContent(WebMessage.InternshipApplicationMessage.StudentHadInterview.PROGRESSION_DESCRIPTION);
            StudentIndexInternshipApplicationPage.HasContent(interviewDate.ToShortDateString());
        
        }

        [TestMethod]
        public void student_can_confirm_he_was_selected_by_the_company_for_the_internship()
        {
            //Act
            const int applicationIndex = 1;
            DateTime companyAcceptedDate = DateTime.Today.AddDays(-7);

            LoginPage.LoginAs(TestData.StudentWhoHadInterview);
            StudentIndexInternshipApplicationPage.GoTo();
            StudentIndexInternshipApplicationPage.UpdateProgression(applicationIndex, companyAcceptedDate);

            //Assert
            StudentIndexInternshipApplicationPage.HasFeedBackMessage(WebMessage.InternshipApplicationMessage.APPLICATION_PROGRESSION_UPDATE_SUCCESS);
            StudentIndexInternshipApplicationPage.HasContent(WebMessage.InternshipApplicationMessage.CompanyAcceptedStudent.PROGRESSION_DESCRIPTION);
            StudentIndexInternshipApplicationPage.HasContent(companyAcceptedDate.ToShortDateString());
        }

        [TestMethod]
        public void student_can_confirm_he_accepted_the_internship()
        {
            //Act
            const int applicationIndex = 1;
            DateTime studentAcceptedDate = DateTime.Today.AddDays(-2);

            LoginPage.LoginAs(TestData.StudentWhoWasAcceptedByCompany);
            StudentIndexInternshipApplicationPage.GoTo();
            StudentIndexInternshipApplicationPage.UpdateProgression(applicationIndex, studentAcceptedDate);

            //Assert
            StudentIndexInternshipApplicationPage.HasFeedBackMessage(WebMessage.InternshipApplicationMessage.APPLICATION_PROGRESSION_UPDATE_SUCCESS);
            StudentIndexInternshipApplicationPage.HasContent(WebMessage.InternshipApplicationMessage.StudentAcceptedOffer.PROGRESSION_DESCRIPTION);
            StudentIndexInternshipApplicationPage.HasContent(studentAcceptedDate.ToShortDateString());
        }
    }
}
