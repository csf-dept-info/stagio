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
        [DisplayName(WebMessage.UserInformation.LAST_NAME)]
        public String FirstName { get; set; }

        [Required]
        [DisplayName(WebMessage.UserInformation.FIRST_NAME)]
        public String LastName { get; set; }

        [DisplayName(WebMessage.UserInformation.PHONE_NUMBER)]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(WebMessage.RegularExpression.PHONE_NUMBER_FORMAT, ErrorMessage = WebMessage.ErrorMessage.INVALID_PHONE_NUMBER_FORMAT)]
        [StringLength(14)]
        public String PhoneNumber { get; set; }

        [DisplayName(WebMessage.UserInformation.EXTENSION_NUMBER)]
        public String ExtensionNumber { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = WebMessage.ErrorMessage.INVALID_EMAIL_FORMAT)]
        [Display(Name = WebMessage.GeneralMessage.EMAIL)]
        public String Identifier { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = WebMessage.ErrorMessage.INVALID_PASSWORD_LENGTH, MinimumLength = 8)]
        [ValidatePassword(ErrorMessage = WebMessage.ErrorMessage.INVALID_PASSWORD_FORMAT)]
        [DataType(DataType.Password)]
        [Display(Name = WebMessage.GeneralMessage.PASSWORD)]
        public String Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = WebMessage.GeneralMessage.CONFIRMATION)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = WebMessage.ErrorMessage.INVALID_PASSWORD_CORRESPONDENCE)]
        public string ConfirmPassword { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int CompanyId { get; set; }
    }
}