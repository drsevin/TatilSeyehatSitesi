using Microsoft.AspNetCore.Mvc;
using WebTatilSitesi.Models.Classes;

namespace WebTatilSitesi.Controllers
{
    public class AboutController : Controller
    {
        TatilDbContext cnt = new TatilDbContext();
        public IActionResult Index()
        {
            var degerler = cnt.HakkimizdaSinifis.ToList();
            return View(degerler);
        }
    }
}
