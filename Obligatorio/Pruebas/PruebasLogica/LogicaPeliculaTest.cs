﻿using Dominio;
using Dominio.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio;
using Logica.Implementaciones;
using Logica.Interfaces;
using Logica.Exceptions;
using System.Runtime.Remoting.Messaging;
using Repositorio.EnDataBase;

namespace Pruebas.PruebasLogica
{
    [TestClass]
    public class LogicaPeliculaTest
    {
        static Genero terror = new Genero() { Nombre = "Terror" };
        static Genero comedia = new Genero() { Nombre = "comedia" };
        static Genero accion = new Genero() { Nombre = "accion" };
        static Pelicula unaPelicula = new Pelicula()
        {
            Identificador = 1,
            Nombre = "nombre",
            GeneroPrincipal = comedia,
            Descripcion = "algo",
            Poster = "ruta"
        };
        ILogicaPelicula logica = new LogicaPelicula(new PeliculaDBRepo(), new PerfilDBRepo());
        ILogicaGenero logicaGenero = new LogicaGenero(new GeneroDBRepo());
        LogicaPerfil logicaPerfil = new LogicaPerfil(new PerfilDBRepo(), new GeneroPuntajeDBRepo(), new PeliculaDBRepo(), new GeneroDBRepo());
        ILogicaUsuario logicaUsuario = new LogicaUsuario(new UsuarioDBRepo(), new PerfilDBRepo());
        ILogicaPersona logicaPersona = new LogicaPersona(new PersonaDBRepo());
        ILogicaPapel logicaPapel = new LogicaPapel(new PapelDBRepo());
        Usuario admin = new Usuario() { EsAdministrador = true };
        static Usuario usuario = new Usuario()
        {
            Nombre = "NombreDeUsuario",
            Email = "usuario@gmail.com",
            Clave = "usuario123"
        };
        Perfil unPerfil = new Perfil()
        {
            Alias = "perfil",
            Usuario = usuario,
            Pin = 12345,
            ConfirmarPin = 12345,

        };

        [TestInitialize]
        public void Setup()
        {
            DBCleanUp.CleanUp();
            logicaGenero.AgregarGenero(admin, comedia);
            logicaGenero.AgregarGenero(admin, accion);
            logicaGenero.AgregarGenero(admin, terror);
            logicaUsuario.RegistrarUsuario(usuario);
            logicaUsuario.AgregarPerfil(usuario, unPerfil);
        }

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
            logica.AltaPelicula(unaPelicula, admin);
            
            logica.BajaPelicula(unaPelicula, admin);

            Assert.IsFalse(logica.Peliculas().Contains(unaPelicula));
        }


        [TestMethod]
        public void FiltrarPeliculasNoAptasTest()
        {
            Pelicula peliculaApta = new Pelicula()
            {
                Nombre = "Harry Potter",
                GeneroPrincipal = accion,
                AptaTodoPublico = true,
                Descripcion = "algo",
                Poster = "ruta"
            };
            Pelicula peliculaNoApta = new Pelicula()
            {
                Nombre = "It",
                GeneroPrincipal = terror,
                AptaTodoPublico = false,
                Descripcion = "algo",
                Poster = "ruta"
            };

            logica.AltaPelicula(peliculaApta, admin);
            logica.AltaPelicula(peliculaNoApta, admin);

            Perfil unPerfil = new Perfil() { EsInfantil = true };

            List<Pelicula> soloAptas = logica.MostrarPeliculas(unPerfil);

            Assert.IsTrue(soloAptas.Count == 1);
        }

