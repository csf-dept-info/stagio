using System.Collections.Generic;
using System.Linq;
using Stagio.DataLayer;
using Stagio.Domain.Entities;

namespace Stagio.Web.Services
{
    public class ArchiveService : IArchiveService
    {
        private readonly IEntityRepository<Student> _studentRepository;
        private readonly IEntityRepository<Employee> _employeeRepository;
        private readonly IEntityRepository<InternshipApplication> _internshipApplicationRepository;
        private readonly IEntityRepository<Company> _companyRepository;
        private readonly IEntityRepository<InternshipOffer> _internshipOfferRepository;
        private readonly IEntityRepository<InternshipPeriod> _internshipPeriodRepository;
        private readonly List<InternshipApplication> _internshipApplicationsList;
        private readonly int companyAcceptedStudentCount;
        private readonly int studentAcceptedOfferCount;

        public ArchiveService(IEntityRepository<Student> studentRepository,
                              IEntityRepository<Employee> employeeRepository,
                              IEntityRepository<InternshipApplication> intershipApplicationRepository,
                              IEntityRepository<Company> companyRepository,
                              IEntityRepository<InternshipOffer> internshipOfferRepository,
                              IEntityRepository<InternshipPeriod> internshipPeriodRepository)
        {
            _studentRepository = studentRepository;
            _employeeRepository = employeeRepository;
            _internshipApplicationRepository = intershipApplicationRepository;
            _companyRepository = companyRepository;
            _internshipOfferRepository = internshipOfferRepository;
            _internshipPeriodRepository = internshipPeriodRepository;
            _internshipApplicationsList = _internshipApplicationRepository.GetAll().ToList();
            studentAcceptedOfferCount = _internshipApplicationsList.Count(x => x.Progression == InternshipApplication.ApplicationStatus.StudentAcceptedOffer);
            companyAcceptedStudentCount = _internshipApplicationsList.Count(x => x.Progression == InternshipApplication.ApplicationStatus.CompanyAcceptedStudent);
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
            return studentAcceptedOfferCount;
        }

        public int GetCompanyOffersCount()
        {
            return companyAcceptedStudentCount + studentAcceptedOfferCount;
        }

        public int GetInterviewsCount()
        {
            
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

        public InternshipPeriod GetLastInternshipPeriod()
        {
            var internshipPeriodsList = _internshipPeriodRepository.GetAll().ToList();
            if (internshipPeriodsList.Count < 1)
            {
                return internshipPeriodsList.Last();
            }
            return null;
        }


    }
}