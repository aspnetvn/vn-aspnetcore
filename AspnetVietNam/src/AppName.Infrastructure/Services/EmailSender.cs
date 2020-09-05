using AppName.Core.Configuration;
using AppName.Infrastructure.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace AppName.Infrastructure.Services
{
    public class EmailSender : IEmailSender
    {
        // How send email with smtp from your domain
        // https://docs.paywhirl.com/en/articles/22023-how-to-send-email-from-your-own-domain-using-smtp
        // source from here: https://www.c-sharpcorner.com/article/sending-email-using-c-sharp/

        private readonly ILogger _logger;
        private readonly EmailSettings _emailSettings;
       
        public EmailSender(
            IOptions<EmailSettings> emailSettings,
            ILoggerFactory logger)
        {
            _logger = logger.CreateLogger<EmailSettings>();
            _emailSettings = emailSettings.Value;
        }
        public Task SendEmailAsync(string addressEmail, string subject, string message)
        {
            // TODO: Wire this up to actual email sending logic via SendGrid, local SMTP, etc.
            MailMessage mailMessage = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            try
            {
                mailMessage.From = new MailAddress(_emailSettings.YourEmail, "AspnetVietNam"); // FromMailAddress
                mailMessage.To.Add(new MailAddress(addressEmail, addressEmail)); // ToMailAddress
                mailMessage.Subject = subject;
                mailMessage.IsBodyHtml = true; //to make message body as html  
                mailMessage.Body = $"<div>{mailMessage}</div>";
                smtp.Port = _emailSettings.SmtpSettings.Gmail.PortNumber;
                smtp.Host = _emailSettings.SmtpSettings.Gmail.Host; // for gmail host  
                smtp.EnableSsl = _emailSettings.SmtpSettings.Gmail.EnabledSsl;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(_emailSettings.YourEmail, _emailSettings.YourEmailPassWord);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                return smtp.SendMailAsync(mailMessage);
            }
            
            catch (Exception ex) {
                _logger.LogError(ex.Message);
                return Task.CompletedTask; 
            }
        }

        private void Smtp_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
