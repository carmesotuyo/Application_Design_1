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
        ILogicaUsuario logicaUsuario = new LogicaUsuario(new UsuarioDBRepo(), new PerfilDBRepo());
        ILogicaGenero logicaGenero = new LogicaGenero(new GeneroDBRepo());
        LogicaPelicula logicaPelicula = new LogicaPelicula(new PeliculaDBRepo(), new PerfilDBRepo());
        Usuario admin = new Usuario() { EsAdministrador = true };
        static Usuario usuario = new Usuario()
        {
            Nombre = "NombreDeUsuario",
            Email = "usuario@gmail.com",
            Clave = "usuario123",
            ConfirmarClave = "usuario123"
        };
        Perfil unPerfil = new Perfil()
        {
            Alias = "perfil",
            Usuario = usuario,
            Pin = 12345,
            ConfirmarPin = 12345,
            EsOwner = true
        };
        Perfil perfilInfantil = new Perfil()
        {
            Alias = "infantil",
            EsInfantil = false,
            Usuario = usuario,
            Pin = 12345,
            ConfirmarPin = 12345
        };
        static Genero comedia = new Genero() { Nombre = "comedia" };
        static Genero romance = new Genero() { Nombre = "romance" };
        Pelicula unaPelicula = new Pelicula()
        {
            Identificador = 1,
            Nombre = "nombre",
            GeneroPrincipal = comedia,
            Descripcion = "algo",
            Poster = "ruta"
        };

        [TestInitialize]
        public void Setup()
        {
            DBCleanUp.CleanUp();
            logicaUsuario.RegistrarUsuario(usuario);
            logicaUsuario.AgregarPerfil(usuario, unPerfil);
            logicaUsuario.AgregarPerfil(usuario, perfilInfantil);
            logicaGenero.AgregarGenero(admin, comedia);
            logicaGenero.AgregarGenero(admin, romance);
            logicaPelicula.AltaPelicula(unaPelicula, admin);
        }

        enum Puntajes
        {
            Negativo = -1,
            Positivo = 1,
            MuyPositivo = 2
        }

        [TestMethod]
        public void PuntuarPeliculaNegativoTest()
        {
            logicaPerfil.AgregarGeneroPuntuado(unPerfil, comedia);

            logicaPerfil.PuntuarNegativo(unaPelicula, unPerfil);

            int puntaje = logicaPerfil.PuntajeGenero(unPerfil, comedia);
            Assert.AreEqual(puntaje, (int)Puntajes.Negativo);
        }

        [TestMethod]
        public void PuntuarPeliculaPositivoTest()
        {
            logicaPerfil.AgregarGeneroPuntuado(unPerfil, comedia);

            logicaPerfil.PuntuarPositivo(unaPelicula, unPerfil);

            int puntaje = logicaPerfil.PuntajeGenero(unPerfil, comedia);
            Assert.AreEqual(puntaje, (int)Puntajes.Positivo);
        }

        [TestMethod]
        public void PuntuarPeliculaMuyPositivoTest()
        {
            logicaPelicula.AgregarGeneroSecundario(unaPelicula, romance);

            logicaPerfil.AgregarGeneroPuntuado(unPerfil, comedia);
            logicaPerfil.AgregarGeneroPuntuado(unPerfil, romance);

            logicaPerfil.PuntuarMuyPositivo(unaPelicula, unPerfil);

            int puntajeComedia = logicaPerfil.PuntajeGenero(unPerfil, comedia);
            int puntajeRomance = logicaPerfil.PuntajeGenero(unPerfil, romance);
            Assert.IsTrue(puntajeComedia == (int)Puntajes.MuyPositivo && puntajeRomance == (int)Puntajes.Positivo);
        }

        [TestMethod]
        public void MarcarPeliculaComoVistaTest()
        {
            logicaPerfil.AgregarGeneroPuntuado(unPerfil, comedia);

            logicaPerfil.MarcarComoVista(unaPelicula, unPerfil);

            Assert.IsTrue(logicaPerfil.VioPelicula(unaPelicula, unPerfil));
        }

        [TestMethod]
        public void PuntajeEditadoPorVerPeliculaTest()
        {
            logicaPerfil.AgregarGeneroPuntuado(unPerfil, comedia);
            logicaPerfil.MarcarComoVista(unaPelicula, unPerfil);

            int puntajeComedia = logicaPerfil.PuntajeGenero(unPerfil, comedia);
            Assert.IsTrue(puntajeComedia == (int)Puntajes.Positivo);
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
            bool NoEraInfantil = !logicaPerfil.EsInfantil(perfilInfantil);

            logicaPerfil.MarcarComoInfantil(perfilInfantil, unPerfil);

            bool AhoraEsInfantil = logicaPerfil.EsInfantil(perfilInfantil);

            Assert.IsTrue(NoEraInfantil && AhoraEsInfantil);
        }

        [TestMethod]
        [ExpectedException(typeof(PerfilNoOwnerException))]
        public void MarcarPerfilComoInfantilSinPermisosTest()
        {
            Perfil noOwner = new Perfil()
            {
                Alias = "noOwner",
                Usuario = usuario,
                Pin = 12345,
                ConfirmarPin = 12345,
                EsOwner = false
            };

            logicaUsuario.AgregarPerfil(usuario, noOwner);

            logicaPerfil.MarcarComoInfantil(perfilInfantil, noOwner);
        }

        [TestMethod]
        [ExpectedException(typeof(NoInfantilException))]
        public void MarcarOwnerComoInfantilTest()
        {
            Perfil otroOwner = new Perfil()
            {
                Alias = "owner",
                Usuario = usuario,
                Pin = 12345,
                ConfirmarPin = 12345,
                EsOwner = true
            };

            logicaUsuario.AgregarPerfil(usuario, otroOwner);

            logicaPerfil.MarcarComoInfantil(otroOwner, unPerfil);
        }

        [TestMethod]
        public void AgregarPeliculaVistaTest()
        {
            logicaPerfil.AgregarPeliculaVista(unaPelicula, unPerfil);

            Assert.IsTrue(logicaPerfil.VioPelicula(unaPelicula, unPerfil));
        }

        [TestMethod]
        [ExpectedException(typeof(PeliculaYaVistaException))]
        public void AgregarPeliculaVistaDosVecesTest()
        {
            logicaPerfil.AgregarPeliculaVista(unaPelicula, unPerfil);
            logicaPerfil.AgregarPeliculaVista(unaPelicula, unPerfil);
        }


        [TestMethod]
        public void VioPeliculaTest()
        {
            logicaPerfil.AgregarPeliculaVista(unaPelicula, unPerfil);

            Assert.IsTrue(logicaPerfil.VioPelicula(unaPelicula, unPerfil));
        }

        [TestMethod]
        public void NoVioPeliculaTest()
        {
            Pelicula unaPelicula = new Pelicula();

            Assert.IsFalse(logicaPerfil.VioPelicula(unaPelicula, unPerfil));
        }

        [TestMethod]
        public void AgregarGeneroPuntajeTest()
        {
            logicaPerfil.AgregarGeneroPuntuado(unPerfil, comedia);

            Assert.IsTrue(logicaPerfil.EstaGenero(unPerfil, comedia));
        }

        [TestMethod]
        public void QuitarGeneroPuntajeTest()
        {
            Genero terror = new Genero() { Nombre = "terror" };
            logicaGenero.AgregarGenero(admin, terror);

            logicaPerfil.AgregarGeneroPuntuado(unPerfil, terror);

            logicaGenero.EliminarGenero(admin, terror, logicaPelicula);
            Assert.IsFalse(logicaPerfil.EstaGenero(unPerfil, terror));
        }

        [TestMethod]
        public void ActualizarListadoPuntajeAgregandoGeneroTest()
        {
            Genero terror = new Genero() { Nombre = "Terror" };
            logicaGenero.AgregarGenero(admin, terror);
            logicaPerfil.AgregarGeneroPuntuado(unPerfil, terror);

            Genero suspenso = new Genero() { Nombre = "suspenso" };
            logicaGenero.AgregarGenero(admin, suspenso);

            logicaPerfil.ActualizarListadoGeneros(unPerfil);

            Assert.IsTrue(logicaPerfil.EstaGenero(unPerfil, suspenso));
        }

        [TestMethod]
        public void ActualizarListadoPuntajeEliminandoGeneroTest()
        {
            Genero terror = new Genero() { Nombre = "Terror" };
            logicaGenero.AgregarGenero(admin, terror);

            logicaPerfil.AgregarGeneroPuntuado(unPerfil, terror);
            logicaPerfil.AgregarGeneroPuntuado(unPerfil, comedia);

            logicaGenero.EliminarGenero(admin, terror, logicaPelicula);
            logicaPerfil.ActualizarListadoGeneros(unPerfil);

            Assert.IsFalse(logicaPerfil.EstaGenero(unPerfil, terror));
        }

        [TestMethod]
        public void PeliculasVistasOrdenadasTest()
        {
            logicaPerfil.MarcarComoVista(unaPelicula, unPerfil);

            Pelicula otra = new Pelicula()
            {
                Identificador = 2,
                Nombre = "otra",
                GeneroPrincipal = comedia,
                Descripcion = "algo",
                Poster = "ruta"
            };

            logicaPelicula.AltaPelicula(otra, admin);
            logicaPerfil.MarcarComoVista(otra, unPerfil);

            List<Pelicula> pelisVistas = logicaPerfil.MostrarPeliculasVistas(unPerfil);

            Assert.IsTrue(pelisVistas[0].Equals(unaPelicula) && pelisVistas[1].Equals(otra));
        }
    }
}
