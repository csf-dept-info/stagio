using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using Stagio.DataLayer;
using Stagio.Domain.Entities;
using Stagio.Web.ViewModels.Email;

namespace Stagio.Web.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IEntityRepository<Notification> _notificationRepository;
        private readonly IEntityRepository<Coordinator> _coordinatorRepository;
        private readonly IEntityRepository<Employee> _employeeRepository;
        private readonly IEntityRepository<Student> _studentRepository;
        private readonly IEntityRepository<InternshipAgreement> _internshipAgreementRepository;
        private readonly IEntityRepository<InternshipApplication> _internshipApplicationRepository;

        public NotificationService(IEntityRepository<Notification> notificationRepository, IEntityRepository<Coordinator> coordinatorRepository, IEntityRepository<Employee> employeeRepository, IEntityRepository<Student> studentRepository, IEntityRepository<InternshipAgreement> internshipAgreementRepository, IEntityRepository<InternshipApplication> internshipApplicationRepository)
        {
            _notificationRepository = notificationRepository;
            _coordinatorRepository = coordinatorRepository;
            _employeeRepository = employeeRepository;
            _studentRepository = studentRepository;
            _internshipAgreementRepository = internshipAgreementRepository;
            _internshipApplicationRepository = internshipApplicationRepository;
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

        public void NotifyInternhipAgreementActivated(int internshipAgreementId, string company, int applicationId, int employeeId, int coordinatorId)
        {
            var agreement = _internshipAgreementRepository.GetById(internshipAgreementId);
            var student = _internshipApplicationRepository.GetById(applicationId).ApplyingStudent;
            var personInCharge = _employeeRepository.GetById(employeeId);
            var coordinator = _coordinatorRepository.GetById(coordinatorId);
            const string ACTION_NAME = "StudentApplicationIndex";
            const string CONTROLLER_NAME = "InternshipApplication";

            var studentNotification = new Notification()
            {
                Object = WebMessage.NotificationMessage.StudentInternshipAgreementActivatedMessage(company),
                SenderId = student.Id,
                ReceiverId = student.Id,
                Unseen = true,
                Time = DateTime.Today,
                LinkAction = ACTION_NAME,
                LinkController = CONTROLLER_NAME
            };

            _notificationRepository.Add(studentNotification);
        }
    }
}
