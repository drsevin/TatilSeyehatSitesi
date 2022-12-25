using Microsoft.AspNetCore.Mvc;
using WebTatilSitesi.Models.Classes;
namespace WebTatilSitesi.Controllers
{
    public class AdminController : Controller
    {
        TatilDbContext cnt = new TatilDbContext();
        public IActionResult Index()
        {
            var deger = cnt.BlogSinifis.ToList();
            return View(deger);
        }
        [HttpGet] //sayfa yüklendiğinde çalışır hiçbir şey yapma sayfanın boş halini döndür
        public IActionResult YeniBlogEkle()
        {
            return View();
        }
        [HttpPost] //sayfada bir şey gönderince burdaki işlemleri döndür
        public IActionResult YeniBlogEkle(BlogSinifi blog)
        {
            cnt.BlogSinifis.Add(blog);
            cnt.SaveChanges(); //dbase de değişiklikleri kaydet
            return RedirectToAction("Index");
        }
        public IActionResult BlogSil(int id)
        {
            var bl = cnt.BlogSinifis.Find(id);
            cnt.BlogSinifis.Remove(bl);
            cnt.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult BlogGetir(int id)
        {
            var bl2 = cnt.BlogSinifis.Find(id);
            return View("BlogGetir", bl2);
        }
        public IActionResult BlogGuncelle(BlogSinifi b)
        {
            var blg = cnt.BlogSinifis.Find(b.ID);
            blg.Aciklama = b.Aciklama;
            blg.AnaBaslik = b.AnaBaslik;
            blg.BlogGorsel = b.BlogGorsel;
            blg.Tarih = b.Tarih;
            cnt.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
