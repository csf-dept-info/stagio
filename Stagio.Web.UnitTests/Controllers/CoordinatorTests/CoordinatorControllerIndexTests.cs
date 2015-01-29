using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;

namespace Stagio.Web.UnitTests.Controllers.CoordinatorTests
{
    [TestClass]
    public class CoordinatorControllerIndexTests : CoordinatorControllerBaseClassTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void index_should_return_view_with_a_coordinator()
        {
            // Arrange   
            var coordinator = _fixture.Create<Coordinator>();
            _coordinatorRepository.GetById(coordinator.Id).Returns(coordinator);
            _httpContext.GetUserId().Returns(coordinator.Id);

            // Action
            var result = _coordinatorController.Index() as ViewResult;
            var model = result.Model as ViewModels.Coordinator.Index;

            // Assert
            model.ShouldBeEquivalentTo(coordinator, options => options.ExcludingMissingProperties());

            result.ViewName.Should().Be("Index");
        }

    }
}
