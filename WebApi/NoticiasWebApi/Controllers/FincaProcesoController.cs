using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoticiasWebApi;
using NoticiasWebApi.Models;
using NoticiasWebApi.Services;


namespace ProyectoVinowWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FincaProcesoController : ControllerBase
    {
       
        public readonly DBContext _Db;
        public FincaProcesoController(DBContext _DBcontext)
        {
            _Db = _DBcontext;
        }       

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FincaProceso>>> getFincaProcesos()
        {
            return await _Db.FincaProceso.Include(x=>x.Finca).ToArrayAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<FincaProceso>> getFincaProceso(int id)
        {
            return await _Db.FincaProceso.Include(x=>x.Finca).FirstOrDefaultAsync(i=>i.idProceso==id);
        }

        [HttpPost]
        public async Task<ActionResult<FincaProceso>> postFincaProceso(FincaProceso proceso)
        {
            try
            {
                proceso.estado = "Creado";
                _Db.FincaProceso.Add(proceso);
               await _Db.SaveChangesAsync();

                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }
           
        }

        [HttpPut("{idFinca}")]

        public async Task<ActionResult> putFincaProceso(int idFinca, FincaProceso proceso)
        {
            if (idFinca ==Convert.ToInt32(proceso.idProceso))
            {
                _Db.Entry(proceso).State = EntityState.Modified;
                await _Db.SaveChangesAsync();
                return Ok();
            }

            return BadRequest();
           
        }

        [HttpDelete("{idProceso}")]
        public async Task<ActionResult> deleteFincaProceso(int idProceso)
        {
            var fincaProceso = await _Db.FincaProceso.FindAsync(idProceso);
            if (fincaProceso == null || fincaProceso.estado != PropiedadesDeModelos.estadoCreado)
            {
                return NotFound();
            }
            _Db.FincaProceso.Remove(fincaProceso);
           await _Db.SaveChangesAsync();
            return Ok();
        }



    }
}