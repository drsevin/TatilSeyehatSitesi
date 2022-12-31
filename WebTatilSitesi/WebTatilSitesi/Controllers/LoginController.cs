using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using WebTatilSitesi.Models.Classes;


namespace WebTatilSitesi.Controllers
{
    public class LoginController : Controller
    {
        TatilDbContext cnt = new TatilDbContext();

        public object FormsAuthentication { get; private set; }
        public object Session { get; private set; }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Kayit kayit)
        {
            bool dbkayit = (kayit.Sifre == kayit.SifreTekrar);
            if (dbkayit)
            {
                cnt.Kayits.Add(kayit);
                cnt.SaveChanges(); //dbase de değişiklikleri kaydet
                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.msj = "Şifreler aynı değil";
                return View();
            }

        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Giris giris, AdminSinifi ad)
        {
            var dbkullanici = cnt.Kayits.FirstOrDefault(x => x.Mail == giris.Mail && x.Sifre == giris.Sifre);
            var bilgiler = cnt.AdminSinifis.FirstOrDefault(x => x.Kullanici == ad.Kullanici && x.Sifre == ad.Sifre);
            if (dbkullanici != null)
            {
                cnt.Girises.Add(giris);
                cnt.SaveChanges(); //dbase de değişiklikleri kaydet
                return RedirectToAction("Index", "Ana");
            }
            //else if (bilgiler != null)
            //{
            //    FormsAuthentication.SetAuthCookie(bilgiler.Kullanici, false);
            //    Session["Kullanici"] = bilgiler.Kullanici.ToString();
            //    return RedirectToAction("Index", "Admin");
            //}
            else
            {
                ViewBag.msj = "Geçersiz Mail Yada Şifre";
                return View();
            }

        }
        //[HttpPost]
        //public IActionResult Login(AdminSinifi ad)
        //{
        //    var bilgiler = cnt.AdminSinifis.FirstOrDefault(x => x.Kullanici == ad.Kullanici && x.Sifre == ad.Sifre);
        //    if (bilgiler != null)
        //    {
        //        FormsAuthentication.SetAuthCookie(bilgiler.Kullanici, false);
        //        Session["Kullanici"] = bilgiler.Kullanici.ToString();
        //        return RedirectToAction("Index", "Admin");
        //    }
        //    else
        //    {
        //        return View();
        //    }

        //}
    }
}
