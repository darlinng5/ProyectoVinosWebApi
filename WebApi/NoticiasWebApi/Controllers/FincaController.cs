using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoticiasWebApi.Models;
using NoticiasWebApi.Services;
using ProyectoVinowWebApi.AppServices;

namespace NoticiasWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FincaController : ControllerBase
    {
        private readonly DBContext _Db;
        private readonly FincaAppServices _fincaAppService;
        public FincaController(DBContext _DBcontext, FincaAppServices fincaAppServices)
        {
            _Db = _DBcontext;
            _fincaAppService = fincaAppServices;


        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Finca>>> getFincas()
        {
            return await _Db.Finca.ToArrayAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Finca>> getFinca(int id)
        {
            return await _Db.Finca.FirstOrDefaultAsync(i => i.idFinca == id);
        }

        [HttpPost]
        public async Task<ActionResult<Finca>> postFinca(Finca finca)
        {
            var  respuesta = await  _fincaAppService.RegistrarFinca(finca);
            if (respuesta == null)
            {
                return Ok("Exito al guardar la finca");
            }
            else
            {
                return BadRequest(respuesta);
            }


        }

        [HttpPut("{idFinca}")]

        public async Task<ActionResult> putFinca(int idFinca, Finca finca)
        {

            if (idFinca == finca.idFinca)
            {
                _Db.Entry(finca).State = EntityState.Modified;
                await _Db.SaveChangesAsync();
                return Ok();
            }

            return BadRequest();

        }

        [HttpDelete("{idFinca}")]
        public async Task<ActionResult> deleteFinca(int idFinca)
        {
            var finca = await _Db.Finca.FindAsync(idFinca);
            if (finca == null || finca.estado != PropiedadesDeModelos.estadoCreado)
            {
                return NotFound();
            }
            _Db.Finca.Remove(finca);
            await _Db.SaveChangesAsync();
            return Ok();
        }



    }
}