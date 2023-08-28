using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewvComponents.Default
{
    public class _FooterPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
