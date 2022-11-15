using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Dominio;
using Dominio.Exceptions;
using Repositorio.EnDataBase;

namespace Pruebas.PruebasDominio
{
    [TestClass]
    public class PersonaTest
    {
        [TestInitialize]
        public void Setup()
        {
            DBCleanUp.CleanUp();
        }

        [TestMethod]
        public void NombrePersonaTest()
        {
            Persona unaPersona = new Persona()
            {
                Nombre = "Guillermo del Toro"
            };
            Assert.AreEqual(unaPersona.Nombre, "Guillermo del Toro");
        }

        [TestMethod]
        [ExpectedException(typeof(NombrePersonaVacioException))]
        public void NombrePersonaVacioTest()
        {
            Persona unaPersona = new Persona()
            {
                Nombre = ""
            };
        }

    }
}
