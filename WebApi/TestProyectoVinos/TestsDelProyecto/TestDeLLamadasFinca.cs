using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoVinowWebApi.Domains;
using ProyectoVinowWebApi.Models;
using System;
using NoticiasWebApi;
using ProyectoVinowWebApi.AppServices;

namespace TestProyectoVinos.TestsDelProyecto
{
    [TestClass]
   public class TestDeLLamadasFinca
    {
        [TestMethod]
        public void validarIdDeProcesoDeFincaLLamada()
        {
            var llamadaData = LlamadaAfincaData();

            LlamadaFincaDomain llamadaDomain = new LlamadaFincaDomain();
            var respuestaValidacion = llamadaDomain.validarParaIngresoDeLlamada(llamadaData);

            Assert.AreEqual("Id de proceso no valido", respuestaValidacion);
        }


        [TestMethod]
        public void validarFechasCorrectas()
        {
            var llamadaData = LlamadaAfincaData();
            LlamadaFincaDomain llamadaFincaDomain = new LlamadaFincaDomain();
            var respuesta = llamadaFincaDomain.validarParaIngresoDeLlamada(llamadaData);

            if (respuesta != null)
            {
                Assert.AreEqual("Las fechas de llamada y visitas son invalidas", respuesta);
            }
            else
            {
                Assert.AreEqual(null, respuesta);
            }
            
        }

        public LLamadasAFinca LlamadaAfincaData()
        {
            LLamadasAFinca llamada = new LLamadasAFinca();
            llamada.fechaLLamada = DateTime.Today;
            llamada.fechaVisita = DateTime.Now;
            llamada.observacion = "Ninguna";
            llamada.idProceso = 0;

            return llamada;
        }
    }
}
