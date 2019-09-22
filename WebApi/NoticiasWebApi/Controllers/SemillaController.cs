using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoticiasWebApi;
using NoticiasWebApi.Models;
using ProyectoVinowWebApi.AppServices;
using ProyectoVinowWebApi.Models;

namespace ProyectoVinowWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SemillaController : ControllerBase
    {
        public readonly DBContext _Db;
        public readonly SemillaAppServices _semillaAppServices;
        public SemillaController(DBContext _DBcontext, SemillaAppServices semillaAppServices)
        {
            _Db = _DBcontext;
            _semillaAppServices = semillaAppServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Semilla>>> getSemillas()
        {
            return await _Db.Semilla.ToArrayAsync();
        }

        [HttpPost]
        public async Task<ActionResult> postSemilla(Semilla semilla)
        {
            var respuestaSemillaAppServices = await _semillaAppServices.ingresarSemilla(semilla);
            var IngresoCorrecto = respuestaSemillaAppServices == null;
            if (IngresoCorrecto)
            {
                return Ok("Exito al guardar semilla");
            }
            else
            {
                return BadRequest(respuestaSemillaAppServices);
            }
        }

    }
}