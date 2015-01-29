using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Stagio.Domain.Entities;
using Stagio.Web.ViewModels.InternshipApplication;

using FluentAssertions;
using NSubstitute;
using Ploeh.AutoFixture;

namespace Stagio.Web.UnitTests.Controllers.InternshipApplicationTests
{
    [TestClass]
    public class InternshipApplicationEmployeeIndexTests : InternshipApplicationControllerBaseClassTests
    {
        [TestMethod]
        public void applications_index_should_return_view_with_internship_offers()
        {
            // Arrange
            const int APPLICATIONS_COUNT = 2;
            var offer = _fixture.Create<InternshipOffer>();
            var applications = _fixture.CreateMany<InternshipApplication>(APPLICATIONS_COUNT);
            var student = _fixture.Create<Student>();
            var employee = _fixture.Create<Employee>();

            offer.Status = InternshipOffer.OfferStatus.Publicated;
            offer.CompanyId = 1;

            for (int i = 0; i < APPLICATIONS_COUNT; i++)
            {
                applications.ToList()[i].InternshipOfferId = offer.Id;
                applications.ToList()[i].InternshipOffer = offer;
                applications.ToList()[i].StudentId = student.Id;
            }

            _httpContext.GetUserId().Returns(employee.Id);
            _studentRepository.GetById(student.Id).Returns(student);
            _internshipOfferRepository.GetById(offer.Id).Returns(offer);
            _internshipApplicationRepository.GetAll().Returns(applications.AsQueryable());

            // Action
            var result = _internshipApplicationController.EmployeeApplicationIndex(offer.Id) as ViewResult;
            var model = result.Model as IEnumerable<EmployeeIndex>;

            model.ShouldBeEquivalentTo(applications, options => options.ExcludingMissingProperties());
        }
    }
}
