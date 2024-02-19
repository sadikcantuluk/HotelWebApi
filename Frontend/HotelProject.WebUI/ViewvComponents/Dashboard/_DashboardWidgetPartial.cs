using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewvComponents.Dashboard
{
    public class _DashboardWidgetPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