        [TestMethod]
        public void NoFiltrarSiNoEsInfantilTest()
        {
            Pelicula peliculaApta = new Pelicula() 
            { 
                Nombre = "Harry Potter", 
                GeneroPrincipal = accion,
                AptaTodoPublico = true,
                Descripcion = "algo",
                Poster = "ruta"
            };
            Pelicula peliculaNoApta = new Pelicula() 
            { 
                Nombre = "It", 
                GeneroPrincipal = terror,
                AptaTodoPublico = false,
                Descripcion = "algo",
                Poster = "ruta"
            };

            logica.AltaPelicula(peliculaApta, admin);
            logica.AltaPelicula(peliculaNoApta, admin);

            Perfil unPerfil = new Perfil() { EsInfantil = false };

            List<Pelicula> todas = logica.MostrarPeliculas(unPerfil);

            Assert.AreEqual(todas.Count(), logica.Peliculas().Count());
        }

        [TestMethod]
        [ExpectedException(typeof(UsuarioNoPermitidoException))]
        public void BajaPeliculaUsuarioNoAdminTest()
        {
            Usuario comun = new Usuario() { EsAdministrador = false };

            logica.BajaPelicula(unaPelicula, comun);
        }

        [TestMethod]
        [ExpectedException(typeof(NullException))]
        public void BajaPeliculaNullTest()
        {
            Pelicula pelicula = null;
            logica.BajaPelicula(pelicula, admin);
        }

        [TestMethod]
        public void OrdenarPeliculasPorGeneroTest()
        {
            Pelicula peliculaA = new Pelicula()
            {
                Nombre = "It",
                GeneroPrincipal = terror,
                Poster = "ruta"
            };
            Pelicula peliculaB = new Pelicula()
            {
                Nombre = "Mamma Mia",
                GeneroPrincipal = comedia,
                Poster = "ruta"
            };
            Pelicula peliculaC = new Pelicula()
            {
                Nombre = "Matrix",
                GeneroPrincipal = accion,
                Poster = "ruta"
            };

            logica.AltaPelicula(peliculaA, admin);
            logica.AltaPelicula(peliculaB, admin);
            logica.AltaPelicula(peliculaC, admin);

            logica.ElegirCriterioOrden(admin, (int)LogicaPelicula.Criterios.OrdenarPorGenero);
            List<Pelicula> pelisMostradas = logica.MostrarPeliculas(unPerfil);

            bool primeraPeliOrdenada = pelisMostradas[0].Equals(peliculaC);
            bool segundaPeliOrdenada = pelisMostradas[1].Equals(peliculaB);
            bool terceraPeliOrdenada = pelisMostradas[2].Equals(peliculaA);

            Assert.IsTrue(primeraPeliOrdenada && segundaPeliOrdenada && terceraPeliOrdenada);
        }

        [TestMethod]
         public void OrdenarPeliculasPorGeneroEmpateTest()
        {
            Pelicula peliculaA = new Pelicula() 
            { 
                Nombre = "It", 
                GeneroPrincipal = terror,
                Poster = "ruta"
            };
            Pelicula peliculaB = new Pelicula() 
            { 
                Nombre = "La huerfana", 
                GeneroPrincipal = terror,
                Poster = "ruta"
            };
            Pelicula peliculaC = new Pelicula() 
            { 
                Nombre = "Chucky", 
                GeneroPrincipal = terror,
                Poster = "ruta"
            };

            logica.AltaPelicula(peliculaA, admin);
            logica.AltaPelicula(peliculaB, admin);
            logica.AltaPelicula(peliculaC, admin);

            logica.ElegirCriterioOrden(admin, (int)LogicaPelicula.Criterios.OrdenarPorGenero);
            List<Pelicula> pelisMostradas = logica.MostrarPeliculas(unPerfil);

            bool primeraPeliOrdenada = pelisMostradas[0].Equals(peliculaC);
            bool segundaPeliOrdenada = pelisMostradas[1].Equals(peliculaA);
            bool terceraPeliOrdenada = pelisMostradas[2].Equals(peliculaB);

            Assert.IsTrue(primeraPeliOrdenada && segundaPeliOrdenada && terceraPeliOrdenada);
        }

