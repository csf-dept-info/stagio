using System.Web.Mvc;
using AutoMapper;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Domain.Application;
using Stagio.Domain.Entities;

namespace Stagio.Web.UnitTests.Controllers.AccountTests
{
    [TestClass]
    public class AccountControllerAllUsersLoginTests : AccountControllerBaseClassTests
    {
        [TestMethod]
        public void login_should_return_view()
        {
            // Arrange 

            // Action
            var result = _accountController.Login() as ViewResult;

            // Assert
            result.ViewName.Should().Be(MVC.Account.Views.ViewNames.Login);
        }

        [TestMethod]
        public void login_post_should_return_view_with_error_when_user_does_not_exist()
        {
            //Arrange
            var user = _fixture.Create<ApplicationUser>();
            var loginViewModel = Mapper.Map<ViewModels.Account.Login>(user);
            
            _accountService.ValidateUser(user.Identifier, user.Password).Returns(new MayBe<ApplicationUser>());

            //Action    
            var result = _accountController.Login(loginViewModel) as ViewResult;

            //Assert
            result.ViewName.Should().Be(MVC.Account.Views.ViewNames.Login);
        }

        [TestMethod]
        public void login_post_should_return_view_with_error_when_system_is_closed()
        {
            //Arrange
            var user = _fixture.Create<ApplicationUser>();
            _internshipPeriodService.IsCurrentDateInInternshipPeriod().Returns(false);
            var loginViewModel = Mapper.Map<ViewModels.Account.Login>(user);

            _accountService.ValidateUser(user.Identifier, user.Password).Returns(new MayBe<ApplicationUser>());

            //Action    
            var result = _accountController.Login(loginViewModel) as ViewResult;

            //Assert
            result.ViewName.Should().Be(MVC.Account.Views.ViewNames.Login);
        }

        [TestMethod]
        public void logout_should_redirect_to_home()
        {
            //Action    
            var routeResult = _accountController.Logout() as RedirectToRouteResult;
            var routeAction = routeResult.RouteValues["Action"];
            var routeController = routeResult.RouteValues["Controller"];

            //Assert
            routeAction.Should().Be(MVC.Home.Views.ViewNames.Index);
            routeController.Should().Be(MVC.Home.Name);
        }
    }
}
