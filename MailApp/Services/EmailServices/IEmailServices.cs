using MailApp.Model;

namespace MailApp.Services.EmailServices
{
    public interface IEmailServices
    {
        void SendEmail(EmailDto reqest);
    }
}
