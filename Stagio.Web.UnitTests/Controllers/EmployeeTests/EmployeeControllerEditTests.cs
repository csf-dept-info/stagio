using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.Domain.Entities;

using AutoMapper;
using FluentAssertions;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Domain.SecurityUtilities;

namespace Stagio.Web.UnitTests.Controllers.EmployeeTests
{
    [TestClass]
    public class EmployeeControllerEditTests : EmployeeControllerBaseClassTests
    {
        [TestMethod]
        public void edit_should_return_view_with_viewModel_when_employeeId_isValid()
        {
            //Arrange
            var employee = _fixture.Create<Employee>();
            _employeeRepository.GetById(employee.Id).Returns(employee);
            _httpContext.GetUserId().Returns(employee.Id);
            var viewModelExpected = Mapper.Map<ViewModels.Employee.Edit>(employee);

            //Action
            var viewResult = _employeeController.Edit() as ViewResult;
            var viewModelObtained = viewResult.ViewData.Model as ViewModels.Employee.Edit;

            //Assert
            viewModelObtained.ShouldBeEquivalentTo(viewModelExpected);
        }

        [TestMethod]
        public void edit_should_return_http_not_found_when_employeeId_is_invalid()
        {
            //Arrange
            const int invalidId = 9999;
            _httpContext.GetUserId().Returns(invalidId);

            //Action
            var result = _employeeController.Edit();

            //Assert
            result.Should().BeOfType<HttpNotFoundResult>();
        }

        [TestMethod]
        public void edit_post_for_profile_should_return_http_not_found_when_viewModel_id_is_invalid()
        {
            //Arrange
            var employee = _fixture.Create<Employee>();
            var viewModel = Mapper.Map<ViewModels.Employee.Edit>(employee);

            //Action
            var result = _employeeController.EditPassword(viewModel);

            //Assert
            result.Should().BeOfType<HttpNotFoundResult>();

        }

        [TestMethod]
        public void edit_post_for_password_should_return_http_not_found_when_viewModel_id_is_invalid()
        {
            //Arrange
            var employee = _fixture.Create<Employee>();
            var viewModel = Mapper.Map<ViewModels.Employee.Edit>(employee);

            //Action
            var result = _employeeController.EditProfile(viewModel);

            //Assert
            result.Should().BeOfType<HttpNotFoundResult>();

        }

        [TestMethod]
        public void edit_post_for_profile_should_update_employee_when_employeeId_is_valid()
        {
            //Arrange
            var employee = _fixture.Create<Employee>();
            _httpContext.GetUserId().Returns(employee.Id);

            _employeeRepository.GetById(employee.Id).Returns(employee);
            var viewModel = Mapper.Map<ViewModels.Employee.Edit>(employee);

            //Action
            var actionResult = _employeeController.EditProfile(viewModel);

            //Assert
            _employeeRepository.Received().Update(Arg.Is<Employee>(x => x.Id == employee.Id));

        }
        [TestMethod]
        public void edit_post_for_password_should_update_employee_when_employeeId_is_valid()
        {
            //Arrange
            var employee = _fixture.Create<Employee>();
            _employeeRepository.GetById(employee.Id).Returns(employee);
            _httpContext.GetUserId().Returns(employee.Id);

            var viewModel = Mapper.Map<ViewModels.Employee.Edit>(employee);
            viewModel.Password = employee.Password;
            viewModel.NewPassword = employee.Password;
            viewModel.ConfirmPassword = employee.Password;

            employee.Password = Cryptography.Encrypt(employee.Password);

            //Action
            var actionResult = _employeeController.EditPassword(viewModel);

            // Assert
            _employeeRepository.Received().Update(Arg.Is<Employee>(x => x.Id == employee.Id));

        }

        [TestMethod]
        public void edit_post_for_profile_should_return_view_with_errors_when_model_state_is_invalid()
        {
            //Arrange
            var employee = _fixture.Create<Employee>();
            _httpContext.GetUserId().Returns(employee.Id);

            var viewModel = Mapper.Map<Employee, ViewModels.Employee.Edit>(employee);
            _employeeRepository.GetById(employee.Id).Returns(employee);

            //Act
            _employeeController.ModelState.AddModelError("Email", "Error");
            var result = _employeeController.EditProfile(viewModel) as ViewResult;
            int errorCount = result.ViewData.ModelState.Count;

            //Assert
            errorCount.Should().NotBe(0);

        }

        [TestMethod]
        public void edit_post_for_profile_should_return_view_with_specific_error_if_email_is_already_used()
        {
            //Arrange
            var loggedInEmployee = _fixture.Create<Employee>();
            _httpContext.GetUserId().Returns(loggedInEmployee.Id);
            _employeeRepository.GetById(loggedInEmployee.Id).Returns(loggedInEmployee);

            var employee2 = _fixture.Create<Employee>();
            _employeeRepository.GetById(employee2.Id).Returns(employee2);
            _accountService.UserIdentifierExist(employee2.Identifier).Returns(true);

            var viewModel = Mapper.Map<Employee, ViewModels.Employee.Edit>(loggedInEmployee);
            viewModel.Identifier = employee2.Identifier;

            //Act
            var result = _employeeController.EditProfile(viewModel) as ViewResult;
            bool emailAlreadyExists = result.ViewData.ModelState.ContainsKey("Email");

            //Assert
            emailAlreadyExists.Should().BeTrue();
        }

        [TestMethod]
        public void edit_post_for_password_should_return_view_with_errors_when_model_state_is_invalid()
        {
            //Arrange
            var employee = _fixture.Create<Employee>();
            _httpContext.GetUserId().Returns(employee.Id);

            var viewModel = Mapper.Map<Employee, ViewModels.Employee.Edit>(employee);
            _employeeRepository.GetById(employee.Id).Returns(employee);

            //Act
            _employeeController.ModelState.AddModelError("Password", "Error");
            var result = _employeeController.EditPassword(viewModel) as ViewResult;
            int errorCount = result.ViewData.ModelState.Count;

            //Assert
            errorCount.Should().NotBe(0);
        }

        [TestMethod]
        public void edit_post_for_password_should_return_view_with_specific_error_if_current_password_is_wrong()
        {
            //Arrange
            var employee = _fixture.Create<Employee>();
            _httpContext.GetUserId().Returns(employee.Id);

            var viewModel = Mapper.Map<Employee, ViewModels.Employee.Edit>(employee);
            _employeeRepository.GetById(employee.Id).Returns(employee);

            //Act
            viewModel.NewPassword = "shouldwork123";
            viewModel.ConfirmPassword = "shouldwork123";
            viewModel.Password = "error";
            var result = _employeeController.EditPassword(viewModel) as ViewResult;
            bool passwordError = result.ViewData.ModelState.ContainsKey("Password");

            //Assert
            passwordError.Should().BeTrue();
        }
    }
}
