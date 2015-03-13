using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Stagio.Web.ViewModels.InternshipOffer
{
    public class StaffMember
    {
        [Required]
        [DisplayName(WebMessage.UserInformation.COMPLETE_NAME)]
        public string Name { get; set; }

        [Required]
        [DisplayName(WebMessage.UserInformation.FUNCTION)]
        public string Title { get; set; }

        [Required]
        [DisplayName(WebMessage.UserInformation.PHONE_NUMBER)]
        public string PhoneNumber { get; set; }

        [Required]
        [DisplayName(WebMessage.GeneralMessage.EMAIL)]
        public string Email { get; set; }
    }
}