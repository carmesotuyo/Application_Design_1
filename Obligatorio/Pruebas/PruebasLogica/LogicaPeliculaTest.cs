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
        Usuario admin = new Usuario() { EsAdministrador = true };

        Perfil unPerfil = new Perfil();
        LogicaPerfil logicaPerfil = new LogicaPerfil();

        Genero terror = new Genero() { Nombre = "Terror" };
        Genero comedia = new Genero() { Nombre = "comedia" };
        Genero accion = new Genero() { Nombre = "accion" };

        [TestMethod]
        public void AltaPeliculaTest()
        {
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
            Pelicula peliculaA = new Pelicula() { GeneroPrincipal = terror };
            Pelicula peliculaB = new Pelicula() { GeneroPrincipal = comedia };
            Pelicula peliculaC = new Pelicula() { GeneroPrincipal = accion };

            logica.AltaPelicula(peliculaA, admin);
            logica.AltaPelicula(peliculaB, admin);
            logica.AltaPelicula(peliculaC, admin);

            logica.ElegirCriterioOrden(admin, (int)LogicaPelicula.Criterios.OrdenarPorGenero);
            List<Pelicula> pelisMostradas = logica.MostrarPeliculas(unPerfil);

            bool primeraPeliOrdenada = pelisMostradas[0] == peliculaC;
            bool segundaPeliOrdenada = pelisMostradas[1] == peliculaB;
            bool terceraPeliOrdenada = pelisMostradas[2] == peliculaA;

            Assert.IsTrue(primeraPeliOrdenada && segundaPeliOrdenada && terceraPeliOrdenada);
        }

        [TestMethod]
        public void OrdenarPeliculasPorGeneroEmpateTest()
        {
            Pelicula peliculaA = new Pelicula() { Nombre = "It", GeneroPrincipal = terror };
            Pelicula peliculaB = new Pelicula() { Nombre = "La huerfana", GeneroPrincipal = terror };
            Pelicula peliculaC = new Pelicula() { Nombre = "Chucky", GeneroPrincipal = terror };

            logica.AltaPelicula(peliculaA, admin);
            logica.AltaPelicula(peliculaB, admin);
            logica.AltaPelicula(peliculaC, admin);

            logica.ElegirCriterioOrden(admin, (int)LogicaPelicula.Criterios.OrdenarPorGenero);
            List<Pelicula> pelisMostradas = logica.MostrarPeliculas(unPerfil);

            bool primeraPeliOrdenada = pelisMostradas[0] == peliculaC;
            bool segundaPeliOrdenada = pelisMostradas[1] == peliculaA;
            bool terceraPeliOrdenada = pelisMostradas[2] == peliculaB;

            Assert.IsTrue(primeraPeliOrdenada && segundaPeliOrdenada && terceraPeliOrdenada);
        }

        [TestMethod]
        public void OrdenarPeliculasPatrocinadasTest()
        {
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

            logica.ElegirCriterioOrden(admin, (int)LogicaPelicula.Criterios.OrdenarPorPatrocinio);
            List<Pelicula> pelisMostradas = logica.MostrarPeliculas(unPerfil);

            bool primeraPeliOrdenada = pelisMostradas[0] == peliculaB;
            bool segundaPeliOrdenada = pelisMostradas[1] == peliculaA;

            Assert.IsTrue(primeraPeliOrdenada && segundaPeliOrdenada);
        }

        [TestMethod]
        public void OrdenarPeliculasPatrocinadasPorGeneroTest()
        {
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

            logica.ElegirCriterioOrden(admin, (int)LogicaPelicula.Criterios.OrdenarPorPatrocinio);
            List<Pelicula> pelisMostradas = logica.MostrarPeliculas(unPerfil);

            bool primeraPeliOrdenada = pelisMostradas[0] == peliculaB;
            bool segundaPeliOrdenada = pelisMostradas[1] == peliculaA;

            Assert.IsTrue(primeraPeliOrdenada && segundaPeliOrdenada);
        }

        [TestMethod]
        public void OrdenarPeliculasPatrocinadasPorNombreTest()
        {
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

            logica.ElegirCriterioOrden(admin, (int)LogicaPelicula.Criterios.OrdenarPorPatrocinio);
            List<Pelicula> pelisMostradas = logica.MostrarPeliculas(unPerfil);

            bool primeraPeliOrdenada = pelisMostradas[0] == peliculaB;
            bool segundaPeliOrdenada = pelisMostradas[1] == peliculaA;

            Assert.IsTrue(primeraPeliOrdenada && segundaPeliOrdenada);
        }

        [TestMethod]
        public void OrdenarPeliculasConMismoNombreTest()
        {
            Pelicula peliculaA = new Pelicula() { Nombre = "It", GeneroPrincipal = terror };
            Pelicula peliculaB = new Pelicula() { Nombre = "It", GeneroPrincipal = terror };
            Pelicula peliculaC = new Pelicula() { Nombre = "Chucky", GeneroPrincipal = terror };

            logica.AltaPelicula(peliculaA, admin);
            logica.AltaPelicula(peliculaB, admin);
            logica.AltaPelicula(peliculaC, admin);

            logica.ElegirCriterioOrden(admin, (int)LogicaPelicula.Criterios.OrdenarPorGenero);
            List<Pelicula> pelisMostradas = logica.MostrarPeliculas(unPerfil);

            bool primeraPeliOrdenada = pelisMostradas[0] == peliculaC;
            bool segundaPeliOrdenada = pelisMostradas[1] == peliculaA;
            bool terceraPeliOrdenada = pelisMostradas[2] == peliculaB;

            Assert.IsTrue(primeraPeliOrdenada && segundaPeliOrdenada && terceraPeliOrdenada);
        }

        [TestMethod]
        public void OrdenarPeliculasPorPuntajeGenerosTest()
        {
            Pelicula peliculaA = new Pelicula() { Nombre = "It", GeneroPrincipal = terror };
            Pelicula peliculaB = new Pelicula() { Nombre = "Yes Man", GeneroPrincipal = comedia };
            Pelicula peliculaC = new Pelicula() { Nombre = "Avengers", GeneroPrincipal = accion };

            logica.AltaPelicula(peliculaA, admin);
            logica.AltaPelicula(peliculaB, admin);
            logica.AltaPelicula(peliculaC, admin);

            GeneroPuntaje generoPuntaje1 = new GeneroPuntaje() { Genero = terror.Nombre };
            GeneroPuntaje generoPuntaje2 = new GeneroPuntaje() { Genero = comedia.Nombre };
            GeneroPuntaje generoPuntaje3 = new GeneroPuntaje() { Genero = accion.Nombre };
            unPerfil.AgregarGeneroPuntaje(generoPuntaje1);
            unPerfil.AgregarGeneroPuntaje(generoPuntaje2);
            unPerfil.AgregarGeneroPuntaje(generoPuntaje3);

            logicaPerfil.PuntuarMuyPositivo(peliculaB, unPerfil);
            logicaPerfil.PuntuarPositivo(peliculaC, unPerfil);
            logicaPerfil.PuntuarNegativo(peliculaA, unPerfil);

            logica.ElegirCriterioOrden(admin, (int)LogicaPelicula.Criterios.OrdenarPorPuntaje);
            List<Pelicula> pelisMostradas = logica.MostrarPeliculas(unPerfil);

            bool primeraPeliOrdenada = pelisMostradas[0] == peliculaB;
            bool segundaPeliOrdenada = pelisMostradas[1] == peliculaC;
            bool terceraPeliOrdenada = pelisMostradas[2] == peliculaA;

            Assert.IsTrue(primeraPeliOrdenada && segundaPeliOrdenada && terceraPeliOrdenada);
        }

        [TestMethod]
        public void OrdenarPeliculasPorPuntajeAcumuladoGenerosTest()
        {
            Pelicula peliculaA = new Pelicula() { Nombre = "It", GeneroPrincipal = terror };
            Pelicula peliculaB = new Pelicula() { Nombre = "Yes Man", GeneroPrincipal = comedia };
            Pelicula peliculaC = new Pelicula() { Nombre = "Mamma Mia", GeneroPrincipal = comedia };

            logica.AltaPelicula(peliculaA, admin);
            logica.AltaPelicula(peliculaB, admin);
            logica.AltaPelicula(peliculaC, admin);

            GeneroPuntaje generoPuntaje1 = new GeneroPuntaje() { Genero = terror.Nombre };
            GeneroPuntaje generoPuntaje2 = new GeneroPuntaje() { Genero = comedia.Nombre };
            unPerfil.AgregarGeneroPuntaje(generoPuntaje1);
            unPerfil.AgregarGeneroPuntaje(generoPuntaje2);

            logicaPerfil.PuntuarMuyPositivo(peliculaB, unPerfil);
            logicaPerfil.PuntuarPositivo(peliculaC, unPerfil);
            logicaPerfil.PuntuarPositivo(peliculaA, unPerfil);

            logica.ElegirCriterioOrden(admin, (int)LogicaPelicula.Criterios.OrdenarPorPuntaje);
            List<Pelicula> pelisMostradas = logica.MostrarPeliculas(unPerfil);

            bool primeraPeliOrdenada = pelisMostradas[0] == peliculaC;
            bool segundaPeliOrdenada = pelisMostradas[1] == peliculaB;
            bool terceraPeliOrdenada = pelisMostradas[2] == peliculaA;

            Assert.IsTrue(primeraPeliOrdenada && segundaPeliOrdenada && terceraPeliOrdenada);
        }

        [TestMethod]
        public void OrdenarPeliculasPorPuntajeGenerosNegativoTest()
        {
            Pelicula peliculaA = new Pelicula() { Nombre = "It", GeneroPrincipal = terror };
            Pelicula peliculaB = new Pelicula() { Nombre = "Yes Man", GeneroPrincipal = comedia };
            Pelicula peliculaC = new Pelicula() { Nombre = "Mamma Mia", GeneroPrincipal = comedia };

            logica.AltaPelicula(peliculaA, admin);
            logica.AltaPelicula(peliculaB, admin);
            logica.AltaPelicula(peliculaC, admin);

            LogicaGenero logicaGenero = new LogicaGenero(new GeneroRepo());
            logicaGenero.AgregarGenero(admin, terror);
            logicaGenero.AgregarGenero(admin, comedia);
            logicaPerfil.ActualizarListadoGeneros(unPerfil, logicaGenero);

            logicaPerfil.PuntuarNegativo(peliculaA, unPerfil);
            logicaPerfil.PuntuarNegativo(peliculaB, unPerfil);
            logicaPerfil.PuntuarNegativo(peliculaC, unPerfil);

            logica.ElegirCriterioOrden(admin, (int)LogicaPelicula.Criterios.OrdenarPorPuntaje);
            List<Pelicula> pelisMostradas = logica.MostrarPeliculas(unPerfil);

            bool primeraPeliOrdenada = pelisMostradas[0] == peliculaA;
            bool segundaPeliOrdenada = pelisMostradas[1] == peliculaC;
            bool terceraPeliOrdenada = pelisMostradas[2] == peliculaB;

            Assert.IsTrue(primeraPeliOrdenada && segundaPeliOrdenada && terceraPeliOrdenada);
        }

        [TestMethod]
        [ExpectedException(typeof(CriterioInexistenteException))]
        public void OrdenarConCriterioInexistenteTest()
        {
            Pelicula peliculaA = new Pelicula() { GeneroPrincipal = terror };
            Pelicula peliculaB = new Pelicula() { GeneroPrincipal = comedia };

            logica.AltaPelicula(peliculaA, admin);
            logica.AltaPelicula(peliculaB, admin);

            int criterioInvalido = 4;
            logica.ElegirCriterioOrden(admin, criterioInvalido);
        }

    }
}
