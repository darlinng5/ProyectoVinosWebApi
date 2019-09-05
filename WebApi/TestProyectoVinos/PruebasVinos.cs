using Microsoft.VisualStudio.TestTools.UnitTesting;
using NoticiasWebApi.Models;
using ProyectoVinowWebApi.Domains;
using System.Collections.Generic;

namespace TestProyectoVinos
{
    [TestClass]
    public class FincaTest
    {
        [TestMethod]
        public void TestValidarNombreDeFincaFinca()
        {
            var finca = DatosFinca();

            FincaAppDomain FincaDomain = new FincaAppDomain();

            var respuesta = FincaDomain.RegistrarFinca(finca);
            Assert.AreEqual("El nombre contiene mas de 10 Caracteres", respuesta);

        }

        [TestMethod]
        public void TestVerificarEstadoDeFinca()
        {
            var finca = DatosFinca();

            FincaAppDomain FincaDomain = new FincaAppDomain();

            var respuesta = FincaDomain.RegistrarFinca(finca);
            Assert.AreEqual("El estado de la finca no es correcto", respuesta);

        }


        private Finca DatosFinca()
        {
            Finca finca = new Finca();
            finca.nombre = "SanCarlos";
            finca.descripcion = "Muy buena finca";
            finca.departamento = "Santa Barabara";
            finca.municipio = "Azacualpa";
            finca.estado = "Iniciada";

            return finca;
        }
    }
}
