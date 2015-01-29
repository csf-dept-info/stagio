using System.ComponentModel;

namespace Stagio.Web.ViewModels.InternshipOffer
{
    public class DisplayOfferDetails
    {   
        [DisplayName("Environnement matériel et logiciel")]
        public string SpecificHardwareAndSoftware { get; set; }

        [DisplayName("Horaire de travail")]
        public string WorkingHours { get; set; }

        [DisplayName("Nombre d'heures de travail par semaine")]
        public string HoursPerWeek { get; set; }

        [DisplayName("Salaire horaire")]
        public string HourlyWage { get; set; }
    }
}