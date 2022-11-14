using Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logica;
using Logica.Implementaciones;
using Logica.Exceptions;
using Repositorio;
using Repositorio.Interfaces;
using Dominio.Exceptions;
using Logica.Interfaces;
using Repositorio.EnDataBase;

namespace Pruebas.PruebasLogica
{
    [TestClass]
    public class LogicaPerfilTest
    {
        LogicaPerfil logicaPerfil = new LogicaPerfil(new PerfilDBRepo(), new GeneroPuntajeDBRepo(), new PeliculaDBRepo(), new GeneroDBRepo());
        LogicaUsuario logicaUsuario = new LogicaUsuario(new UsuarioDBRepo(), new PerfilDBRepo());
        Perfil unPerfil = new Perfil();
        enum Puntajes
        {
            Negativo = -1,
            Positivo = 1,
            MuyPositivo = 2
        }

        [TestMethod]
        public void PuntuarPeliculaNegativoTest()
        {
            Genero comedia = new Genero() { Nombre = "comedia" };
            Pelicula unaPelicula = new Pelicula() { GeneroPrincipal = comedia };

            logicaPerfil.AgregarGeneroPuntuado(unPerfil, comedia);

            logicaPerfil.PuntuarNegativo(unaPelicula, unPerfil);

            Assert.IsTrue(unPerfil.PuntajeGeneros[0].Puntaje == (int)Puntajes.Negativo);
        }

        [TestMethod]
        public void PuntuarPeliculaPositivoTest()
        {
            Genero comedia = new Genero() { Nombre = "comedia" };
            Pelicula unaPelicula = new Pelicula() { GeneroPrincipal = comedia };
            logicaPerfil.AgregarGeneroPuntuado(unPerfil, comedia);

            logicaPerfil.PuntuarPositivo(unaPelicula, unPerfil);

            Assert.IsTrue(unPerfil.PuntajeGeneros[0].Puntaje == (int)Puntajes.Positivo);
        }

        [TestMethod]
        public void PuntuarPeliculaMuyPositivoTest()
        {
            Genero comedia = new Genero() { Nombre = "comedia" };
            Genero romance = new Genero() { Nombre = "Romance" };
            Pelicula unaPelicula = new Pelicula() { GeneroPrincipal = comedia };
            unaPelicula.AgregarGeneroSecundario(romance);

            logicaPerfil.AgregarGeneroPuntuado(unPerfil, comedia);
            logicaPerfil.AgregarGeneroPuntuado(unPerfil, romance);

            logicaPerfil.PuntuarMuyPositivo(unaPelicula, unPerfil);

            Assert.IsTrue(unPerfil.PuntajeGeneros[0].Puntaje == (int)Puntajes.MuyPositivo && unPerfil.PuntajeGeneros[1].Puntaje == (int)Puntajes.Positivo);
        }

        [TestMethod]
        public void MarcarPeliculaComoVistaTest()
        {
            Genero comedia = new Genero() { Nombre = "comedia" };
            Pelicula unaPelicula = new Pelicula() { GeneroPrincipal = comedia };

            logicaPerfil.AgregarGeneroPuntuado(unPerfil, comedia);

            logicaPerfil.MarcarComoVista(unaPelicula, unPerfil);

            Assert.IsTrue(unPerfil.EstaPeliculaVista(unaPelicula));
        }

        [TestMethod]
        public void PuntajeEditadoPorVerPeliculaTest()
        {
            Genero comedia = new Genero() { Nombre = "comedia" };
            Pelicula unaPelicula = new Pelicula() { GeneroPrincipal = comedia };

            logicaPerfil.AgregarGeneroPuntuado(unPerfil, comedia);
            logicaPerfil.MarcarComoVista(unaPelicula, unPerfil);

            Assert.IsTrue(unPerfil.PuntajeGeneros[0].Puntaje == (int)Puntajes.Positivo);
        }

        [TestMethod]
        public void AccederAPerfilAdultoTest()
        {
            unPerfil.EsInfantil = false;
            unPerfil.Pin = 12345;

            Perfil AccesoCorrecto = logicaPerfil.AccederAlPerfil(unPerfil, 12345);

            Assert.IsTrue(AccesoCorrecto.Equals(unPerfil));
        }

        [TestMethod]
        [ExpectedException(typeof(PinIncorrectoException))]
        public void AccederConPinIncorrectoTest()
        {
            unPerfil.EsInfantil = false;
            unPerfil.Pin = 12345;

            Perfil AccesoIncorrecto = logicaPerfil.AccederAlPerfil(unPerfil, 11111);
        }

        [TestMethod]
        public void AccederAPerfilInfantilTest()
        {
            unPerfil.EsInfantil = true;
            unPerfil.Pin = 12345;
            int pinSinImportancia = 10000;

            Perfil AccesoCorrecto = logicaPerfil.AccederAlPerfil(unPerfil, pinSinImportancia);

            Assert.IsTrue(AccesoCorrecto.Equals(unPerfil));
        }

        [TestMethod]
        public void MarcarPerfilComoInfantilTest()
        {
            unPerfil.EsOwner = true;
            Perfil perfilInfantil = new Perfil() { Alias = "fer", EsInfantil = false };
            Usuario usuario = new Usuario();
            logicaUsuario.AgregarPerfil(usuario, unPerfil);
            logicaUsuario.AgregarPerfil(usuario, perfilInfantil);

            logicaPerfil.MarcarComoInfantil(perfilInfantil, unPerfil);

            Assert.IsTrue(perfilInfantil.EsInfantil);
        }

