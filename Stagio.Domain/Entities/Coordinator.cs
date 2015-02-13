
namespace Stagio.Domain.Entities
{
    public class Coordinator : ApplicationUser
    {
        public string FullName()
        {
            return this.FirstName + " " + this.LastName;
        }
    }
}
