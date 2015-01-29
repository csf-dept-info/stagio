using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;

namespace Stagio.Web.UnitTests.Controllers.InternshipOfferTests
{
    [TestClass]
    public class InternshipOfferControllerStudentIndexTests : InternshipOfferControllerBaseClassTests
    {
        [TestMethod]
        public void index_should_return_view_with_internship_offers()
        {
            // Arrange
            const int OFFER_COUNT = 5;
            var offers = _fixture.CreateMany<InternshipOffer>(OFFER_COUNT);
            var applications = _fixture.CreateMany<InternshipApplication>(OFFER_COUNT);

            for (var i = 0; i < OFFER_COUNT; i++)
            {
                offers.ToList()[i].Status = InternshipOffer.OfferStatus.Publicated;
                applications.ToList()[i].InternshipOfferId = offers.ToList()[i].Id;
            }

            _httpContextService.GetUserId().Returns(1);
            _internshipOfferRepository.GetAll().Returns(offers.AsQueryable());
            _internshipApplicationRepository.GetAll().Returns(applications.AsQueryable());

            // Action
            var result = _internshipOfferController.StudentIndex() as ViewResult;
            var model = result.Model as IEnumerable<ViewModels.InternshipOffer.Index>;

            model.ShouldBeEquivalentTo(offers, options => options.ExcludingMissingProperties());
        }
    }
}
