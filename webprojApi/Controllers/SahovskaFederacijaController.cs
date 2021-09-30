using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using webproj.Models;
namespace webproj.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SahovskaFederacijaController : ControllerBase
    {
        public SahovskaFederacijaContext ctx {get;set;}
        public SahovskaFederacijaController(SahovskaFederacijaContext context)
        {
            ctx = context;
        }
        [Route("PreuzmiSahiste")]
        [HttpGet]
        public async Task<List<Sahista>> PreuzmiSahiste()
        {
            return await ctx.Sahisti.ToListAsync();
        }
        [Route("UpisiSahistu")]
        [HttpPost]
        public async Task UpisiSahistu([FromBody] Sahista sahista)
        {
            ctx.Sahisti.Add(sahista);
            await ctx.SaveChangesAsync();
        }
        [Route("IzmeniSahistu")]
        [HttpPut]
        public async Task IzmeniSahistu([FromBody] Sahista sahista)
        {
            ctx.Update<Sahista>(sahista);
            await ctx.SaveChangesAsync();
        }
        [Route("IzbrisiSahistu/{id}")]
        [HttpDelete]
        public async Task IzbrisiSahistu(int id)
        {
            var sahista = await ctx.Sahisti.FindAsync(id);
            ctx.Remove(sahista);
            await ctx.SaveChangesAsync();
        }
        [Route("PreuzmiPartije/{id}")]
        [HttpGet]
        public async Task<List<Partija>> PreuzmiPartije(int id)
        {
            return await ctx.Partije.Include(p=>p.BeliSahista)
                                    .Include(p=>p.CrniSahista)
                                    .Where(p=>p.Turnir.Id == id)
                                    .ToListAsync();
        }
        //ovo upisuje i sahiste
        [Route("UpisiPartiju/{beliId}/{crniId}/{turnirId}")]
        [HttpPost]
        public async Task<IActionResult> UpisiPartiju(int beliId,int crniId,int turnirId,[FromBody] Partija partija)
        {
            var beli = await ctx.Sahisti.FindAsync(beliId);
            var crni = await ctx.Sahisti.FindAsync(crniId);
            var turnir = await ctx.Turniri.FindAsync(turnirId);
            Partija p = new Partija();
            p.BeliSahista = beli;
            p.CrniSahista=crni;
            p.Turnir=turnir;
            p.Ishod=partija.Ishod;
            p.Trajanje=partija.Trajanje;
            ctx.Partije.Add(p);
            await ctx.SaveChangesAsync();
            return Ok();
        }
        [Route("IzmeniPartiju/{idPartije}/{beliId}/{crniId}/{turnirId}")]
        [HttpPut]
        public async Task<IActionResult> IzmeniPartiju(int idPartije,int beliId,int crniId,int turnirId,[FromBody] Partija partija)
        {
            var beli = await ctx.Sahisti.FindAsync(beliId);
            var crni = await ctx.Sahisti.FindAsync(crniId);
            var turnir = await ctx.Turniri.FindAsync(turnirId);
            var p = await ctx.Partije.FindAsync(idPartije);
            p.BeliSahista = beli;
            p.CrniSahista=crni;
            p.Turnir=turnir;
            p.Ishod=partija.Ishod;
            p.Trajanje=partija.Trajanje;
            ctx.Partije.Update(p);
            await ctx.SaveChangesAsync();
            return Ok();
        }
        [Route("IzbrisiPartiju/{id}")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> IzbrisiPartiju(int id)
        {
            var partija = await ctx.Partije.FindAsync(id);
            ctx.Partije.Remove(partija);
            await ctx.SaveChangesAsync();
            return Ok();
        }
        [Route("UpisiTurnir")]
        [HttpPost]
        public async Task<IActionResult> UpisiTurnir([FromBody] Turnir turnir)
        {
            ctx.Turniri.Add(turnir);
            await ctx.SaveChangesAsync();
            return Ok();
        }
        [Route("PreuzmiTurnire")]
        [HttpGet]
        public async Task<List<Turnir>> PreuzmiTurnire()
        {
            //todo
            return await ctx.Turniri.Include(p=>p.OdigranePartije).ToListAsync();
        }
    }
}
