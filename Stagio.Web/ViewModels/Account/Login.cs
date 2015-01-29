using System.ComponentModel.DataAnnotations;

namespace Stagio.Web.ViewModels.Account
{
    public class Login
    {
        [Required(ErrorMessage = WebMessage.RequiredFieldMessage.REQUIRED_IDENTIFIER)]
        public string Identifier { get; set; }

        [Required(ErrorMessage = WebMessage.RequiredFieldMessage.REQUIRED_PASSWORD)]
        public string Password { get; set; }
    }
}