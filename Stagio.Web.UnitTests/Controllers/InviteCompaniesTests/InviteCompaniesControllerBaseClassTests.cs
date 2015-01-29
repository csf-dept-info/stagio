using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Stagio.DataLayer;
using Stagio.Domain.Entities;
using Stagio.Web.Controllers;
using Stagio.Web.Services;

namespace Stagio.Web.UnitTests.Controllers.InviteCompaniesTests
{
    [TestClass]
    public class InviteCompaniesControllerBaseClassTests : AllControllersBaseClassTests
    {
        protected InviteCompaniesController _inviteCompaniesController;
        protected IEntityRepository<Employee> _employeeRepository;
        protected IHttpContextService _httpContextService;
        protected IEntityRepository<Coordinator> _coordinatorRepository;
        protected IEmailService _emailService;

        [TestInitialize]
        public void Initialize()
        {
            _employeeRepository = Substitute.For<IEntityRepository<Employee>>();
            _httpContextService = Substitute.For<IHttpContextService>();
            _coordinatorRepository = Substitute.For<IEntityRepository<Coordinator>>();
            _emailService = Substitute.For<IEmailService>();

            _inviteCompaniesController = new InviteCompaniesController(_employeeRepository, _emailService,
                _httpContextService, _coordinatorRepository);
        }
    }
}
