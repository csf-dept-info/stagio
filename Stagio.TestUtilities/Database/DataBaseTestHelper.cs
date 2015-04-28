using Stagio.Domain.Entities;
using Stagio.DataLayer;
using Stagio.DataLayer.EntityFramework;
using Stagio.Domain.SecurityUtilities;

namespace Stagio.TestUtilities.Database
{
    public class DataBaseTestHelper
    {
        private readonly IEntityRepository<Company> _companyRepository;
        private readonly IEntityRepository<Student> _studentRepository;
        private readonly IEntityRepository<Employee> _employeeRepository;
        private readonly IEntityRepository<Coordinator> _coordinatorRepository;
        private readonly IEntityRepository<InternshipApplication> _internshipApplicationRepository;
        private readonly IEntityRepository<InternshipOffer> _internshipOfferRepository;
        private readonly IEntityRepository<InternshipPeriod> _internshipPeriodRepository; 
        private readonly IEntityRepository<Notification> _notificationRepository;
        private readonly IEntityRepository<DepartmentalArchives> _departementalArchivesRepository; 

        private int _companyId1;
        private int _companyId2;
        private int _companyId3;

        private int _studentId1;
        private int _studentId2;
        private int _studentId3;

        private int _studentWhoAppliedId;
        private int _studentWhoHadInterviewId;
        private int _studentWhoWasAcceptedByCompanyId;
        private int _studentWhoAcceptedInternshipId;

        private int _internshipOfferId2;
        private int _internshipOfferId3;
        private int _internshipOfferId4;
        private int _internshipOfferId5;
        private int _internshipOfferId6;

        private int _employeeId1;
        private int _employeeId2;

        private int _coordinatorId1;

        public DataBaseTestHelper()
        {
            _studentRepository = new EfEntityRepository<Student>();
            _companyRepository = new EfEntityRepository<Company>();
            _employeeRepository = new EfEntityRepository<Employee>();
            _coordinatorRepository = new EfEntityRepository<Coordinator>();
            _internshipApplicationRepository = new EfEntityRepository<InternshipApplication>();
            _internshipOfferRepository = new EfEntityRepository<InternshipOffer>();
            _internshipPeriodRepository = new EfEntityRepository<InternshipPeriod>();
            _notificationRepository = new EfEntityRepository<Notification>();
            _departementalArchivesRepository = new EfEntityRepository<DepartmentalArchives>();
        }

        public void SeedTables()
        {
            AddStudents();
            AddCompanies();
            AddCoordinators();
            AddEmployees();
            AddInternshipOffers();
            AddInternshipApplications();
            AddNotifications();
            AddInternshipPeriod();
            AddDepartmentalArchives();
        }

        private void AddNotifications()
        {
            var notif1 = TestData.Notification1;
            notif1.ReceiverId = _coordinatorId1;
            notif1.SenderId = _employeeId1;
            notif1.Object = "Une nouvelle offre de stage à été ajoutée par " + TestData.Employee1.FullName();
            _notificationRepository.Add(notif1);

            var notif2 = TestData.Notification2;
            notif2.ReceiverId = _coordinatorId1;
            notif2.SenderId = _employeeId2;
            notif2.Object = "Une nouvelle offre de stage à été ajoutée par " + TestData.Employee2.FullName();
            _notificationRepository.Add(notif2);
        }

        public void AddStudents()
        {
            var subscribedStudent = TestData.SubscribedStudent1;
            EncryptPasswordBeforeAddingToDataBase(subscribedStudent);

            var notSubscribedStudent = TestData.NotSubscribedStudent;
            EncryptPasswordBeforeAddingToDataBase(notSubscribedStudent);

            var student2 = TestData.SubscribedStudent2;
            EncryptPasswordBeforeAddingToDataBase(student2);

            var student3 = TestData.SubscribedStudent3;
            EncryptPasswordBeforeAddingToDataBase(student3);

            var student4 = TestData.StudentWhoApplied;
            EncryptPasswordBeforeAddingToDataBase(student4);

            var student5 = TestData.StudentWhoHadInterview;
            EncryptPasswordBeforeAddingToDataBase(student5);

            var student6 = TestData.StudentWhoWasAcceptedByCompany;
            EncryptPasswordBeforeAddingToDataBase(student6);

            var student7 = TestData.StudentWhoAcceptedInternship;
            EncryptPasswordBeforeAddingToDataBase(student7);

            _studentRepository.Add(subscribedStudent);
            _studentRepository.Add(notSubscribedStudent);
            _studentRepository.Add(student2);
            _studentRepository.Add(student3);

            _studentRepository.Add(student4);
            _studentRepository.Add(student5);
            _studentRepository.Add(student6);
            _studentRepository.Add(student7);

            _studentId1 = student2.Id;
            _studentId2 = student3.Id;
            _studentId3 = subscribedStudent.Id;

            _studentWhoAppliedId = student4.Id;
            _studentWhoHadInterviewId = student5.Id;
            _studentWhoWasAcceptedByCompanyId = student6.Id;
            _studentWhoAcceptedInternshipId = student7.Id;
        }

