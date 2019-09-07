﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoticiasWebApi;
using NoticiasWebApi.Models;
using NoticiasWebApi.Services;
using ProyectoVinowWebApi.AppServices;

namespace ProyectoVinowWebApi.Controllers
{
    [Route("api/proceso")]
    [ApiController]
    public class FincaProcesoController : ControllerBase
    {   
        private readonly DBContext _Db;
        public readonly ProcesoAppServices _procesoAppServices;
        public FincaProcesoController(DBContext _DBcontext, ProcesoAppServices procesoAppServices)
        {
            _Db = _DBcontext;
            _procesoAppServices = procesoAppServices;
        }       

     
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FincaProceso>>> getFincaProcesos()
        {
            //return await _Db.FincaProceso.ToArrayAsync();
            return await _Db.FincaProceso.Include(x => x.Finca).Include(f => f.Productos).Include(g=>g.Productos.Semilla).ToArrayAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<FincaProceso>> getFincaProceso(int id)
        {
            return await _Db.FincaProceso.Include(x=>x.Finca).FirstOrDefaultAsync(i=>i.idProceso==id);
        }

        [HttpPost]
        public async Task<ActionResult<FincaProceso>> postFincaProceso(FincaProceso proceso)
        {
            var respuesta = await _procesoAppServices.RegistrarFinca(proceso);
            if (respuesta == null)
            {
                return Ok("Guardado exitosamente");
            }
            else
            {
                return BadRequest(respuesta);
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



        public async Task<ActionResult> cambiarEstadoFincaProceso(int idFincaProceso, string estado)
        {
            var FincaProceso = await _Db.FincaProceso.FindAsync(idFincaProceso);
            if (FincaProceso == null || FincaProceso.estado==estado)
            {
                return BadRequest();
            }

            bool puedoEvaluar = FincaProceso.estado == PropiedadesDeModelos.estadoCreado && estado == PropiedadesDeModelos.estadoEvaluado;
            if (puedoEvaluar)
            {
                FincaProceso.estado = PropiedadesDeModelos.estadoEvaluado ;
               await _Db.SaveChangesAsync();
                return Ok();
            }
            bool puedoInspeccionar = FincaProceso.estado == PropiedadesDeModelos.estadoEvaluado && estado == PropiedadesDeModelos.estadoInspeccionado;
            if (puedoInspeccionar)
            {
                FincaProceso.estado = PropiedadesDeModelos.estadoInspeccionado;
                await _Db.SaveChangesAsync();
                return Ok();
            }

            return BadRequest();
        }



    }
}