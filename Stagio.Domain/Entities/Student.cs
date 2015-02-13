
namespace Stagio.Domain.Entities
{
    public class Student : ApplicationUser
    {
        public bool Active { get; set; }  //TODO verifier "active" au login

        public string StudentId { get; set; }

        public string FullName()
        {
            return this.FirstName + " " + this.LastName;
        }
    }
}
