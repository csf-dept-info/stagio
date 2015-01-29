using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.DataLayer;
using Stagio.Domain.Entities;
using Stagio.Web.Services;
using Stagio.Web.UnitTests.Controllers;

namespace Stagio.Web.UnitTests.Services
{
    [TestClass]
    public class NotificationServiceTests : AllControllersBaseClassTests
    {
        public INotificationService _notificationService;

        private IEntityRepository<Coordinator> _coordinatorRepository;
        private IEntityRepository<Employee> _employeeRepository;
        private IEntityRepository<Notification> _notificationRepository;

        [TestInitialize]
        public void Initialize()
        {
            _coordinatorRepository = Substitute.For<IEntityRepository<Coordinator>>();
            _employeeRepository = Substitute.For<IEntityRepository<Employee>>();
            _notificationRepository = Substitute.For<IEntityRepository<Notification>>();

            _notificationService = new NotificationService(_notificationRepository, 
                                                        _coordinatorRepository,
                                                        _employeeRepository);
        }

        [Ignore]
        [TestMethod]
        public void notification_service_should_create_notification_when_new_internship_offer()
        {
            // Arrange   
            var employee = _fixture.Create<Employee>();
            var coordinators = _fixture.CreateMany<Coordinator>();
            _employeeRepository.GetById(employee.Id).Returns(employee);
            _coordinatorRepository.GetAll().Returns(coordinators);

            //Action
            _notificationService.NotifyNewInternshipOfferCreated(employee.Id);

            //Assert
            //_notificationRepository.Received().Add(Arg.Is<Notification>());
        }
    }
}
