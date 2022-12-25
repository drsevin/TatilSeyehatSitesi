using Microsoft.AspNetCore.Mvc;
using WebTatilSitesi.Models.Classes;

namespace WebTatilSitesi.Controllers
{
    public class BlogController : Controller
    {
        TatilDbContext cnt = new TatilDbContext();
        BlogYorumlari yrm = new BlogYorumlari();
        public IActionResult Index()
        {
            //var blogs = cnt.BlogSinifis.ToList();
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
        public PartialViewResult YorumEkle()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult YorumEkle(YorumSinifi y)
        {
            cnt.YorumSinifis.Add(y);
            cnt.SaveChanges();
            return PartialView();
        }
    }
}
