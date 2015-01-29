using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.Domain.Entities;
using AutoMapper;
using FluentAssertions;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Domain.SecurityUtilities;

namespace Stagio.Web.UnitTests.Controllers.StudentTests
{
    [TestClass]
    public class StudentControllerEditTests : StudentControllerBaseClassTests
    {
        [TestMethod]
        public void edit_should_return_view_with_studentVM_when_studentId_isValid()
        {
            //Arrange
            var viewModelExpected = CreateAViewModelEditStudent();
            _httpContextService.GetUserId().Returns(viewModelExpected.Id);

            //Action
            var viewResult = _studentController.Edit() as ViewResult;
            var viewModelObtained = viewResult.ViewData.Model as ViewModels.Student.Edit;

            //Assert
            viewModelObtained.ShouldBeEquivalentTo(viewModelExpected);
        }

        [TestMethod]
        public void edit_should_return_http_not_found_when_studentId_is_invalid()
        {
            //Arrange
            const int INVALID_ID = 9999;
            _httpContextService.GetUserId().Returns(INVALID_ID);

            //Action
            var result = _studentController.Edit();

            //Assert
            result.Should().BeOfType<HttpNotFoundResult>();
        }

        [TestMethod]
        public void edit_should_return_default_view_when_password_is_empty()
        {
            //Arrange
            var editVM = CreateAViewModelEditStudent();
            editVM.NewPassword = "b";
            _httpContextService.GetUserId().Returns(editVM.Id);

            //Action
            var result = _studentController.EditPassword(editVM) as ViewResult;

            //Assert
            result.ViewName.Should().Be(MVC.Student.Views.ViewNames.Edit);
        }

        [TestMethod]
        public void edit_should_return_default_view_when_studentVM_password_is_invalid()
        {
            //Arrange
            var editVM = CreateAViewModelEditStudent();
            editVM.Password = "a";
            editVM.NewPassword = "b";
            editVM.ConfirmPassword = "b";
            _httpContextService.GetUserId().Returns(editVM.Id);

            //Action
            var result = _studentController.EditPassword(editVM) as ViewResult;

            //Assert
            result.ViewName.Should().Be(MVC.Student.Views.ViewNames.Edit);
        }

        [TestMethod]
        public void edit_should_return_http_not_found_when_studentVM_is_invalid_password()
        {
            //Arrange
            var student = _fixture.Create<Student>();
            var editVM = Mapper.Map<ViewModels.Student.Edit>(student);
            _httpContextService.GetUserId().Returns(editVM.Id);

            //Action
            var result = _studentController.EditPassword(editVM);

            //Assert
            result.Should().BeOfType<HttpNotFoundResult>();
        }

        [TestMethod]
        public void edit_should_return_http_not_found_when_studentVM_is_invalid_profile()
        {
            //Arrange
            var student = _fixture.Create<Student>();
            var editVM = Mapper.Map<ViewModels.Student.Edit>(student);
            _httpContextService.GetUserId().Returns(editVM.Id);

            //Action
            var result = _studentController.EditProfile(editVM);

            //Assert
            result.Should().BeOfType<HttpNotFoundResult>();
        }

        [TestMethod]
        public void edit_post_should_update_student_when_studentId_is_valid_profile()
        {
            //Arrange
            var studentVM = CreateAViewModelEditStudent();
            _httpContextService.GetUserId().Returns(studentVM.Id);

            //Action
            var actionResult = _studentController.EditProfile(studentVM);

            // Assert
            _studentRepository.Received().Update(Arg.Is<Student>(x => x.Id == studentVM.Id));
        }

        [TestMethod]
        public void edit_post_should_update_student_when_studentId_is_valid_password()
        {
            const string NEW_PWORD = "pomme1234";

            //Arrange
            var student = _fixture.Create<Student>();
            _httpContextService.GetUserId().Returns(student.Id);
            _studentRepository.GetById(student.Id).Returns(student);

            var studentVM = Mapper.Map<Student, ViewModels.Student.Edit>(student);
            studentVM.Password = student.Password;
            studentVM.NewPassword = NEW_PWORD;
            studentVM.ConfirmPassword = NEW_PWORD;
            student.Password = Cryptography.Encrypt(student.Password);

            //Action
            var actionResult = _studentController.EditPassword(studentVM);

            // Assert
            _studentRepository.Received().Update(Arg.Is<Student>(x => x.Id == student.Id));
        }

        [TestMethod]
        public void edit_post_should_redirect_to_index_on_success_profile()
        {
            //Arrange
            var studentVM = CreateAViewModelEditStudent();
            _httpContextService.GetUserId().Returns(studentVM.Id);

            //Act
            var result = _studentController.EditProfile(studentVM) as RedirectToRouteResult;

            var action = result.RouteValues["Action"];

            //Assert
            action.Should().Be(MVC.Student.Views.ViewNames.Index);
        }

        [TestMethod]
        public void edit_post_should_redirect_to_index_on_success_password()
        {
            const string NEW_PWORD = "pomme1234";

            //Arrange
            var student = _fixture.Create<Student>();
            _studentRepository.GetById(student.Id).Returns(student);
            _httpContextService.GetUserId().Returns(student.Id);

            var studentVM = Mapper.Map<Student, ViewModels.Student.Edit>(student);
            studentVM.Password = student.Password;
            studentVM.NewPassword = NEW_PWORD;
            studentVM.ConfirmPassword = NEW_PWORD;
            student.Password = Cryptography.Encrypt(student.Password);

            //Act
            var result = _studentController.EditPassword(studentVM) as RedirectToRouteResult;

            var action = result.RouteValues["Action"];

            //Assert
            action.Should().Be(MVC.Student.Views.ViewNames.Index);
        }

        [TestMethod]
        public void edit_post_should_return_default_view_when_model_state_is_invalid_profile()
        {
            //Arrange
            var studentVM = CreateAViewModelEditStudent();
            _httpContextService.GetUserId().Returns(studentVM.Id);
            _studentController.ModelState.AddModelError("Error", "Error");

            //Act
            var result = _studentController.EditProfile(studentVM) as ViewResult;

            //Assert
            result.ViewName.Should().Be(MVC.Student.Views.ViewNames.Edit);
        }

        [TestMethod]
        public void edit_post_should_return_default_view_when_model_state_is_invalid_password()
        {
            //Arrange
            var studentVM = CreateAViewModelEditStudent();
            _httpContextService.GetUserId().Returns(studentVM.Id);
            _studentController.ModelState.AddModelError("Error", "Error");

            //Act
            var result = _studentController.EditPassword(studentVM) as ViewResult;

            //Assert
            result.ViewName.Should().Be(MVC.Student.Views.ViewNames.Edit);
        }

        private ViewModels.Student.Edit CreateAViewModelEditStudent()
        {
            var student = _fixture.Create<Student>();
            _studentRepository.GetById(student.Id).Returns(student);
            return Mapper.Map<Student, ViewModels.Student.Edit>(student);
        }
    }
}
