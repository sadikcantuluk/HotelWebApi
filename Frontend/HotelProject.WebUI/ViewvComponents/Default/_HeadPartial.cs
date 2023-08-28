using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewvComponents.Default
{
    public class _HeadPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
