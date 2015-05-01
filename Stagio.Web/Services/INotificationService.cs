using System.Net.Mail;
using Stagio.Domain.Entities;
using Stagio.Web.ViewModels.Email;

namespace Stagio.Web.Services
{
    public interface INotificationService
    {
        void NotifyNewInternshipOfferCreated(int internshipOfferAuthorId);
        void RoleGroupNotification(string roleName, string message, string linkControllerName, string linkMethodName);
        void CompanyNotification(Company company, string message, string linkControllerName, string linkMethodName);
        void NewCompanyJoinedStagio(Company company, string message, string linkControllerName, string linkMethodName);
    }
}
