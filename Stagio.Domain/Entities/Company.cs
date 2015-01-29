using System.Collections.Generic;
using System.ComponentModel;

namespace Stagio.Domain.Entities
{
    public class Company : Entity
    {
        [DisplayName("Entreprise ou organisation")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<InternshipOffer> InternshipOffers { get; set; }

        public Company()
        {
            Employees = new List<Employee>();
            InternshipOffers = new List<InternshipOffer>();
        }
    }
}
