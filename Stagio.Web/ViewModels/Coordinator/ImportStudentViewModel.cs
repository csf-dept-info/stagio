using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Stagio.Web.ViewModels.Coordinator
{
    public class ImportStudentViewModel
    {
        [Required]
        [DisplayName(WebMessage.UserInformation.LAST_NAME)]
        public string LastName { get; set; }

        [Required]
        [DisplayName(WebMessage.UserInformation.FIRST_NAME)]
        public string FirstName { get; set; }

        [Required]
        [DisplayName(WebMessage.UserInformation.IDENTIFIER)]
        [StringLength(7, ErrorMessage = WebMessage.ErrorMessage.INVALID_IDENTIFIER_FORMAT)]
        public string Identifier { get; set; }                      

        [Required]
        public bool Renew { get; set; }
    }
}