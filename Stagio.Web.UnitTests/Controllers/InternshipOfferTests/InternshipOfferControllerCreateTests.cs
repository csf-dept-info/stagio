using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.Domain.Entities;
using AutoMapper;
using FluentAssertions;
using NSubstitute;
using Ploeh.AutoFixture;

namespace Stagio.Web.UnitTests.Controllers.InternshipOfferTests
{
    [TestClass]
    public class InternshipOfferControllerCreateTests : InternshipOfferControllerBaseClassTests
    {
        [TestMethod]
        public void create_get_should_render_default_view_if_employee_exists()
        {
            //Arrange
            var employee = _fixture.Create<Employee>();
            _httpContextService.GetUserId().Returns(employee.Id);
            _employeeRepository.GetById(employee.Id).Returns(employee);

            //Action
            var result = _internshipOfferController.Create() as ViewResult;

            //Assert
            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void create_get_should_return_httpNotFound_when_employee_does_not_exist()
        {
            //Arrange
            const int INVALID_ID = 99999;
            _httpContextService.GetUserId().Returns(INVALID_ID);

            //Action
            var result = _internshipOfferController.Create();

            //Assert
            result.Should().BeOfType<HttpNotFoundResult>();
        }

        [TestMethod]
        public void create_post_should_return_view_with_errors_when_model_state_is_invalid()
        {
            //Arrange
            var internshipOffer = _fixture.Create<InternshipOffer>();
            var internshipOfferViewModel = Mapper.Map<ViewModels.InternshipOffer.Create>(internshipOffer);

            //Act
            _internshipOfferController.ModelState.AddModelError("Title", "Error");
            var result = _internshipOfferController.Create(internshipOfferViewModel) as ViewResult;
            int errorCount = result.ViewData.ModelState.Count;

            //Assert
            errorCount.Should().NotBe(0);
        }

        [TestMethod]
        public void create_post_should_add_internshipOffer_to_repository()
        {
            // Arrange   
            var internshipOffer = _fixture.Create<InternshipOffer>();

            var internshipOfferViewModel = Mapper.Map<ViewModels.InternshipOffer.Create>(internshipOffer);
            // Action
            _internshipOfferController.Create(internshipOfferViewModel);

            //Assert
            _internshipOfferRepository.Received().Add(Arg.Is<InternshipOffer>(x => x.Id == internshipOffer.Id));
        }

        [TestMethod]
        public void create_post_for_an_existing_draft_should_update_internship_offer()
        {
            // Arrange   
            var internshipOffer = _fixture.Create<InternshipOffer>();
            internshipOffer.Status = InternshipOffer.OfferStatus.Draft;
            _internshipOfferRepository.GetById(internshipOffer.Id).Returns(internshipOffer);

            var internshipOfferViewModel = Mapper.Map<ViewModels.InternshipOffer.Create>(internshipOffer);

            // Action
            _internshipOfferController.Create(internshipOfferViewModel);

            //Assert
            _internshipOfferRepository.Received().Update(Arg.Is<InternshipOffer>(x => x.Id == internshipOffer.Id));
        }

        [TestMethod]
        public void create_post_should_redirect_to_employee_index_on_success()
        {
            //Arrange
            var internshipOffer = _fixture.Create<InternshipOffer>();
            var internshipOfferViewModel = Mapper.Map<ViewModels.InternshipOffer.Create>(internshipOffer);

            //Act
            var result = _internshipOfferController.Create(internshipOfferViewModel) as RedirectToRouteResult;
            var action = result.RouteValues["Action"];

            //Assert
            action.ShouldBeEquivalentTo("Employee" + MVC.InternshipOffer.Views.ViewNames.Index);
        }
    }
}