        [TestMethod]
        public void OrdenarPeliculasConMismoNombreTest()
        {
            Pelicula peliculaA = new Pelicula() { 
                Nombre = "It", 
                GeneroPrincipal = terror,
                Poster = "ruta"
            };
            Pelicula peliculaB = new Pelicula() { 
                Nombre = "It", 
                GeneroPrincipal = terror,
                Poster = "ruta"
            };
            Pelicula peliculaC = new Pelicula() { 
                Nombre = "Chucky", 
                GeneroPrincipal = terror,
                Poster = "ruta"
            };

            logica.AltaPelicula(peliculaA, admin);
            logica.AltaPelicula(peliculaB, admin);
            logica.AltaPelicula(peliculaC, admin);

            logica.ElegirCriterioOrden(admin, (int)LogicaPelicula.Criterios.OrdenarPorGenero);
            List<Pelicula> pelisMostradas = logica.MostrarPeliculas(unPerfil);

            bool primeraPeliOrdenada = pelisMostradas[0].Equals(peliculaC);
            bool segundaPeliOrdenada = pelisMostradas[1].Equals(peliculaB);
            bool terceraPeliOrdenada = pelisMostradas[2].Equals(peliculaA);

            Assert.IsTrue(primeraPeliOrdenada && segundaPeliOrdenada && terceraPeliOrdenada);
        }

        [TestMethod]
        public void OrdenarPeliculasPatrocinadasTest()
        {
            Pelicula peliculaA = new Pelicula()
            {
                EsPatrocinada = false,
                Nombre = "It",
                GeneroPrincipal = terror,
                Poster = "ruta"
            };
            Pelicula peliculaB = new Pelicula()
            {
                EsPatrocinada = true,
                Nombre = "Pesadilla en la Calle Elm",
                GeneroPrincipal = terror,
                Poster = "ruta"
            };

            logica.AltaPelicula(peliculaA, admin);
            logica.AltaPelicula(peliculaB, admin);

            logica.ElegirCriterioOrden(admin, (int)LogicaPelicula.Criterios.OrdenarPorPatrocinio);
            List<Pelicula> pelisMostradas = logica.MostrarPeliculas(unPerfil);

            bool primeraPeliOrdenada = pelisMostradas[0].Equals(peliculaB);
            bool segundaPeliOrdenada = pelisMostradas[1].Equals(peliculaA);

            Assert.IsTrue(primeraPeliOrdenada && segundaPeliOrdenada);
        }

        [TestMethod]
        public void OrdenarPeliculasPatrocinadasPorGeneroTest()
        {
            Pelicula peliculaA = new Pelicula()
            {
                EsPatrocinada = true,
                Nombre = "Chucky",
                GeneroPrincipal = terror,
                Poster = "ruta"
            };
            Pelicula peliculaB = new Pelicula()
            {
                EsPatrocinada = true,
                Nombre = "La Mascara",
                GeneroPrincipal = comedia,
                Poster = "ruta"
            };

            logica.AltaPelicula(peliculaA, admin);
            logica.AltaPelicula(peliculaB, admin);

            logica.ElegirCriterioOrden(admin, (int)LogicaPelicula.Criterios.OrdenarPorPatrocinio);
            List<Pelicula> pelisMostradas = logica.MostrarPeliculas(unPerfil);

            bool primeraPeliOrdenada = pelisMostradas[0].Equals(peliculaB);
            bool segundaPeliOrdenada = pelisMostradas[1].Equals(peliculaA);

            Assert.IsTrue(primeraPeliOrdenada && segundaPeliOrdenada);
        }

