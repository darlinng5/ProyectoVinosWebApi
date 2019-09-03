using NoticiasWebApi;
using ProyectoVinowWebApi.Domains;
using ProyectoVinowWebApi.Models;
using System;
using NoticiasWebApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoVinowWebApi.AppServices
{
    public class LlamadaAppServices
    {
        private readonly DBContext _DB;
        private readonly LlamadaFincaDomain _LlamadaAppDomain;
        public LlamadaAppServices(DBContext db, LlamadaFincaDomain LlamadaDomain)
        {
            _DB = db;
            _LlamadaAppDomain = LlamadaDomain;
        }

        public async Task<string> HacerLlamada(LLamadasAFinca llamadaFinca)
        {
            var respuesta = _LlamadaAppDomain.validarParaIngresoDeLlamada(llamadaFinca);
            bool ErrorEnDomainDeLLamada = respuesta != null;
            if (ErrorEnDomainDeLLamada)
            {
                return respuesta;
            }

            try
            {
                _DB.LLamadasAFinca.Add(llamadaFinca);
                await _DB.SaveChangesAsync();

                return null;
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }
    }
}
