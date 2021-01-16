using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace JokeSender.Domain.EmailSender
{
    public class SmtpEmailSender : IEmailSender
    {
        private readonly SmtpEmailSenderConfiguration _configuration;
        private readonly SmtpClient _mailClient;

        public SmtpEmailSender(SmtpEmailSenderConfiguration configuration)
        {
            _configuration = configuration;

            _mailClient = new SmtpClient(_configuration.Host)
            {
                Credentials = new NetworkCredential(_configuration.UserName, _configuration.Password)
            };
        }

        public async Task SendMessageAsync(string email, string title, string message)
        {
            try
            {
                await _mailClient.SendMailAsync(new MailMessage(_configuration.SenderEmail, email, title, message));
            }
            catch (Exception ex)
            {
                throw new EmailSendFailedException($"Failed to send an email to '{email}'", ex);
            }
        }
    }
}
