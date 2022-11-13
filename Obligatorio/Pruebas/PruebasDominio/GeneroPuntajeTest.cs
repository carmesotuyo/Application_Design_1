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
            GeneroPuntaje unGeneroPuntaje = new GeneroPuntaje();
            unGeneroPuntaje.ModificarPuntaje(3);
            Assert.AreEqual(unGeneroPuntaje.Puntaje, 3);
        }

        [TestMethod]
        public void SumarPuntajeNegativoTest()
        {
            GeneroPuntaje unGeneroPuntaje = new GeneroPuntaje();
            unGeneroPuntaje.ModificarPuntaje(3);
            unGeneroPuntaje.ModificarPuntaje(-5);
            Assert.AreEqual(unGeneroPuntaje.Puntaje, -2);
        }

        [TestMethod]
        public void NombreGeneroValidoTest()
        {
            Genero genero = new Genero() { Nombre = "Terror" };
            GeneroPuntaje unGeneroPuntaje = new GeneroPuntaje()
            {
                Genero = genero
            };
            Assert.AreEqual(unGeneroPuntaje.Genero.Nombre, "Terror");
        }

        [TestMethod]
        [ExpectedException(typeof(DatoVacioException))]
        public void NombreGeneroVacioTest()
        {

            Genero genero = new Genero() { Nombre = "" };

            GeneroPuntaje unGeneroPuntaje = new GeneroPuntaje()
            {
                Genero = genero
            };

        }
    }
}

