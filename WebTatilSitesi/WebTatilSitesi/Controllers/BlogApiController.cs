using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebTatilSitesi.Models.Classes;

namespace WebTatilSitesi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YazarApiController : ControllerBase
    {
        TatilDbContext k = new TatilDbContext();
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<List<BlogSinifi>>> Get()
        {
            var y = await k.BlogSinifis.ToListAsync();
            if (y is null)
            {
                return NoContent();
            }
            return y;

        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BlogSinifi>> Get(int id)
        {
            var y = await k.BlogSinifis.FirstOrDefaultAsync(x => x.ID == id);
            if (y is null)
            {
                return NoContent();
            }
            return y;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult Post([FromBody] BlogSinifi y)
        {
            k.BlogSinifis.Add(y);
            k.SaveChanges();
            return Ok();
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BlogSinifi y)
        {
            var y1 = k.BlogSinifis.FirstOrDefault(x => x.ID == id);
            if (y1 is null)
            {
                return NotFound();
            }
            y1.AnaBaslik = y.AnaBaslik;
            y1.Aciklama = y.Aciklama;
            y1.BlogGorsel = y.BlogGorsel;
            y1.Tarih = y.Tarih;
            k.Update(y1);
            k.SaveChanges();
            return Ok();
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var y1 = k.BlogSinifis.FirstOrDefault(x => x.ID == id);
            if (y1 is null)
            {
                return NotFound();
            }
            if (k.YorumSinifis.Any(x => x.ID == id))
            {
                return NotFound("Bloga ait yorumlar var");
            }
            k.BlogSinifis.Remove(y1);
            k.SaveChanges();
            return Ok();
        }
    }
}
