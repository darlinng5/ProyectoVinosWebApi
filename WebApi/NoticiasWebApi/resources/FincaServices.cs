using NoticiasWebApi;
using NoticiasWebApi.Models;
using ProyectoVinowWebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoVinowWebApi.AplicationServices
{
    public class FincaServices
    {
        private readonly DBContext _Db;
        private readonly FincaDomain _fincaDomain;
        public FincaServices(DBContext db, FincaDomain fincaDomain)
        {
            _Db = db;
            _fincaDomain = fincaDomain;

        }


        public async Task<string> RegistrarFinca(Finca finca)
        {

          
            var respuesta= _fincaDomain.RegistrarFinca(finca);

            bool vieneConErrorDelDomain = respuesta != null;
            if (vieneConErrorDelDomain)
            {
                return respuesta;
            }


                finca.estado = PropiedadesDeModelos.estadoCreado;
                _Db.Finca.Add(finca);
                await _Db.SaveChangesAsync();

                return null;
        }
    }
}
