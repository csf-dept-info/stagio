using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Stagio.Web.ViewModels.Coordinator
{
    public class Index
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [DisplayName(WebMessage.UserInformation.LAST_NAME)]
        public string LastName { get; set; }

        [DisplayName(WebMessage.UserInformation.FIRST_NAME)]
        public string FirstName { get; set; }

        [DisplayName(WebMessage.UserInformation.PHONE_NUMBER)]
        [DataType(DataType.PhoneNumber)]
        [StringLength(10)]
        public string PhoneNumber { get; set; }

        [Display(Name = WebMessage.UserInformation.ID)]
        public string Identifier { get; set; }
    }
}