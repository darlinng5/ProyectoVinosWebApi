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

namespace ProyectoVinowWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FincaCompraController : ControllerBase
    {
        public readonly DBContext _Db;
        public FincaCompraController(DBContext _DBcontext)
        {
            _Db = _DBcontext;
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<FincaProceso>>> getFincaProcesosInspeccionados()
        {

            return await _Db.FincaProceso.Include(x=>x.Productos).Include(y=>y.Finca).Include(z=>z.Productos.Semilla).Where(x => x.estado == PropiedadesDeModelos.estadoInspeccionado).OrderByDescending(z => z.idProceso).ToArrayAsync();
        }

        [HttpGet("{idProceso}")]
        public async Task<ActionResult<IEnumerable<FincaCompra>>> getFincaCompraPorProceso(int idProceso)
        {

            return await _Db.FincaCompra.Include(x=>x.ProductoPresentacion).Where(x => x.idProceso == idProceso).OrderByDescending(z => z.id).ToArrayAsync();
        }


        [HttpPost]
        public async Task<ActionResult<FincaCompra>> postFincaCompra(FincaCompra compra)
        {
            try
            {
                var FincaProceso = await _Db.FincaProceso.FindAsync(compra.idProceso);
                bool puedoGuardarCompra = FincaProceso != null && FincaProceso.estado == PropiedadesDeModelos.estadoInspeccionado;
                if (puedoGuardarCompra)
                {
                    _Db.FincaCompra.Add(compra);             
                    await _Db.SaveChangesAsync();
                    return Ok();
                }

               

                return BadRequest();
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }

        }

    }
}