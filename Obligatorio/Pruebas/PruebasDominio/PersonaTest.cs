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

        [TestMethod]
        public void FotoPersonaTest()
        {
            Persona persona = new Persona() { Nombre = "Guillermo del Toro", FotoPerfil = "ruta" };
            Assert.AreEqual(persona.FotoPerfil, "ruta");
        }

        [TestMethod]
        public void FechaNacimientoTest()
        {
            DateTime fechaNac = new DateTime(1980, 10, 30);
            Persona persona = new Persona() { Nombre = "Guillermo del Toro", FechaNacimiento = fechaNac };
            Assert.AreEqual(persona.FechaNacimiento, fechaNac);
        }

        [TestMethod]
        [ExpectedException(typeof(FechaInvalidaException))]
        public void FechaInvalidaTest()
        {
            DateTime fechaNac = new DateTime(2023, 10, 30);
            Persona persona = new Persona() { Nombre = "Guillermo del Toro", FechaNacimiento = fechaNac };
        }
    }
}
