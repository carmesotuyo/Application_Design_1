using Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio;
using Logica.Implementaciones;
using Logica.Exceptions;
using System.Runtime.Remoting.Messaging;

namespace Pruebas.PruebasLogica
{
    [TestClass]
    public class LogicaPeliculaTest
    {
        Pelicula unaPelicula = new Pelicula();
        PeliculaRepo repo = new PeliculaRepo();
        LogicaPelicula logica = new LogicaPelicula(new PeliculaRepo());

        [TestMethod]
        public void AltaPeliculaTest()
        {
            Usuario admin = new Usuario() { EsAdministrador = true };

            logica.AltaPelicula(unaPelicula, admin);

            Assert.IsTrue(logica.Peliculas().Contains(unaPelicula));
        }

        [TestMethod]
        [ExpectedException(typeof(UsuarioNoPermitidoException))]
        public void AltaPeliculaUsuarioNoAdminTest()
        {
            Usuario comun = new Usuario() { EsAdministrador = false };

            logica.AltaPelicula(unaPelicula, comun);
        }

        [TestMethod]
        public void BajaPeliculaTest()
        {
            Usuario admin = new Usuario() { EsAdministrador = true };

            logica.BajaPelicula(unaPelicula, admin);

            Assert.IsFalse(repo.EstaPelicula(unaPelicula));
        }

        [TestMethod]
        [ExpectedException(typeof(UsuarioNoPermitidoException))]
        public void BajaPeliculaUsuarioNoAdminTest()
        {
            Usuario comun = new Usuario() { EsAdministrador = false };

            logica.BajaPelicula(unaPelicula, comun);
        }

        [TestMethod]
        public void OrdenarPeliculasPorGeneroTest()
        {
            Usuario admin = new Usuario() { EsAdministrador = true };

            Genero terror = new Genero() { Nombre = "Terror" };
            Genero comedia = new Genero() { Nombre = "Comedia" };
            Genero accion = new Genero() { Nombre = "Acción" };

            Pelicula peliculaA = new Pelicula() { GeneroPrincipal = terror };
            Pelicula peliculaB = new Pelicula() { GeneroPrincipal = comedia };
            Pelicula peliculaC = new Pelicula() { GeneroPrincipal = accion };

            logica.AltaPelicula(peliculaA, admin);
            logica.AltaPelicula(peliculaB, admin);
            logica.AltaPelicula(peliculaC, admin);

            logica.PeliculasAMostrar = logica.OrdenarPorGenero(admin);

            bool primeraPeliOrdenada = logica.PeliculasAMostrar[0] == peliculaC;
            bool segundaPeliOrdenada = logica.PeliculasAMostrar[1] == peliculaB;
            bool terceraPeliOrdenada = logica.PeliculasAMostrar[2] == peliculaA;

            Assert.IsTrue(primeraPeliOrdenada && segundaPeliOrdenada && terceraPeliOrdenada);
        }

        [TestMethod]
        public void OrdenarPeliculasPorGeneroEmpateTest()
        {
            Usuario admin = new Usuario() { EsAdministrador = true };
            Genero terror = new Genero() { Nombre = "Terror" };

            Pelicula peliculaA = new Pelicula() { Nombre = "It", GeneroPrincipal = terror };
            Pelicula peliculaB = new Pelicula() { Nombre = "La huerfana", GeneroPrincipal = terror };
            Pelicula peliculaC = new Pelicula() { Nombre = "Chucky", GeneroPrincipal = terror };

            logica.AltaPelicula(peliculaA, admin);
            logica.AltaPelicula(peliculaB, admin);
            logica.AltaPelicula(peliculaC, admin);

            logica.PeliculasAMostrar = logica.OrdenarPorGenero(admin);

            bool primeraPeliOrdenada = logica.PeliculasAMostrar[0] == peliculaC;
            bool segundaPeliOrdenada = logica.PeliculasAMostrar[1] == peliculaA;
            bool terceraPeliOrdenada = logica.PeliculasAMostrar[2] == peliculaB;

            Assert.IsTrue(primeraPeliOrdenada && segundaPeliOrdenada && terceraPeliOrdenada);
        }

        [TestMethod]
        public void OrdenarPeliculasPatrocinadasTest()
        {
            Usuario admin = new Usuario() { EsAdministrador = true };
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

            logica.AltaPelicula(peliculaA, admin);
            logica.AltaPelicula(peliculaB, admin);

            logica.PeliculasAMostrar = logica.OrdenarPorPatrocinio(admin);

            bool primeraPeliOrdenada = logica.PeliculasAMostrar[0] == peliculaB;
            bool segundaPeliOrdenada = logica.PeliculasAMostrar[1] == peliculaA;

            Assert.IsTrue(primeraPeliOrdenada && segundaPeliOrdenada);
        }

