using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Stagio.Web.UnitTests.Controllers.HomeTests
{
    [TestClass]
    public class HomeControllerIndexTests : HomeControllerBaseClassTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void home_index_should_return_view_with_right_model_if_system_is_closed()
        {
            // Arrange 
            _internshipPeriodService.IsCurrentDateInInternshipPeriod().Returns(false);

            // Action
            var result = _homeController.Index() as ViewResult;

            // Assert
            result.ViewName.Should().Be("");
            result.Model.ShouldBeEquivalentTo(false);
        }

        [TestMethod]
        public void home_index_should_return_view_with_right_model_if_system_is_opened()
        {
            // Arrange 
            _internshipPeriodService.IsCurrentDateInInternshipPeriod().Returns(true);

            // Action
            var result = _homeController.Index() as ViewResult;

            // Assert
            result.ViewName.Should().Be("");
            result.Model.ShouldBeEquivalentTo(true);
        }
    }
}
