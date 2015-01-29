using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Stagio.Web.ViewModels.Employee
{
    public class Index
    {
        [DisplayName("Candidatures au total")]
        public int TotalApplicationsCount { get; set; }

        [DisplayName("Offres refusées")]
        public int RefusedOffersCount { get; set; }

        [DisplayName("Offres en validation")]
        public int OnValidationOffersCount { get; set; }

        [DisplayName("Offres publiées")]
        public int PublishedOffersCount { get; set; }
    }
}