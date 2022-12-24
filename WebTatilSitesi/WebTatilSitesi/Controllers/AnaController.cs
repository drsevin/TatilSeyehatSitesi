using Microsoft.AspNetCore.Mvc;
using WebTatilSitesi.Models.Classes;
namespace WebTatilSitesi.Controllers
{
    public class AnaController : Controller
    {
        TatilDbContext cnt = new TatilDbContext();
        public IActionResult Index()
        {
           
            var dgr =cnt.BlogSinifis.ToList();
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
            var deger = cnt.BlogSinifis.OrderByDescending(x => x.ID).Take(2).ToList();
            return PartialView(deger);
            //ViewBag.data = deger;
        }
        public PartialViewResult Partial2()
		{
			var deger2 = cnt.BlogSinifis.Where(x => x.ID == 2).ToList();
			return PartialView(deger2);
			//ViewBag.data = deger2;
		}
	}
}
