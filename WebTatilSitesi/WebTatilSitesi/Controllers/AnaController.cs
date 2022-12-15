using Microsoft.AspNetCore.Mvc;

namespace WebTatilSitesi.Controllers
{
    public class AnaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
    }
}
