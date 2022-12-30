using Microsoft.AspNetCore.Mvc;
using WebTatilSitesi.Models.Classes;

namespace WebTatilSitesi.Comp3ViewComponent
{
    public class Comp3 :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            TatilDbContext cnt = new TatilDbContext();
            var deger3 = cnt.BlogSinifis.Take(10).ToList();
            return View(deger3);
        }
    }
}
