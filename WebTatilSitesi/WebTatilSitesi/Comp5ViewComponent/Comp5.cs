using Microsoft.AspNetCore.Mvc;
using WebTatilSitesi.Models.Classes;

namespace WebTatilSitesi.Comp5ViewComponent
{
    public class Comp5 :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            TatilDbContext cnt = new TatilDbContext();
            var deger5 = cnt.BlogSinifis.Take(4).OrderByDescending(x => x.ID).ToList();
            return View(deger5);
        }
    }
}
