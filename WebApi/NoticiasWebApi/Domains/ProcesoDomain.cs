    using NoticiasWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoVinowWebApi.Domains
{
    public class ProcesoDomain
    {
        public string validarPostProceso(FincaProceso fincaProceso)
        {
            int tamañoMaximoDelNombre = 30;

            var TamañoNoMayorAlAcordado = fincaProceso.nombre.Length > tamañoMaximoDelNombre;

            if (TamañoNoMayorAlAcordado)
            {
                return "El nombre del proceso de finca es demasido largo";
            }

            var fechaNula = fincaProceso.fechaInicio == null;
            if (fechaNula)
            {
                return "La fecha de inicio es invalida";
            }

            var IdDeFincaIncorrecto = fincaProceso.idFinca == 0;
            if (IdDeFincaIncorrecto)
            {
                return "El id de la finca es invalido";
            }

            var idProductoIncorrecto = fincaProceso.idProducto == 0;
            if (idProductoIncorrecto)
            {
                return "El id de producto es incorrecto";
            }

            var estadoNoCreado = fincaProceso.estado != "Creado";
            if (estadoNoCreado)
            {
                return "El estado es incorrecto";
            }

            return null;
        }
    }
}
