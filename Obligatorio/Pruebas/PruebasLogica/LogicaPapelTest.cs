using Dominio;
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
        static Persona actor = new Persona() { Id = 1 };
        static Genero accion = new Genero() { Nombre = "accion" };
        static Pelicula pelicula = new Pelicula()
        {
            Identificador = 1,
            Nombre = "nombre",
            GeneroPrincipal = accion,
            Descripcion = "algo",
            Poster = "ruta"
        };
        Usuario admin = new Usuario() { EsAdministrador = true };
        ILogicaPapel logicaPapel = new LogicaPapel(new PapelDBRepo());
        ILogicaPelicula logicaPelicula = new LogicaPelicula(new PeliculaDBRepo(), new PerfilDBRepo());
        ILogicaPersona logicaPersona = new LogicaPersona(new PersonaDBRepo());
        ILogicaGenero logicaGenero = new LogicaGenero(new GeneroDBRepo());

        Papel papel = new Papel() { Nombre = "Harry", Actor = actor, Pelicula = pelicula };

        [TestInitialize]
        public void Setup()
        {
            DBCleanUp.CleanUp();
            logicaGenero.AgregarGenero(admin, accion);
            logicaPelicula.AltaPelicula(pelicula, admin);
            logicaPersona.AltaPersona(actor, admin);
        }

        [TestMethod]
        public void AsociarActorPeliculaTest()
        {
            logicaPapel.AsociarActorPelicula(papel, admin);

            Assert.IsTrue(logicaPapel.Papeles().Contains(papel));
        }

        [TestMethod]
        public void DesasociarActorPeliculaTest()
        {
            logicaPapel.AsociarActorPelicula(papel, admin);
            logicaPapel.DesasociarActorPelicula(papel, admin);

            Assert.IsFalse(logicaPapel.Papeles().Contains(papel));
        }
    }
}
