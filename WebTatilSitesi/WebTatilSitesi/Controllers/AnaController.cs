using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using WebTatilSitesi.Models.Classes;
namespace WebTatilSitesi.Controllers
{
    public class AnaController : Controller
    {
        //[Authorize(Roles = "User")]
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
