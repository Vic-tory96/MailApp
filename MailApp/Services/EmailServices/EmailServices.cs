using MailApp.Model;
using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using MailApp.AppSettings;
using Microsoft.Extensions.Options;
using MailKit.Net.Smtp;

namespace MailApp.Services.EmailServices
{
    public class EmailServices : IEmailServices
    {
        private readonly EmailConfiguration _emailConfig;
        public EmailServices(IOptions<EmailConfiguration> emailConfig) => _emailConfig = emailConfig.Value;

        public void SendEmail(EmailDto request)
        {

            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_emailConfig.From));
            email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject = request.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = request.Body };

            using var smtp = new SmtpClient();
            smtp.Connect(_emailConfig.Host, _emailConfig.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_emailConfig.From, _emailConfig.Password);
            smtp.Send(email);
            smtp.Disconnect(true);

        }
    }
}
