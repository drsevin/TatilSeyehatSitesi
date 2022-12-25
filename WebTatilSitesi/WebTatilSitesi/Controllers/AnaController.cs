using Microsoft.AspNetCore.Mvc;
using WebTatilSitesi.Models.Classes;
namespace WebTatilSitesi.Controllers
{
    public class AnaController : Controller
    {
        TatilDbContext cnt = new TatilDbContext();
        public IActionResult Index()
        {
            
            var dgr = cnt.BlogSinifis.Take(4).ToList();
            return View(dgr);
        }
        public IActionResult About()
        {
            return View();
        }
        //public async Task<IActionResult> Partial1(BlogSinifi model)
        //{
        //    var deger = cnt.BlogSinifis.OrderByDescending(x => x.ID).Take(2).ToList();
        //    ViewBag.data = deger;
        //}
        public PartialViewResult Partial1()
        {
            var deger = cnt.BlogSinifis.Take(2).OrderByDescending(x => x.ID).ToList();
            return PartialView(deger);
            //ViewBag.data = deger;
        }
        public PartialViewResult Partial2()
        {
            var deger2 = cnt.BlogSinifis.Where(x => x.ID == 2).ToList();
            return PartialView(deger2);
            //ViewBag.data = deger2;
        }
        public PartialViewResult Partial3()
        {
            var deger3 = cnt.BlogSinifis.ToList();
            return PartialView(deger3);
        }
        public PartialViewResult Partial4()
        {
            var deger4 = cnt.BlogSinifis.Take(3).ToList();
            return PartialView(deger4);
        }
        public PartialViewResult Partial5()
        {
            var deger5 = cnt.BlogSinifis.Take(3).OrderByDescending(x => x.ID).ToList();
            return PartialView(deger5);
        }
    }
}