        [TestMethod]
        public void OrdenarPeliculasPatrocinadasPorNombreTest()
        {
            Pelicula peliculaA = new Pelicula()
            {
                EsPatrocinada = true,
                Nombre = "It",
                GeneroPrincipal = terror,
                Poster = "ruta"
            };
            Pelicula peliculaB = new Pelicula()
            {
                EsPatrocinada = true,
                Nombre = "Chucky",
                GeneroPrincipal = terror,
                Poster = "ruta"
            };

            logica.AltaPelicula(peliculaA, admin);
            logica.AltaPelicula(peliculaB, admin);

            logica.ElegirCriterioOrden(admin, (int)LogicaPelicula.Criterios.OrdenarPorPatrocinio);
            List<Pelicula> pelisMostradas = logica.MostrarPeliculas(unPerfil);

            bool primeraPeliOrdenada = pelisMostradas[0].Equals(peliculaB);
            bool segundaPeliOrdenada = pelisMostradas[1].Equals(peliculaA);

            Assert.IsTrue(primeraPeliOrdenada && segundaPeliOrdenada);
        }

        [TestMethod]
        public void OrdenarPeliculasPatrocinadasPorFechaAgregadasTest()
        {
            Pelicula peliculaA = new Pelicula()
            {
                EsPatrocinada = true,
                Nombre = "It",
                GeneroPrincipal = terror,
                Poster = "ruta"
            };
            Pelicula peliculaB = new Pelicula()
            {
                EsPatrocinada = true,
                Nombre = "It",
                GeneroPrincipal = terror,
                Poster = "ruta"
            };

            logica.AltaPelicula(peliculaA, admin);
            logica.AltaPelicula(peliculaB, admin);

            logica.ElegirCriterioOrden(admin, (int)LogicaPelicula.Criterios.OrdenarPorPatrocinio);
            List<Pelicula> pelisMostradas = logica.MostrarPeliculas(unPerfil);

            bool primeraPeliOrdenada = pelisMostradas[0].Equals(peliculaB);
            bool segundaPeliOrdenada = pelisMostradas[1].Equals(peliculaA);

            Assert.IsTrue(primeraPeliOrdenada && segundaPeliOrdenada);
        }

        [TestMethod]
        public void OrdenarPeliculasPorPuntajeGenerosTest()
        {
            Pelicula peliculaA = new Pelicula() 
            { 
                Nombre = "It", 
                GeneroPrincipal = terror,
                Poster = "ruta"
            };
            Pelicula peliculaB = new Pelicula() 
            { 
                Nombre = "Yes Man", 
                GeneroPrincipal = comedia,
                Poster = "ruta"
            };
            Pelicula peliculaC = new Pelicula() 
            { 
                Nombre = "Avengers", 
                GeneroPrincipal = accion,
                Poster = "ruta"
            };

            logica.AltaPelicula(peliculaA, admin);
            logica.AltaPelicula(peliculaB, admin);
            logica.AltaPelicula(peliculaC, admin);

            logicaPerfil.AgregarGeneroPuntuado(unPerfil, terror);
            logicaPerfil.AgregarGeneroPuntuado(unPerfil, comedia);
            logicaPerfil.AgregarGeneroPuntuado(unPerfil, accion);

            logicaPerfil.PuntuarMuyPositivo(peliculaB, unPerfil);
            logicaPerfil.PuntuarPositivo(peliculaC, unPerfil);
            logicaPerfil.PuntuarNegativo(peliculaA, unPerfil);

            logica.ElegirCriterioOrden(admin, (int)LogicaPelicula.Criterios.OrdenarPorPuntaje);
            List<Pelicula> pelisMostradas = logica.MostrarPeliculas(unPerfil);

            bool primeraPeliOrdenada = pelisMostradas[0].Equals(peliculaB);
            bool segundaPeliOrdenada = pelisMostradas[1].Equals(peliculaC);
            bool terceraPeliOrdenada = pelisMostradas[2].Equals(peliculaA);

            Assert.IsTrue(primeraPeliOrdenada && segundaPeliOrdenada && terceraPeliOrdenada);
        }

