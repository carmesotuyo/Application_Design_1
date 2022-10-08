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
            Genero otroGenero = new Genero() { Nombre = "Comedia" };
            GeneroRepo repoGenero = new GeneroRepo();

            PeliculaRepo repoPelis = new PeliculaRepo();
            Pelicula pelicula = new Pelicula { GeneroPrincipal = otroGenero };
            repoPelis.AgregarPelicula(pelicula);

            logica.AltaGenero(admin, unGenero, repoGenero);
            logica.BajaGenero(admin, unGenero, repoGenero, repoPelis);

            Assert.IsFalse(repoGenero.EstaGenero(unGenero));
        }

        [TestMethod]
        [ExpectedException(typeof(UsuarioNoPermitidoException))]
        public void BajaGeneroUsuarioNoPermitidoTest()
        {
            Genero unGenero = new Genero() { Nombre = "Terror" };
            Genero otroGenero = new Genero() { Nombre = "Comedia" };
            GeneroRepo repoGenero = new GeneroRepo();

            PeliculaRepo repoPelis = new PeliculaRepo();
            Pelicula pelicula = new Pelicula { GeneroPrincipal = otroGenero };
            repoPelis.AgregarPelicula(pelicula);

            logica.AltaGenero(admin, unGenero, repoGenero);
            logica.BajaGenero(usuarioComun, unGenero, repoGenero, repoPelis);
        }

        [TestMethod]
        [ExpectedException(typeof(GeneroConPeliculaAsociadaException))]
        public void BajaGeneroConPeliculasAsociadasComoPrincipalTest()
        {
            Genero unGenero = new Genero() { Nombre = "Terror" };
            GeneroRepo repoGenero = new GeneroRepo();

            PeliculaRepo repoPelis = new PeliculaRepo();
            Pelicula pelicula = new Pelicula { GeneroPrincipal = unGenero };
            repoPelis.AgregarPelicula(pelicula);

            logica.AltaGenero(admin, unGenero, repoGenero);
            logica.BajaGenero(admin, unGenero, repoGenero, repoPelis);
        }

        [TestMethod]
        [ExpectedException(typeof(GeneroConPeliculaAsociadaException))]
        public void BajaGeneroConPeliculasAsociadasComoSecundarioTest()
        {
            Genero unGenero = new Genero() { Nombre = "Terror" };
            Genero otroGenero = new Genero() { Nombre = "Comedia" };
            GeneroRepo repoGenero = new GeneroRepo();

            PeliculaRepo repoPelis = new PeliculaRepo();
            Pelicula pelicula = new Pelicula() { GeneroPrincipal = otroGenero };
            pelicula.AgregarGeneroSecundario(unGenero);
            repoPelis.AgregarPelicula(pelicula);

            logica.AltaGenero(admin, unGenero, repoGenero);
            logica.BajaGenero(admin, unGenero, repoGenero, repoPelis);
        }

        [TestMethod]
        public void OrdenarPeliculasPorGeneroTest()
        {
            Genero terror = new Genero() { Nombre = "Terror" };
            Genero comedia = new Genero() { Nombre = "Comedia" };
            Genero accion = new Genero() { Nombre = "Acción" };

            Pelicula peliculaA = new Pelicula() { GeneroPrincipal = terror };
            Pelicula peliculaB = new Pelicula() { GeneroPrincipal = comedia };
            Pelicula peliculaC = new Pelicula() { GeneroPrincipal = accion };

            PeliculaRepo repoPelis = new PeliculaRepo();
            repoPelis.AgregarPelicula(peliculaA);
            repoPelis.AgregarPelicula(peliculaB);
            repoPelis.AgregarPelicula(peliculaC);

            repoPelis.peliculas = logica.OrdenarPorGenero(admin, repoPelis);

            bool primeraPeliOrdenada = repoPelis.peliculas[0] == peliculaC;
            bool segundaPeliOrdenada = repoPelis.peliculas[1] == peliculaB;
            bool terceraPeliOrdenada = repoPelis.peliculas[2] == peliculaA;

            Assert.IsTrue(primeraPeliOrdenada && segundaPeliOrdenada && terceraPeliOrdenada);
        }

        [TestMethod]
        public void OrdenarPeliculasPorGeneroEmpateTest()
        {
            Genero terror = new Genero() { Nombre = "Terror" };

            Pelicula peliculaA = new Pelicula() { Nombre = "It", GeneroPrincipal = terror };
            Pelicula peliculaB = new Pelicula() { Nombre = "La huerfana", GeneroPrincipal = terror };
            Pelicula peliculaC = new Pelicula() { Nombre = "Chucky", GeneroPrincipal = terror };

            PeliculaRepo repoPelis = new PeliculaRepo();
            repoPelis.AgregarPelicula(peliculaA);
            repoPelis.AgregarPelicula(peliculaB);
            repoPelis.AgregarPelicula(peliculaC);

            repoPelis.peliculas = logica.OrdenarPorGenero(admin, repoPelis);

            bool primeraPeliOrdenada = repoPelis.peliculas[0] == peliculaC;
            bool segundaPeliOrdenada = repoPelis.peliculas[1] == peliculaA;
            bool terceraPeliOrdenada = repoPelis.peliculas[2] == peliculaB;

            Assert.IsTrue(primeraPeliOrdenada && segundaPeliOrdenada && terceraPeliOrdenada);
        }

        [TestMethod]
        public void OrdenarPeliculasPatrocinadasTest()
        {
            Genero terror = new Genero() { Nombre = "Terror" };

            Pelicula peliculaA = new Pelicula() 
            { 
                EsPatrocinada = false, 
                Nombre = "It", 
                GeneroPrincipal = terror 
            };
            Pelicula peliculaB = new Pelicula() 
            { 
                EsPatrocinada = true, 
                Nombre = "Chucky", 
                GeneroPrincipal = terror 
            };

            PeliculaRepo repoPelis = new PeliculaRepo();
            repoPelis.AgregarPelicula(peliculaA);
            repoPelis.AgregarPelicula(peliculaB);

            repoPelis.peliculas = logica.OrdenarPorPatrocinio(admin, repoPelis);

            bool primeraPeliOrdenada = repoPelis.peliculas[0] == peliculaB;
            bool segundaPeliOrdenada = repoPelis.peliculas[1] == peliculaA;

            Assert.IsTrue(primeraPeliOrdenada && segundaPeliOrdenada);
        }

        [TestMethod]
        public void OrdenarPeliculasPatrocinadasPorGeneroTest()
        {
            Genero terror = new Genero() { Nombre = "Terror" };
            Genero comedia = new Genero() { Nombre = "Comedia" };

            Pelicula peliculaA = new Pelicula()
            {
                EsPatrocinada = true,
                Nombre = "Chucky",
                GeneroPrincipal = terror
            };
            Pelicula peliculaB = new Pelicula()
            {
                EsPatrocinada = true,
                Nombre = "La Mascara",
                GeneroPrincipal = comedia
            };

            PeliculaRepo repoPelis = new PeliculaRepo();
            repoPelis.AgregarPelicula(peliculaA);
            repoPelis.AgregarPelicula(peliculaB);

            repoPelis.peliculas = logica.OrdenarPorPatrocinio(admin, repoPelis);

            bool primeraPeliOrdenada = repoPelis.peliculas[0] == peliculaB;
            bool segundaPeliOrdenada = repoPelis.peliculas[1] == peliculaA;

            Assert.IsTrue(primeraPeliOrdenada && segundaPeliOrdenada);
        }

        [TestMethod]
        public void OrdenarPeliculasPatrocinadasPorNombreTest()
        {
            Genero terror = new Genero() { Nombre = "Terror" };

            Pelicula peliculaA = new Pelicula()
            {
                EsPatrocinada = false,
                Nombre = "It",
                GeneroPrincipal = terror
            };
            Pelicula peliculaB = new Pelicula()
            {
                EsPatrocinada = false,
                Nombre = "Chucky",
                GeneroPrincipal = terror
            };

            PeliculaRepo repoPelis = new PeliculaRepo();
            repoPelis.AgregarPelicula(peliculaA);
            repoPelis.AgregarPelicula(peliculaB);

            repoPelis.peliculas = logica.OrdenarPorPatrocinio(admin, repoPelis);

            bool primeraPeliOrdenada = repoPelis.peliculas[0] == peliculaB;
            bool segundaPeliOrdenada = repoPelis.peliculas[1] == peliculaA;

            Assert.IsTrue(primeraPeliOrdenada && segundaPeliOrdenada);
        }
    }
}
