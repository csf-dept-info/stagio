using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Stagio.Web.Custom_Annotations.AllUsers;

namespace Stagio.Web.ViewModels.Student
{
    public class CreateProfile
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [DisplayName("Courriel")]
        public string Identifier { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = WebMessage.ErrorMessage.INVALID_PASSWORD_LENGTH, MinimumLength = 8)]
        [ValidatePassword(ErrorMessage = WebMessage.ErrorMessage.INVALID_PASSWORD_FORMAT)]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmation")]
        [System.ComponentModel.DataAnnotations.CompareAttribute("NewPassword", ErrorMessage = WebMessage.ErrorMessage.INVALID_PASSWORD_CORRESPONDENCE)]
        public string ConfirmPassword { get; set; }

        [DisplayName("Nom")]
        public string LastName { get; set; }

        [DisplayName("Prénom")]
        public string FirstName { get; set; }

        [DisplayName("Téléphone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(WebMessage.RegularExpression.PHONE_NUMBER_FORMAT, ErrorMessage = WebMessage.ErrorMessage.INVALID_PHONE_NUMBER_FORMAT)]
        [StringLength(14)]
        public string PhoneNumber { get; set; }

        public string StudentId { get; set; }
    }
}