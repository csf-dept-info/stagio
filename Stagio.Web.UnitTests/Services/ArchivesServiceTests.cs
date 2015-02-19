using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Stagio.DataLayer;
using Stagio.Domain.Entities;
using Stagio.Web.Services;
using Stagio.Web.UnitTests.Controllers;

namespace Stagio.Web.UnitTests.Services
{
    class ArchivesServiceTests :AllControllersBaseClassTests
    {
        public IArchivesService _archivesService;

        private IEntityRepository<Student> _studentRepository;
        private IEntityRepository<Employee> _employeeRepository;
        private IEntityRepository<InternshipApplication> _internshipApplicationRepository;
        private IEntityRepository<Company> _companyRepository;
        private IEntityRepository<InternshipOffer> _internshipOfferRepository;
        private IEntityRepository<InternshipPeriod> _internshipPeriodRepository;

        [TestInitialize]
        public void Initialize()
        {
            _studentRepository = Substitute.For<IEntityRepository<Student>>();
            _employeeRepository = Substitute.For<IEntityRepository<Employee>>();
            _internshipApplicationRepository = Substitute.For<IEntityRepository<InternshipApplication>>();
            _companyRepository = Substitute.For<IEntityRepository<Company>>();
            _internshipOfferRepository = Substitute.For<IEntityRepository<InternshipOffer>>();
            _internshipPeriodRepository = Substitute.For<IEntityRepository<InternshipPeriod>>();

            _archivesService = new ArchivesService(_studentRepository, _employeeRepository, 
                                                   _internshipApplicationRepository, _companyRepository, 
                                                   _internshipOfferRepository, _internshipPeriodRepository);
        }
    }
}
