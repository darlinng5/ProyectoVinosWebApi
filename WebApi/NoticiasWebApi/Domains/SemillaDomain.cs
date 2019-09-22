using NoticiasWebApi.Models;
using ProyectoVinowWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoVinowWebApi.Domains
{
    public class SemillaDomain
    {
        public string validarIngresoSemilla(Semilla semilla)
        {
            bool modeloSemillaEstaVacio = semilla == null;
            if (modeloSemillaEstaVacio)
            {
                return "El modelo esta vacio";
            }

            bool nombreEstaVacio = semilla.nombre == null;
            if (nombreEstaVacio)
            {
                return "El nombre esta vacio";
            }

            bool descripcionEstaVacio = semilla.descripcion == null;
            if (descripcionEstaVacio)
            {
                return "No hay descripcion de la semilla";
            }

            bool estadoIncorrecto = semilla.estado != PropiedadesDeModelos.estadoCreado;
            if (estadoIncorrecto)
            {
                return "El estado es incorrecto";
            }

            return null;
        }
    }
}
