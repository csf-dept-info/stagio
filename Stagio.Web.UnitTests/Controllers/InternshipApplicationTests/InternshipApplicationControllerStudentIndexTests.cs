using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;

namespace Stagio.Web.UnitTests.Controllers.InternshipApplicationTests
{
    [TestClass]
    public class InternshipApplicationControllerStudentIndexTests : InternshipApplicationControllerBaseClassTests
    {
        private InternshipApplication.ApplicationStatus[] _offerStatuses;

        [TestInitialize]
        public void initialize()
        {
            _offerStatuses = new InternshipApplication.ApplicationStatus[]
            {
                InternshipApplication.ApplicationStatus.StudentHasApplied,
                InternshipApplication.ApplicationStatus.StudentHadInterview,
                InternshipApplication.ApplicationStatus.CompanyAcceptedStudent,
                InternshipApplication.ApplicationStatus.StudentAcceptedOffer
            };
        }

        [TestMethod]
        public void index_should_return_view_with_internship_applications_for_the_current_student()
        {
            // Arrange
            int OFFER_COUNT = _offerStatuses.Length; //This way, we can test every possible application status

            var offers = _fixture.CreateMany<InternshipOffer>(OFFER_COUNT);
            var applications = _fixture.CreateMany<InternshipApplication>(OFFER_COUNT);

            var student = _fixture.Create<Student>();
            _studentRepository.GetById(student.Id).Returns(student);
            _httpContext.GetUserId().Returns(student.Id);

            for (var i = 0; i < OFFER_COUNT; i++)
            {
                offers.ToList()[i].Status = InternshipOffer.OfferStatus.Publicated;
                offers.ToList()[i].Company = _fixture.Create<Company>();
                applications.ToList()[i].InternshipOffer = offers.ToList()[i];
                applications.ToList()[i].ApplyingStudent = student;
                applications.ToList()[i].Progression = _offerStatuses[i];
            }
            
            _internshipOfferRepository.GetAll().Returns(offers.AsQueryable());
            _internshipApplicationRepository.GetAll().Returns(applications.AsQueryable());

            // Action
            var result = _internshipApplicationController.StudentApplicationIndex() as ViewResult;
            var model = result.Model as IEnumerable<ViewModels.InternshipApplication.StudentIndex>;

            // Assert
            model.ShouldBeEquivalentTo(applications, options => options.ExcludingMissingProperties());
        }

        [TestMethod]
        public void index_should_return_http_not_found_when_invalid_id()
        {
            const int INVALID_ID = 999999;

            _httpContext.GetUserId().Returns(INVALID_ID);

            //Action
            var result = _internshipApplicationController.GetApplicationsForSpecificStudent(INVALID_ID);

            //Assert
            result.Should().BeOfType<HttpNotFoundResult>();
        }
    }
}
