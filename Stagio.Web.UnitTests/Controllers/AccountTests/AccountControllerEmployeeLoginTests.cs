using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using FluentAssertions;
using Stagio.Domain.Application;
using Stagio.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Web.ViewModels.Account;

namespace Stagio.Web.UnitTests.Controllers.AccountTests
{
    [TestClass]
    public class AccountControllerEmployeeLoginTests : AccountControllerBaseClassTests
    {
        [TestMethod]
        public void login_should_redirect_to_employee_index_when_employee_is_valid()
        {
            //Arrange
            var user = _fixture.Create<Employee>();
            _internshipPeriodService.IsCurrentDateInInternshipPeriod().Returns(true);

            //Action    
            var routeResult = _accountController.Login(CreateAnEmployee(user)) as RedirectToRouteResult;
            var routeAction = routeResult.RouteValues["Action"];
            var routeController = routeResult.RouteValues["Controller"];
            
            //Assert
            routeAction.Should().Be(MVC.Employee.Views.ViewNames.Index);
            routeController.Should().Be(MVC.Employee.Name);
        }

        [TestMethod]
        public void login_post_should_stay_on_login_page_when_there_is_an_error_employee()
        {
            //Arrange
            var employee = _fixture.Create<Employee>();
            _accountController.ModelState.AddModelError("Error", "Error");

            //Action    
            var routeResult = _accountController.Login(CreateAnEmployee(employee)) as ViewResult;

            //Assert
            routeResult.ViewName.Should().Be(MVC.Account.Views.ViewNames.Login);
        }

        [TestMethod]
        public void login_should_authenticate_employee_when_employee_is_valid()
        {
            //Arrange
            var user = _fixture.Create<Employee>();
            var employee = CreateAnEmployee(user);
            _internshipPeriodService.IsCurrentDateInInternshipPeriod().Returns(true);

            //Action    
            _accountController.Login(employee);


            //Assert
            _httpContext.Received().AuthentificateUser(user);
        }

        [TestMethod]
        public void logout_should_deauthenticate_employee()
        {
            //Arrange
            var user = _fixture.Create<ApplicationUser>();
            //Action    
            _accountController.Login(CreateAnEmployee(user));
            _accountController.Logout();
            //Assert
            _httpContext.Received().AuthenticationSignOut();
        }

        public Login CreateAnEmployee(ApplicationUser user)
        {
            user.Roles.Add(new UserRole());
            user.Roles.First().RoleName = RoleNames.Employee;

            var loginViewModel = Mapper.Map<Login>(user);

            LoginAnEmployee(user, loginViewModel);

            return loginViewModel;
        }

        public void LoginAnEmployee(ApplicationUser user, Login loginViewModel)
        {
            var valideUser = new MayBe<ApplicationUser>(user);
            _accountService.ValidateUser(loginViewModel.Identifier, loginViewModel.Password).Returns(valideUser);
        }

    }
}
