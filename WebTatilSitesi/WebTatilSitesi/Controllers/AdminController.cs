using Microsoft.AspNetCore.Mvc;

namespace WebTatilSitesi.Controllers
{
	public class AdminController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
