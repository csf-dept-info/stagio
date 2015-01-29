using System.Linq;
using Stagio.DataLayer;
using Stagio.Domain.Application;
using Stagio.Domain.Entities;
using Stagio.Domain.SecurityUtilities;

namespace Stagio.Web.Services
{
    public class AccountService : IAccountService
    {
        private readonly IEntityRepository<ApplicationUser> _userRepository;
        private readonly IEntityRepository<Student> _studentRepository;

        public AccountService(IEntityRepository<ApplicationUser> userRepository, IEntityRepository<Student> studentRepository)
        {
            _userRepository = userRepository;
            _studentRepository = studentRepository;
        }

        public MayBe<ApplicationUser> ValidateUser(string identifier, string password)
        {
            var user = _userRepository.GetAll().FirstOrDefault(x => x.Identifier == identifier);

            if (user == null)
            {
                return new MayBe<ApplicationUser>();
            }
            if (user.Password != HashPassword(password))
            {
                return new MayBe<ApplicationUser>();
            }

            return new MayBe<ApplicationUser>(user);
        }


        public string HashPassword(string password)
        {
            return Cryptography.Encrypt(password);
        }

        //Todo YM: non testé
        public bool UserIdentifierExist(string identifier)
        {
            var user = _userRepository.GetAll().FirstOrDefault(x => x.Identifier == identifier);

            return user != null;
        }

        public ApplicationUser GetStudentByStudentId(string studentId)
        {
            return _studentRepository.GetAll().FirstOrDefault(x => x.StudentId == studentId);
        }

        public bool StudentExist(string studentId)
        {
            var student = _studentRepository.GetAll().FirstOrDefault(x => x.StudentId == studentId);
            return student != null;
        }

        public static bool VerifyPassword(string storedPassword, string sentPassword)
        {
            return (storedPassword == Cryptography.Encrypt(sentPassword));
        }

    }
}