        private void AddCompanies()
        {
            var company1 = TestData.Company1;
            _companyRepository.Add(company1);
            _companyId1 = company1.Id;

            var company2 = TestData.Company2;
            _companyRepository.Add(company2);
            _companyId2 = company2.Id;

            var company3 = TestData.Company3;
            _companyRepository.Add(company3);
            _companyId3 = company3.Id;
        }

        private void AddInternshipOffers()
        {
            var internshipOffer1 = TestData.InternshipOfferOnValidation1;
            internshipOffer1.CompanyId = _companyId2;
            internshipOffer1.OfferOwnerId = _employeeId2;
            _internshipOfferRepository.Add(internshipOffer1);

            
            var internshipOffer2 = TestData.InternshipOfferDraft1;
            internshipOffer2.CompanyId = _companyId1;
            internshipOffer2.OfferOwnerId = _employeeId1;
            _internshipOfferRepository.Add(internshipOffer2);
            _internshipOfferId2 = internshipOffer2.Id;

            
            var internshipOffer3 = TestData.InternshipOfferPublicated1;
            internshipOffer3.CompanyId = _companyId1;
            internshipOffer3.OfferOwnerId = _employeeId1;
            _internshipOfferRepository.Add(internshipOffer3);
            _internshipOfferId3 = internshipOffer3.Id;


            var internshipOffer4 = TestData.InternshipOfferPublicated2;
            internshipOffer4.CompanyId = _companyId1;
            internshipOffer4.OfferOwnerId = _employeeId1;
            _internshipOfferRepository.Add(internshipOffer4);
            _internshipOfferId4 = internshipOffer4.Id;


            var internshipOffer5 = TestData.InternshipOfferPublicated3;
            internshipOffer5.CompanyId = _companyId2;
            internshipOffer5.OfferOwnerId = _employeeId2;
            _internshipOfferRepository.Add(internshipOffer5);
            _internshipOfferId5 = internshipOffer5.Id;


            var internshipOffer6 = TestData.InternshipOfferPublicated4;
            internshipOffer6.CompanyId = _companyId2;
            internshipOffer6.OfferOwnerId = _employeeId2;
            _internshipOfferRepository.Add(internshipOffer6);
            _internshipOfferId6 = internshipOffer6.Id;


            var internshipOffer7 = TestData.InternshipOfferOnValidation2;
            internshipOffer7.CompanyId = _companyId1;
            internshipOffer7.OfferOwnerId = _employeeId1;
            _internshipOfferRepository.Add(internshipOffer7);


            var internshipOffer8 = TestData.InternshipOfferOnValidation3;
            internshipOffer8.CompanyId = _companyId1;
            internshipOffer8.OfferOwnerId = _employeeId1;
            _internshipOfferRepository.Add(internshipOffer8);


            var internshipOffer9 = TestData.InternshipOfferDraft3;
            internshipOffer9.CompanyId = _companyId1;
            internshipOffer9.OfferOwnerId = _employeeId1;
            _internshipOfferRepository.Add(internshipOffer9);


            var internshipOffer10 = TestData.InternshipOfferDraft4;
            internshipOffer10.CompanyId = _companyId2;
            internshipOffer10.OfferOwnerId = _employeeId2;
            _internshipOfferRepository.Add(internshipOffer10);
        }

        public void AddCoordinators()
        {
            var coordinator = TestData.Coordinator1;
            EncryptPasswordBeforeAddingToDataBase(coordinator);
            _coordinatorRepository.Add(coordinator);

            _coordinatorId1 = coordinator.Id;
        }

