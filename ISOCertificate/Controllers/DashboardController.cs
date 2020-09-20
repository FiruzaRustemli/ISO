using Microsoft.AspNetCore.Mvc;

namespace ISOCertificate.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult About_One()
        {
            return View();
        }

        public IActionResult About_Two()
        {
            return View();
        }
    }
}