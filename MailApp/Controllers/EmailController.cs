using MailApp.AppSettings;
using MailApp.Model;
using MailApp.Services.EmailServices;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;

namespace MailApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailServices _emailServices;
        public EmailController(IEmailServices emailServices) => _emailServices = emailServices;
       
        [HttpPost]
        public IActionResult SendEmail(EmailDto request)
        {
           _emailServices.SendEmail(request);
            return Ok();


        }
    }
}
