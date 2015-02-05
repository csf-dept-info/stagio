using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using Stagio.DataLayer;
using Stagio.Domain.Application;
using Stagio.Domain.Entities;
using Stagio.Web.ViewModels.Email;

namespace Stagio.Web.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IEntityRepository<Notification> _notificationRepository;
        private readonly IEntityRepository<Coordinator> _coordinatorRepository;
        private readonly IEntityRepository<Employee> _employeeRepository;
        private readonly IEntityRepository<ApplicationUser> _applicationUserRepository;
        private readonly IHttpContextService _httpContext;

        public NotificationService(IEntityRepository<Notification> notificationRepository, IEntityRepository<Coordinator> coordinatorRepository, IEntityRepository<Employee> employeeRepository, IEntityRepository<ApplicationUser> applicationUserRepository, IHttpContextService httpContext)
        {
            _notificationRepository = notificationRepository;
            _coordinatorRepository = coordinatorRepository;
            _employeeRepository = employeeRepository;
            _applicationUserRepository = applicationUserRepository;
            _httpContext = httpContext;
        }

        public void NotifyNewInternshipOfferCreated(int internshipOfferAuthorId)
        {
            var employee = _employeeRepository.GetById(internshipOfferAuthorId);
            var allCoordinators = _coordinatorRepository.GetAll().AsEnumerable();
            const string ACTION_NAME = "CoordinatorIndex";
            const string CONTROLLER_NAME = "InternshipOffer";

            foreach (var coordinator in allCoordinators)
            {
                var notification = new Notification()
                {
                    Object = WebMessage.NotificationMessage.NewInternshipOfferCreatedMessage(employee.Company.Name, employee.FullName()),
                    SenderId = employee.Id,
                    ReceiverId = coordinator.Id,
                    Unseen = true,
                    Time = DateTime.Today,
                    LinkAction = ACTION_NAME,
                    LinkController = CONTROLLER_NAME
                };
                
                _notificationRepository.Add(notification);
            }
        }

        public void GroupNotification(string roleName, string message, string linkControllerName, string linkMethodName)
        {
            var selectedUsers = _applicationUserRepository.GetAll().Where(x => x.Roles.FirstOrDefault().RoleName == roleName).AsEnumerable();

            foreach (var user in selectedUsers)
            {
                var notification = new Notification()
                {
                    Object = message,
                    SenderId = _httpContext.GetUserId(),
                    ReceiverId = user.Id,
                    Unseen = true,
                    Time = DateTime.Today,
                    LinkAction = linkMethodName,
                    LinkController = linkControllerName
                };

                _notificationRepository.Add(notification);
            }
        }
    }
}
