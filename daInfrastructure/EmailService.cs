using System;
using System.Threading.Tasks;
using DomainModel.Core;
using DomainServices.Core;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace daInfrastructure
{
    public class EmailService : IEmailService
    {
        public async Task<bool> Send(Email email)
        {

            var client = new SendGridClient("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");
            var from = new EmailAddress(email.From);
            var subject = "Bekreft nyhetsbrev-abonnent!";
            var to = new EmailAddress(email.To);
            var plainTextContent = "Email subscription";
            var htmlContent = email.Text;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
            return true;
        }
    }
}
