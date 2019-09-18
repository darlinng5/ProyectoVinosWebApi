using NoticiasWebApi;
using NoticiasWebApi.Models;
using ProyectoVinowWebApi.Domains;
using ProyectoVinowWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoVinowWebApi.AppServices
{    
    public class SemillaAppServices
    {
        private readonly DBContext _DB;
        private readonly SemillaDomain _semillaDomain;

        public SemillaAppServices(DBContext dBContext, SemillaDomain semillaDomain)
        {
            _DB = dBContext;
            _semillaDomain = semillaDomain;
        }

        public async Task<string> ingresarSemilla(Semilla semilla)
        {
            var respuestaSemillaDomain = _semillaDomain.validarIngresoSemilla();
            bool vieneErrorDelDomain = respuestaSemillaDomain != null;

            if (vieneErrorDelDomain)
            {
                return respuestaSemillaDomain;
            }

            try
            {
                semilla.estado = PropiedadesDeModelos.estadoCreado;
                _DB.Add(semilla);
                await _DB.SaveChangesAsync();
            }
            catch (Exception e)
            {

                return e.Message;
            }
            return null;
        }
    }
}
