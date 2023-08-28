using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewvComponents.Default
{
    public class _RoomPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
