using System.Collections.Generic;
using Stagio.Domain.Entities;

namespace Stagio.Web.Services
{
    public interface IArchivesService
    {
        void CreateArchive(InternshipPeriod period);

        int GetStudentsCount();

        int GetStudentsWithInternshipCount();

        int GetInternshipApplicationsCount();

        int GetCompanyOffersCount();

        int GetInterviewsCount();

        int GetEmployeesCount();

        int GetCompaniesCount();

        int GetPublicatedIntershipOffersCount();

        IEnumerable<DepartmentalArchives> GetArchives();

        DepartmentalArchives GetArchiveById(int id);
    }
}