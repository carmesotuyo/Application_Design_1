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
        [TestMethod]
        public void NombreGeneroValidoTest()
        {
            Genero unGenero = new Genero();
            unGenero.Nombre = "Terror";
            Assert.AreEqual(unGenero.Nombre, "Terror");
        }

        [TestMethod]
        [ExpectedException(typeof(DatoVacioException))]
        public void NombreGeneroInvalidoTest()
        {
            Genero unGenero = new Genero();
            string nombreVacio = "";
            unGenero.Nombre = nombreVacio;
        }

        [TestMethod]
        public void DescripcionGeneroValida()
        {
            Genero unGenero = new Genero();

            unGenero.Descripcion = "Descripcion de prueba";

            Assert.AreEqual(unGenero.Descripcion, "Descripcion de prueba");
        }
    }
}
