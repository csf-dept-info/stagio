using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.DataLayer;
using Stagio.Domain.Entities;
using Stagio.Web.Controllers;
using Stagio.Web.Services;

namespace Stagio.Web.UnitTests.Controllers.InternshipOfferTests
{
    [TestClass]
    public class NotificationControllerBaseTests : AllControllersBaseClassTests
    {
        protected NotificationController _notificationController;
        protected IEntityRepository<Notification> _notificationRepository;
        protected IEntityRepository<ApplicationUser> _applicationUserRepository;
        protected INotificationService _notificationService;
        protected IHttpContextService _httpContextService;

        [TestInitialize]
        public void Initialize()
        {
            _notificationRepository = Substitute.For<IEntityRepository<Notification>>();
            _applicationUserRepository = Substitute.For<IEntityRepository<ApplicationUser>>();
            _notificationService = Substitute.For<INotificationService>();
            _httpContextService = Substitute.For<IHttpContextService>();

            _notificationController = new NotificationController(_notificationRepository, 
                _httpContextService,
                _applicationUserRepository);
        }
    }
}
