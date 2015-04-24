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
        [DisplayName(WebMessage.GeneralMessage.EMAIL)]
        public string Identifier { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = WebMessage.ErrorMessage.INVALID_PASSWORD_LENGTH, MinimumLength = 8)]
        [ValidatePassword(ErrorMessage = WebMessage.ErrorMessage.INVALID_PASSWORD_FORMAT)]
        [DataType(DataType.Password)]
        [Display(Name = WebMessage.GeneralMessage.PASSWORD)]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = WebMessage.GeneralMessage.CONFIRMATION)]
        [System.ComponentModel.DataAnnotations.CompareAttribute("NewPassword", ErrorMessage = WebMessage.ErrorMessage.INVALID_PASSWORD_CORRESPONDENCE)]
        public string ConfirmPassword { get; set; }

        [DisplayName(WebMessage.UserInformation.LAST_NAME)]
        public string LastName { get; set; }

        [DisplayName(WebMessage.UserInformation.FIRST_NAME)]
        public string FirstName { get; set; }

        [DisplayName(WebMessage.UserInformation.PHONE_NUMBER)]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(WebMessage.RegularExpression.PHONE_NUMBER_FORMAT, ErrorMessage = WebMessage.ErrorMessage.INVALID_PHONE_NUMBER_FORMAT)]
        [StringLength(14)]
        public string PhoneNumber { get; set; }

        public string StudentId { get; set; }
    }
}