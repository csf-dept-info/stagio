using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Stagio.Web.Custom_Annotations.AllUsers;

namespace Stagio.Web.ViewModels.Employee
{
    public class Edit
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [DisplayName("Nom")]
        public string LastName { get; set; }

        [DisplayName("Prénom")]
        public string FirstName { get; set; }

        [DisplayName("Téléphone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(WebMessage.RegularExpression.PHONE_NUMBER_FORMAT, ErrorMessage = WebMessage.ErrorMessage.INVALID_PHONE_NUMBER_FORMAT)]
        [StringLength(14)]
        public string PhoneNumber { get; set; }

        [DisplayName("Poste")]
        [Range(0, int.MaxValue, ErrorMessage = WebMessage.ErrorMessage.INVALID_EXTENSION_NUMBER_FORMAT)]
        public string ExtensionNumber { get; set; }

        [DisplayName("Mot de passe actuel")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [StringLength(100, ErrorMessage = WebMessage.ErrorMessage.INVALID_PASSWORD_LENGTH, MinimumLength = 8)]
        [ValidatePassword(ErrorMessage = WebMessage.ErrorMessage.INVALID_PASSWORD_FORMAT)]
        [DataType(DataType.Password)]
        [Display(Name = "Nouveau mot de passe")]
        public string NewPassword { get; set; }

        [Display(Name = "Confirmation")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.CompareAttribute("NewPassword", ErrorMessage = WebMessage.ErrorMessage.INVALID_PASSWORD_CORRESPONDENCE)]
        public string ConfirmPassword { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int CompanyId { get; set; }

        [EmailAddress(ErrorMessage = WebMessage.ErrorMessage.INVALID_EMAIL_FORMAT)]
        [Display(Name = "Courriel")]
        public string Identifier { get; set; }
    }
}