        [TestMethod]
        [ExpectedException(typeof(PerfilNoOwnerException))]
        public void MarcarPerfilComoInfantilSinPermisosTest()
        {
            unPerfil.EsOwner = false;
            Perfil perfilOwner = new Perfil() { Alias = "carme", EsOwner = true };
            Perfil perfilInfantil = new Perfil() { Alias = "fer", EsInfantil = false };
            Usuario usuario = new Usuario();

            logicaUsuario.AgregarPerfil(usuario, perfilOwner);
            logicaUsuario.AgregarPerfil(usuario, unPerfil);
            logicaUsuario.AgregarPerfil(usuario, perfilInfantil);

            logicaPerfil.MarcarComoInfantil(perfilInfantil, unPerfil);
        }

        [TestMethod]
        [ExpectedException(typeof(NoInfantilException))]
        public void MarcarOwnerComoInfantilTest()
        {
            unPerfil.EsOwner = true;
            Perfil otroOwner = new Perfil() { Alias = "carme", EsOwner = true };
            Usuario unUsuario = new Usuario();

            logicaUsuario.AgregarPerfil(unUsuario, unPerfil);
            logicaUsuario.AgregarPerfil(unUsuario, otroOwner);

            logicaPerfil.MarcarComoInfantil(otroOwner, unPerfil);
        }

        [TestMethod]
        public void AgregarPeliculaVistaTest()
        {
            Pelicula unaPelicula = new Pelicula();

            logicaPerfil.AgregarPeliculaVista(unaPelicula, unPerfil);

            Assert.IsTrue(unPerfil.EstaPeliculaVista(unaPelicula));
        }

        [TestMethod]
        [ExpectedException(typeof(PeliculaYaVistaException))]
        public void AgregarPeliculaVistaDosVecesTest()
        {
            Pelicula unaPelicula = new Pelicula();

            logicaPerfil.AgregarPeliculaVista(unaPelicula, unPerfil);
            logicaPerfil.AgregarPeliculaVista(unaPelicula, unPerfil);
        }


        [TestMethod]
        public void VioPeliculaTest()
        {
            Pelicula unaPelicula = new Pelicula();

            logicaPerfil.AgregarPeliculaVista(unaPelicula, unPerfil);

            Assert.IsTrue(logicaPerfil.VioPelicula(unaPelicula, unPerfil));
        }

        [TestMethod]
        public void NoVioPeliculaTest()
        {
            Pelicula unaPelicula = new Pelicula();

            Assert.IsFalse(logicaPerfil.VioPelicula(unaPelicula, unPerfil));
        }

        //[TestMethod]
        //public void AgregarGeneroPuntajeTest()
        //{
        //    Perfil unPerfil = new Perfil();
        //    GeneroPuntaje generoPuntaje = new GeneroPuntaje();
        //    logicaPerfil.AgregarGeneroPuntuado(generoPuntaje);
        //    Assert.IsTrue(unPerfil.PuntajeGeneros.Contains(generoPuntaje));
        //}

        //[TestMethod]
        //public void QuitarGeneroPuntajeTest()
        //{
        //    Perfil unPerfil = new Perfil();
        //    GeneroPuntaje generoPuntaje = new GeneroPuntaje();
        //    unPerfil.AgregarGeneroPuntaje(generoPuntaje);
        //    unPerfil.QuitarGeneroPuntaje(generoPuntaje);
        //    Assert.IsFalse(unPerfil.PuntajeGeneros.Contains(generoPuntaje));
        //}

        [TestMethod]
        public void ActualizarListadoPuntajeAgregandoGeneroTest()
        {
            GeneroRepo repo = new GeneroRepo();
            ILogicaGenero logicaGenero = new LogicaGenero(repo);
            Genero terror = new Genero() { Nombre = "Terror" };
            repo.AgregarGenero(terror);
            logicaPerfil.AgregarGeneroPuntuado(unPerfil, terror);

            Genero comedia = new Genero() { Nombre = "comedia" };
            repo.AgregarGenero(comedia);

            logicaPerfil.ActualizarListadoGeneros(unPerfil);

            Assert.IsTrue(logicaPerfil.EstaGenero(unPerfil, comedia));
        }

        [TestMethod]
        public void ActualizarListadoPuntajeEliminandoGeneroTest()
        {
            GeneroRepo repo = new GeneroRepo();
            ILogicaGenero logicaGenero = new LogicaGenero(repo);
            Genero terror = new Genero() { Nombre = "Terror" };
            repo.AgregarGenero(terror);

            Genero comedia = new Genero() { Nombre = "comedia" };
            repo.AgregarGenero(comedia);

            logicaPerfil.AgregarGeneroPuntuado(unPerfil, terror);
            logicaPerfil.AgregarGeneroPuntuado(unPerfil, comedia);

            repo.EliminarGenero(comedia);
            logicaPerfil.ActualizarListadoGeneros(unPerfil);

            Assert.IsFalse(logicaPerfil.EstaGenero(unPerfil, comedia));
        }
    }
}
