using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stagio.Domain.Entities
{
    public class Employee : ApplicationUser
    {
        public string ExtensionNumber { get; set; }

        [Key]
        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public string FullName()
        {
            return this.FirstName + " " + this.LastName;
        }

        public string FullPhoneNumber()
        {
            return this.PhoneNumber + " (poste " + this.ExtensionNumber + ")";
        }
    }
}
