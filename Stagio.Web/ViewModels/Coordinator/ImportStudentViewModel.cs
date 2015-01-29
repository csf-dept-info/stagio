using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Stagio.Web.ViewModels.Coordinator
{
    public class ImportStudentViewModel
    {
        [Required]
        [DisplayName("Nom")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Prénom")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Matricule")]
        [StringLength(7, ErrorMessage = WebMessage.ErrorMessage.INVALID_IDENTIFIER_FORMAT)]
        public string Identifier { get; set; }                      

        [Required]
        public bool Renew { get; set; }
    }
}