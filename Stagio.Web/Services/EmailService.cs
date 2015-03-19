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

            if (environment == "dev")
            {
                var client = new SmtpClient("jenkinssmtp.cegep-ste-foy.qc.ca", 25)
                {
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false
                };

                client.Send(mail);
            }
            else if (environment == "prod")
            {
                var username = ConfigurationManager.AppSettings["mailAccountSendGrid"];    
                var pswd = ConfigurationManager.AppSettings["mailPasswordSenGrid"]; 

                var credentials = new NetworkCredential(username, pswd);

                SendGridMessage myMessage = new SendGridMessage();
                myMessage.AddTo(mail.To.ToString());
                myMessage.From = new MailAddress(mail.From.ToString(), "Coordonateur de stages");
                myMessage.Subject = mail.Subject.ToString();
                myMessage.Text = mail.Body.ToString();

                var transportWeb = new SendGrid.Web(credentials);

                transportWeb.Deliver(myMessage);
            }
            else
            {
                throw new Exception("L'environment doit être prod ou dev. Voir <appSettings> dans Web.Config.");
            }

        }
    }
}
