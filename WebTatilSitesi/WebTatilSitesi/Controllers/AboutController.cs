using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using WebTatilSitesi.Models.Classes;

namespace WebTatilSitesi.Controllers
{
    public class AboutController : Controller
    {
        private readonly ILogger<AboutController> _logger;
        private readonly IStringLocalizer<AboutController> _localizer;

        TatilDbContext cnt = new TatilDbContext();
        public AboutController(ILogger<AboutController> logger, IStringLocalizer<AboutController> localizer, TatilDbContext cnt)
        {
            _logger = logger;
            _localizer = localizer;
            this.cnt = cnt;
        }

        public IActionResult Index()
        {
            var d = _localizer["Hakkımızda"];
            var degerler = cnt.HakkimizdaSinifis.ToList();
            return View(degerler);
        }
    }
}
