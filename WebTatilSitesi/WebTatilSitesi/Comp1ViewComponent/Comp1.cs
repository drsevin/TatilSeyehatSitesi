using Microsoft.AspNetCore.Mvc;
using WebTatilSitesi.Models.Classes;

namespace WebTatilSitesi.ViewComponents
{ 
	public class Comp1 : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			TatilDbContext cnt = new TatilDbContext();
			var deger = cnt.BlogSinifis.Take(2).OrderByDescending(x => x.ID).ToList();
			return View(deger);
		}
	}
}
