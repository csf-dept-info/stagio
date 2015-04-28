using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Stagio.Web.ViewModels.InternshipOffer
{
    public class OfferDetails
    {   
        [Required]
        [DisplayName(WebMessage.InternshipOfferMessage.OfferDetails.REQUIRED_SOFTWARE_HARDWARE)]
        public string SpecificHardwareAndSoftware { get; set; }

        [Required]
        [DisplayName(WebMessage.InternshipOfferMessage.OfferDetails.REQUIRED_SCHEDULE)]
        public string WorkingHours { get; set; }

        [Required]
        [DisplayName(WebMessage.InternshipOfferMessage.OfferDetails.REQUIRED_HOURS_PER_WEEK)]
        public string HoursPerWeek { get; set; }

        [Required]
        [DisplayName(WebMessage.InternshipOfferMessage.OfferDetails.REQUIRED_WAGE)]
        public string HourlyWage { get; set; }
    }
}