using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Dominio.Exceptions;

namespace Pruebas.PruebasDominio
{
    [TestClass]
    public class GeneroTest
    {
        Genero unGenero = new Genero();

        [TestMethod]
        public void NombreGeneroValidoTest()
        {
            unGenero.Nombre = "Terror";

            Assert.AreEqual(unGenero.Nombre, "Terror");
        }

        [TestMethod]
        [ExpectedException(typeof(DatoVacioException))]
        public void NombreGeneroInvalidoTest()
        {
            string nombreVacio = "";

            unGenero.Nombre = nombreVacio;
        }

        [TestMethod]
        public void DescripcionGeneroValida()
        {
            unGenero.Descripcion = "Descripcion de prueba";

            Assert.AreEqual(unGenero.Descripcion, "Descripcion de prueba");
        }

        [TestMethod]
        public void DevolverNombreTest()
        {
            unGenero.Nombre = "terror";

            Assert.AreEqual(unGenero.ToString(), "Terror");
        }
    }
}
