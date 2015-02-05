using System;

namespace Stagio.Domain.Entities
{
    public class DepartmentalArchives : Entity
    {
        public int StudentsCount { get; set; }

        public int StudentsWithInternship { get; set; }

        public int EmployeesCount { get; set; }

        public int CompaniesCount { get; set; }

        public int InternshipOffersCount { get; set; }

        public InternshipPeriod InternshipPeriod { get; set; }

        public int InterviewsCount { get; set; }

        public int InternshipApplicationsCount { get; set; }

        public int CompanyOffersCount { get; set; }
    }
}
