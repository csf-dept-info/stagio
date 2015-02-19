using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Stagio.DataLayer;
using Stagio.Domain.Entities;
using Stagio.Web.Controllers;
using Stagio.Web.Services;

namespace Stagio.Web.UnitTests.Controllers.InternshipApplicationTests
{
    [TestClass]
    public class InternshipApplicationControllerBaseClassTests : AllControllersBaseClassTests
    {
        protected InternshipApplicationController _internshipApplicationController;
        protected AccountController _accountController;
        protected IEntityRepository<InternshipOffer> _internshipOfferRepository;
        protected IEntityRepository<Student> _studentRepository;
        protected IEntityRepository<InternshipApplication> _internshipApplicationRepository;
        protected IHttpContextService _httpContext;
        protected IAccountService _accountService;
        protected IFileSaveService _fileService;
        protected IInternshipPeriodService _internshipPeriodService;
        protected INotificationService _notificationService;

        [TestInitialize]
        public void Initialize()
        {
            _internshipApplicationRepository = Substitute.For<IEntityRepository<InternshipApplication>>();
            _internshipOfferRepository = Substitute.For<IEntityRepository<InternshipOffer>>();
            _studentRepository = Substitute.For<IEntityRepository<Student>>();
            _httpContext = Substitute.For<IHttpContextService>();
            _fileService = Substitute.For<IFileSaveService>();
            _accountService = Substitute.For<IAccountService>();
            _internshipPeriodService = Substitute.For<IInternshipPeriodService>();

            _internshipApplicationController = new InternshipApplicationController(_internshipApplicationRepository, _internshipOfferRepository, _studentRepository, _fileService, _httpContext, _notificationService);
            _accountController = new AccountController(_httpContext, _accountService, _internshipPeriodService);
        }
    }
}
