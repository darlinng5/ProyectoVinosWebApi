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
            int maximoCarctereseParaNombre = 10;

            if (finca == null)
            {
                return "Por favor ingrese datos para la finca";
            }

            if (finca.nombre.Count() > maximoCarctereseParaNombre)
            {
                return "El nombre contiene mas de "+maximoCarctereseParaNombre + " Caracteres";
            }

            if (finca.estado != "Iniciado")
            {
                return "El estado de la finca no es correcto";
            }

            return null;
        }


    }
}
