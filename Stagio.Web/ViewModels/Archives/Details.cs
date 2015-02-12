using System.Web.Mvc;
using Stagio.Domain.Entities;

namespace Stagio.Web.ViewModels.Archives
{
    public class Details
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        
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