        [TestMethod]
        public void OrdenarPeliculasPorPuntajeAcumuladoGenerosTest()
        {
            Pelicula peliculaA = new Pelicula() 
            { 
                Nombre = "It", 
                GeneroPrincipal = terror,
                Poster = "ruta"
            };
            Pelicula peliculaB = new Pelicula() 
            { 
                Nombre = "Yes Man", 
                GeneroPrincipal = comedia,
                Poster = "ruta"
            };
            Pelicula peliculaC = new Pelicula() 
            { 
                Nombre = "Mamma Mia", 
                GeneroPrincipal = comedia,
                Poster = "ruta"
            };

            logica.AltaPelicula(peliculaA, admin);
            logica.AltaPelicula(peliculaB, admin);
            logica.AltaPelicula(peliculaC, admin);

            logicaPerfil.AgregarGeneroPuntuado(unPerfil, terror);
            logicaPerfil.AgregarGeneroPuntuado(unPerfil, comedia);

            logicaPerfil.PuntuarMuyPositivo(peliculaB, unPerfil);
            logicaPerfil.PuntuarPositivo(peliculaC, unPerfil);
            logicaPerfil.PuntuarPositivo(peliculaA, unPerfil);

            logica.ElegirCriterioOrden(admin, (int)LogicaPelicula.Criterios.OrdenarPorPuntaje);
            List<Pelicula> pelisMostradas = logica.MostrarPeliculas(unPerfil);

            bool primeraPeliOrdenada = pelisMostradas[0].Equals(peliculaC);
            bool segundaPeliOrdenada = pelisMostradas[1].Equals(peliculaB);
            bool terceraPeliOrdenada = pelisMostradas[2].Equals(peliculaA);

            Assert.IsTrue(primeraPeliOrdenada && segundaPeliOrdenada && terceraPeliOrdenada);
        }

        [TestMethod]
        public void OrdenarPeliculasPorPuntajeGenerosNegativoTest()
        {
            Pelicula peliculaA = new Pelicula() 
            { 
                Nombre = "It", 
                GeneroPrincipal = terror,
                Poster = "ruta"
            };
            Pelicula peliculaB = new Pelicula() 
            { 
                Nombre = "Yes Man", 
                GeneroPrincipal = comedia,
                Poster = "ruta"
            };
            Pelicula peliculaC = new Pelicula() 
            { 
                Nombre = "Mamma Mia", 
                GeneroPrincipal = comedia,
                Poster = "ruta"
            };

            logica.AltaPelicula(peliculaA, admin);
            logica.AltaPelicula(peliculaB, admin);
            logica.AltaPelicula(peliculaC, admin);

            LogicaGenero logicaGenero = new LogicaGenero(new GeneroRepo());
            logicaGenero.AgregarGenero(admin, terror);
            logicaGenero.AgregarGenero(admin, comedia);
            logicaPerfil.ActualizarListadoGeneros(unPerfil);

            logicaPerfil.PuntuarNegativo(peliculaA, unPerfil);
            logicaPerfil.PuntuarNegativo(peliculaB, unPerfil);
            logicaPerfil.PuntuarNegativo(peliculaC, unPerfil);

            logica.ElegirCriterioOrden(admin, (int)LogicaPelicula.Criterios.OrdenarPorPuntaje);
            List<Pelicula> pelisMostradas = logica.MostrarPeliculas(unPerfil);

            bool primeraPeliOrdenada = pelisMostradas[0].Equals(peliculaA);
            bool segundaPeliOrdenada = pelisMostradas[1].Equals(peliculaC);
            bool terceraPeliOrdenada = pelisMostradas[2].Equals(peliculaB);

            Assert.IsTrue(primeraPeliOrdenada && segundaPeliOrdenada && terceraPeliOrdenada);
        }

