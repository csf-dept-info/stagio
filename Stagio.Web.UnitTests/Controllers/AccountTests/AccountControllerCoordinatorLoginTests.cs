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
    public class AccountControllerCoordinatorLoginTests : AccountControllerBaseClassTests
    {
        [TestMethod]
        public void login_should_redirect_to_coordinator_index_when_coordinator_is_valid()
        {
            //Arrange
            var user = _fixture.Create<ApplicationUser>();
            _internshipPeriodService.IsCurrentDateInInternshipPeriod().Returns(true);

            //Action    
            var routeResult = _accountController.Login(CreateACoordinator(user)) as RedirectToRouteResult;
            var routeAction = routeResult.RouteValues["Action"];
            var routeController = routeResult.RouteValues["Controller"];

            //Assert
            routeAction.Should().Be(MVC.Coordinator.Views.ViewNames.Index);
            routeController.Should().Be(MVC.Coordinator.Name);
        }

        [TestMethod]
        public void login_post_should_stay_on_login_page_when_there_is_an_error_coordinator()
        {
            //Arrange
            var user = _fixture.Create<ApplicationUser>();
            _accountController.ModelState.AddModelError("Error", "Error");

            //Action    
            var routeResult = _accountController.Login(CreateACoordinator(user)) as ViewResult;

            //Assert
            routeResult.ViewName.Should().Be(MVC.Account.Views.ViewNames.Login);
        }

        [TestMethod]
        public void login_should_authenticate_coordinator_when_coordinator_is_valid()
        {
            //Arrange
            var user = _fixture.Create<ApplicationUser>();
            _internshipPeriodService.IsCurrentDateInInternshipPeriod().Returns(true);

            //Action    
            _accountController.Login(CreateACoordinator(user));


            //Assert
            _httpContext.Received().AuthentificateUser(user);
        }

        [TestMethod]
        public void logout_should_deauthenticate_coordinator()
        {
            var user = _fixture.Create<ApplicationUser>();

            //Action    
            _accountController.Login(CreateACoordinator(user));
            _accountController.Logout();
            //Assert
            _httpContext.Received().AuthenticationSignOut();
        }


        public Login CreateACoordinator(ApplicationUser user)
        {
            user.Roles.Add(new UserRole());
            user.Roles.First().RoleName = RoleNames.Coordinator;

            var loginViewModel = Mapper.Map<Login>(user);

            LoginACoordinator(user, loginViewModel);

            return loginViewModel;
        }

        public void LoginACoordinator(ApplicationUser user, Login loginViewModel)
        {
            //Arrange
            var valideUser = new MayBe<ApplicationUser>(user);
            _accountService.ValidateUser(loginViewModel.Identifier, loginViewModel.Password).Returns(valideUser);
        }

    }
}
