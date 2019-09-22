using NoticiasWebApi.Models;
using ProyectoVinowWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoVinowWebApi.Domains
{
    public class EvaluacionDomain
    {
        public string validarEvaluacion(FincaEvaluacion fincaEvaluacion)
        {
            bool estaVacio = fincaEvaluacion == null;

            if (estaVacio)
            {
                return "No hay Datos";
            }

            bool estadoVacio = fincaEvaluacion.estado == string.Empty;
            if (estadoVacio)
            {
                return "El estado esta vacio";
            }

            bool estadoEsIncorrecto = fincaEvaluacion.estado != PropiedadesDeModelos.estadoCreado;
            if (estadoEsIncorrecto)
            {
                return "El estado es incorrecto";
            }

            bool fechaIncorrecta = fincaEvaluacion.fechaVisita > fincaEvaluacion.fechaInspeccion;
            if (fechaIncorrecta)
            {
                return "La fecha de la evaluacion es mayor a la de inspeccion";
            }

            bool ProcesoIncorrectoFinca = fincaEvaluacion.idProceso == 0;
            if (ProcesoIncorrectoFinca)
            {
                return "Proceso no valido";
            }

            

            return null;
        }
    }
}
