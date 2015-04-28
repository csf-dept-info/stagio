using System.ComponentModel;
using System.Web.Mvc;

namespace Stagio.Web.ViewModels.Student
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
        public string PhoneNumber { get; set; }

        [DisplayName(WebMessage.UserInformation.ID)]
        public string Identifier { get; set; }
    }
}