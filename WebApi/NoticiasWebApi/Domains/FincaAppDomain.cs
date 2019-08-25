using NoticiasWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoVinowWebApi.Domains
{
    public class FincaAppDomain
    {
        public string RegistrarFinca(Finca finca)
        {
            int maximoCarctereseParaNombre = 5;

            if (finca.nombre.Count() > maximoCarctereseParaNombre)
            {
                return "El nombre contiene mas de "+maximoCarctereseParaNombre+" para nombre";
            }
            return null;
        }


    }
}
