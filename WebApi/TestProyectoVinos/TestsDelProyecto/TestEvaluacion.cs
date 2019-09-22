using Microsoft.VisualStudio.TestTools.UnitTesting;
using NoticiasWebApi;
using NoticiasWebApi.Models;
using ProyectoVinowWebApi.AppServices;
using ProyectoVinowWebApi.Domains;
using ProyectoVinowWebApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProyectoVinos.TestsDelProyecto
{
    [TestClass]
    public class TestEvaluacion
    {
        [TestMethod]
        public void validarDataEvaluacion()
        {
            var dataEvaluacion = DataEvaluacion();
            EvaluacionDomain evaluacionDomain = new EvaluacionDomain();
            var respuestaDomain = evaluacionDomain.validarEvaluacion(dataEvaluacion);

            Assert.AreEqual("No hay Datos", respuestaDomain);

        }

        [TestMethod]
        public void validarEstado()
        {
            var dataEvaluacion = DataEvaluacion();
            EvaluacionDomain evaluacionDomain = new EvaluacionDomain();
            var respuestaDomain = evaluacionDomain.validarEvaluacion(dataEvaluacion);

            Assert.AreEqual("El estado esta vacio", respuestaDomain);
        }

        [TestMethod]
        public void validarEstadoIncorrecto()
        {
            var dataEvaluacion = DataEvaluacion();
            EvaluacionDomain evaluacionDomain = new EvaluacionDomain();
            var respuestaDomain = evaluacionDomain.validarEvaluacion(dataEvaluacion);

            Assert.AreEqual("El estado es incorrecto", respuestaDomain);
        }

        [TestMethod]
        public void validarFecha()
        {
            var dataEvaluacion = DataEvaluacion();
            EvaluacionDomain evaluacionDomain = new EvaluacionDomain();
            var respuestaDomain = evaluacionDomain.validarEvaluacion(dataEvaluacion);

            Assert.AreEqual("La fecha de la evaluacion es mayor a la de inspeccion", respuestaDomain);
        }

        [TestMethod]
        public void validarProceso()
        {
            var dataEvaluacion = DataEvaluacion();
            EvaluacionDomain evaluacionDomain = new EvaluacionDomain();
            var respuestaDomain = evaluacionDomain.validarEvaluacion(dataEvaluacion);

            Assert.AreEqual("Proceso no valido", respuestaDomain);
        }

        public FincaEvaluacion DataEvaluacion()
        {
            FincaEvaluacion fincaEvaluacion = new FincaEvaluacion();
            fincaEvaluacion.fechaVisita = DateTime.Today;
            fincaEvaluacion.fechaInspeccion = DateTime.Now;
            fincaEvaluacion.idProceso = 1;
            fincaEvaluacion.observacion = "Buena tierra";
            fincaEvaluacion.valoracionTerreno = "Tierra apta para la cosecha de viños";
            fincaEvaluacion.estado = PropiedadesDeModelos.estadoCreado;

            fincaEvaluacion.idProceso = 0;

            return fincaEvaluacion;
        }
    }
}
