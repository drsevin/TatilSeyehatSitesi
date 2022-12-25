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
        //public async Task<IActionResult> Partial1(BlogSinifi model)
        //{
        //    var deger = cnt.BlogSinifis.OrderByDescending(x => x.ID).Take(2).ToList();
        //    ViewBag.data = deger;
        //}
        public PartialViewResult Partial1()
        {
            TatilDbContext cnt = new TatilDbContext();
            var deger = cnt.BlogSinifis.Take(2).OrderByDescending(x => x.ID).ToList();
            return PartialView(deger);
            //ViewBag.data = deger;
        }
        public PartialViewResult Partial2()
        {
            TatilDbContext cnt = new TatilDbContext();
            var deger2 = cnt.BlogSinifis.Where(x => x.ID == 2).ToList();
            return PartialView(deger2);
            //ViewBag.data = deger2;
        }
        public PartialViewResult Partial3()
        {
            TatilDbContext cnt = new TatilDbContext();
            var deger3 = cnt.BlogSinifis.Take(10).ToList();
            return PartialView(deger3);
        }
        public PartialViewResult Partial4()
        {
            TatilDbContext cnt = new TatilDbContext();
            var deger4 = cnt.BlogSinifis.Take(3).ToList();
            return PartialView(deger4);
        }
        public PartialViewResult Partial5()
        {
            TatilDbContext cnt = new TatilDbContext();
            var deger5 = cnt.BlogSinifis.Take(3).OrderByDescending(x => x.ID).ToList();
            return PartialView(deger5);
        }
    }
}
