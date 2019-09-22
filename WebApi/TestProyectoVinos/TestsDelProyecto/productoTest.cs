using Microsoft.VisualStudio.TestTools.UnitTesting;
using NoticiasWebApi.Models;
using ProyectoVinowWebApi.Domains;
using ProyectoVinowWebApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProyectoVinos.TestsDelProyecto
{
    [TestClass]
    public class productoTest
    {
        [TestMethod]
        public void validarModelo()
        {
            var dataProducto = DataProducto();
            ProductoDomain productoDomain = new ProductoDomain();
            var respuetsa = productoDomain.validarIngresoProducto(dataProducto);

            Assert.AreEqual("El modelo de producto esta vacio", respuetsa);
        }

        [TestMethod]
        public void validarNombreProducto()
        {
            var dataProducto = DataProducto();
            ProductoDomain productoDomain = new ProductoDomain();
            var respuetsa = productoDomain.validarIngresoProducto(dataProducto);

            Assert.AreEqual("El nombre del producto esta vacio", respuetsa);
        }

        [TestMethod]
        public void validarEstado()
        {
            var dataProducto = DataProducto();
            ProductoDomain productoDomain = new ProductoDomain();
            var respuetsa = productoDomain.validarIngresoProducto(dataProducto);

            Assert.AreEqual("El estado es incorrecto", respuetsa);
        }


        public Productos DataProducto()
        {
            Productos producto = new Productos();
            producto.nombre = "uva";
            producto.idSemilla = 1;
            producto.estado = PropiedadesDeModelos.estadoCreado;

            return producto;
        }
    }
}
