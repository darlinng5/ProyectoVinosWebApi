using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoticiasWebApi;
using ProyectoVinowWebApi.AppServices;
using ProyectoVinowWebApi.Models;

namespace ProyectoVinowWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FincaLLamadaController : ControllerBase
    {
        public readonly DBContext _Db;
        public readonly LlamadaAppServices _llamadaAppServices;

        public FincaLLamadaController(DBContext _DBcontext, LlamadaAppServices llamadaAppServices)
        {
            _Db = _DBcontext;
            _llamadaAppServices = llamadaAppServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LLamadasAFinca>>> getFincaLLamadas()
        {
            return await _Db.LLamadasAFinca.ToArrayAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<LLamadasAFinca>>> getFincaLLamada(int id)
        {

            return await _Db.LLamadasAFinca.Where(x => x.idProceso == id).OrderByDescending(z => z.idLLamada).ToArrayAsync();
        }


        [HttpPost]
        public async Task<ActionResult<LLamadasAFinca>> postFincaLLamada(LLamadasAFinca llamada)
        {
            var respuesta = await _llamadaAppServices.HacerLlamada(llamada);
            if (respuesta == null)
            {
                return Ok("Guardado exitosamente");
            }
            else
            {
                return BadRequest(respuesta);
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
            var llamada = await _Db.LLamadasAFinca.FindAsync(idLLamada);
            if (llamada == null)
            {
                return NotFound();
            }
            _Db.LLamadasAFinca.Remove(llamada);
            await _Db.SaveChangesAsync();
            return Ok();
        }

    }
}