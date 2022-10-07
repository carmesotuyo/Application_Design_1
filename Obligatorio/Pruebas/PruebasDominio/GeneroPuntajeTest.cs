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
    }
}
