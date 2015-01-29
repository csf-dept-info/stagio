using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Stagio.Web.ViewModels.InternshipOffer
{
    public class StaffMember
    {
        [Required]
        [DisplayName("Nom complet")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Titre / Fonction")]
        public string Title { get; set; }

        [Required]
        [DisplayName("Téléphone")]
        public string PhoneNumber { get; set; }

        [Required]
        [DisplayName("Courriel")]
        public string Email { get; set; }
    }
}