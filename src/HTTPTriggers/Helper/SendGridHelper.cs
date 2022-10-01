using SendGrid.Helpers.Mail;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Services.AppAuthentication;

namespace HTTPTriggers.Helper
{
    public class SendGridHelper
    {
        public static async Task<bool> Execute()
        {

            var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
            var emailAddess = Environment.GetEnvironmentVariable("SENDGRID_EMAIL_ADDRESS");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(emailAddess, "Example User");
            var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress(emailAddess, "Example User");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
