using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebTatilSitesi.Areas.Identity;
using WebTatilSitesi.Models;
using WebTatilSitesi.Models.Classes;
namespace WebTatilSitesi.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        TatilDbContext cnt = new TatilDbContext();

        private RoleManager<IdentityRole> _roleManager;

        private UserManager<User> _userManager;
        public AdminController(RoleManager<IdentityRole> roleManager,
            UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;

        }
        public async Task<IActionResult> RoleEdit(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            var members = new List<User>();
            var nonmembers = new List<User>();

            foreach (var user in _userManager.Users)
            {
                var list = await _userManager.IsInRoleAsync(user, role.Name)
                    ?members:nonmembers;
                list.Add(user);
            }
            var model = new RoleDetails()
            {
                Role = role,
                Members = members,
                NonMembers= nonmembers
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> RoleEdit(RoleEditModel model)
        {
            if (!ModelState.IsValid)
            {
                foreach (var userId in model.IdsToAdd ?? new string[] {})
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if(user!=null)
                    {
                        var result = await _userManager.AddToRoleAsync(user,model.RoleName);
                        if (!result.Succeeded)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }
                    }
                }

                foreach (var userId in model.IdsToDelete ?? new string[] { })
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        var result = await _userManager.RemoveFromRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }
                    }
                }
            }
            return Redirect("/admin/role/" + model.RoleId);
        }
            public IActionResult RoleList()
        {
            return View(_roleManager.Roles);
        }
        public IActionResult RoleCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RoleCreate(RoleModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _roleManager.CreateAsync(new IdentityRole(model.Name));
                if(result.Succeeded)
                {
                    return RedirectToAction("RoleList");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }
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
