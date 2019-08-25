using NoticiasWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoVinowWebApi.Domains
{
    public class FincaDomain
    {
        public string RegistrarFinca(Finca finca)
        {
            int maximoCaracteresParaNombre = 4;

            if (finca.nombre.Count() > maximoCaracteresParaNombre)
            {
                return "El nombre contiene mas de " + maximoCaracteresParaNombre + " carateres";
            }


            return null;
        }
    }
}
