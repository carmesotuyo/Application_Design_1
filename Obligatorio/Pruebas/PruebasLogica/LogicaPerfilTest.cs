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

namespace Pruebas.PruebasLogica
{
    [TestClass]
    public class LogicaPerfilTest
    {
        LogicaPerfil logica = new LogicaPerfil();
        LogicaPerfil logicaInfantil = new LogicaPerfilInfantil();
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
        public void FiltrarPeliculasNoAptasTest()
        {
            PeliculaRepo repo = new PeliculaRepo();
            Pelicula peliculaApta = new Pelicula() { AptaTodoPublico = true };
            Pelicula peliculaNoApta = new Pelicula() { AptaTodoPublico = false };
            repo.AgregarPelicula(peliculaApta);
            repo.AgregarPelicula(peliculaNoApta);
            Perfil unPerfil = new Perfil() { EsInfantil = true };

            List<Pelicula> soloAptas = logicaInfantil.MostrarPeliculas(repo);

            Assert.IsTrue(soloAptas.Count == 1);
        }

        [TestMethod]
        public void NoFiltrarSiNoEsInfantilTest()
        {
            PeliculaRepo repo = new PeliculaRepo();
            Pelicula peliculaApta = new Pelicula() { AptaTodoPublico = true };
            Pelicula peliculaNoApta = new Pelicula() { AptaTodoPublico = false };
            repo.AgregarPelicula(peliculaApta);
            repo.AgregarPelicula(peliculaNoApta);
            Perfil unPerfil = new Perfil() { EsInfantil = false };

            List<Pelicula> todas = logica.MostrarPeliculas(repo);

            Assert.AreEqual(todas, repo.peliculas);
        }

        [TestMethod]
        public void AccederAPerfilAdultoTest()
        {
            unPerfil.EsInfantil = false;
            unPerfil.Pin = 1234;

            Perfil AccesoCorrecto = logica.AccederAlPerfil(unPerfil, 1234);

            Assert.IsTrue(AccesoCorrecto.Equals(unPerfil));
        }

        [TestMethod]
        [ExpectedException(typeof(PinIncorrectoException))]
        public void AccederConPinIncorrectoTest()
        {
            unPerfil.EsInfantil = false;
            unPerfil.Pin = 1234;

            Perfil AccesoIncorrecto = logica.AccederAlPerfil(unPerfil, 1111);
        }

        [TestMethod]
        public void AccederAPerfilInfantilTest()
        {
            unPerfil.EsInfantil = true;
            unPerfil.Pin = 1234;
            int pinSinImportancia = 0;

            Perfil AccesoCorrecto = logicaInfantil.AccederAlPerfil(unPerfil, pinSinImportancia);

            Assert.IsTrue(AccesoCorrecto.Equals(unPerfil));
        }

        [TestMethod]
        [ExpectedException(typeof(PerfilNoInfantilException))]
        public void AdultoNoAccedeALogicaInfantilTest()
        {
            unPerfil.EsInfantil = false;
            unPerfil.Pin = 1234;

            Perfil AccesoIncorrecto = logicaInfantil.AccederAlPerfil(unPerfil, 1234);
        }

        [TestMethod]
        public void MarcarPerfilComoInfantilTest()
        {
            unPerfil.EsOwner = true;
            Perfil perfilInfantil = new Perfil() { EsInfantil = false };
            Usuario usuario = new Usuario();
            usuario.AgregarPerfil(unPerfil);
            usuario.AgregarPerfil(perfilInfantil);

            logica.MarcarComoInfantil(perfilInfantil, unPerfil, usuario);

            Assert.IsTrue(perfilInfantil.EsInfantil);
        }

        [TestMethod]
        [ExpectedException(typeof(PerfilNoOwnerException))]
        public void MarcarPerfilComoInfantilSinPermisosTest()
        {
            unPerfil.EsOwner = false;
            Perfil perfilOwner = new Perfil() { EsOwner = true };
            Perfil perfilInfantil = new Perfil() { EsInfantil = false };
            Usuario usuario = new Usuario();

            usuario.AgregarPerfil(perfilOwner);
            usuario.AgregarPerfil(unPerfil);
            usuario.AgregarPerfil(perfilInfantil);

            logica.MarcarComoInfantil(perfilInfantil, unPerfil, usuario);
        }

        [TestMethod]
        [ExpectedException(typeof(NoExistePerfilException))]
        public void MarcarPerfilComoInfantilDeOtroUsuarioTest()
        {
            unPerfil.EsOwner = true;
            Perfil perfilInfantil = new Perfil() { EsInfantil = false };
            Usuario unUsuario = new Usuario();
            Usuario otroUsuario = new Usuario();

            unUsuario.AgregarPerfil(unPerfil);
            otroUsuario.AgregarPerfil(perfilInfantil);

            logica.MarcarComoInfantil(perfilInfantil, unPerfil, unUsuario);
        }

        [TestMethod]
        [ExpectedException(typeof(NoInfantilException))]
        public void MarcarOwnerComoInfantilTest()
        {
            unPerfil.EsOwner = true;
            Perfil otroOwner = new Perfil() { EsOwner = true };
            Usuario unUsuario = new Usuario();

            unUsuario.AgregarPerfil(unPerfil);
            unUsuario.AgregarPerfil(otroOwner);

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
            Genero terror = new Genero() { Nombre = "Terror" };
            repo.AgregarGenero(terror);
            logica.AgregarGenero(unPerfil, terror);

            Genero comedia = new Genero() { Nombre = "comedia" };
            repo.AgregarGenero(comedia);

            logica.ActualizarListadoGeneros(unPerfil, repo);

            Assert.IsTrue(logica.EstaGenero(unPerfil, comedia));
        }

        [TestMethod]
        public void ActualizarListadoPuntajeEliminandoGeneroTest()
        {
            GeneroRepo repo = new GeneroRepo();
            Genero terror = new Genero() { Nombre = "Terror" };
            repo.AgregarGenero(terror);

            Genero comedia = new Genero() { Nombre = "comedia" };
            repo.AgregarGenero(comedia);

            logica.AgregarGenero(unPerfil, terror);
            logica.AgregarGenero(unPerfil, comedia);

            repo.EliminarGenero(comedia);
            logica.ActualizarListadoGeneros(unPerfil, repo);

            Assert.IsFalse(logica.EstaGenero(unPerfil, comedia));
        }
    }
}
