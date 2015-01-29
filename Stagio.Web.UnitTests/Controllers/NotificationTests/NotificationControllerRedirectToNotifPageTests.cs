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
    public class NotificationControllerRedirectToNotifPageTests : NotificationControllerBaseTests
    {
        [TestMethod]
        public void notif_should_redirect_to_his_linked_page()
        {
            const string CONTROLLER_NAME = "InternshipOffer";
            const string METHOD_NAME = "CoordinatorIndex";

            var notif = _fixture.Create<Notification>();
            notif.LinkController = CONTROLLER_NAME;
            notif.LinkAction = METHOD_NAME;

            _notificationRepository.GetById(notif.Id).Returns(notif);

            //Act
            var routeResult = _notificationController.RedirectToNotificationPage(notif.Id) as RedirectToRouteResult;
            var routeAction = routeResult.RouteValues["Action"];

            routeAction.Should().Be(METHOD_NAME);
        } 
    }
}
