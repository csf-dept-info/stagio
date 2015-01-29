using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.DataLayer;
using Stagio.Domain.Entities;
using Stagio.Web.Controllers;
using NSubstitute;
using Stagio.Web.Services;

namespace Stagio.Web.UnitTests.Controllers.StudentTests
{
    [TestClass]
    public class StudentControllerBaseClassTests : AllControllersBaseClassTests
    {
        protected StudentController _studentController;
        protected IEntityRepository<Student> _studentRepository;
        protected IAccountService _accountService;
        protected IHttpContextService _httpContextService;

        [TestInitialize]
        public void Initialize()
        {
            _studentRepository = Substitute.For<IEntityRepository<Student>>();
            _httpContextService = Substitute.For<IHttpContextService>();
            _accountService = Substitute.For<IAccountService>();

            _studentController = new StudentController(_studentRepository, _accountService, _httpContextService);
        }
    }
}
