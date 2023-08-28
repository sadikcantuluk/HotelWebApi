using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewvComponents.Default
{
    public class _VideoPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
