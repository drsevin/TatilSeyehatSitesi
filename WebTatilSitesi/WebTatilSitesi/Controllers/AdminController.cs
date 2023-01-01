using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebTatilSitesi.Models.Classes;
namespace WebTatilSitesi.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        TatilDbContext cnt = new TatilDbContext();
        [Authorize(Roles = "Admin")]
        public IActionResult Index2()
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
            return RedirectToAction("Index2");
        }
        public IActionResult BlogSil(int id)
        {
            var bl = cnt.BlogSinifis.Find(id);
            cnt.BlogSinifis.Remove(bl);
            cnt.SaveChanges();
            return RedirectToAction("Index2");
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
            return RedirectToAction("Index2");
        }
        public IActionResult YorumListesi()
        {
            var yorumlar = cnt.YorumSinifis.Include(x=> x.Blog).ToList();
            return View(yorumlar);
        }
        public IActionResult YorumSil(int id)
        {
            var yrm = cnt.YorumSinifis.Find(id);
            cnt.YorumSinifis.Remove(yrm);
            cnt.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
        public IActionResult YorumGetir(int id)
        {
            var yr2 = cnt.BlogSinifis.Find(id);
            return View("YorumGetir", yr2);
        }
        public IActionResult YorumGuncelle(YorumSinifi y)
        {
            var yrm2 = cnt.YorumSinifis.Find(y.ID);
            yrm2.KullaniciAdi = y.KullaniciAdi;
            yrm2.Mail = y.Mail;
            yrm2.Yorum = y.Yorum;
            cnt.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
    }
}
