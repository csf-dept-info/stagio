using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using FluentAssertions;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;

namespace Stagio.Web.UnitTests.Controllers.InternshipOfferTests
{
    [TestClass]
    public class InternshipOfferControllerEmployeePublicatedOffersIndexTests : InternshipOfferControllerBaseClassTests
    {
        [TestMethod]
        public void publicated_offers_index_should_return_view_with_internship_offers()
        {
            // Arrange
            var employee = _fixture.Create<Employee>();
            _employeeRepository.GetById(employee.Id).Returns(employee);
            _httpContextService.GetUserId().Returns(employee.Id);
            var offers = initializeOffers(employee.CompanyId);
            

            // Action
            var result = _internshipOfferController.EmployeePublicatedOffersIndex() as ViewResult;
            var model = result.Model as IEnumerable<ViewModels.InternshipOffer.Index>;

            //Assert
            model.ShouldBeEquivalentTo(offers, options => options.ExcludingMissingProperties());
        }

        private List<InternshipOffer> initializeOffers(int employeeCompanyId)
        {
            const int OFFER_COUNT = 4;
            var offers = _fixture.CreateMany<InternshipOffer>(OFFER_COUNT);
            var applications = _fixture.CreateMany<InternshipApplication>(OFFER_COUNT);

            for (int i = 0; i < OFFER_COUNT; i++)
            {
                offers.ToList()[i].Status = InternshipOffer.OfferStatus.Publicated;
                offers.ToList()[i].CompanyId = employeeCompanyId;
                offers.ToList()[i].InternshipApplications = new List<InternshipApplication>();
                offers.ToList()[i].InternshipApplications.Add(applications.ToList()[i]);
                applications.ToList()[i].InternshipOfferId = offers.ToList()[i].Id;
                applications.ToList()[i].InternshipOffer = offers.ToList()[i];
            }

            _internshipOfferRepository.GetAll().Returns(offers.AsQueryable());
            _internshipApplicationRepository.GetAll().Returns(applications.AsQueryable());

            return offers.ToList();
        }
    }
}
