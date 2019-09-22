using NoticiasWebApi;
using NoticiasWebApi.Models;
using ProyectoVinowWebApi.Controllers;
using ProyectoVinowWebApi.Domains;
using ProyectoVinowWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoVinowWebApi.AppServices
{
    public class EvaluacionAppServices
    {
        private readonly DBContext _dB;
        private readonly EvaluacionDomain _EvaluacionDomain;
        public EvaluacionAppServices(DBContext db, EvaluacionDomain evaluacionDomain)
        {
            _dB = db;
            _EvaluacionDomain = evaluacionDomain;
        }

        public async Task<string> IngresarEvaluacion(FincaEvaluacion fincaEvaluacion)
        {
            var respuestaDomain = _EvaluacionDomain.validarEvaluacion(fincaEvaluacion);
            bool errorEnDomain = respuestaDomain != null;
            if (errorEnDomain)
            {
                return respuestaDomain;
            }

            try
            {
                fincaEvaluacion.estado = PropiedadesDeModelos.estadoCreado;

                _dB.FincaEvaluacion.Add(fincaEvaluacion);
                await _dB.SaveChangesAsync();
                var DomainProceso = new ProcesoDomain();
                var procesoAppServices = new ProcesoAppServices(_dB, DomainProceso);
                var fincaProceso = new FincaProcesoController(_dB, procesoAppServices);
                await fincaProceso.cambiarEstadoFincaProceso(fincaEvaluacion.idProceso, PropiedadesDeModelos.estadoEvaluado);

                return null;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
