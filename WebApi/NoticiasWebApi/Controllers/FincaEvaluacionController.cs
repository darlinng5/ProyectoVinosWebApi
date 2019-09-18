using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoticiasWebApi;
using NoticiasWebApi.Models;
using ProyectoVinowWebApi.Models;
using ProyectoVinowWebApi.Controllers;
using ProyectoVinowWebApi.AppServices;
using ProyectoVinowWebApi.Domains;

namespace ProyectoVinowWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FincaEvaluacionController : ControllerBase
    {

        public readonly DBContext _Db;
        private readonly EvaluacionAppServices _evaluacionAppServices;
        public FincaEvaluacionController(DBContext _DBcontext, EvaluacionAppServices evaluacionAppServices)
        {
            _Db = _DBcontext;
            _evaluacionAppServices = evaluacionAppServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FincaEvaluacion>>> getFincaEvaluaciones()
        {
            return await _Db.FincaEvaluacion.Include(x => x.FincaProceso).ToArrayAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<FincaEvaluacion>>> getFincaEvaluacion(int id)
        {

            return await _Db.FincaEvaluacion.Where(x => x.idProceso == id).OrderByDescending(z => z.idEvaluacion).ToArrayAsync();
        }


        [HttpPost]
        public async Task<ActionResult<FincaEvaluacion>> postFincaEvaluacion(FincaEvaluacion evaluacion)
        {
            var respuestaAppServices = await _evaluacionAppServices.IngresarEvaluacion(evaluacion);
            if (respuestaAppServices == null)
            {
                return Ok("Exito al guardar la finca");
            }
            else
            {
                return BadRequest(respuestaAppServices);
            }
        }

        [HttpPut("{idEvaluacion}")]

        public async Task<ActionResult> putFincaEvaluacion(int idEvaluacion, FincaEvaluacion evaluacion)
        {
            if (idEvaluacion == Convert.ToInt32(evaluacion.idEvaluacion))
            {
                _Db.Entry(evaluacion).State = EntityState.Modified;
                await _Db.SaveChangesAsync();
                return Ok();
            }

            return BadRequest();

        }

        [HttpDelete("{idEvaluacion}")]
        public async Task<ActionResult> deleteFincaEvaluacion(int idEvaluacion)
        {
            var evaluacion = await _Db.FincaEvaluacion.FindAsync(idEvaluacion);
            if (evaluacion == null)
            {
                return NotFound();
            }
            _Db.FincaEvaluacion.Remove(evaluacion);
            await _Db.SaveChangesAsync();
            return Ok();
        }




    }
}