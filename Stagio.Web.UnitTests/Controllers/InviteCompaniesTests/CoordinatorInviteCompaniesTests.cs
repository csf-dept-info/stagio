using System.Linq;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;
using Stagio.Web.ViewModels.Coordinator;
using Stagio.Web.ViewModels.InviteCompanies;

namespace Stagio.Web.UnitTests.Controllers.InviteCompaniesTests
{
    [TestClass]
    public class CoordinatorInviteCompaniesTests : InviteCompaniesControllerBaseClassTests
    {
        [TestMethod]
        public void invite_companies_should_return_invite_companies_view()
        {
           var view = _inviteCompaniesController.InviteCompanies() as ViewResult;
           view.ViewName.Should().Be(MVC.InviteCompanies.Views.ViewNames.InviteCompanies);
        }

        [TestMethod]
        public void invite_companies_post_should_return_view_if_model_state_is_invalid()
        {
            var inviteCompaniesVm = CreateInviteCompaniesVm();
            
            _inviteCompaniesController.ModelState.AddModelError("Error", "Error");
            var view = _inviteCompaniesController.InviteCompanies(inviteCompaniesVm) as ViewResult;

            view.ViewName.Should().Be(MVC.InviteCompanies.Views.ViewNames.InviteCompanies);
        }

        [TestMethod]
        public void invite_companies_post_should_return_to_index_if_message_was_sent_correctly()
        {
            const int EMPLOYEES_COUNT = 5;

            var inviteCompaniesVm = CreateInviteCompaniesVm();
            var coordinator = _fixture.Create<Coordinator>();
            var employees = _fixture.CreateMany<Employee>(EMPLOYEES_COUNT).AsQueryable();

            _httpContextService.GetUserId().Returns(coordinator.Id);
            _coordinatorRepository.GetById(coordinator.Id).Returns(coordinator);
            _employeeRepository.GetAll().Returns(employees);

            var result = _inviteCompaniesController.InviteCompanies(inviteCompaniesVm) as RedirectToRouteResult;
            var action = result.RouteValues["Action"];

            action.Should().Be(MVC.Coordinator.Views.ViewNames.Index);
        }

        private InviteCompanies CreateInviteCompaniesVm()
        {
            const string BODY = "test body";
            const string SUBJECT = "test subject";

            return new InviteCompanies {Body = BODY, Subject = SUBJECT};
        }
    }
}

