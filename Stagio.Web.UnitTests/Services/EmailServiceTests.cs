using System;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.Web.Services;
using Stagio.Web.ViewModels.Email;

namespace Stagio.Web.UnitTests.Services
{
    [TestClass]
    public class EmailServiceTests
    {
        public IEmailService _emailService;


        [TestInitialize]
        public void Initialize()
        {
            _emailService = new EmailService();
        }

        [TestMethod]
        public void build_mail_should_create_a_mail_with_proper_details()
        {
            var sendEmail = BuildSendEmail();
            var mail = _emailService.BuildMail(sendEmail.To, sendEmail.From, sendEmail.Subject, sendEmail.Body);

            mail.Subject.ShouldBeEquivalentTo(sendEmail.Subject);
            mail.Body.ShouldBeEquivalentTo(sendEmail.Body);
            mail.From.Address.ShouldBeEquivalentTo(sendEmail.From);
            mail.To.First().Address.ShouldBeEquivalentTo(sendEmail.To);
        }

        [TestMethod]
        public void send_email_should_send_the_specified_mail_without_error()
        {
            var sendEmail = BuildSendEmail();
            var mail = _emailService.BuildMail(sendEmail.To, sendEmail.From, sendEmail.Subject, sendEmail.Body);
            var success = true;

            try
            {
                _emailService.SendEmail(mail);
            }
            catch (Exception)
            {
                success = false;
            }

            success.Should().BeTrue();
        }

        private static SendEmail BuildSendEmail()
        {
            const string PLACEHOLDER_SUBJECT = "test";
            const string PLACEHOLDER_BODY = "test123";
            const string PLACEHOLDER_FROM = "test123@test.com";
            const string PLACEHOLDER_TO = "test987@test.ca";

            var sendEmail = new SendEmail
            {
                Subject = PLACEHOLDER_SUBJECT,
                Body = PLACEHOLDER_BODY,
                From = PLACEHOLDER_FROM,
                To = PLACEHOLDER_TO
            };

            return sendEmail;
        }
    }
}
