using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.DataLayer;
using Stagio.Domain.Entities;
using Stagio.Web.Controllers;
using NSubstitute;
using Stagio.Web.Services;

namespace Stagio.Web.UnitTests.Controllers.InternshipOfferTests
{
    [TestClass]
    public class InternshipOfferControllerBaseClassTests : AllControllersBaseClassTests
    {
        protected InternshipOfferController _internshipOfferController;
        protected IEntityRepository<InternshipOffer> _internshipOfferRepository;
        protected IEntityRepository<InternshipApplication> _internshipApplicationRepository;
        protected IEntityRepository<Employee> _employeeRepository;
        protected IHttpContextService _httpContextService;
        protected IEntityRepository<Coordinator> _coordinatorRepository;
        protected IEmailService _emailService;
        protected INotificationService _notificationService;
        protected IFileSaveService _fileService;

        [TestInitialize]
        public void Initialize()
        {
            _internshipOfferRepository = Substitute.For<IEntityRepository<InternshipOffer>>();
            _internshipApplicationRepository = Substitute.For<IEntityRepository<InternshipApplication>>();
            _employeeRepository = Substitute.For<IEntityRepository<Employee>>();
            _httpContextService = Substitute.For<IHttpContextService>();
            _coordinatorRepository = Substitute.For<IEntityRepository<Coordinator>>();
            _fileService = Substitute.For<IFileSaveService>();
            _emailService = Substitute.For<IEmailService>();
            _notificationService = Substitute.For<INotificationService>();

            _internshipOfferController = new InternshipOfferController(_internshipOfferRepository, _employeeRepository,
                _httpContextService, _coordinatorRepository, _emailService, _fileService,_internshipApplicationRepository, _notificationService);
        }
    }
}