        [TestMethod]
        [ExpectedException(typeof(CriterioInexistenteException))]
        public void OrdenarConCriterioInexistenteTest()
        {
            Pelicula peliculaA = new Pelicula() 
            { 
                Nombre = "It",
                GeneroPrincipal = terror,
                Poster = "ruta"
            };
            Pelicula peliculaB = new Pelicula() 
            { 
                Nombre = "Mamma mia",
                GeneroPrincipal = comedia,
                Poster = "ruta"
            };

            logica.AltaPelicula(peliculaA, admin);
            logica.AltaPelicula(peliculaB, admin);

            int criterioInvalido = 4;
            logica.ElegirCriterioOrden(admin, criterioInvalido);
        }

        [TestMethod]
        public void CriterioSeleccionadoTest()
        {
            string criterio = LogicaPelicula.Criterios.OrdenarPorPuntaje.ToString();
            
            logica.ElegirCriterioOrden(admin, (int)LogicaPelicula.Criterios.OrdenarPorPuntaje);

            Assert.AreEqual(logica.CriterioSeleccionado(), criterio);
        }



        static Persona robert = new Persona() { Id = 1, Nombre = "Robert" };
        static Persona tom = new Persona() { Id = 2, Nombre = "Tom" };
        static Persona kate = new Persona() { Id = 3, Nombre = "Kate" };
        static Persona johnny = new Persona() { Id = 4, Nombre = "Johnny" };
        static Persona helen = new Persona() { Id = 5, Nombre = "Helen" };


        Papel papelRobert = new Papel() { Nombre = "papel robert", Actor = robert, Pelicula = unaPelicula };
        Papel papelTom = new Papel() { Nombre = "papel tom", Actor = tom, Pelicula = unaPelicula };
        Papel papelKate = new Papel() { Nombre = "papel kate", Actor = kate, Pelicula = unaPelicula };
        Papel papelJohnny = new Papel() { Nombre = "papel johnny", Actor = johnny, Pelicula = unaPelicula };
        Papel papelHelen = new Papel() { Nombre = "papel helen", Actor = helen, Pelicula = unaPelicula };


        [TestMethod]
        public void DevolverActoresTest()
        {
            logicaPersona.AltaPersona(robert, admin);
            logicaPersona.AltaPersona(tom, admin);
            logicaPersona.AltaPersona(kate, admin);
            logicaPersona.AltaPersona(johnny, admin);
            logicaPersona.AltaPersona(helen, admin);

            logicaPapel.AsociarActorPelicula(papelRobert, admin);
            logicaPapel.AsociarActorPelicula(papelTom, admin);
            logicaPapel.AsociarActorPelicula(papelKate, admin);
            logicaPapel.AsociarActorPelicula(papelJohnny, admin);
            logicaPapel.AsociarActorPelicula(papelHelen, admin);

            string mostrarActores = logica.Actores(unaPelicula, 5);

            //Assert.IsTrue(mostrarActores.Contains("Robert") && mostrarActores.Contains("Tom")
            //    && mostrarActores.Contains("Kate") && mostrarActores.Contains("Johnny") && mostrarActores.Contains("Helen"));
            Assert.AreEqual(mostrarActores, "Elenco: Robert. Tom. Kate. Johnny. Helen. ");
        }

        [TestMethod]
        public void DevolverConMenosDe5ActoresTest()
        {
            logicaPersona.AltaPersona(robert, admin);
            logicaPersona.AltaPersona(tom, admin);
            logicaPersona.AltaPersona(kate, admin);

            logicaPapel.AsociarActorPelicula(papelRobert, admin);
            logicaPapel.AsociarActorPelicula(papelTom, admin);
            logicaPapel.AsociarActorPelicula(papelKate, admin);

            string mostrarActores = logica.Actores(unaPelicula, 5);

            //Assert.IsTrue(mostrarActores.Contains("Robert") && mostrarActores.Contains("Tom")
            //    && mostrarActores.Contains("Kate"));
            Assert.AreEqual(mostrarActores, "Elenco: Robert. Tom. Kate. ");
        }

