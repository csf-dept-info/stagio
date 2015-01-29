using System.Net.Mail;

namespace Stagio.Web.Services
{
    public interface IEmailService
    {
        MailMessage BuildMail(string to, string from, string subject, string body);

        void SendEmail(MailMessage mail);
    }
}
