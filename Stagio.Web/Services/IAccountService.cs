using System;
using Stagio.Domain.Application;
using Stagio.Domain.Entities;

namespace Stagio.Web.Services
{
    public interface IAccountService
    {
        MayBe<ApplicationUser> ValidateUser(string email, string password);

        string HashPassword(string password);

        bool UserIdentifierExist(string email);

        ApplicationUser GetStudentByStudentId(string identifier);

        bool StudentExist(string studentId);   
    }
}