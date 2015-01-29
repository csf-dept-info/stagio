using System.Linq;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;

namespace Stagio.Web.UnitTests.Controllers.CoordinatorTests
{
    [TestClass]
    public class CoordinatorControllerStudentsListTests : CoordinatorControllerBaseClassTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void students_list_should_return_view_with_students()
        {
            // Arrange
            const int OFFER_COUNT = 4;
            var students = _fixture.CreateMany<Student>(OFFER_COUNT);
            var coordinator = _fixture.Create<Student>();

            for (var i = 0; i < OFFER_COUNT - 1; i++)
            {
                students.ToList()[i].Identifier = "test@test.test";
            }
            students.ToList()[OFFER_COUNT - 1].Identifier = "1234567";

            _httpContext.GetUserId().Returns(coordinator.Id);
            _studentRepository.GetAll().Returns(students.AsQueryable());

            // Action
            var result = _coordinatorController.StudentsList() as ViewResult;
            var model = result.Model as ViewModels.Coordinator.StudentsList;

            //Assert
            model.ShouldBeEquivalentTo(students, options => options.ExcludingMissingProperties());
        }

    }
}
