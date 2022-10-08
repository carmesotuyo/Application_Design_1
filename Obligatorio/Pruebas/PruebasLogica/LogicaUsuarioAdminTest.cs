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
        [TestMethod]
        public void AltaPeliculaTest()
        {
            Usuario admin = new Usuario() { EsAdministrador = true };
            LogicaUsuarioAdmin logica = new LogicaUsuarioAdmin();
            Pelicula unaPelicula = new Pelicula();
            PeliculaRepo repo = new PeliculaRepo();

            logica.AltaPelicula(admin, unaPelicula, repo);
            Assert.IsTrue(repo.EstaPelicula(unaPelicula));
        }

        [TestMethod]
        [ExpectedException(typeof(UsuarioNoPermitidoException))]
        public void AltaPeliculaUsuarioNoPermitidoTest()
        {
            Usuario usuarioComun = new Usuario() { EsAdministrador = false };
            LogicaUsuarioAdmin logica = new LogicaUsuarioAdmin();
            Pelicula unaPelicula = new Pelicula();
            PeliculaRepo repo = new PeliculaRepo();

            logica.AltaPelicula(usuarioComun, unaPelicula, repo);
        }

        [TestMethod]
        public void BajaPeliculaTest()
        {
            Usuario admin = new Usuario() { EsAdministrador = true };
            LogicaUsuarioAdmin logica = new LogicaUsuarioAdmin();
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
            Usuario admin = new Usuario() { EsAdministrador = true };
            Usuario usuarioComun = new Usuario() { EsAdministrador = false };
            LogicaUsuarioAdmin logica = new LogicaUsuarioAdmin();
            Pelicula unaPelicula = new Pelicula();
            PeliculaRepo repo = new PeliculaRepo();

            logica.AltaPelicula(admin, unaPelicula, repo);
            logica.BajaPelicula(usuarioComun, unaPelicula, repo);
        }
    }
}
