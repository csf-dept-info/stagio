using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Stagio.DataLayer;
using Stagio.Domain.Entities;
using Stagio.Web.Services;

namespace Stagio.Web.Controllers
{
    public partial class NotificationController : Controller
    {
        private readonly IEntityRepository<Notification> _notificationRepository;
        private readonly IEntityRepository<ApplicationUser> _applicationUserRepository;
        private readonly IHttpContextService _httpContextService;

        public NotificationController(
            IEntityRepository<Notification> notificationRepository,
            IHttpContextService httpContextService,
            IEntityRepository<ApplicationUser> applicationUserRepository)
        {
            DependencyService.VerifyDependencies(notificationRepository, httpContextService, applicationUserRepository);
            
            _notificationRepository = notificationRepository;
            _httpContextService = httpContextService;
            _applicationUserRepository = applicationUserRepository;
        }

        public virtual ActionResult NotificationIndex()
        {
            const int NUMBER_NOTIF_MAX = 10;
            var userId = _httpContextService.GetUserId();
            var currentUser = _applicationUserRepository.GetById(userId);

            var notifications = Mapper.Map<IEnumerable<ViewModels.Notification.Notification>>(currentUser.Notifications.OrderByDescending(x => x.Time));

            if (notifications.Count() > NUMBER_NOTIF_MAX)
            {
                var shortNotif = notifications.Take(NUMBER_NOTIF_MAX);
                return PartialView("_MenuPartial", shortNotif);
            }

            return PartialView("_MenuPartial", notifications);
        }

        public virtual ActionResult RedirectToNotificationPage(int notifId)
        {
            var notification = _notificationRepository.GetById(notifId);

            notification.Unseen = false;

            _notificationRepository.Update(notification);

            return RedirectToAction(notification.LinkAction, notification.LinkController);
        }
	}
}