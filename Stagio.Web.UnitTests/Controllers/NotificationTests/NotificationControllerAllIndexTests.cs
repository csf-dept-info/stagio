using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;
using Stagio.Web.UnitTests.Controllers.InternshipOfferTests;

namespace Stagio.Web.UnitTests.Controllers.NotificationTests
{
    [TestClass]
    public class NotificationControllerAllIndexTests : NotificationControllerBaseTests
    {
        [TestMethod]
        public void index_should_return_view_with_notifications()
        {
            // Arrange
            var user = _fixture.Create<ApplicationUser>();

            const int NOTIF_COUNT = 11;
            var notifs = _fixture.CreateMany<Notification>(NOTIF_COUNT);

            for (int i = 0; i < NOTIF_COUNT; i++)
            {
                notifs.ToList()[i].ReceiverId = user.Id;
            }

            user.Notifications = new List<Notification>(notifs);

            _applicationUserRepository.GetById(user.Id).Returns(user);
            _httpContextService.GetUserId().Returns(user.Id);

            // Action
            var result = _notificationController.AllNotificationIndex() as ViewResult;
            var model = result.Model as IEnumerable<ViewModels.Notification.Notification>;

            //Assert
            model.ShouldBeEquivalentTo(notifs, options => options.ExcludingMissingProperties());
            result.ViewName.Should().Be("AllNotificationIndex");
        }
    }
}
