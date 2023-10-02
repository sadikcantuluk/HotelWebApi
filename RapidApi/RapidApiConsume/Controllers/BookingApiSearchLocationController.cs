using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiConsume.Models;
using System.Net.Http.Headers;

namespace RapidApiConsume.Controllers
{
    public class BookingApiSearchLocationController : Controller
    {
        public async Task<IActionResult> Index(string cityname)
        {
            if (!string.IsNullOrWhiteSpace(cityname))
            {
                List<BookingApiSearchLocationViewModel> bookingApiSearchLocationViewModel = new List<BookingApiSearchLocationViewModel>();
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name={cityname}&locale=en-gb"),
                    Headers =
    {
        { "X-RapidAPI-Key", "9284c70ef1msh3396da3a7d254c0p104f22jsna3bd8d1c3078" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    bookingApiSearchLocationViewModel = JsonConvert.DeserializeObject<List<BookingApiSearchLocationViewModel>>(body);
                    return View(bookingApiSearchLocationViewModel.Take(1).ToList());

                }
            }
            else
            {
                List<BookingApiSearchLocationViewModel> bookingApiSearchLocationViewModel = new List<BookingApiSearchLocationViewModel>();
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/hotels/locations?name=paris&locale=en-gb"),
                    Headers =
    {
        { "X-RapidAPI-Key", "9284c70ef1msh3396da3a7d254c0p104f22jsna3bd8d1c3078" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    bookingApiSearchLocationViewModel = JsonConvert.DeserializeObject<List<BookingApiSearchLocationViewModel>>(body);
                    return View(bookingApiSearchLocationViewModel.Take(1).ToList());

                }
            }

        }
    }
}
