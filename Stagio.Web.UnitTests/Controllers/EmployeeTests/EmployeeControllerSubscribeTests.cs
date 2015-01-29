using System.Web.Mvc;
using AutoMapper;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;
using Stagio.Web.ViewModels.Employee;

namespace Stagio.Web.UnitTests.Controllers.EmployeeTests
{
    [TestClass]
    public class EmployeeControllerSubscribeTests : EmployeeControllerBaseClassTests
    {
        [TestMethod]
        public void subscribe_action_should_render_default_view()
        {
            var company = _fixture.Create<Company>();

            var result = _employeeController.Create(company.Id) as ViewResult;

            result.ViewName.Should().Be("");
        }

        
        [TestMethod]
        public void subscribe_post_should_add_employee_to_repository()
        {
            // Arrange   
            var employee = _fixture.Create<Employee>();
            employee.CompanyId = 1;
            var employeeViewModel = Mapper.Map<Create>(employee);

            // Action
            _employeeController.Create(employeeViewModel);

            // Assert
            _employeeRepository.Received().Add(Arg.Is<Employee>(x => x.Id == employee.Id));
        }

        [TestMethod]
        public void subscribe_post_should_return_default_view_when_modelState_is_not_valid()
        {
            //Arrange
            var employeeViewModel = _fixture.Create<Create>();
            _employeeController.ModelState.AddModelError("Error", "Error");

            //Act
            var result = _employeeController.Create(employeeViewModel) as ViewResult;

            //Assert
            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void subscribe_post_should_return_default_view_if_idenfier_already_exists()
        {
            //Arrange
            var employeeViewModel = _fixture.Create<Create>();
            _accountService.UserIdentifierExist(employeeViewModel.Identifier).Returns(true);

            //Act
            var result = _employeeController.Create(employeeViewModel) as ViewResult;

            //Assert
            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void subscribe_post_should_redirect_to_index_on_success()
        {
            //Arrange
            var employeeViewModel = _fixture.Create<Create>();
            employeeViewModel.CompanyId = 1;

            //Act
            var result = _employeeController.Create(employeeViewModel) as RedirectToRouteResult;

            var action = result.RouteValues["Action"];

            //Assert
            action.Should().Be(MVC.Employee.Views.ViewNames.Index);

        }
    }
}
