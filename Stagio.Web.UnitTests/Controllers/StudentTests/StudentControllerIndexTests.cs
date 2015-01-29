using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;

namespace Stagio.Web.UnitTests.Controllers.StudentTests
{
    [TestClass]
    public class StudentControllerIndexTests : StudentControllerBaseClassTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void index_should_return_view_with_a_student()
        {
            // Arrange   
            var student = _fixture.Create<Student>();
            _studentRepository.GetById(student.Id).Returns(student);
            _httpContextService.GetUserId().Returns(student.Id);

            // Action
            var result = _studentController.Index() as ViewResult;
            var model = result.Model as ViewModels.Student.Index;

            // Assert
            model.ShouldBeEquivalentTo(student, options => options.ExcludingMissingProperties());

            result.ViewName.Should().Be("Index");

        }
    }
}
