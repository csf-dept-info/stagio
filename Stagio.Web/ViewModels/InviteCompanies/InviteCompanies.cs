using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Stagio.Web.ViewModels.InviteCompanies
{
    public class InviteCompanies
    {
        [Required]
        [DisplayName("Sujet")]
        public string Subject { get; set; }

        [Required]
        [DisplayName("Message")]
        public string Body { get; set; }
    }
}