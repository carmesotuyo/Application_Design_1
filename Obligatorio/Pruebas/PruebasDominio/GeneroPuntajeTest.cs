using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Dominio;
using Dominio.Exceptions;

namespace Pruebas.PruebasDominio
{
    [TestClass]
    public class GeneroPuntajeTest
    {
        [TestMethod]
        public void PuntajeEnCeroTest()
        {
            GeneroPuntaje unGeneroPuntaje = new GeneroPuntaje();

            Assert.AreEqual(unGeneroPuntaje.Puntaje, 0);

        }

        [TestMethod]
        public void SumarPuntajeTest()
        {
            //arrange
            GeneroPuntaje unGeneroPuntaje = new GeneroPuntaje();
            unGeneroPuntaje.ModificarPuntaje(3);

            //assert
            Assert.AreEqual(unGeneroPuntaje.Puntaje, 3);

        }

        [TestMethod]
        public void SumarPuntajeNegativoTest()
        {
            //arrange
            GeneroPuntaje unGeneroPuntaje = new GeneroPuntaje();
            unGeneroPuntaje.ModificarPuntaje(3);
            unGeneroPuntaje.ModificarPuntaje(-5);

            //assert
            Assert.AreEqual(unGeneroPuntaje.Puntaje, -2);

        }

        [TestMethod]
        public void NombreGeneroValidoTest()
        {
            //arrange
            GeneroPuntaje unGeneroPuntaje = new GeneroPuntaje()
            {
                Genero = "Terror"
            };

            //assert
            Assert.AreEqual(unGeneroPuntaje.Genero, "Terror");

        }

        [TestMethod]
        [ExpectedException(typeof(DatoVacioException))]
        public void NombreGeneroVacioTest()
        {
            //arrange
            GeneroPuntaje unGeneroPuntaje = new GeneroPuntaje()
            {
                Genero = ""
            };

        }
    }
}

