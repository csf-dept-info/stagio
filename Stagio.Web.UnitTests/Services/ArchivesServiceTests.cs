using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.DataLayer;
using Stagio.Domain.Entities;
using Stagio.Web.Services;
using Stagio.Web.UnitTests.Controllers;

namespace Stagio.Web.UnitTests.Services
{
    class ArchivesServiceTests : AllControllersBaseClassTests
    {
        public IArchivesService _archivesService;

        private IEntityRepository<Student> _studentRepository;
        private IEntityRepository<DepartmentalArchives> _archivesRepository;
        private IEntityRepository<Employee> _employeeRepository;
        private IEntityRepository<InternshipApplication> _internshipApplicationRepository;
        private IEntityRepository<Company> _companyRepository;
        private IEntityRepository<InternshipOffer> _internshipOfferRepository;

        private const int STUDENTS_COUNT = 8;
        private const int EMPLOYEES_COUNT = 4;
        private const int COMPANIES_COUNT = 3;
        private const int PUBLISHED_OFFERS_COUNT = 10;
        private const int APP_STUDENT_ACCEPTED_OFFER_COUNT = 1;
        private const int APP_COMPANY_ACCEPTED_STUDENT_COUNT = 2;
        private const int APP_STUDENT_HAD_INTERVIEW_COUNT = 3;
        private const int APP_STUDENT_HAS_APPLIED_COUNT = 4;
        private const int ARCHIVES_COUNT = 2;
        private DepartmentalArchives archive;


        [TestInitialize]
        public void Initialize()
        {
            _studentRepository = Substitute.For<IEntityRepository<Student>>();
            _archivesRepository = Substitute.For<IEntityRepository<DepartmentalArchives>>();
            _employeeRepository = Substitute.For<IEntityRepository<Employee>>();
            _internshipApplicationRepository = Substitute.For<IEntityRepository<InternshipApplication>>();
            _companyRepository = Substitute.For<IEntityRepository<Company>>();
            _internshipOfferRepository = Substitute.For<IEntityRepository<InternshipOffer>>();

            _archivesService = new ArchivesService(_studentRepository, _archivesRepository,
                                                   _employeeRepository, _internshipApplicationRepository,
                                                   _companyRepository, _internshipOfferRepository);
            InitializeInternshipPeriod();
        }

        [TestMethod]
        public void get_students_count_should_return_correct_number()
        {

        }

        [TestMethod]
        public void get_employees_count_should_return_correct_number()
        {

        }

        [TestMethod]
        public void get_companies_count_should_return_correct_number()
        {

        }

        [TestMethod]
        public void get_publicated_internship_offers_count_should_return_correct_number()
        {

        }

        [TestMethod]
        public void get_internship_applications_count_should_return_correct_number()
        {

        }

        [TestMethod]
        public void get_interviews_count_should_return_correct_number()
        {

        }

        [TestMethod]
        public void get_students_with_internship_count_should_return_correct_number()
        {

        }

        [TestMethod]
        public void get_company_offers_count_should_return_correct_number()
        {

        }

        [TestMethod]
        public void get_archives_should_return_a_complete_list_of_archives()
        {

        }

        [TestMethod]
        public void get_archives_by_id_should_return_correct_archive()
        {

        }

        [TestMethod]
        public void create_archive_should_create_and_add_an_archive_to_the_repository()
        {

        }

        private void InitializeInternshipPeriod()
        {
            GenerateUsers();
            GenerateInternshipOffers();
            GenerateInternshipApplications();
            GenerateDepartmentalArchives();
        }

        private void GenerateUsers()
        {
            var students = _fixture.CreateMany<Student>(STUDENTS_COUNT).AsQueryable();
            _studentRepository.GetAll().Returns(students);
            var companies = _fixture.CreateMany<Company>(COMPANIES_COUNT).AsQueryable();
            _companyRepository.GetAll().Returns(companies);
            var employees = _fixture.CreateMany<Employee>(EMPLOYEES_COUNT).AsQueryable();
            _employeeRepository.GetAll().Returns(employees);
        }

        private void GenerateInternshipOffers()
        {
            var publishedOffers = _fixture.CreateMany<InternshipOffer>(PUBLISHED_OFFERS_COUNT).AsQueryable();
            foreach (var offer in publishedOffers)
            {
                offer.Status = InternshipOffer.OfferStatus.Publicated;
            }

            GenerateInternshipApplications();

            _internshipOfferRepository.GetAll().Returns(publishedOffers);
        }

        private void GenerateInternshipApplications()
        {
            const int APPLICATIONS_COUNT = APP_COMPANY_ACCEPTED_STUDENT_COUNT + APP_STUDENT_ACCEPTED_OFFER_COUNT + APP_STUDENT_HAD_INTERVIEW_COUNT + APP_STUDENT_HAS_APPLIED_COUNT;

            var applications = _fixture.CreateMany<InternshipApplication>(APPLICATIONS_COUNT).AsQueryable();

            for (var i = 0; i < APPLICATIONS_COUNT; i++)
            {
                if (i < APP_STUDENT_HAS_APPLIED_COUNT)
                {
                    applications.ElementAt(i).Progression = InternshipApplication.ApplicationStatus.StudentHasApplied;
                }
                else if (i < APP_STUDENT_HAS_APPLIED_COUNT + APP_STUDENT_HAD_INTERVIEW_COUNT && i >= APP_STUDENT_HAS_APPLIED_COUNT)
                {
                    applications.ElementAt(i).Progression = InternshipApplication.ApplicationStatus.StudentHadInterview;
                }
                else if (i < APPLICATIONS_COUNT - APP_STUDENT_ACCEPTED_OFFER_COUNT && i >= APP_STUDENT_HAS_APPLIED_COUNT + APP_STUDENT_HAD_INTERVIEW_COUNT)
                {
                    applications.ElementAt(i).Progression = InternshipApplication.ApplicationStatus.CompanyAcceptedStudent;
                }
                else
                {
                    applications.ElementAt(i).Progression = InternshipApplication.ApplicationStatus.StudentAcceptedOffer;
                }
            }

            _internshipApplicationRepository.GetAll().Returns(applications);
        }

        private void GenerateDepartmentalArchives()
        {
            var archives = _fixture.CreateMany<DepartmentalArchives>(ARCHIVES_COUNT).AsQueryable();
            archive = archives.First();
            _archivesRepository.GetAll().Returns(archives);
            _archivesRepository.GetById(archive.Id).Returns(archive);
        }
    }
}
