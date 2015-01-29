using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Stagio.DataLayer;
using Stagio.Domain.Entities;
using Stagio.Web.Services;
using Stagio.Web.UnitTests.Controllers;

using NSubstitute;
using FluentAssertions;
using Ploeh.AutoFixture;

namespace Stagio.Web.UnitTests.Services
{
    [TestClass]
    public class EmployeeServiceTests : AllControllersBaseClassTests
    {
        protected IEmployeeService _employeeService;
        protected IEntityRepository<Employee> _employeeRepository;
        protected IEntityRepository<InternshipApplication> _internshipApplicationRepository;
        protected IEntityRepository<InternshipOffer> _internshipOfferRepository;
        
        private Employee employee;
        private Company company;

        private IQueryable<InternshipOffer> offers;
        private IQueryable<InternshipApplication> applications;

        private const int REFUSED_OFFERS_COUNT = 2;
        private const int ON_VALIDATION_OFFERS_COUNT = 3;
        private const int PUBLISHED_OFFERS_COUNT = 6;

        private const int APPLICATIONS_COUNT = PUBLISHED_OFFERS_COUNT;

        [TestInitialize]
        public void Initialize()
        {
            _employeeRepository = Substitute.For<IEntityRepository<Employee>>();
            _internshipApplicationRepository = Substitute.For<IEntityRepository<InternshipApplication>>();
            _internshipOfferRepository = Substitute.For<IEntityRepository<InternshipOffer>>();

            _employeeService = new EmployeeService(_employeeRepository, _internshipApplicationRepository, _internshipOfferRepository);
            
            this.InitializeAttributes();
        }

        [TestMethod]
        public void fetch_total_number_of_applications_should_return_correct_number()
        {
            _employeeService.FetchTotalNumberOfApplications(employee.Id).Should().Be(APPLICATIONS_COUNT);
        }

        [TestMethod]
        public void fetch_total_number_of_refused_offers_should_return_correct_number()
        {
            _employeeService.FetchTotalNumberOfRefusedOffers(employee.Id).Should().Be(REFUSED_OFFERS_COUNT);
        }

        [TestMethod]
        public void fetch_total_number_of_offers_on_validation_should_return_correct_number()
        {
            _employeeService.FetchTotalNumberOfOnValidationOffers(employee.Id).Should().Be(ON_VALIDATION_OFFERS_COUNT);
        }

        [TestMethod]
        public void fetch_total_number_of_published_offers_should_return_correct_number()
        {
            _employeeService.FetchTotalNumberOfPublishedOffers(employee.Id).Should().Be(PUBLISHED_OFFERS_COUNT);
        }

        private void InitializeAttributes()
        {
            company = _fixture.Create<Company>();
            employee = _fixture.Create<Employee>();
            employee.Company = company;
            employee.CompanyId = company.Id;

            _employeeRepository.GetById(employee.Id).Returns(employee);

            this.GenerateInternshipOffers();
        }

        private void GenerateInternshipOffers()
        {
            var refusedOffers = _fixture.CreateMany<InternshipOffer>(REFUSED_OFFERS_COUNT).AsQueryable();
            foreach (InternshipOffer offer in refusedOffers)
            {
                offer.Status = InternshipOffer.OfferStatus.Refused;
                offer.CompanyId = company.Id;
            }

            var onValidationOffers = _fixture.CreateMany<InternshipOffer>(ON_VALIDATION_OFFERS_COUNT).AsQueryable();
            foreach (InternshipOffer offer in onValidationOffers)
            {
                offer.Status = InternshipOffer.OfferStatus.OnValidation;
                offer.CompanyId = company.Id;
            }

            var publishedOffers = _fixture.CreateMany<InternshipOffer>(PUBLISHED_OFFERS_COUNT).AsQueryable();
            foreach (InternshipOffer offer in publishedOffers)
            {
                offer.Status = InternshipOffer.OfferStatus.Publicated;
                offer.CompanyId = company.Id;
            }

            this.GenerateInternshipApplications(publishedOffers);
              
            offers = refusedOffers.Concat(onValidationOffers).Concat(publishedOffers);
            
            _internshipOfferRepository.GetAll().Returns(offers);
        }

        private void GenerateInternshipApplications(IQueryable<InternshipOffer> publicatedOffers)
        {
            int applicationsCount = publicatedOffers.Count();

            applications = _fixture.CreateMany<InternshipApplication>(applicationsCount).AsQueryable();

            for (int i = 0; i < applicationsCount; i++)
            {
                applications.ElementAt(i).InternshipOffer = publicatedOffers.ElementAt(i);
                applications.ElementAt(i).InternshipOfferId = publicatedOffers.ElementAt(i).Id;
            }

            this._internshipApplicationRepository.GetAll().Returns(applications);
        }

    }
}
