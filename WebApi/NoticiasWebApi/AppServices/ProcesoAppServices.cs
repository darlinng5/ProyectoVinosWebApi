using NoticiasWebApi;
using NoticiasWebApi.Models;
using ProyectoVinowWebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoVinowWebApi.AppServices
{
    public class ProcesoAppServices
    {
        private readonly DBContext _dB;
        private readonly ProcesoDomain _procesoDomain;

        public ProcesoAppServices(DBContext db, ProcesoDomain procesoDomain)
        {
            _dB = db;
            _procesoDomain = procesoDomain;
        }

        public async Task<string> RegistrarFinca(FincaProceso proceso)
        {

            var respuesta = _procesoDomain.validarPostProceso(proceso);

            bool vieneConErrorDelDomainDeProceso = respuesta != null;

            if (vieneConErrorDelDomainDeProceso)
            {
                return respuesta;
            }


            try
            {
                proceso.estado = PropiedadesDeModelos.estadoCreado;
                _dB.FincaProceso.Add(proceso);
                await _dB.SaveChangesAsync();

                return null;
            }
            catch (Exception e)
            {

                return e.Message;
            }

        }

    }
}
