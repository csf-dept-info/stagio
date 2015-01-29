using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;

namespace Stagio.Web.UnitTests.Controllers.StudentTests
{
    [TestClass]
    public class StudentControllerSubscribeTests : StudentControllerBaseClassTests
    {
        [TestMethod]
        public void subscribe_student_should_return_view()
        {
            var expectedResult = MVC.Student.Views.ViewNames.Subscribe;

            var result = _studentController.SubscribeStudent() as ViewResult;
            var viewNameObtained = result.ViewName;

            viewNameObtained.Should().Be(expectedResult);
        }

        [TestMethod]
        public void subscribe_student_post_should_return_view_if_Matricule_is_not_found()
        {
            var subscribe = _fixture.Create<ViewModels.Student.Subscribe>();
            var expectedResult = MVC.Student.Views.ViewNames.Subscribe;
            _accountService.UserIdentifierExist(subscribe.StudentId).Returns(false);

            var result = _studentController.SubscribeStudent(subscribe) as ViewResult;
            var viewNameObtained = result.ViewName;

            viewNameObtained.Should().Be(expectedResult);
        }

        [TestMethod]
        public void subscribe_student_post_should_return_create_profile_view_if_matricule_is_found()
        {
            var subscribe = _fixture.Create<ViewModels.Student.Subscribe>();
            var student = _fixture.Create<Student>();
            var expectedResult = MVC.Student.Views.ViewNames.CreateProfile;
            _accountService.UserIdentifierExist(subscribe.StudentId).Returns(true);
            _accountService.GetStudentByStudentId(subscribe.StudentId).Returns(student);

            var routeResult = _studentController.SubscribeStudent(subscribe) as RedirectToRouteResult;
            var routeAction = routeResult.RouteValues["Action"];

            routeAction.Should().Be(expectedResult);
        }

        [TestMethod]
        public void subscribe_student_post_should_return_subscribe_student_view_if_model_state_is_invalid()
        {
            var subscribe = _fixture.Create<ViewModels.Student.Subscribe>();
            var expectedResult = MVC.Student.Views.ViewNames.Subscribe;
            _accountService.UserIdentifierExist(subscribe.StudentId).Returns(true);
            _studentController.ModelState.AddModelError("error", "error");

            var result = _studentController.SubscribeStudent(subscribe) as ViewResult;
            var viewNameObtained = result.ViewName;

            viewNameObtained.Should().Be(expectedResult);
        }

    }
}
