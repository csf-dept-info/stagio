using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;

namespace Stagio.Web.UnitTests.Controllers.InternshipOfferTests
{
    [TestClass]
    public class InternshipOfferControllerDeleteDraftTests : InternshipOfferControllerBaseClassTests
    {
        [TestMethod]
        public void delete_draft_accept_button_in_modal_should_return_to_draft_list()
        {
            var offer = _fixture.Create<InternshipOffer>();
            var offerVm = Mapper.Map<ViewModels.InternshipOffer.Create>(offer);
            _internshipOfferRepository.GetById(offer.Id).Returns(offer);

            var result = _internshipOfferController.DeleteDraft(offerVm) as RedirectToRouteResult;
            var action = result.RouteValues["Action"];

            action.Should().Be("Employee" + MVC.InternshipOffer.Views.ViewNames.Index);
        }

        [TestMethod]
        public void delete_draft_accept_button_in_modal_should_remove_draft_if_offer_is_found()
        {
            var offer = _fixture.Create<InternshipOffer>();
            var offerVm = Mapper.Map<ViewModels.InternshipOffer.Create>(offer);
            _internshipOfferRepository.GetById(offer.Id).Returns(offer);

            _internshipOfferRepository.Add(offer);

            _internshipOfferController.DeleteDraft(offerVm);

            _internshipOfferRepository.Received().Delete(offer);
        }

        [TestMethod]
        public void delete_draft_accept_button_in_modal_should_return_http_not_found_if_offer_is_not_found()
        {
            var offer = _fixture.Create<InternshipOffer>();
            var offerVm = Mapper.Map<ViewModels.InternshipOffer.Create>(offer);

            var result = _internshipOfferController.DeleteDraft(offerVm);

            result.Should().BeOfType<HttpNotFoundResult>();
        }


    }
}
