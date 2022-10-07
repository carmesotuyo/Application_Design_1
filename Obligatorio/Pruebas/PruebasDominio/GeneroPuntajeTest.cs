using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Dominio;

namespace Pruebas.PruebasDominio
{
    [TestClass]
    public class GeneroPuntajeTest
    {
        [TestMethod]
        public void PuntajeEnCero()
        {
            //arrange
            GeneroPuntaje unGeneroPuntaje = new GeneroPuntaje();

            //assert
            Assert.AreEqual(unGeneroPuntaje.Puntaje, 0);

        }

        [TestMethod]
        public void SumarPuntaje()
        {
            //arrange
            GeneroPuntaje unGeneroPuntaje = new GeneroPuntaje();
            unGeneroPuntaje.ModificarPuntaje(3);

            //assert
            Assert.AreEqual(unGeneroPuntaje.Puntaje, 3);

        }

        [TestMethod]
        public void SumarPuntajeNegativo()
        {
            //arrange
            GeneroPuntaje unGeneroPuntaje = new GeneroPuntaje();
            unGeneroPuntaje.ModificarPuntaje(3);
            unGeneroPuntaje.ModificarPuntaje(-5);

            //assert
            Assert.AreEqual(unGeneroPuntaje.Puntaje, -2);

        }

        [TestMethod]
        public void NombreGeneroValido()
        {
            //arrange
            GeneroPuntaje unGeneroPuntaje = new GeneroPuntaje()
            {
                Genero = Terror;
            }

            //assert
            Assert.AreEqual(unGeneroPuntaje.Genero, "Terror");

        }
    }
}
