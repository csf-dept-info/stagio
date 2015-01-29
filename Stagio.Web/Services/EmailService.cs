using System.Net.Mail;

namespace Stagio.Web.Services
{
    public class EmailService : IEmailService
    {

        public MailMessage BuildMail(string to, string from, string subject, string body)
        {
            var mail = new MailMessage(from, to) { Subject = subject, Body = body };

            return mail;
        }


        public void SendEmail(MailMessage mail)
        {
            var client = new SmtpClient("jenkinssmtp.cegep-ste-foy.qc.ca", 25)
            {DeliveryMethod = SmtpDeliveryMethod.Network, UseDefaultCredentials = false};

            client.Send(mail);
        }
    }
}