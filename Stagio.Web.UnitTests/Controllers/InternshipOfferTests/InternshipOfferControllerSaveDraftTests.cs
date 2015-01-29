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
    public class InternshipOfferControllerSaveDraftTests : InternshipOfferControllerBaseClassTests
    {
        [TestMethod]
        public void edit_draft_should_return_create_view_with_associated_view_model()
        {
            // Arrange   
            var internshipOffer = _fixture.Create<InternshipOffer>();
            var employee = _fixture.Create<Employee>();
            _httpContextService.GetUserId().Returns(employee.Id);
            _internshipOfferRepository.GetById(internshipOffer.Id).Returns(internshipOffer);
            _employeeRepository.GetById(employee.Id).Returns(employee);
            var viewModelExpected = Mapper.Map<ViewModels.InternshipOffer.Create>(internshipOffer);
            viewModelExpected.EmployeeId = employee.Id;

            //Action
            var viewResult = _internshipOfferController.Edit(internshipOffer.Id) as ViewResult;
            var viewModelObtained = viewResult.ViewData.Model as ViewModels.InternshipOffer.Create;

            //Assert
            viewModelObtained.ShouldBeEquivalentTo(viewModelExpected); 
        }

        [TestMethod]
        public void save_draft_post_should_add_internship_offer_to_repository_even_if_there_are_model_state_errors()
        {
            // Arrange   
            var internshipOffer = _fixture.Create<InternshipOffer>();
            var internshipOfferViewModel = Mapper.Map<ViewModels.InternshipOffer.Create>(internshipOffer);

            // Action
            _internshipOfferController.ModelState.AddModelError("Title", "Error");
            _internshipOfferController.ModelState.AddModelError("Description", "Error");
            _internshipOfferController.ModelState.AddModelError("Contact.Email", "Error");

            _internshipOfferController.SaveDraft(internshipOfferViewModel);

            //Assert
            _internshipOfferRepository.Received().Add(Arg.Is<InternshipOffer>(x => x.Id == internshipOffer.Id));
        }

        [TestMethod]
        public void save_draft_post_for_an_existing_internship_offer_should_update_internship_offer()
        {
            // Arrange   
            var internshipOffer = _fixture.Create<InternshipOffer>();
            _internshipOfferRepository.GetById(internshipOffer.Id).Returns(internshipOffer);

            var internshipOfferViewModel = Mapper.Map<ViewModels.InternshipOffer.Create>(internshipOffer);
            internshipOfferViewModel.Description = "";
            internshipOfferViewModel.Title = "";
            internshipOfferViewModel.Details = null;

            // Action
            _internshipOfferController.SaveDraft(internshipOfferViewModel);

            //Assert
            _internshipOfferRepository.Received().Update(Arg.Is<InternshipOffer>(x => x.Id == internshipOffer.Id));
        }

        [TestMethod]
        public void save_draft_post_should_redirect_to_employee_index_on_success()
        {
            //Arrange
            var internshipOffer = _fixture.Create<InternshipOffer>();
            var internshipOfferViewModel = Mapper.Map<ViewModels.InternshipOffer.Create>(internshipOffer);

            //Act
            var result = _internshipOfferController.SaveDraft(internshipOfferViewModel) as RedirectToRouteResult;

            //Assert
            result.RouteValues["Action"].ShouldBeEquivalentTo("Employee" + MVC.Employee.Views.ViewNames.Index);
        }

        [TestMethod]
        public void save_draft_post_should_return_http_not_found_if_internshipoffer_id_is_not_associated_to_current_logged_in_employee()
        {
            //Arrange
            var employee = _fixture.Create<Employee>();
            _employeeRepository.GetById(employee.Id).Returns(employee);
            _httpContextService.GetUserId().Returns(employee.Id);

            const int INVALID_ID = 9999;

            var internshipOffer = _fixture.Create<InternshipOffer>();
            var internshipOfferViewModel = Mapper.Map<ViewModels.InternshipOffer.Create>(internshipOffer);
            internshipOfferViewModel.EmployeeId = INVALID_ID;

            //Action
            var result = _internshipOfferController.SaveDraft(internshipOfferViewModel);

            //Assert
            result.Should().BeOfType<HttpNotFoundResult>();
        }
    }
}
