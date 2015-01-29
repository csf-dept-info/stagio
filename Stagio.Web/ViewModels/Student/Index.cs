using System.ComponentModel;
using System.Web.Mvc;

namespace Stagio.Web.ViewModels.Student
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
        public string PhoneNumber { get; set; }

        [DisplayName("Identifiant")]
        public string Identifier { get; set; }
    }
}