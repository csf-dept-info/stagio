using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Stagio.Web.ViewModels.InviteCompanies
{
    public class InviteCompanies
    {
        [Required]
        [DisplayName(WebMessage.CoordinatorMessage.InviteCompanies.OBJECT)]
        public string Subject { get; set; }

        [Required]
        [DisplayName(WebMessage.CoordinatorMessage.InviteCompanies.MESSAGE)]
        public string Body { get; set; }
    }
}