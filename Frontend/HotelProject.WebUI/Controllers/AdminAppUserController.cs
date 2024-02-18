using HotelProject.WebUI.Dtos.AppUser;
using HotelProject.WebUI.Dtos.RoomDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.Controllers
{
    public class AdminAppUserController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminAppUserController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5150/api/AppUser");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAppUserDto>>(jsonData);
                return View(values);
            }
            return View();
        }

    }
}