        public void AddEmployees()
        {
            var employee1 = TestData.Employee1;
            employee1.CompanyId = _companyId1;
            EncryptPasswordBeforeAddingToDataBase(employee1);
            _employeeRepository.Add(employee1);
            _employeeId1 = employee1.Id;

            var employee2 = TestData.Employee2;
            employee2.CompanyId = _companyId2;
            EncryptPasswordBeforeAddingToDataBase(employee2);
            _employeeRepository.Add(employee2);
            _employeeId2 = employee2.Id;
        }

        public void AddInternshipApplications()
        {
            //Student 3 applications
            var internshipApplication1 = TestData.InternshipApplication1;
            internshipApplication1.StudentId = _studentId3;
            internshipApplication1.InternshipOfferId = _internshipOfferId3;
            _internshipApplicationRepository.Add(internshipApplication1);

            var internshipApplication2 = TestData.InternshipApplication2;
            internshipApplication2.StudentId = _studentId2;
            internshipApplication2.InternshipOfferId = _internshipOfferId3;
            _internshipApplicationRepository.Add(internshipApplication2);

            var internshipApplication3 = TestData.InternshipApplication3;
            internshipApplication3.StudentId = _studentId2;
            internshipApplication3.InternshipOfferId = _internshipOfferId4;
            _internshipApplicationRepository.Add(internshipApplication3);

            //Student 2 applications
            var internshipApplication4 = TestData.InternshipApplication4;
            internshipApplication4.StudentId = _studentId1;
            internshipApplication4.InternshipOfferId = _internshipOfferId4;
            _internshipApplicationRepository.Add(internshipApplication4);

            var internshipApplication5 = TestData.InternshipApplication5;
            internshipApplication5.StudentId = _studentId1;
            internshipApplication5.InternshipOfferId = _internshipOfferId5;
            _internshipApplicationRepository.Add(internshipApplication5);

            var internshipApplication6 = TestData.InternshipApplication6;
            internshipApplication6.StudentId = _studentId3;
            internshipApplication6.InternshipOfferId = _internshipOfferId5;
            _internshipApplicationRepository.Add(internshipApplication6);

            var internshipApplication7 = TestData.InternshipApplication7;
            internshipApplication7.StudentId = _studentId1;
            internshipApplication7.InternshipOfferId = _internshipOfferId6;
            _internshipApplicationRepository.Add(internshipApplication7);

            //Student progression test
            var internshipApplication8 = TestData.InternshipApplication8;
            internshipApplication8.StudentId = _studentWhoAppliedId;
            internshipApplication8.InternshipOfferId = _internshipOfferId6;
            _internshipApplicationRepository.Add(internshipApplication8);

            var internshipApplication9 = TestData.InternshipApplication9;
            internshipApplication9.StudentId = _studentWhoHadInterviewId;
            internshipApplication9.InternshipOfferId = _internshipOfferId3;
            _internshipApplicationRepository.Add(internshipApplication9);

            var internshipApplication10 = TestData.InternshipApplication10;
            internshipApplication10.StudentId = _studentWhoWasAcceptedByCompanyId;
            internshipApplication10.InternshipOfferId = _internshipOfferId4;
            _internshipApplicationRepository.Add(internshipApplication10);

            var internshipApplication11 = TestData.InternshipApplication11;
            internshipApplication11.StudentId = _studentWhoAcceptedInternshipId;
            internshipApplication11.InternshipOfferId = _internshipOfferId5;
            _internshipApplicationRepository.Add(internshipApplication11);
        }

        public void AddInternshipPeriod()
        {
            var internshipPeriod1 = TestData.ValidInternshipPeriod;
            
            _internshipPeriodRepository.Add(internshipPeriod1);
        }

        public void AddDepartmentalArchives()
        {
            var departmentalArchive1 = TestData.Archive1;
            var departmentalArchive2 = TestData.Archive2;

            _departementalArchivesRepository.Add(departmentalArchive1);
            _departementalArchivesRepository.Add(departmentalArchive2);
        }

        private static void EncryptPasswordBeforeAddingToDataBase(ApplicationUser user)
        {
            user.Password = Cryptography.Encrypt(user.Password);
        }
    }
}
