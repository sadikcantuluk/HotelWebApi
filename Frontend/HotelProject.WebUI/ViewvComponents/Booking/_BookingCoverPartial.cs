using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewvComponents.Booking
{
    public class _BookingCoverPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
