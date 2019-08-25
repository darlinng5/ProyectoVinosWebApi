using NoticiasWebApi;
using NoticiasWebApi.Models;
using ProyectoVinowWebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoVinowWebApi.AppServices
{
   
    public class FincaAppServices
    {
        private readonly DBContext _dB;
        private readonly FincaAppDomain _fincaAppDomain;
        public FincaAppServices(DBContext db, FincaAppDomain fincaAppDomain)
        {
            _dB = db;
            _fincaAppDomain = fincaAppDomain;
        }


        public async Task<string> RegistrarFinca(Finca finca)
        {

            var respuesta = _fincaAppDomain.RegistrarFinca(finca);

            bool vieneConErrorDeFincaAppDomain = respuesta != null;

            if (vieneConErrorDeFincaAppDomain)
            {
                return respuesta;
            }
            

            try
            {
                finca.estado = PropiedadesDeModelos.estadoCreado;
                _dB.Finca.Add(finca);
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
