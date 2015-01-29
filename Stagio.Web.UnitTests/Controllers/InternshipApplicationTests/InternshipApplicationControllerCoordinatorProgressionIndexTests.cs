using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;
using Stagio.Web.ViewModels.InternshipApplication;

namespace Stagio.Web.UnitTests.Controllers.InternshipApplicationTests
{
    [TestClass]
    public class InternshipApplicationControllerCoordinatorProgressionIndexTests : InternshipApplicationControllerBaseClassTests
    {
        [TestMethod]
        public void index_should_return_view_with_student_and_his_most_progressed_application()
        {
            // Arrange
            const int INDEX_TO_CHECK = 0;
            var expectedvalue = ArrangeExpectedModel();

            // Action
            var result = _internshipApplicationController.CoordinatorApplicationIndex() as ViewResult;
            var model = result.Model as IEnumerable<ViewModels.InternshipApplication.CoordinatorProgressionIndex>;

            model.ElementAt(INDEX_TO_CHECK).BestProgression.Progression.ShouldBeEquivalentTo
                (expectedvalue.ElementAt(INDEX_TO_CHECK).BestProgression.Progression);
            model.ElementAt(INDEX_TO_CHECK).BestProgression.ProgressionPercentage.ShouldBeEquivalentTo
                (expectedvalue.ElementAt(INDEX_TO_CHECK).BestProgression.ProgressionPercentage);
        }

        private IEnumerable<CoordinatorProgressionIndex> ArrangeExpectedModel()
        {
            //TODO Refactor?
            var student = _fixture.Create<Student>();
            var application = _fixture.Create<InternshipApplication>();

            application.ApplyingStudent = student;
            application.StudentId = student.Id;
            application.Progression = InternshipApplication.ApplicationStatus.StudentHasApplied;

            var studentsRepo = new List<Student> { student };
            var applicationsRepo = new List<InternshipApplication> { application };

            _studentRepository.GetAll().Returns(studentsRepo.AsQueryable());
            _internshipApplicationRepository.GetAll().Returns(applicationsRepo.AsQueryable());

            var expectedValue = SetExpectedValue(student);

            return expectedValue;
        }

        private static IEnumerable<CoordinatorProgressionIndex> SetExpectedValue(ApplicationUser student)
        {
            var expectedvalue = new List<CoordinatorProgressionIndex>
            {
                new CoordinatorProgressionIndex
                {
                    StudentId = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    BestProgression = new StudentIndex { ProgressionPercentage = 25 }
                }
            };

            return expectedvalue;
        }
    }
}
