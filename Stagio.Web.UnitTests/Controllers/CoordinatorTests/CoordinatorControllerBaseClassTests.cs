using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Stagio.DataLayer;
using Stagio.Domain.Entities;
using Stagio.Web.Controllers;
using Stagio.Web.Services;

namespace Stagio.Web.UnitTests.Controllers.CoordinatorTests
{
    [TestClass]
    public class CoordinatorControllerBaseClassTests : AllControllersBaseClassTests
    {
        protected CoordinatorController _coordinatorController;
        protected IEntityRepository<Coordinator> _coordinatorRepository;
        protected IEntityRepository<Student> _studentRepository; 
        protected IHttpContextService _httpContext;
        protected IAccountService _accountService;
        protected IFileImportService _fileService;
        protected IInternshipPeriodService _internshipPeriodService;
        protected IArchivesService _archivesService;

        [TestInitialize]
        public void Initialize()
        {
            _coordinatorRepository = Substitute.For<IEntityRepository<Coordinator>>();
            _studentRepository = Substitute.For<IEntityRepository<Student>>();
            _httpContext = Substitute.For<IHttpContextService>();
            _accountService = Substitute.For<IAccountService>();
            _fileService = Substitute.For<IFileImportService>();
            _internshipPeriodService = Substitute.For<IInternshipPeriodService>();
            _archivesService = Substitute.For<IArchivesService>();
            
            _coordinatorController = new CoordinatorController(_coordinatorRepository, _studentRepository, 
                                                               _accountService, _fileService, 
                                                               _httpContext, _internshipPeriodService, _archivesService);
        }
    }
}
