using HotelProject.WebUI.Models.Mail;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Org.BouncyCastle.Crypto.Macs;
using System.Net.Mail;

namespace HotelProject.WebUI.Controllers
{
    public class AdminMailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(AdminMailViewModel adminMailViewModel)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("Hotelier Admin", "bedava452@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress(adminMailViewModel.RecieverName, adminMailViewModel.RecieverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = adminMailViewModel.Message;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = adminMailViewModel.Subject;

            MailKit.Net.Smtp.SmtpClient smtpClient = new MailKit.Net.Smtp.SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("bedava452@gmail.com", "wkvjtmkqxgxuamjr");
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);
            return View();
        }
    }
}
