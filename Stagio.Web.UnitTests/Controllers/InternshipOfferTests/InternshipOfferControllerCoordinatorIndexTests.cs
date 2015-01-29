using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;
using Stagio.Web.ViewModels.InternshipOffer;
using StaffMember = Stagio.Domain.Entities.StaffMember;

namespace Stagio.Web.UnitTests.Controllers.InternshipOfferTests
{
    [TestClass]
    public class InternshipOfferControllerCoordinatorIndexTests : InternshipOfferControllerBaseClassTests
    {
        const int INVALID_ID = 999999;

        [TestMethod]
        public void index_should_return_view_with_internship_offers()
        {
            // Arrange
            const int OFFER_COUNT = 5;
            var offers = _fixture.CreateMany<InternshipOffer>(OFFER_COUNT);

            for (int i = 0; i < OFFER_COUNT; i++)
            {
                offers.ToList()[i].Status = InternshipOffer.OfferStatus.OnValidation;
            }

            _internshipOfferRepository.GetAll().Returns(offers.AsQueryable());

            // Action
            var result = _internshipOfferController.CoordinatorIndex() as ViewResult;
            var model = result.Model as IEnumerable<Index>;

            model.ShouldBeEquivalentTo(offers, options => options.ExcludingMissingProperties());
        }

        [TestMethod]
        public void validate_an_offer_should_change_status()
        {
            // Arrange
            var offer = _fixture.Create<InternshipOffer>();
            offer.Status = InternshipOffer.OfferStatus.Draft;
            _internshipOfferRepository.GetById(offer.Id).Returns(offer);

            // Action
            var result = _internshipOfferController.ValidateOffer(offer.Id);

            _internshipOfferRepository.Received().Update(Arg.Is<InternshipOffer>(x => x.Id == offer.Id));
            _internshipOfferRepository.Received().Update(Arg.Is<InternshipOffer>(x => x.Status == InternshipOffer.OfferStatus.Publicated));
        }

        [TestMethod]
        public void deny_an_offer_should_change_status()
        {
            // Arrange
            var fullOffer = PrepareDeny();

            // Action
            var result = _internshipOfferController.Details(fullOffer);

            //Assert
            _internshipOfferRepository.Received().Update(Arg.Is<InternshipOffer>(x => x.Id == fullOffer.Id));
            _internshipOfferRepository.Received().Update(Arg.Is<InternshipOffer>(x => x.Status == InternshipOffer.OfferStatus.Refused));
        }

        [TestMethod]
        public void validate_should_return_http_not_found_when_offerID_is_not_valid()
        {
            //Action
            var result = _internshipOfferController.ValidateOffer(INVALID_ID);
            //Assert
            result.Should().BeOfType<HttpNotFoundResult>();
        }

        [TestMethod]
        public void deny_should_return_http_not_found_when_offerID_is_not_valid()
        {

            //Action
            var result = _internshipOfferController.Details(INVALID_ID);
            //Assert
            result.Should().BeOfType<HttpNotFoundResult>();
        }

        [TestMethod]
        public void validate_should_redirect_to_internship_offer_index_on_success()
        {
            //Arrange
            var offer = _fixture.Create<InternshipOffer>();
            _internshipOfferRepository.GetById(offer.Id).Returns(offer);

            //Act
            var routeResult = _internshipOfferController.ValidateOffer(offer.Id) as RedirectToRouteResult;
            var routeAction = routeResult.RouteValues["Action"];

            //Assert
            routeAction.Should().Be("Coordinator" + MVC.InternshipOffer.Views.ViewNames.Index);
        }

        [TestMethod]
        public void deny_should_redirect_to_internship_offer_index_on_success()
        {
            //Arrange
            var offer = PrepareDeny();

            //Act
            var result = _internshipOfferController.Details(offer) as RedirectToRouteResult;
            
            var action = result.RouteValues["Action"];

            //Assert
            action.Should().Be("Coordinator" + MVC.InternshipOffer.Views.ViewNames.Index);
        }

        private FullOffer PrepareDeny()
        {
            var offer = _fixture.Create<InternshipOffer>();
            var offerOwner = _fixture.Create<StaffMember>();
            var coordinator = _fixture.Create<Coordinator>();
            offer.Status = InternshipOffer.OfferStatus.Draft;
            var fullOffer = Mapper.Map<FullOffer>(offer);
            offer.Contact = offerOwner;
            _internshipOfferRepository.GetById(offer.Id).Returns(offer);
            _coordinatorRepository.GetById(coordinator.Id).Returns(coordinator);
            _httpContextService.GetUserId().Returns(coordinator.Id);

            return fullOffer;
        }
    }
}
