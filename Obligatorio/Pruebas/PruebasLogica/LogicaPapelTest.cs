using Dominio;
using Logica.Exceptions;
using Logica.Implementaciones;
using Logica.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositorio.EnDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pruebas.PruebasLogica
{
    [TestClass]
    public class LogicaPapelTest
    {
        ILogicaPapel logicaPapel = new LogicaPapel(new PapelDBRepo());
        ILogicaPelicula logicaPelicula = new LogicaPelicula(new PeliculaDBRepo(), new PerfilDBRepo(), new PersonaDBRepo());
        ILogicaPersona logicaPersona = new LogicaPersona(new PersonaDBRepo());
        ILogicaGenero logicaGenero = new LogicaGenero(new GeneroDBRepo());

        static Persona actor;
        static Genero accion;
        static Pelicula pelicula;
        Usuario admin;
        Usuario comun;

        [TestInitialize]
        public void Setup()
        {
            DBCleanUp.CleanUp();

            actor = new Persona() { Id = 1, Nombre = "daniel", FotoPerfil = "foto" };
            accion = new Genero() { Nombre = "accion" };
            pelicula = new Pelicula()
            {
                Identificador = 1,
                Nombre = "nombre",
                GeneroPrincipal = accion,
                Descripcion = "algo",
                Poster = "ruta"
            };
            admin = new Usuario() { EsAdministrador = true };
            comun = new Usuario() { EsAdministrador = false };

            logicaGenero.AgregarGenero(admin, accion);
            logicaPelicula.AltaPelicula(pelicula, admin);
            logicaPersona.AltaPersona(actor, admin);
        }

        [TestMethod]
        public void AsociarActorPeliculaTest()
        {
            Papel papel = new Papel() { Nombre = "Harry", Actor = actor, Pelicula = pelicula };
            logicaPapel.AsociarActorPelicula(papel, admin);

            Assert.IsTrue(logicaPapel.Papeles().Contains(papel));
        }

        [TestMethod]
        [ExpectedException(typeof(UsuarioNoPermitidoException))]
        public void AsociarSinPermisoTest()
        {
            Papel papel = new Papel() { Nombre = "Harry", Actor = actor, Pelicula = pelicula };
            logicaPapel.AsociarActorPelicula(papel, comun);
        }

        [TestMethod]
        public void DesasociarActorPeliculaTest()
        {
            Papel papel = new Papel() { Nombre = "Harry", Actor = actor, Pelicula = pelicula };
            logicaPapel.AsociarActorPelicula(papel, admin);
            logicaPapel.DesasociarActorPelicula(papel, admin);

            Assert.IsFalse(logicaPapel.Papeles().Contains(papel));
        }

        [TestMethod]
        [ExpectedException(typeof(UsuarioNoPermitidoException))]
        public void DesasociarSinPermisoTest()
        {
            Papel papel = new Papel() { Nombre = "Harry", Actor = actor, Pelicula = pelicula };
            logicaPapel.AsociarActorPelicula(papel, admin);
            logicaPapel.DesasociarActorPelicula(papel, comun);
        }
    }
}