        [TestMethod]
        public void DevolverConMasDe5ActoresTest()
        {
            Persona jennifer = new Persona() { Id = 5, Nombre = "Jennifer" };
            Papel papelJennifer = new Papel() { Nombre = "papel Jennifer", Actor = jennifer, Pelicula = unaPelicula };

            logicaPersona.AltaPersona(robert, admin);
            logicaPersona.AltaPersona(tom, admin);
            logicaPersona.AltaPersona(kate, admin);
            logicaPersona.AltaPersona(johnny, admin);
            logicaPersona.AltaPersona(helen, admin);
            logicaPersona.AltaPersona(jennifer, admin);

            logicaPapel.AsociarActorPelicula(papelRobert, admin);
            logicaPapel.AsociarActorPelicula(papelTom, admin);
            logicaPapel.AsociarActorPelicula(papelKate, admin);
            logicaPapel.AsociarActorPelicula(papelJohnny, admin);
            logicaPapel.AsociarActorPelicula(papelHelen, admin);
            logicaPapel.AsociarActorPelicula(papelJennifer, admin);

            string mostrarActores = logica.Actores(unaPelicula, 5);

            Assert.IsFalse(mostrarActores.Contains("Jennifer")); 
            //Assert.AreEqual(mostrarActores, "Elenco: Robert. Tom. Kate. Johnny. Helen. ");
        }

        [TestMethod]
        public void DevolverDirectoresTest()
        {
            logicaPersona.AltaPersona(robert, admin);
            logicaPersona.AltaPersona(tom, admin);
            logicaPersona.AltaPersona(kate, admin);

            logicaPersona.AsociarDirector(robert, unaPelicula, admin);
            logicaPersona.AsociarDirector(tom, unaPelicula, admin);
            logicaPersona.AsociarDirector(kate, unaPelicula, admin);

            string mostrarDirectores = logica.Directores(unaPelicula, 3);

            //Assert.IsTrue(mostrarDirectores.Contains("Robert") && mostrarDirectores.Contains("Tom")
            //    && mostrarDirectores.Contains("Kate"));
            Assert.AreEqual(mostrarDirectores, "Dirección: Robert. Tom. Kate. ");
        }

        [TestMethod]
        public void DevolverConMenosDe3DirectoresTest()
        {
            logicaPersona.AltaPersona(robert, admin);
            logicaPersona.AltaPersona(tom, admin);

            logicaPersona.AsociarDirector(robert, unaPelicula, admin);
            logicaPersona.AsociarDirector(tom, unaPelicula, admin);

            string mostrarDirectores = logica.Directores(unaPelicula, 3);

            //Assert.IsTrue(mostrarDirectores.Contains("Robert") && mostrarDirectores.Contains("Tom"));
            Assert.AreEqual(mostrarDirectores, "Dirección: Robert. Tom. ");
        }

        [TestMethod]
        public void DevolverConMasDe3DirectoresTest()
        {
            logicaPersona.AltaPersona(robert, admin);
            logicaPersona.AltaPersona(tom, admin);
            logicaPersona.AltaPersona(kate, admin);
            logicaPersona.AltaPersona(johnny, admin);

            logicaPersona.AsociarDirector(robert, unaPelicula, admin);
            logicaPersona.AsociarDirector(tom, unaPelicula, admin);
            logicaPersona.AsociarDirector(kate, unaPelicula, admin);
            logicaPersona.AsociarDirector(johnny, unaPelicula, admin);

            string mostrarDirectores = logica.Directores(unaPelicula, 3);

            //Assert.IsTrue(mostrarDirectores.Contains("Robert") && mostrarDirectores.Contains("Tom")
            //    && mostrarDirectores.Contains("Kate"));
            Assert.IsFalse(mostrarDirectores.Contains("Johhny"));
            Assert.AreEqual(mostrarDirectores, "Dirección: Robert. Tom. Kate. ");
        }

    }
}
