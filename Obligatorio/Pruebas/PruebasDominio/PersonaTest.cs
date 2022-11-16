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

        [TestMethod]
        public void AgregarPapelQueActuaTest()
        {
            Papel papel = new Papel();
            Persona persona = new Persona();
            persona.PapelesQueActua.Add(papel);

            Assert.IsTrue(persona.PapelesQueActua.Contains(papel));
        }

        [TestMethod]
        public void QuitarPapelQueActuaTest()
        {
            Papel papel = new Papel();
            Persona persona = new Persona();
            persona.PapelesQueActua.Add(papel);

            persona.PapelesQueActua.Remove(papel);

            Assert.IsFalse(persona.PapelesQueActua.Contains(papel));
        }

        [TestMethod]
        public void AgregarPeliculaQueDirigeaTest()
        {
            Pelicula pelicula = new Pelicula();
            Persona persona = new Persona();
            persona.PeliculasQueDirige.Add(pelicula);

            Assert.IsTrue(persona.PeliculasQueDirige.Contains(pelicula));
        }

        [TestMethod]
        public void QuitarPeliculaQueDirigeTest()
        {
            Pelicula pelicula = new Pelicula();
            Persona persona = new Persona();
            persona.PeliculasQueDirige.Add(pelicula);

            persona.PeliculasQueDirige.Remove(pelicula);

            Assert.IsFalse(persona.PeliculasQueDirige.Contains(pelicula));
        }
    }
}
