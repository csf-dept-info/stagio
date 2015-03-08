using System.Collections.Generic;
using System.Linq;
using Stagio.DataLayer;
using Stagio.Domain.Entities;

namespace Stagio.Web.Services
{
    public class ArchivesService : IArchivesService
    {
        private readonly IEntityRepository<Student> _studentRepository;
        private readonly IEntityRepository<DepartmentalArchives> _archivesRepository; 
        private readonly IEntityRepository<Employee> _employeeRepository;
        private readonly IEntityRepository<Company> _companyRepository;
        private readonly IEntityRepository<InternshipOffer> _internshipOfferRepository;
        private readonly List<InternshipApplication> _internshipApplicationsList;

        public ArchivesService(IEntityRepository<Student> studentRepository,
                               IEntityRepository<DepartmentalArchives> archivesRepository,
                               IEntityRepository<Employee> employeeRepository,
                               IEntityRepository<InternshipApplication> intershipApplicationRepository,
                               IEntityRepository<Company> companyRepository,
                               IEntityRepository<InternshipOffer> internshipOfferRepository)
        {
            _studentRepository = studentRepository;
            _archivesRepository = archivesRepository;
            _employeeRepository = employeeRepository;
            _companyRepository = companyRepository;
            _internshipOfferRepository = internshipOfferRepository;
            _internshipApplicationsList = intershipApplicationRepository.GetAll().ToList();
        }

        public void CreateArchive(InternshipPeriod period)
        {
            var archive = new DepartmentalArchives
            {
                InternshipPeriod = period,
                CompaniesCount = GetCompaniesCount(),
                CompanyOffersCount = GetCompanyOffersCount(),
                EmployeesCount = GetEmployeesCount(),
                InternshipApplicationsCount = GetInternshipApplicationsCount(),
                InternshipOffersCount = GetIntershipOffersCount(),
                InterviewsCount = GetInterviewsCount(),
                StudentsCount = GetStudentsCount(),
                StudentsWithInternship = GetStudentsWithInternshipCount()
            };

            _archivesRepository.Add(archive);
        }



        public int GetStudentsCount()
        {
            return _studentRepository.GetAll().Count();
        }

        public int GetInternshipApplicationsCount()
        {
            return _internshipApplicationsList.Count();
        }

        public int GetStudentsWithInternshipCount()
        {
            return _internshipApplicationsList.Count(x => x.Progression == InternshipApplication.ApplicationStatus.StudentAcceptedOffer);
        }

        public int GetCompanyOffersCount()
        {
            return _internshipApplicationsList.Count(x => x.Progression == InternshipApplication.ApplicationStatus.CompanyAcceptedStudent) + GetStudentsWithInternshipCount();
        }

        public int GetInterviewsCount()
        {
            return _internshipApplicationsList.Count(x => x.Progression == InternshipApplication.ApplicationStatus.StudentHadInterview) + GetCompanyOffersCount();
        }

        public int GetEmployeesCount()
        {
            return _employeeRepository.GetAll().Count();
        }

        public int GetCompaniesCount()
        {
            return _companyRepository.GetAll().Count();
        }

        public int GetIntershipOffersCount()
        {
            return _internshipOfferRepository.GetAll().Count();
        }

        public IEnumerable<DepartmentalArchives> GetArchives()
        {
            return _archivesRepository.GetAll().ToList();
        }

        public DepartmentalArchives GetArchiveById(int id)
        {
            return _archivesRepository.GetById(id);
        }
    }
}