﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoticiasWebApi;
using NoticiasWebApi.Models;
using ProyectoVinowWebApi.AppServices;
using ProyectoVinowWebApi.Domains;
using ProyectoVinowWebApi.Models;

namespace ProyectoVinowWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FincaInspeccionController : ControllerBase
    {
        public readonly DBContext _Db;
        public FincaInspeccionController(DBContext _DBcontext)
        {
            _Db = _DBcontext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FincaInspeccion>>> getFincaInspecciones()
        {
             return await _Db.FincaInspeccion.Include(x => x.FincaProceso).ToArrayAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<FincaInspeccion>>> getFincaInspeccion(int id)
        {

            return await _Db.FincaInspeccion.Where(x => x.idProceso == id).OrderByDescending(z => z.idInspeccion).ToArrayAsync();
        }

        [HttpPost]
        public async Task<ActionResult<FincaInspeccion>> postFincaInspeccion(FincaInspeccion inspeccion)
        {
            try
            {

                _Db.FincaInspeccion.Add(inspeccion);
                await _Db.SaveChangesAsync();
                var DomainProceso = new ProcesoDomain();
                var procesoAppServices = new ProcesoAppServices(_Db, DomainProceso);
                var fincaProceso = new FincaProcesoController(_Db, procesoAppServices);
                await fincaProceso.cambiarEstadoFincaProceso(inspeccion.idProceso, PropiedadesDeModelos.estadoInspeccionado);

                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }

        }

        [HttpPut("{idInspeccion}")]

        public async Task<ActionResult> putFincaEvaluacion(int idInspeccion, FincaInspeccion inspeccion)
        {
            if (idInspeccion == Convert.ToInt32(inspeccion.idInspeccion))
            {
                _Db.Entry(inspeccion).State = EntityState.Modified;
                await _Db.SaveChangesAsync();
                return Ok();
            }

            return BadRequest();

        }

        [HttpDelete("{idInspeccion}")]
        public async Task<ActionResult> deleteFincaInspeccion(int idInspeccion)
        {
            var inspeccion = await _Db.FincaInspeccion.FindAsync(idInspeccion);
            if (inspeccion == null || inspeccion.estado!= PropiedadesDeModelos.estadoCreado)
            {
                return NotFound();
            }
            _Db.FincaInspeccion.Remove(inspeccion);
            await _Db.SaveChangesAsync();
            return Ok();
        }

    }
}