using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Stagio.Web.ViewModels.Employee
{
    public class Index
    {
        [DisplayName(WebMessage.InternshipApplicationMessage.TOTAL_APPLICATIONS)]
        public int TotalApplicationsCount { get; set; }

        [DisplayName(WebMessage.InternshipOfferMessage.REFUSED_OFFERS_COMPLETE)]
        public int RefusedOffersCount { get; set; }

        [DisplayName(WebMessage.InternshipOfferMessage.OFFERS_ON_VALIDATION_COMPLETE)]
        public int OnValidationOffersCount { get; set; }

        [DisplayName(WebMessage.InternshipOfferMessage.PUBLICATED_OFFERS_COMPLETE)]
        public int PublishedOffersCount { get; set; }
    }
}