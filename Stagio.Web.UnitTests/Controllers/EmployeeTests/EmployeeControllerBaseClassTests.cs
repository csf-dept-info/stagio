using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.DataLayer;
using Stagio.Domain.Entities;
using Stagio.Web.Controllers;
using NSubstitute;
using Stagio.Web.Services;

namespace Stagio.Web.UnitTests.Controllers.EmployeeTests
{
    [TestClass]
    public class EmployeeControllerBaseClassTests : AllControllersBaseClassTests
    {
        protected IEmployeeService _employeeService;
        protected EmployeeController _employeeController;
        protected IEntityRepository<Employee> _employeeRepository;
        protected IHttpContextService _httpContext;
        protected IAccountService _accountService;

        [TestInitialize]
        public void Initialize()
        {
            _employeeService = Substitute.For<IEmployeeService>();
            _employeeRepository = Substitute.For<IEntityRepository<Employee>>();
            _httpContext = Substitute.For<IHttpContextService>();
            _accountService = Substitute.For<IAccountService>();
            _employeeController = new EmployeeController(_employeeService, _employeeRepository, _httpContext, _accountService);
        }
    }
}
