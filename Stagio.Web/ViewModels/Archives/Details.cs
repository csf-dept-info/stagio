using System.ComponentModel;
using System.Web.Mvc;
using Stagio.Domain.Entities;

namespace Stagio.Web.ViewModels.Archives
{
    public class Details
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [DisplayName(WebMessage.InternshipPeriodMessage.STUDENTS_COUNT)]
        public int StudentsCount { get; set; }

        [DisplayName(WebMessage.InternshipPeriodMessage.STUDENTS_WITH_INTERNSHIP_COUNT)]
        public int StudentsWithInternship { get; set; }

        [DisplayName(WebMessage.InternshipPeriodMessage.EMPLOYEES_COUNT)]
        public int EmployeesCount { get; set; }

        [DisplayName(WebMessage.InternshipPeriodMessage.COMPANIES_COUNT)]
        public int CompaniesCount { get; set; }

        [DisplayName(WebMessage.InternshipPeriodMessage.INTERNSHIP_OFFERS_COUNT)]
        public int InternshipOffersCount { get; set; }

        public InternshipPeriod InternshipPeriod { get; set; }

        [DisplayName(WebMessage.InternshipPeriodMessage.INTERVIEWS_COUNT)]
        public int InterviewsCount { get; set; }

        [DisplayName(WebMessage.InternshipPeriodMessage.INTERNSHIP_APPLICATIONS_COUNT)]
        public int InternshipApplicationsCount { get; set; }

        [DisplayName(WebMessage.InternshipPeriodMessage.COMPANY_OFFERS_COUNT)]
        public int CompanyOffersCount { get; set; }
    }
}