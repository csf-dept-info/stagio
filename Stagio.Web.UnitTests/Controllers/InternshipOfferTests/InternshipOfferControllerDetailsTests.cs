using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.Domain.Entities;
using AutoMapper;
using FluentAssertions;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Web.ViewModels.InternshipOffer;
using System.IO;
using System.Linq;
using Stagio.TestUtilities.Database;
using StaffMember = Stagio.Domain.Entities.StaffMember;

namespace Stagio.Web.UnitTests.Controllers.InternshipOfferTests
{

    [TestClass]
    public class InternshipOfferControllerDetailsTests : InternshipOfferControllerBaseClassTests
    {
        [TestMethod]
        public void detail_should_render_default_view_if_offer_exists()
        {
            //Arrange
            var offer = _fixture.Create<InternshipOffer>();
            _internshipOfferRepository.GetById(offer.Id).Returns(offer);

            //Action
            var result = _internshipOfferController.Details(offer.Id) as ViewResult;

            //Assert
            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void details_should_return_http_not_found_when_employee_does_not_exist()
        {
            //Arrange
            var offer = _fixture.Create<InternshipOffer>();

            //Action
            var result = _internshipOfferController.Details(offer.Id);

            //Assert
            result.Should().BeOfType<HttpNotFoundResult>();
        }

        [TestMethod]
        public void details_post_should_return_view_with_errors_when_model_state_is_invalid()
        {
            //Arrange
            var internshipOfferViewModel = PrepareDeny();

            //Act
            _internshipOfferController.ModelState.AddModelError("Title", "Error");
            var result = _internshipOfferController.Details(internshipOfferViewModel) as ViewResult;
            var errorCount = result.ViewData.ModelState.Count;

            //Assert
            errorCount.Should().NotBe(0);
        }

        [TestMethod]
        public void details_post_should_redirect_to_index_when_deny_is_successful()
        {
            //Arrange
            var internshipOfferViewModel = PrepareDeny();

            //Act
            var result = _internshipOfferController.Details(internshipOfferViewModel) as RedirectToRouteResult;

            var action = result.RouteValues["Action"];
            //Assert
            action.Should().Be("Coordinator" + MVC.InternshipOffer.Views.ViewNames.Index);
        }

        [TestMethod]
        public void details_post_should_return_http_not_found_when_intership_offer_does_not_exist()
        {
            //Arrange
            var offer = _fixture.Create<InternshipOffer>();
            var internshipOfferViewModel = Mapper.Map<FullOffer>(offer);

            //Act
            var result = _internshipOfferController.Details(internshipOfferViewModel);

            //Assert
            result.Should().BeOfType<HttpNotFoundResult>();
        }

        [TestMethod]
        public void details_post_should_return_view_details_with_error_if_update_and_send_are_not_executed_correctly()
        {
            //Arrange
            var internshipOfferViewModel = PrepareDeny();

            _emailService.When(x => x.BuildMail(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>())).Do(x => { throw new Exception(); });

            //Act
            var result = _internshipOfferController.Details(internshipOfferViewModel) as ViewResult;

            //Assert
            result.ViewName.Should().Be(MVC.InternshipOffer.Views.ViewNames.Details);
        }

        [TestMethod]
        public void download_file_should_redirect_to_details_view_if_file_does_not_exist()
        {
            // Arrange   
            var internshipOffer = _fixture.Create<InternshipOffer>();
            var internshipOfferViewModel = Mapper.Map<FullOffer>(internshipOffer);
            var threeFoldersUp = Path.GetFullPath("../../../");
            var testFilesPath = Directory.GetDirectories(threeFoldersUp, "TestFiles", SearchOption.AllDirectories)
                                               .FirstOrDefault();

            // Action
            var result = _internshipOfferController.DownloadFile(testFilesPath, TestData.InternshipOfferOnValidation1.Id) as RedirectToRouteResult;
            var action = result.RouteValues["Action"];
            _internshipOfferController.Details(TestData.InternshipOfferOnValidation1.Id);

            //Assert
            action.ShouldBeEquivalentTo(MVC.InternshipOffer.Views.ViewNames.Details);
        }

        [TestMethod]
        public void download_file_should_return_file_result_view_if_file_exists()
        {
            // Arrange   
            var internshipOffer = _fixture.Create<InternshipOffer>();
            var internshipOfferViewModel = Mapper.Map<FullOffer>(internshipOffer);
            var threeFoldersUp = Path.GetFullPath("../../../");
            var testFilesPath = Directory.GetDirectories(threeFoldersUp, "TestFiles", SearchOption.AllDirectories)
                                               .FirstOrDefault();

            // Action
            var result = _internshipOfferController.DownloadFile(testFilesPath + "\\TestFile.pdf", TestData.InternshipOfferOnValidation1.Id) as FileResult;

            //Assert
            result.FileDownloadName.ShouldBeEquivalentTo("TestFile.pdf");
        }

        [TestMethod]
        public void details_should_render_view_without_apply_button_if_student_already_applied()
        {

            //Arrange
            var application = _fixture.Create<InternshipApplication>();
            var offer = _fixture.Create<InternshipOffer>();
            var student = _fixture.Create<Student>();
            application.StudentId = student.Id;
            application.InternshipOfferId = offer.Id;
            var offers = new[] { offer };
            var applications = new[] { application };
            _httpContextService.GetUserId().Returns(student.Id);
            _internshipApplicationRepository.GetAll().Returns(applications.AsQueryable());
            _internshipOfferRepository.GetAll().Returns(offers.AsQueryable());
            _internshipOfferRepository.GetById(offer.Id).Returns(offer);


            //Action
            var result = _internshipOfferController.Details(offer.Id) as ViewResult;

            //Assert
            bool isApplicated = result.ViewBag.IsApplicated;
            isApplicated.Should().Be(true);
        }

        private FullOffer PrepareDeny()
        {
            var offer = _fixture.Create<InternshipOffer>();
            var offerOwner = _fixture.Create<StaffMember>();
            var coordinator = _fixture.Create<Coordinator>();
            offer.Status = InternshipOffer.OfferStatus.Draft;
            var fullOffer = Mapper.Map<FullOffer>(offer);
            _internshipOfferRepository.GetById(offer.Id).Returns(offer);
            _coordinatorRepository.GetById(coordinator.Id).Returns(coordinator);
            offer.Contact = offerOwner;
            _httpContextService.GetUserId().Returns(coordinator.Id);

            return fullOffer;
        }
    }
}
