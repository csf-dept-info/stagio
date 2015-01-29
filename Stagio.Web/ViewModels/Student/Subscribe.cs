using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DataAnnotationsExtensions;

namespace Stagio.Web.ViewModels.Student
{
    public class Subscribe
    {
        [Required]
        [DisplayName("Matricule")]
        [Integer(ErrorMessage = WebMessage.ErrorMessage.INVALID_IDENTIFIER_FORMAT)]
        public string StudentId { get; set; }
    }
}