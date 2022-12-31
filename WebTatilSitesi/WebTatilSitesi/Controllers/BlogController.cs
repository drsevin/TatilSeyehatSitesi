using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using WebTatilSitesi.Models.Classes;

namespace WebTatilSitesi.Controllers
{
    //[Authorize(Roles = "User")]
    public class BlogController : Controller
    {
        TatilDbContext cnt = new TatilDbContext();
        BlogYorumlari yrm = new BlogYorumlari();
        public IActionResult Index()
        {
                yrm.blogSinifis = cnt.BlogSinifis.ToList();
                yrm.blogSinifis2 = cnt.BlogSinifis.OrderByDescending(x => x.ID).Take(3).ToList();
                return View(yrm);
        }

        public IActionResult BlogDetayi(int id)
        {

            //var blogara = cnt.BlogSinifis.Where(x => x.ID== id).ToList();
            yrm.blogSinifis = cnt.BlogSinifis.Where(x => x.ID == id).ToList();
            yrm.yorumSinifis = cnt.YorumSinifis.Where(x => x.Blogid == id).ToList();
            return View(yrm);
        }
        [HttpGet]
        public IActionResult YorumEkle(int id)
        {
            ViewBag.deger = id;
            return View();
        }
        [HttpPost]
        public IActionResult YorumEkle(YorumSinifi y)
        {
            if (ModelState.IsValid)
            {
                cnt.YorumSinifis.Add(y);
                cnt.SaveChanges();
                return RedirectToAction("BlogDetayi");
            }
            return View("BlogDetayi");
        }
    }
}
