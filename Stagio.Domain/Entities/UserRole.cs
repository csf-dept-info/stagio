
namespace Stagio.Domain.Entities
{
    public class UserRole : Entity
    {
        public string RoleName { get; set; }

        // Foreign key
        public int ApplicationUserId { get; set; }

        // Navigation properties
        public ApplicationUser ApplicationUsers { get; set; }

    }
}