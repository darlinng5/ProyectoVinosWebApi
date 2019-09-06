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
        public FincaEvaluacionController(DBContext _DBcontext)
        {
            _Db = _DBcontext;
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
            try
            {
                evaluacion.estado = PropiedadesDeModelos.estadoCreado;

                _Db.FincaEvaluacion.Add(evaluacion);
                await _Db.SaveChangesAsync();
                var DomainProceso = new ProcesoDomain();
                var procesoAppServices = new ProcesoAppServices(_Db, DomainProceso);
                //var fincaProceso = new FincaProcesoController(_Db, procesoAppServices);
               // await fincaProceso.cambiarEstadoFincaProceso(evaluacion.idProceso, PropiedadesDeModelos.estadoEvaluado);
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e);
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