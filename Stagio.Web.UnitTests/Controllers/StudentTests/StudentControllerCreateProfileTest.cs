using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;
using Stagio.TestUtilities.Database;

namespace Stagio.Web.UnitTests.Controllers.StudentTests
{
    [TestClass]
    public class StudentControllerCreateProfileTest : StudentControllerBaseClassTests
    {
        [TestMethod]
        public void create_profile_should_return_view_with_createProfileVM_when_subscriber_isValid()
        {
            var expectedResult = MVC.Student.Views.ViewNames.CreateProfile;

            var result = _studentController.CreateProfile(TestData.ToSubscribeStudent.StudentId) as ViewResult;
            var viewNameObtained = result.ViewName;

            viewNameObtained.Should().Be(expectedResult);
        }
        [TestMethod]
        public void create_profile_post_should_return_view_if_model_state_if_invalid()
        {
            _studentController.ModelState.AddModelError("error", "error");
            var model = _fixture.Create<ViewModels.Student.CreateProfile>();
            var expectedResult = MVC.Student.Views.ViewNames.CreateProfile;

            var result = _studentController.CreateProfile(model) as ViewResult;
            var viewNameObtained = result.ViewName;

            viewNameObtained.Should().Be(expectedResult);
        }

        [TestMethod]
        public void create_profile_post_should_return_view_if_email_is_already_used()
        {
            var model = _fixture.Create<ViewModels.Student.CreateProfile>();
            var expectedResult = MVC.Student.Views.ViewNames.CreateProfile;
            _accountService.UserIdentifierExist(model.Identifier).Returns(true);

            var result = _studentController.CreateProfile(model) as ViewResult;
            var viewNameObtained = result.ViewName;

            viewNameObtained.Should().Be(expectedResult);
        }

        [TestMethod]
        public void create_profile_should_update_student_if_form_is_valid()
        {
            var model = _fixture.Create<ViewModels.Student.CreateProfile>();
            var student = _fixture.Create<Student>();
            _studentRepository.GetById(model.Id).Returns(student);
            _accountService.UserIdentifierExist(model.StudentId).Returns(false);

            _studentController.CreateProfile(model);


            _studentRepository.Received().Update(Arg.Any<Student>());
        }
    }
}
