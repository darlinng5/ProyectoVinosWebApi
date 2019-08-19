using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoticiasWebApi;
using ProyectoVinowWebApi.Models;

namespace ProyectoVinowWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FincaLLamadaController : ControllerBase
    {
        public readonly DBContext _Db;
        public FincaLLamadaController(DBContext _DBcontext)
        {
            _Db = _DBcontext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LLamadasAFinca>>> getFincaLLamadas()
        {
            return await _Db.LlamadasAFinca.Include(x => x.FincaProceso).ToArrayAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<LLamadasAFinca>> getFincaLLamada(int id)
        {
            return await _Db.LlamadasAFinca.Include(x => x.FincaProceso).FirstOrDefaultAsync(i => i.idLLamada == id);
        }

        [HttpPost]
        public async Task<ActionResult<LLamadasAFinca>> postFincaLLamada(LLamadasAFinca llamada)
        {
            try
            {
               
                _Db.LlamadasAFinca.Add(llamada);
                await _Db.SaveChangesAsync();

                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }

        }

        [HttpPut("{idLLamada}")]

        public async Task<ActionResult> putFincaLLamada(int idLlamada, LLamadasAFinca llamada)
        {
            if (idLlamada == Convert.ToInt32(llamada.idLLamada))
            {
                _Db.Entry(llamada).State = EntityState.Modified;
                await _Db.SaveChangesAsync();
                return Ok();
            }

            return BadRequest();

        }

        [HttpDelete("{idLLamada}")]
        public async Task<ActionResult> deleteFincaLLamada(int idLLamada)
        {
            var llamada = await _Db.LlamadasAFinca.FindAsync(idLLamada);
            if (llamada == null)
            {
                return NotFound();
            }
            _Db.LlamadasAFinca.Remove(llamada);
            await _Db.SaveChangesAsync();
            return Ok();
        }

    }
}