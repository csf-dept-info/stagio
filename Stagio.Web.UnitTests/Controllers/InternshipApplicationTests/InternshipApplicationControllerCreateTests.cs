using System;
using System.Web;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.Domain.Entities;
using Stagio.Web.ViewModels.InternshipApplication;
using AutoMapper;
using FluentAssertions;
using NSubstitute;
using Ploeh.AutoFixture;

namespace Stagio.Web.UnitTests.Controllers.InternshipApplicationTests
{
    [TestClass]
    public class InternshipApplicationControllerCreateTests : InternshipApplicationControllerBaseClassTests
    {
        [TestMethod]
        public void create_action_should_render_default_view()
        {
            var result = _internshipApplicationController.Create(1) as ViewResult;

            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void create_post_should_add_application_to_repository()
        {
            // Arrange   
            var application = _fixture.Create<InternshipApplication>();
            var applicationViewModel = Mapper.Map<Create>(application);

            // Action
            _internshipApplicationController.Create(applicationViewModel);

            // Assert
            _internshipApplicationRepository.Received().Add(Arg.Is<InternshipApplication>(x => x.Id == application.Id));
            _internshipApplicationRepository.Received().Add(Arg.Is<InternshipApplication>(x => x.Progression == InternshipApplication.ApplicationStatus.StudentHasApplied));
        }

        [TestMethod]
        public void create_post_should_return_default_view_when_modelState_is_not_valid()
        {
            //Arrange
            var application = _fixture.Create<InternshipApplication>();
            var applicationViewModel = Mapper.Map<Create>(application);
            _internshipApplicationController.ModelState.AddModelError("Error", "Error");

            //Act
            var result = _internshipApplicationController.Create(applicationViewModel) as ViewResult;

            //Assert
            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void create_post_should_redirect_to_student_index_on_success()
        {
            //Arrange
            const string expectedViewName = "StudentApplicationIndex";
            var application = _fixture.Create<InternshipApplication>();
            var applicationViewModel = Mapper.Map<Create>(application);

            //Act
            var result = _internshipApplicationController.Create(applicationViewModel) as RedirectToRouteResult;

            var action = result.RouteValues["Action"];

            //Assert
            action.Should().Be(expectedViewName);
        }

        [Ignore] // À revoir
        [TestMethod]
        public void create_post_should_ignore_if_no_file_is_linked()
        {
            //Arrange
            var application = _fixture.Create<InternshipApplication>();
            var applicationViewModel = Mapper.Map<Create>(application);

            var student = _fixture.Create<Student>();
            _studentRepository.GetById(applicationViewModel.StudentId).Returns(student);

            var offer = _fixture.Create<InternshipOffer>();
            _internshipOfferRepository.GetById(applicationViewModel.InternshipOfferId).Returns(offer);

            var file1 = Substitute.For<HttpPostedFileBase>();
            file1.FileName.Returns("file1.pdf");
            file1.ContentLength.Returns(1);

            var file2 = Substitute.For<HttpPostedFileBase>();
            file1.FileName.Returns("file2.pdf");
            file1.ContentLength.Returns(2);

            var app = Substitute.For<AppDomain>();
            app.GetData("DataDirectory").Returns("C:\\");

            applicationViewModel.CoverLetter = file1;
            applicationViewModel.Resume = file2;

            //Act
            var result = _internshipApplicationController.Create(applicationViewModel) as ViewResult;

            //Assert
            result.ViewName.Should().Be(MVC.Student.Views.ViewNames.Index);
        }
    }
}
