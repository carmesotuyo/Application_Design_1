using Dominio;
using Dominio.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pruebas.PruebasDominio
{
    [TestClass]
    public class PapelTest
    {
        Papel papel = new Papel();
        Persona actor = new Persona();
        Pelicula pelicula = new Pelicula();

        [TestMethod]
        public void NombrePapelValidoTest()
        {
            papel.Nombre = "Harry Potter";

            Assert.AreEqual(papel.Nombre, "Harry Potter");
        }

        [TestMethod]
        [ExpectedException(typeof(DatoVacioException))]
        public void NombrePapelInvalidoTest()
        {
            papel.Nombre = "";
        }

        [TestMethod]
        public void ActorValidoTest()
        {
            papel.Actor = actor;
            Assert.AreEqual(papel.Actor, actor);
        }

        [TestMethod]
        [ExpectedException(typeof(NullException))]
        public void ActorInvalidoTest()
        {
            papel.Actor = null;
        }

        [TestMethod]
        public void PeliculaValidaTest()
        {
            papel.Pelicula = pelicula;
            Assert.AreEqual(papel.Pelicula, pelicula);
        }

        [TestMethod]
        [ExpectedException(typeof(NullException))]
        public void PeliculaInvalidaTest()
        {
            papel.Pelicula = null;
        }
    }
}
