using HotelProject.WebUI.Dtos.ContactDto;
using HotelProject.WebUI.Dtos.SendMessageDto;
using HotelProject.WebUI.Models.Mail;
using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class AdminContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Inbox()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5150/api/Contact");

            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("http://localhost:5150/api/Contact/GetContactCount");

            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("http://localhost:5150/api/SendMessage/GetSendMessageCount");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<InboxContactDto>>(jsonData);

                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                ViewBag.contactCount = jsonData2;

                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                ViewBag.sendMessageCount = jsonData3;

                return View(values);
            }
            return View();
        }

        public PartialViewResult SideBarAdminContactPartial()
        {
            return PartialView();
        }

        public PartialViewResult SideBarAdminContactCategoryPartial()
        {
            return PartialView();
        }

        [HttpGet]
        public IActionResult AddSendMessage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSendMessage(CreateSendMessageDto createSendMessageDto)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("Hotelier Admin", "bedava452@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);
            MailboxAddress mailboxAddressTo = new MailboxAddress(createSendMessageDto.ReceiverName, createSendMessageDto.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = createSendMessageDto.Content;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = createSendMessageDto.Subject;

            MailKit.Net.Smtp.SmtpClient smtpClient = new MailKit.Net.Smtp.SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("bedava452@gmail.com", "wkvjtmkqxgxuamjr");
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);

            createSendMessageDto.SenderName = "Admin";
            createSendMessageDto.SenderMail = "admin@gmail.com";
            createSendMessageDto.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createSendMessageDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5150/api/SendMessage", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SendBox");
            }
            return View();
        }




        //[HttpPost]
        //public async Task<IActionResult> AddSendMessage(CreateSendMessageDto createSendMessageDto)
        //{
        //    createSendMessageDto.SenderName = "Admin";
        //    createSendMessageDto.SenderMail = "admin@gmail.com";
        //    createSendMessageDto.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
        //    var client = _httpClientFactory.CreateClient();
        //    var jsonData = JsonConvert.SerializeObject(createSendMessageDto);
        //    StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //    var responseMessage = await client.PostAsync("http://localhost:5150/api/SendMessage", content);
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("SendBox");
        //    }
        //    return View();
        //}

        public async Task<IActionResult> Sendbox()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5150/api/SendMessage");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSendboxDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> MessageDetailsContact(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5150/api/Contact/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                //Sadece 1 veri geleceği için DeserializeObject List<> olarak almadık.

                var value = JsonConvert.DeserializeObject<InboxContactDto>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> MessageDetailsSend(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5150/api/SendMessage/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                //Sadece 1 veri geleceği için DeserializeObject List<> olarak almadık.

                var value = JsonConvert.DeserializeObject<ResultSendboxDto>(jsonData);
                return View(value);
            }
            return View();
        }



    }
}
