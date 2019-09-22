using NoticiasWebApi.Models;
using ProyectoVinowWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoVinowWebApi.Domains
{
    public class InspeccionDomain
    {
        public string validarInspeccion(FincaInspeccion fincaInspeccion)
        {
            bool modeloFincaInspeccionEstaVacio = fincaInspeccion == null;
            if (modeloFincaInspeccionEstaVacio)
            {
                return "El modelo esta vacio";
            }

            bool fechaErronea = fincaInspeccion.fechaVisita > fincaInspeccion.fechaCompra;
            if (fechaErronea)
            {
                return "Fecha visita es mayor a la de compra";
            }

            bool estadoEstaVacio = fincaInspeccion.estado == null;
            if (estadoEstaVacio)
            {
                return "El estado esta vacio";
            }

            bool estadoIncorrecto = fincaInspeccion.estado != PropiedadesDeModelos.estadoCreado;
            if (estadoIncorrecto)
            {
                return "El estado es incorrecto";
            }

            return null;
        }
    }
}
