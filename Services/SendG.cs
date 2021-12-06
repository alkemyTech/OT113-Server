using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface SendGInterface
    {
        Task SendEmailAsync(string ToEmail, string body, string subject);
    }
    public class SendG : SendGInterface
    {
        private IConfiguration _configuration;
        public SendG(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string ToEmail, string body, string subject)
        {
            try
            {
                string path = "../Core/Templates/htmlpage.html";
                string html = File.ReadAllText(path);
                html = html.Replace("{mail_title}", subject);
                html = html.Replace("{mail_body}", body);
                var apiKey = _configuration.GetSection("MailService:SendGridAPI").Value;
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress(_configuration.GetSection("MailService:VerifiedAPIMail").Value);
                var to = new EmailAddress(ToEmail);
                var msg = MailHelper.CreateSingleEmail(from, to, subject, "", html);
                var response = await client.SendEmailAsync(msg).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
