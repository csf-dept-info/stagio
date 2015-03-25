using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using SendGrid;

namespace Stagio.Web.Services
{
    public class EmailService : IEmailService
    {

        public MailMessage BuildMail(string to, string from, string subject, string body)
        {
            var mail = new MailMessage(from, to)
            {
                Subject = subject, 
                Body = body
            };

            return mail;
        }


        public void SendEmail(MailMessage mail)
        {
            var environment = ConfigurationManager.AppSettings["environment"];
            
            if (environment == "prod")
            {
                var accountSendGrid = ConfigurationManager.AppSettings["mailAccountSendGrid"];
                var passwordSendGrid = ConfigurationManager.AppSettings["mailPasswordSenGrid"];
                var credentials = new NetworkCredential(accountSendGrid, passwordSendGrid);
                var transportWeb = new SendGrid.Web(credentials);

                SendGridMessage myMessage = new SendGridMessage();
                myMessage.AddTo(mail.To.ToString());
                myMessage.From = new MailAddress(mail.From.ToString(), "Coordonateur de stages");
                myMessage.Subject = mail.Subject.ToString();
                myMessage.Text = mail.Body.ToString();

                transportWeb.Deliver(myMessage);
            }
            else
            {
                var client = new SmtpClient("jenkinssmtp.cegep-ste-foy.qc.ca", 25)
                {
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false
                };

                client.Send(mail);
            }

        }
    }
}
