using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;
using Stagio.Domain.SecurityUtilities;
using Stagio.Web.ViewModels.Coordinator;

namespace Stagio.Web.UnitTests.Controllers.CoordinatorTests
{
    [TestClass]
    public class CoordinatorControllerCleanDatabaseTests : CoordinatorControllerBaseClassTests
    {
        [TestMethod]
        public void clean_database_button_should_return_clean_database_view()
        {
            var result = _coordinatorController.CleanDatabase() as ViewResult;
            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void clean_database_control_should_return_clean_database_view_if_coordinator_password_is_invalid()
        {
            var coordinator = _fixture.Create<Coordinator>();
            _httpContext.GetUserId().Returns(coordinator.Id);
            _coordinatorRepository.GetById(coordinator.Id).Returns(coordinator);
            var cleanDatabaseVm = _fixture.Create<CleanDatabase>();

            var result = _coordinatorController.CleanDatabase(cleanDatabaseVm) as ViewResult;

            result.ViewName.Should().Be(MVC.Coordinator.Views.ViewNames.CleanDatabase);
        }

        [TestMethod]
        public void clean_database_control_should_return_clean_database_view_if_view_model_is_null()
        {
            var result = _coordinatorController.CleanDatabase(null) as ViewResult;

            result.ViewName.Should().Be(MVC.Coordinator.Views.ViewNames.CleanDatabase);
        }



        [TestMethod]
        public void clean_database_control_should_clean_database_if_coordinator_password_is_valid()
        {
            var result = _coordinatorController.CleanDatabase() as ViewResult;
            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void clean_database_control_should_return_index_if_coordinator_password_is_valid()
        {
            var coordinator = _fixture.Create<Coordinator>();
            var cleanDatabaseVm = new CleanDatabase { Password = coordinator.Password };
            _httpContext.GetUserId().Returns(coordinator.Id);
            coordinator.Password = Cryptography.Encrypt(cleanDatabaseVm.Password);
            _coordinatorRepository.GetById(coordinator.Id).Returns(coordinator);

            var result = _coordinatorController.CleanDatabase(cleanDatabaseVm) as RedirectToRouteResult;
            var action = result.RouteValues["Action"];
            action.Should().Be("CleanDatabase");
        }
    }
}
