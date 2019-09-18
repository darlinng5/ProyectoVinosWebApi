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
    public class InspeccionAppServices
    {
        private readonly DBContext _dB;
        private readonly InspeccionDomain _InspeccionDomain;

        public InspeccionAppServices(DBContext dBContext, InspeccionDomain inspeccionDomain)
        {
            _dB = dBContext;
            _InspeccionDomain = inspeccionDomain;
        }

        public async Task<string> IngresarInspeccion(FincaInspeccion inspeccion)
        {
            var respuestaDomain = _InspeccionDomain.validarInspeccion();
            bool errorEnDomain = respuestaDomain != null;

            if (errorEnDomain)
            {
                return respuestaDomain;
            }

            try
            {
                _dB.FincaInspeccion.Add(inspeccion);
                await _dB.SaveChangesAsync();
                var DomainProceso = new ProcesoDomain();
                var procesoAppServices = new ProcesoAppServices(_dB, DomainProceso);
                var fincaProceso = new FincaProcesoController(_dB, procesoAppServices);
                await fincaProceso.cambiarEstadoFincaProceso(inspeccion.idProceso, PropiedadesDeModelos.estadoInspeccionado);

            }
            catch (Exception e)
            {
                return e.Message;               
            }
            return null;
        }
    }
}
