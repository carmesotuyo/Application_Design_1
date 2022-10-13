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
using Dominio.Exceptions;
using Logica.Interfaces;

namespace Pruebas.PruebasLogica
{
    [TestClass]
    public class LogicaPerfilTest
    {
        LogicaPerfil logica = new LogicaPerfil();
        LogicaUsuario logicaUsuario = new LogicaUsuario(new RepoUsuarios());
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
            GeneroPuntaje generoPuntaje = new GeneroPuntaje() { Genero = comedia.Nombre };
            unPerfil.AgregarGeneroPuntaje(generoPuntaje);

            logica.PuntuarNegativo(unaPelicula, unPerfil);

            Assert.IsTrue(unPerfil.PuntajeGeneros[0].Puntaje == (int)Puntajes.Negativo);
        }

        [TestMethod]
        public void PuntuarPeliculaPositivoTest()
        {
            Genero comedia = new Genero() { Nombre = "comedia" };
            Pelicula unaPelicula = new Pelicula() { GeneroPrincipal = comedia };
            GeneroPuntaje generoPuntaje = new GeneroPuntaje() { Genero = comedia.Nombre };
            unPerfil.AgregarGeneroPuntaje(generoPuntaje);

            logica.PuntuarPositivo(unaPelicula, unPerfil);

            Assert.IsTrue(unPerfil.PuntajeGeneros[0].Puntaje == (int)Puntajes.Positivo);
        }

        [TestMethod]
        public void PuntuarPeliculaMuyPositivoTest()
        {
            Genero comedia = new Genero() { Nombre = "comedia" };
            Genero romance = new Genero() { Nombre = "Romance" };
            Pelicula unaPelicula = new Pelicula() { GeneroPrincipal = comedia };
            unaPelicula.AgregarGeneroSecundario(romance);
            GeneroPuntaje generoComedia = new GeneroPuntaje() { Genero = comedia.Nombre };
            GeneroPuntaje generoRomance = new GeneroPuntaje() { Genero = romance.Nombre };
            unPerfil.AgregarGeneroPuntaje(generoComedia);
            unPerfil.AgregarGeneroPuntaje(generoRomance);

            logica.PuntuarMuyPositivo(unaPelicula, unPerfil);

            Assert.IsTrue(unPerfil.PuntajeGeneros[0].Puntaje == (int)Puntajes.MuyPositivo && unPerfil.PuntajeGeneros[1].Puntaje == (int)Puntajes.Positivo);
        }

        [TestMethod]
        public void MarcarPeliculaComoVistaTest()
        {
            Genero comedia = new Genero() { Nombre = "comedia" };
            Pelicula unaPelicula = new Pelicula() { GeneroPrincipal = comedia };
            GeneroPuntaje generoComedia = new GeneroPuntaje() { Genero = comedia.Nombre };
            unPerfil.AgregarGeneroPuntaje(generoComedia);

            logica.MarcarComoVista(unaPelicula, unPerfil);

            Assert.IsTrue(unPerfil.EstaPeliculaVista(unaPelicula));
        }

        [TestMethod]
        public void PuntajeEditadoPorVerPeliculaTest()
        {
            Genero comedia = new Genero() { Nombre = "comedia" };
            Pelicula unaPelicula = new Pelicula() { GeneroPrincipal = comedia };
            GeneroPuntaje generoComedia = new GeneroPuntaje() { Genero = comedia.Nombre };
            
            unPerfil.AgregarGeneroPuntaje(generoComedia);
            logica.MarcarComoVista(unaPelicula, unPerfil);

            Assert.IsTrue(unPerfil.PuntajeGeneros[0].Puntaje == (int)Puntajes.Positivo);
        }

        [TestMethod]
        public void AccederAPerfilAdultoTest()
        {
            unPerfil.EsInfantil = false;
            unPerfil.Pin = 12345;

            Perfil AccesoCorrecto = logica.AccederAlPerfil(unPerfil, 12345);

            Assert.IsTrue(AccesoCorrecto.Equals(unPerfil));
        }

        [TestMethod]
        [ExpectedException(typeof(PinIncorrectoException))]
        public void AccederConPinIncorrectoTest()
        {
            unPerfil.EsInfantil = false;
            unPerfil.Pin = 12345;

            Perfil AccesoIncorrecto = logica.AccederAlPerfil(unPerfil, 11111);
        }

        [TestMethod]
        public void AccederAPerfilInfantilTest()
        {
            unPerfil.EsInfantil = true;
            unPerfil.Pin = 12345;
            int pinSinImportancia = 10000;

            Perfil AccesoCorrecto = logica.AccederAlPerfil(unPerfil, pinSinImportancia);

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

            logica.MarcarComoInfantil(perfilInfantil, unPerfil, usuario);

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

            logica.MarcarComoInfantil(perfilInfantil, unPerfil, usuario);
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

            logica.MarcarComoInfantil(otroOwner, unPerfil, unUsuario);
        }

        [TestMethod]
        public void AgregarPeliculaVistaTest()
        {
            Pelicula unaPelicula = new Pelicula();

            logica.AgregarPeliculaVista(unaPelicula, unPerfil);

            Assert.IsTrue(unPerfil.EstaPeliculaVista(unaPelicula));
        }

        [TestMethod]
        [ExpectedException(typeof(PeliculaYaVistaException))]
        public void AgregarPeliculaVistaDosVecesTest()
        {
            Pelicula unaPelicula = new Pelicula();

            logica.AgregarPeliculaVista(unaPelicula, unPerfil);
            logica.AgregarPeliculaVista(unaPelicula, unPerfil);
        }


        [TestMethod]
        public void VioPeliculaTest()
        {
            Pelicula unaPelicula = new Pelicula();

            logica.AgregarPeliculaVista(unaPelicula, unPerfil);

            Assert.IsTrue(logica.VioPelicula(unaPelicula, unPerfil));
        }

        [TestMethod]
        public void NoVioPeliculaTest()
        {
            Pelicula unaPelicula = new Pelicula();

            Assert.IsFalse(logica.VioPelicula(unaPelicula, unPerfil));
        }

        [TestMethod]
        public void ActualizarListadoPuntajeAgregandoGeneroTest()
        {
            GeneroRepo repo = new GeneroRepo();
            ILogicaGenero logicaGenero = new LogicaGenero(repo);
            Genero terror = new Genero() { Nombre = "Terror" };
            repo.AgregarGenero(terror);
            logica.AgregarGenero(unPerfil, terror);

            Genero comedia = new Genero() { Nombre = "comedia" };
            repo.AgregarGenero(comedia);

            logica.ActualizarListadoGeneros(unPerfil, logicaGenero);

            Assert.IsTrue(logica.EstaGenero(unPerfil, comedia));
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

            logica.AgregarGenero(unPerfil, terror);
            logica.AgregarGenero(unPerfil, comedia);

            repo.EliminarGenero(comedia);
            logica.ActualizarListadoGeneros(unPerfil, logicaGenero);

            Assert.IsFalse(logica.EstaGenero(unPerfil, comedia));
        }
    }
}
