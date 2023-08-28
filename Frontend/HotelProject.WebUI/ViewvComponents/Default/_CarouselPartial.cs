using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewvComponents.Default
{
    public class _CarouselPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
