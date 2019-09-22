using Microsoft.VisualStudio.TestTools.UnitTesting;
using NoticiasWebApi.Models;
using ProyectoVinowWebApi.Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProyectoVinos.TestsDelProyecto
{
    [TestClass]
    public class TestProceso
    {
        [TestMethod]
        public void validarTamanioDelNombre()
        {
            var procesPrueba = procesoDataPrueba();
            ProcesoDomain _procesoDomain = new ProcesoDomain();
            var respuesta = _procesoDomain.ValidarPostProceso(procesPrueba);

            Assert.AreEqual("El nombre del proceso de finca es demasido largo", respuesta);
        }

        [TestMethod]
        public void validarFechaInicio()
        {
            var procesPrueba = procesoDataPrueba();
            ProcesoDomain _procesoDomain = new ProcesoDomain();
            var respuesta = _procesoDomain.ValidarPostProceso(procesPrueba);

            Assert.AreEqual("La fecha de inicio es invalida", respuesta);
        }

        [TestMethod]
        public void validarIdFincaCorreto()
        {
            var procesPrueba = procesoDataPrueba();
            ProcesoDomain _procesoDomain = new ProcesoDomain();
            var respuesta = _procesoDomain.ValidarPostProceso(procesPrueba);

            Assert.AreEqual("El id de la finca es invalido", respuesta);
        }

        [TestMethod]
        public void validarIdProductoCorrecto()
        {
            var procesPrueba = procesoDataPrueba();
            ProcesoDomain _procesoDomain = new ProcesoDomain();
            var respuesta = _procesoDomain.ValidarPostProceso(procesPrueba);

            Assert.AreEqual("El id de producto es incorrecto", respuesta);
        }

        [TestMethod]
        public void validarEstadoDelProceso()
        {
            var procesPrueba = procesoDataPrueba();
            ProcesoDomain _procesoDomain = new ProcesoDomain();
            var respuesta = _procesoDomain.ValidarPostProceso(procesPrueba);

            Assert.AreEqual("El estado es incorrecto", respuesta);
        }

        [TestMethod]
        public void validarProcesoCompleto()
        {


            var procesPrueba = procesoDataPrueba();
            ProcesoDomain _procesoDomain = new ProcesoDomain();
            var respuesta = _procesoDomain.ValidarPostProceso(procesPrueba);

            Assert.AreEqual(null, respuesta);
        }


        public FincaProceso procesoDataPrueba()
        {
            Productos producto = new Productos();
            Finca finca = new Finca();
            FincaProceso proceso = new FincaProceso();

            proceso.nombre = "Nombre de proceso";
            proceso.Productos = producto;
            proceso.idProducto = 0;
            proceso.idFinca = 1;
            proceso.Finca = finca;
            proceso.fechaInicio = DateTime.Now;
            proceso.estado = PropiedadesDeModelos.estadoCreado;

            return proceso;
        }
    }
}
