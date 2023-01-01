using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebTatilSitesi.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebTatilSitesi.Controllers
{
    public class CallBlogApiController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<BlogSinifi> BlogSinifis= new List<BlogSinifi>();
            var hhtc = new HttpClient();
            var response = await hhtc.GetAsync("https://localhost:44333/api/BlogApi");
            string resString = await response.Content.ReadAsStringAsync();
            BlogSinifis = JsonConvert.DeserializeObject<List<BlogSinifi>>(resString);
            return View(BlogSinifis);
        }
    }
}
