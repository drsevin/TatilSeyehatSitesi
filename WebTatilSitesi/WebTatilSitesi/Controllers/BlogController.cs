using Microsoft.AspNetCore.Mvc;
using WebTatilSitesi.Models.Classes;

namespace WebTatilSitesi.Controllers
{
	public class BlogController : Controller
	{
		TatilDbContext cnt = new TatilDbContext();
		public IActionResult Index()
		{
			var blogs = cnt.BlogSinifis.ToList();
			return View(blogs);
		}
		public IActionResult BlogDetayi(int id)
		{
			var blogara = cnt.BlogSinifis.Where(x => x.ID== id).ToList();
			return View(blogara);	
		}
	}
}
