using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoticiasWebApi.Services
{
    public class ProyectoServices
    {
        public readonly DBContext _ProyectoDB;
        public ProyectoServices(DBContext ProyectoDB)
        {
            _ProyectoDB = ProyectoDB;
        }

        //public List<Finca> VerFincas()
        //{
        //    //  var Fincas = _ProyectoDB.Finca.Include(x => x.idFinca).OrderByDescending(x=>x.idFinca).ToList();
        //    var list = _ProyectoDB.Finca.ToList();
        //    return list;
        //}

        //public List<FincaProceso> fincaProcesos()
        //{
        //    var fincaProcesos = _ProyectoDB.FincaProceso.Include(x => x.Finca).ToList();
        //    //var lista = _ProyectoDB.FincaProceso.ToList();
        //    return fincaProcesos;
        //}

        //public Finca ObtenerPorID(int FincaId)
        //{
        //    try
        //    {
        //        var FincaBuscada = _ProyectoDB.Finca.Where(x => x.idFinca == FincaId).FirstOrDefault();

        //        return FincaBuscada;
        //    }
        //    catch (Exception)
        //    {
        //        //return new Finca();
        //    }
        //}
    }
}



//namespace ProyectoVinowWebApi.Scripts
//{
//    public class ProyectoServices
//    {

//    }
//}
