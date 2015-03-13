using System.ComponentModel;

namespace Stagio.Web.ViewModels.InternshipOffer
{
    public class DisplayOfferDetails
    {   
        [DisplayName(WebMessage.InternshipOfferMessage.OfferDetails.SOFTWARE_HARDWARE]
        public string SpecificHardwareAndSoftware { get; set; }

        [DisplayName(WebMessage.InternshipOfferMessage.OfferDetails.SCHEDULE)]
        public string WorkingHours { get; set; }

        [DisplayName(WebMessage.InternshipOfferMessage.OfferDetails.HOURS_PER_WEEK)]
        public string HoursPerWeek { get; set; }

        [DisplayName(WebMessage.InternshipOfferMessage.OfferDetails.WAGE)]
        public string HourlyWage { get; set; }
    }
}