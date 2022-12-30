using Microsoft.AspNetCore.Mvc;
using WebTatilSitesi.Models.Classes;
namespace WebTatilSitesi.Controllers
{
    public class AnaController : Controller
    {
        
        public IActionResult Index()
        {
            TatilDbContext cnt = new TatilDbContext();
            var dgr = cnt.BlogSinifis.Take(8).ToList();
            return View(dgr);
        }
        public IActionResult About()
        {
            return View();
        }
        
        
    }
}
