using Dominio;
using Logica.Exceptions;
using Logica.Implementaciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pruebas.PruebasLogica
{
    [TestClass]
    public class LogicaUsuarioAdminTest
    {
        Usuario admin = new Usuario() { EsAdministrador = true };
        Usuario usuarioComun = new Usuario() { EsAdministrador = false };
        LogicaUsuarioAdmin logica = new LogicaUsuarioAdmin();

        [TestMethod]
        public void AltaPeliculaTest()
        {
            Pelicula unaPelicula = new Pelicula();
            PeliculaRepo repo = new PeliculaRepo();

            logica.AltaPelicula(admin, unaPelicula, repo);
            Assert.IsTrue(repo.EstaPelicula(unaPelicula));
        }

        [TestMethod]
        [ExpectedException(typeof(UsuarioNoPermitidoException))]
        public void AltaPeliculaUsuarioNoPermitidoTest()
        {
            Pelicula unaPelicula = new Pelicula();
            PeliculaRepo repo = new PeliculaRepo();

            logica.AltaPelicula(usuarioComun, unaPelicula, repo);
        }

        [TestMethod]
        public void BajaPeliculaTest()
        {
            Pelicula unaPelicula = new Pelicula();
            PeliculaRepo repo = new PeliculaRepo();

            logica.AltaPelicula(admin, unaPelicula, repo);
            logica.BajaPelicula(admin, unaPelicula, repo);

            Assert.IsFalse(repo.EstaPelicula(unaPelicula));
        }

        [TestMethod]
        [ExpectedException(typeof(UsuarioNoPermitidoException))]
        public void BajaPeliculaUsuarioNoPermitidoTest()
        {
            Pelicula unaPelicula = new Pelicula();
            PeliculaRepo repo = new PeliculaRepo();

            logica.AltaPelicula(admin, unaPelicula, repo);
            logica.BajaPelicula(usuarioComun, unaPelicula, repo);
        }

        [TestMethod]
        public void AltaGeneroTest()
        {
            Genero unGenero = new Genero() { Nombre = "Terror" };
            GeneroRepo repo = new GeneroRepo();

            logica.AltaGenero(admin, unGenero, repo);
            Assert.IsTrue(repo.EstaGenero(unGenero));
        }

        [TestMethod]
        [ExpectedException(typeof(UsuarioNoPermitidoException))]
        public void AltaGeneroUsuarioNoPermitidoTest()
        {
            Genero unGenero = new Genero() { Nombre = "Terror" };
            GeneroRepo repo = new GeneroRepo();

            logica.AltaGenero(usuarioComun, unGenero, repo);
        }

        [TestMethod]
        public void BajaGeneroTest()
        {
            Genero unGenero = new Genero() { Nombre = "Terror" };
            GeneroRepo repo = new GeneroRepo();

            logica.AltaGenero(admin, unGenero, repo);
            logica.BajaGenero(admin, unGenero, repo);

            Assert.IsFalse(repo.EstaGenero(unGenero));
        }

        [TestMethod]
        [ExpectedException(typeof(UsuarioNoPermitidoException))]
        public void BajaGeneroUsuarioNoPermitidoTest()
        {
            Genero unGenero = new Genero() { Nombre = "Terror" };
            GeneroRepo repo = new GeneroRepo();

            logica.AltaGenero(admin, unGenero, repo);
            logica.BajaGenero(usuarioComun, unGenero, repo);
        }
    }
}
