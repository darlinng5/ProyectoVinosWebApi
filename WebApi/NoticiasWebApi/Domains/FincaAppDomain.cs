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
            

            if (finca == null)
            {
                return "Por favor ingrese datos para la finca";
            }


            int maximoCarcteresParaNombre = 20;
            var nombreEsDemasiadoLargo = finca.nombre.Count() > maximoCarcteresParaNombre;
            var nombreEstaEnBlanco = finca.nombre == string.Empty;

            if (nombreEstaEnBlanco)
            {
                return "El nombre no puede ser nulo.";
            }

            if (nombreEsDemasiadoLargo)
            {
                return "El nombre contiene mas caracteres de lo permitido.";

            }

            if (finca.estado != "Iniciado")
            {
                return "El estado de la finca no es correcto";
            }

            return null;
        }


    }
}
