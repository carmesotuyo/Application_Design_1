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

    }
}
