using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Stagio.Web.ViewModels.Coordinator
{
    public class Index
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [DisplayName("Nom")]
        public string LastName { get; set; }

        [DisplayName("Prénom")]
        public string FirstName { get; set; }

        [DisplayName("Téléphone")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(10)]
        public string PhoneNumber { get; set; }

        [Display(Name = "Identifiant")]
        public string Identifier { get; set; }
    }
}