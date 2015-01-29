using System.Web.Mvc;
using AutoMapper;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;
using Stagio.TestUtilities.Database;

namespace Stagio.Web.UnitTests.Controllers.CoordinatorTests
{
    [TestClass]
    public class CoordinatorChoosePeriodTests : CoordinatorControllerBaseClassTests
    {
        [TestMethod]
        public void choose_period_should_return_default_view()
        {
            _internshipPeriodService.GetActualInternshipPeriod().Returns(TestData.ValidInternshipPeriod);

            var viewResult = _coordinatorController.ChooseInternshipPeriod() as ViewResult;

            //Assert
            viewResult.ViewName.Should().Be(MVC.Coordinator.Views.ChooseInternshipPeriod);
        }

        [TestMethod]
        public void choose_period_should_return_default_view_without_a_model()
        {
            //Arrange
            _internshipPeriodService.GetActualInternshipPeriod().Returns((InternshipPeriod)null);

            //Action
            var viewResult = _coordinatorController.ChooseInternshipPeriod() as ViewResult;

            //Assert
            viewResult.ViewName.Should().Be(MVC.Coordinator.Views.ChooseInternshipPeriod);
        }

        [TestMethod]
        public void choose_period_post_should_return_default_view_with_error_if_start_date_is_greater_than_end_date()
        {
            //Arrange
            var period = _fixture.Create<InternshipPeriod>();
            period.StartDate = TestData.ValidInternshipPeriod.EndDate;
            period.EndDate = TestData.ValidInternshipPeriod.StartDate;
            var vmPeriod = Mapper.Map<ViewModels.Coordinator.ChoosePeriod>(period);

            //Act
            var result = _coordinatorController.ChooseInternshipPeriod(vmPeriod) as ViewResult;
            var errorCount = result.ViewData.ModelState.Count;

            //Assert
            result.ViewName.Should().Be(MVC.Coordinator.Views.ChooseInternshipPeriod);
            errorCount.Should().BeGreaterThan(0);
        }

        [TestMethod]
        public void choose_period_post_should_return_default_view_with_error_if_start_date_is_equal_to_end_date()
        {
            //Arrange
            var period = _fixture.Create<InternshipPeriod>();
            period.StartDate = TestData.ValidInternshipPeriod.StartDate;
            period.EndDate = TestData.ValidInternshipPeriod.StartDate;
            var vmPeriod = Mapper.Map<ViewModels.Coordinator.ChoosePeriod>(period);

            //Act
            var result = _coordinatorController.ChooseInternshipPeriod(vmPeriod) as ViewResult;
            var errorCount = result.ViewData.ModelState.Count;

            //Assert
            result.ViewName.Should().Be(MVC.Coordinator.Views.ChooseInternshipPeriod);
            errorCount.Should().BeGreaterThan(0);
        }

        [TestMethod]
        public void choose_period_post_should_return_to_index_if_period_is_valid()
        {
            //Arrange
            var vmPeriod = Mapper.Map<ViewModels.Coordinator.ChoosePeriod>(TestData.ValidInternshipPeriod);

            //Act
            var result = _coordinatorController.ChooseInternshipPeriod(vmPeriod) as RedirectToRouteResult;
            var action = result.RouteValues["Action"];

            //Assert
            action.Should().Be(MVC.Coordinator.Views.ViewNames.Index);
        }
    }
}
