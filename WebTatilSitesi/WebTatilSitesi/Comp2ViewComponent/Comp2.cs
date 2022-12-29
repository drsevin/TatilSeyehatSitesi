using Microsoft.AspNetCore.Mvc;
using WebTatilSitesi.Models.Classes;

namespace WebTatilSitesi.Comp2ViewComponent
{
    public class Comp2 :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            TatilDbContext cnt = new TatilDbContext();
            var deger2 = cnt.BlogSinifis.Where(x => x.ID == 3).ToList();
            return View(deger2);
        }
        
    }
}