        [TestMethod]
        public void OrdenarPeliculasPatrocinadasPorGeneroTest()
        {
            Usuario admin = new Usuario() { EsAdministrador = true };
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

            logica.AltaPelicula(peliculaA, admin);
            logica.AltaPelicula(peliculaB, admin);

            logica.PeliculasAMostrar = logica.OrdenarPorPatrocinio(admin);

            bool primeraPeliOrdenada = logica.PeliculasAMostrar[0] == peliculaB;
            bool segundaPeliOrdenada = logica.PeliculasAMostrar[1] == peliculaA;

            Assert.IsTrue(primeraPeliOrdenada && segundaPeliOrdenada);
        }

        [TestMethod]
        public void OrdenarPeliculasPatrocinadasPorNombreTest()
        {
            Usuario admin = new Usuario() { EsAdministrador = true };
            Genero terror = new Genero() { Nombre = "Terror" };

            Pelicula peliculaA = new Pelicula()
            {
                EsPatrocinada = true,
                Nombre = "It",
                GeneroPrincipal = terror
            };
            Pelicula peliculaB = new Pelicula()
            {
                EsPatrocinada = true,
                Nombre = "Chucky",
                GeneroPrincipal = terror
            };

            logica.AltaPelicula(peliculaA, admin);
            logica.AltaPelicula(peliculaB, admin);

            logica.PeliculasAMostrar = logica.OrdenarPorPatrocinio(admin);

            bool primeraPeliOrdenada = logica.PeliculasAMostrar[0] == peliculaB;
            bool segundaPeliOrdenada = logica.PeliculasAMostrar[1] == peliculaA;

            Assert.IsTrue(primeraPeliOrdenada && segundaPeliOrdenada);
        }

        [TestMethod]
        public void OrdenarPeliculasConMismoNombreTest()
        {
            Usuario admin = new Usuario() { EsAdministrador = true };
            Genero terror = new Genero() { Nombre = "Terror" };

            Pelicula peliculaA = new Pelicula() { Nombre = "It", GeneroPrincipal = terror };
            Pelicula peliculaB = new Pelicula() { Nombre = "It", GeneroPrincipal = terror };
            Pelicula peliculaC = new Pelicula() { Nombre = "Chucky", GeneroPrincipal = terror };

            logica.AltaPelicula(peliculaA, admin);
            logica.AltaPelicula(peliculaB, admin);
            logica.AltaPelicula(peliculaC, admin);

            logica.PeliculasAMostrar = logica.OrdenarPorGenero(admin);

            bool primeraPeliOrdenada = logica.PeliculasAMostrar[0] == peliculaC;
            bool segundaPeliOrdenada = logica.PeliculasAMostrar[1] == peliculaA;
            bool terceraPeliOrdenada = logica.PeliculasAMostrar[2] == peliculaB;

            Assert.IsTrue(primeraPeliOrdenada && segundaPeliOrdenada && terceraPeliOrdenada);
        }

        [TestMethod]
        public void OrdenarPeliculasPorPuntajeGenerosTest()
        {
            Usuario admin = new Usuario() { EsAdministrador = true };
            Perfil perfil = new Perfil();
            LogicaPerfil logicaPerfil = new LogicaPerfil();

            Genero terror = new Genero() { Nombre = "Terror" };
            Genero comedia = new Genero() { Nombre = "comedia" };

            Pelicula peliculaA = new Pelicula() { Nombre = "It", GeneroPrincipal = terror };
            Pelicula peliculaB = new Pelicula() { Nombre = "Yes Man", GeneroPrincipal = comedia };

            logica.AltaPelicula(peliculaA, admin);
            logica.AltaPelicula(peliculaB, admin);

            logicaPerfil.PuntuarMuyPositivo(peliculaB, perfil);
            logicaPerfil.PuntuarNegativo(peliculaA, perfil);

            logica.PeliculasAMostrar = logica.OrdenarPorPuntaje(admin);

            bool primeraPeliOrdenada = logica.PeliculasAMostrar[0] == peliculaB;
            bool segundaPeliOrdenada = logica.PeliculasAMostrar[1] == peliculaA;

            Assert.IsTrue(primeraPeliOrdenada && segundaPeliOrdenada);
        }
    }
}
