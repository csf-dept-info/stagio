using System.ComponentModel;
using System.Web.Mvc;

namespace Stagio.Web.ViewModels.Company
{
    public class CompanyItem
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [DisplayName(WebMessage.CompanyMessage.NAME)]
        public string Name { get; set; }
    }
}