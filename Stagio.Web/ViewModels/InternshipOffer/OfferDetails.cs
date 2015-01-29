using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Stagio.Web.ViewModels.InternshipOffer
{
    public class OfferDetails
    {   
        [Required]
        [DisplayName("Environnement matériel et logiciel *")]
        public string SpecificHardwareAndSoftware { get; set; }

        [Required]
        [DisplayName("Horaire de travail *")]
        public string WorkingHours { get; set; }

        [Required]
        [DisplayName("Nombre d'heures de travail par semaine *")]
        public string HoursPerWeek { get; set; }

        [Required]
        [DisplayName("Salaire horaire *")]
        public string HourlyWage { get; set; }
    }
}