using System.ComponentModel;
using System.Web.Mvc;

namespace Stagio.Web.ViewModels.Email
{
    public class SendEmail
    {
        [HiddenInput(DisplayValue = false)]
        public int OfferId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string To { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string From { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string Subject { get; set; }

        [DisplayName("Message")]
        public string Body { get; set; }
    }
}