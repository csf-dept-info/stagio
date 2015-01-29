using System;
using System.Collections.Generic;
using System.Linq;
using Stagio.DataLayer;
using Stagio.Domain.Entities;

namespace Stagio.Web.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEntityRepository<Employee> _employeeRepository;
        private readonly IEntityRepository<InternshipApplication> _internshipApplicationRepository;
        private readonly IEntityRepository<InternshipOffer> _internshipOfferRepository;

        public EmployeeService(
            IEntityRepository<Employee> employeeRepository,
            IEntityRepository<InternshipApplication> internshipApplicationRepository,
            IEntityRepository<InternshipOffer> internshipOfferRepository)
        {
            DependencyService.VerifyDependencies(employeeRepository, internshipApplicationRepository, internshipApplicationRepository);
            _employeeRepository = employeeRepository;
            _internshipApplicationRepository = internshipApplicationRepository;
            _internshipOfferRepository = internshipOfferRepository;
        }

        public int FetchTotalNumberOfApplications(int employeeID)
        {
            var internshipOffers = this.GetInternshipOffersForEmployee(employeeID);
            var internshipApplications = _internshipApplicationRepository.GetAll();

            var totalNumberOfApplications = internshipOffers.Join(internshipApplications,
                    c => c.Id,
                    cm => cm.InternshipOfferId,
                    (c, cm) => new { Offer = c, application = cm })
                    .Select(x => x.Offer).Count();

            return totalNumberOfApplications;
        }

        public int FetchTotalNumberOfRefusedOffers(int employeeID)
        {
            var offersCount = this.GetInternshipOffersForEmployee(employeeID)
                .Where(offer => offer.Status == InternshipOffer.OfferStatus.Refused)
                .Count();

            return offersCount;
        }

        public int FetchTotalNumberOfOnValidationOffers(int employeeID)
        {
            var offersCount = this.GetInternshipOffersForEmployee(employeeID)
                .Where(offer => offer.Status == InternshipOffer.OfferStatus.OnValidation)
                .Count();

            return offersCount;
        }

        public int FetchTotalNumberOfPublishedOffers(int employeeID)
        {
            var offersCount = this.GetInternshipOffersForEmployee(employeeID)
                .Where(offer => offer.Status == InternshipOffer.OfferStatus.Publicated)
                .Count();

            return offersCount;
        }

        private List<InternshipOffer> GetInternshipOffersForEmployee(int employeeID)
        {
            var employee = _employeeRepository.GetById(employeeID);

            var internshipOffers = _internshipOfferRepository.GetAll();
            internshipOffers = internshipOffers.Where(offer => offer.CompanyId == employee.CompanyId);

            return internshipOffers.ToList();
        }
    }
}