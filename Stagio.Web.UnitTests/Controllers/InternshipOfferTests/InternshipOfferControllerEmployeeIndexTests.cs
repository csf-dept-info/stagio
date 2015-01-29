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
    public class InternshipOfferControllerEmployeeIndexTests : InternshipOfferControllerBaseClassTests
    {
        [TestMethod]
        public void index_should_return_view_with_internship_offers()
        {
            // Arrange
            var employee = _fixture.Create<Employee>();
            _employeeRepository.GetById(employee.Id).Returns(employee);
            _httpContextService.GetUserId().Returns(employee.Id);

            const int OFFER_COUNT = 4;
            var offers = _fixture.CreateMany<InternshipOffer>(OFFER_COUNT);

            for (int i = 0; i < OFFER_COUNT; i++)
            {
                offers.ToList()[i].CompanyId = employee.CompanyId;
            }

            _internshipOfferRepository.GetAll().Returns(offers.AsQueryable());

            // Action
            var result = _internshipOfferController.EmployeeIndex() as ViewResult;
            var model = result.Model as IEnumerable<ViewModels.InternshipOffer.Index>;

            //Assert
            model.ShouldBeEquivalentTo(offers, options => options.ExcludingMissingProperties());
        }
    }
}
