using System;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace DomainModelTests
{
    class Program
    {
            static void Main()
            {
                Execute().Wait();
            }

            static async Task <Response> Execute()
            {
                var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress("evenvagen@hotmail.com");
                var subject = "Sending with SendGrid is Fun";
                var to = new EmailAddress("evenvagen@gmail.com");
                var plainTextContent = "and easy to do anywhere, even with C#";
                var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                var response = await client.SendEmailAsync(msg);
                return response;
            }
        }
    }


