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
    public class AccountControllerStudentLoginTests : AccountControllerBaseClassTests
    {
        [TestMethod]
        public void login_should_redirect_to_student_index_when_student_is_valid()
        {
            //Arrange
            var user = _fixture.Create<ApplicationUser>();
            _internshipPeriodService.IsCurrentDateInInternshipPeriod().Returns(true);

            //Action    
            var routeResult = _accountController.Login(CreateAStudent(user)) as RedirectToRouteResult;
            var routeAction = routeResult.RouteValues["Action"];
            var routeController = routeResult.RouteValues["Controller"];

            //Assert
            routeAction.Should().Be(MVC.Student.Views.ViewNames.Index);
            routeController.Should().Be(MVC.Student.Name);
        }

        [TestMethod]
        public void login_post_should_stay_on_login_page_when_there_is_an_error_student()
        {
            //Arrange
            var user = _fixture.Create<ApplicationUser>();
            _accountController.ModelState.AddModelError("Error", "Error");

            //Action    
            var routeResult = _accountController.Login(CreateAStudent(user)) as ViewResult;

            //Assert
            routeResult.ViewName.Should().Be(MVC.Account.Views.ViewNames.Login);
        }

        [TestMethod]
        public void login_should_authenticate_student_when_student_is_valid()
        {
            //Arrange
            var user = _fixture.Create<ApplicationUser>();
            _internshipPeriodService.IsCurrentDateInInternshipPeriod().Returns(true);

            //Action    
            _accountController.Login(CreateAStudent(user));


            //Assert
            _httpContext.Received().AuthentificateUser(user);
        }

        [TestMethod]
        public void logout_should_deauthenticate_student()
        {
            //Arrange
            var user = _fixture.Create<ApplicationUser>();
            //Action    
            _accountController.Login(CreateAStudent(user));
            _accountController.Logout();
            //Assert
            _httpContext.Received().AuthenticationSignOut();
        }

        public Login CreateAStudent(ApplicationUser user)
        {
            //Arrange


            user.Roles.Add(new UserRole());
            user.Roles.First().RoleName = RoleNames.Student;

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
