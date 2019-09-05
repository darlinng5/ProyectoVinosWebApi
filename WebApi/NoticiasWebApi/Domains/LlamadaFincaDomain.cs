using ProyectoVinowWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoVinowWebApi.Domains
{
    public class LlamadaFincaDomain
    {
        public string validarParaIngresoDeLlamada(LLamadasAFinca llamada)
        {
            bool fechaInvalida = llamada.fechaLLamada > llamada.fechaVisita;
            if (fechaInvalida)
            {
                return "Las fechas de llamada y visitas son invalidas";
            }

            var IdProcesoNoValido = 0;
            if (llamada.idProceso == IdProcesoNoValido)
            {
                return "Id de proceso no valido";
            }

            return null;
        }
    }
}
