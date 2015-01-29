using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stagio.Domain.Entities
{
    public class InternshipOfferDetails
    {
        public string SpecificHardwareAndSoftware { get; set; }
        public string WorkingHours { get; set; }
        public string HoursPerWeek { get; set; }
        public string HourlyWage { get; set; }

        [Key]
        [ForeignKey("InternshipOffer")]
        public int InternshipOfferId { get; set; }
        public virtual InternshipOffer InternshipOffer { get; set; }
        
    }
}
