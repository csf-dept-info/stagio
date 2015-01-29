using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;

namespace Stagio.Web.ViewModels.Company
{
    public class ChooseCompany
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        public List<CompanyItem> CompaniesList { set; get; }

        [DisplayName("Votre entreprise est ...")]
        public int SelectedCompanyId { set; get; }
    }
}