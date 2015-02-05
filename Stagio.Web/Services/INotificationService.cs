using System.Net.Mail;
using Stagio.Domain.Entities;
using Stagio.Web.ViewModels.Email;

namespace Stagio.Web.Services
{
    public interface INotificationService
    {
        void NotifyNewInternshipOfferCreated(int internshipOfferAuthorId);
        void GroupNotification(UserRole role, string message, string linkControllerName, string linkMethodName);
    }
}
