using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Stagio.Domain.Entities
{
    public class ApplicationUser : Entity
    {
        public ApplicationUser()
        {
            Roles = new List<UserRole>();
        }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Identifier { get; set; }

        public string PhoneNumber { get; set; }

        //Navigation properties
        public virtual ICollection<UserRole> Roles { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }

    }
}