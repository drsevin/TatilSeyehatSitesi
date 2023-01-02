using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using System.Security.Claims;
using WebTatilSitesi.Models.Classes;


namespace WebTatilSitesi.Controllers
{
    public class LoginController : Controller
    {
        TatilDbContext cnt = new TatilDbContext();
        //private UserManager
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
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        //[AllowAnonymous]
        //[HttpPost]
        //public async Task<IActionResult> Login(AdminSinifi p)
        //{
        //    var bilgiler = cnt.AdminSinifis.FirstOrDefault(x=>x.Mail == p.Mail && x.Sifre == p.Sifre);
        //    if(bilgiler != null)
        //    {
        //        var claims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.Name,p.Mail)
        //        };
        //        var useridentity = new ClaimsIdentity(claims,"Login");
        //        ClaimsPrincipal principal= new ClaimsPrincipal(useridentity);
        //        await HttpContext.SignInAsync(principal);
        //        return RedirectToAction("Index2","Admin");
        //    }
        //    return View();
        //}

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login","Login");
        }
        [HttpPost]
        public IActionResult Login(Giris giris/*, AdminSinifi ad*/)
        {
            var dbkullanici = cnt.Kayits.FirstOrDefault(x => x.Mail == giris.Mail && x.Sifre == giris.Sifre);
            //var bilgiler = cnt.AdminSinifis.FirstOrDefault(y => y.Kullanici == ad.Kullanici && y.Sifre == ad.Sifre);
            if (dbkullanici != null)
            {
                cnt.Girises.Add(giris);
                cnt.SaveChanges(); //dbase de değişiklikleri kaydet
                return RedirectToAction("Index2", "Admin");
            }
            //else if (bilgiler != null)
            //{
            //    //formsauthentication.setauthcookie(bilgiler.kullanici, false);
            //    //session["kullanici"] = bilgiler.kullanici.tostring();
            //    cnt.Girises.Add(ad);
            //    cnt.SaveChanges();
            //    return RedirectToAction("Index2", "Admin");
            //}
            else
            {
                ViewBag.msj = "Geçersiz Mail Yada Şifre";
                return View();
            }

        }
    }
}
