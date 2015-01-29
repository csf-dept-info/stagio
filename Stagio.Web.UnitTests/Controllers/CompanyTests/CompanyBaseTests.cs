using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.DataLayer;
using Stagio.Domain.Entities;
using Stagio.Web.Controllers;
using NSubstitute;
using Stagio.Web.Services;

namespace Stagio.Web.UnitTests.Controllers.CompanyTests
{
    [TestClass]
    public class CompanyBaseTests : AllControllersBaseClassTests
    {
        protected CompanyController _companyController;
        protected IEntityRepository<Employee> _employeeRepository; 
        protected IEntityRepository<Company> _companyRepository;
        protected IHttpContextService _httpContextService;

        [TestInitialize]
        public void Initialize()
        {
            _companyRepository = Substitute.For<IEntityRepository<Company>>();
            _employeeRepository = Substitute.For<IEntityRepository<Employee>>();
            _httpContextService = Substitute.For<IHttpContextService>();
            _companyController = new CompanyController(_companyRepository, _employeeRepository, _httpContextService);
        }
    }
}
