using Microsoft.AspNetCore.Mvc;
using WebTatilSitesi.Models.Classes;

namespace WebTatilSitesi.Comp4ViewComponent
{
    public class Comp4 : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            TatilDbContext cnt = new TatilDbContext();
            var deger4 = cnt.BlogSinifis.Take(4).ToList();
            return View(deger4);
        }
    }
}
