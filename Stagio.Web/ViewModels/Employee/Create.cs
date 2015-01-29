using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Stagio.Web.Custom_Annotations.AllUsers;

namespace Stagio.Web.ViewModels.Employee
{
    public class Create
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [DisplayName("Nom")]
        public String FirstName { get; set; }

        [Required]
        [DisplayName("Prénom")]
        public String LastName { get; set; }

        [DisplayName("Téléphone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(WebMessage.RegularExpression.PHONE_NUMBER_FORMAT, ErrorMessage = WebMessage.ErrorMessage.INVALID_PHONE_NUMBER_FORMAT)]
        [StringLength(14)]
        public String PhoneNumber { get; set; }

        [DisplayName("Numéro de poste")]
        public String ExtensionNumber { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = WebMessage.ErrorMessage.INVALID_EMAIL_FORMAT)]
        [Display(Name = "Courriel")]
        public String Identifier { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = WebMessage.ErrorMessage.INVALID_PASSWORD_LENGTH, MinimumLength = 8)]
        [ValidatePassword(ErrorMessage = WebMessage.ErrorMessage.INVALID_PASSWORD_FORMAT)]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public String Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmation")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = WebMessage.ErrorMessage.INVALID_PASSWORD_CORRESPONDENCE)]
        public string ConfirmPassword { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int CompanyId { get; set; }
    }
}