using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace HotelProject.WebUI.ViewvComponents.Default
{
    public class _HeaderPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
