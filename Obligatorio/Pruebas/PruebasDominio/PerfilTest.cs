using Dominio;
using Dominio.Exceptions;
using Logica.Implementaciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositorio.EnDataBase;
using System;

namespace Pruebas.PruebasDominio
{
    [TestClass]
    public class PerfilTest
    {
        [TestInitialize]
        public void Setup()
        {
            DBCleanUp.CleanUp();
        }
        
        [TestMethod]
        public void AliasValidoTest()
        {
            Perfil unPerfil = new Perfil()
            {
                Alias = "nano"
            };
            Assert.AreEqual(unPerfil.Alias, "nano");
        }

        [TestMethod]
        [ExpectedException(typeof(AliasInvalidoException))]
        public void AliasInvalidoTest()
        {
            Perfil unPerfil = new Perfil()
            {
                Alias = ""
            };
        }


        [TestMethod]
        [ExpectedException(typeof(AliasInvalidoException))]
        public void AliasCon16CaracteresTest()
        {
            string alias16Caracteres = "aaaaaaaaaaaaaaaa";
            Perfil unPerfil = new Perfil()
            {
                Alias = alias16Caracteres
            };
        }

        [TestMethod]
        [ExpectedException(typeof(AliasInvalidoException))]
        public void AliasSoloNumeroTest()
        {
            string soloNumeros = "12345";
            Perfil unPerfil = new Perfil()
            {
                Alias = soloNumeros
            };
        }

        [TestMethod]
        [ExpectedException(typeof(AliasInvalidoException))]
        public void AliasEspaciosEnBlancoTest()
        {
            string aliasEspaciosEnBlanco = "         ";
            Perfil unPerfil = new Perfil()
            {
                Alias = aliasEspaciosEnBlanco
            };
        }

        [TestMethod]
        public void PinValidoTest()
        {
            Perfil unPerfil = new Perfil()
            {
                Pin = 12345
            };
            Assert.AreEqual(unPerfil.Pin, 12345);
        }

        [TestMethod]
        [ExpectedException(typeof(PinInvalidoException))]
        public void PinInvalidoLargoTest()
        {
            int PinInvalido = 123456;
            Perfil unPerfil = new Perfil()
            {
                Pin = PinInvalido
            };
        }

        [TestMethod]
        [ExpectedException(typeof(PinInvalidoException))]
        public void PinInvalidoCortoTest()
        {
            int PinInvalido = 1234;
            Perfil unPerfil = new Perfil()
            {
                Pin = PinInvalido
            };
        }

        [TestMethod]
        public void PinYConfirmacionCoincidenTest()
        {
            Perfil unPerfil = new Perfil()
            {
                Pin = 12345,
                ConfirmarPin = 12345
            };
            Assert.AreEqual(unPerfil.Pin, unPerfil.ConfirmarPin);
        }

        [TestMethod]
        [ExpectedException(typeof(PinNoCoincideException))]
        public void PinNoCoincideConConfirmacionTest()
        {
            Perfil unPerfil = new Perfil()
            {
                Pin = 12345,
                ConfirmarPin = 54321
            };
        }

        [TestMethod]
        public void PerfilInfantilTest()
        {
            Perfil unPerfil = new Perfil()
            {
                EsInfantil = true
            };

            Assert.IsTrue(unPerfil.EsInfantil);
        }

        [TestMethod]
        public void PerfilNoInfantilTest()
        {
            Perfil unPerfil = new Perfil()
            {
                EsInfantil = false
            };
            Assert.IsFalse(unPerfil.EsInfantil);
        }

        [TestMethod]
        public void AgregarPeliculaVistaTest()
        {
            Perfil unPerfil = new Perfil();
            Pelicula unaPelicula = new Pelicula();

            unPerfil.AgregarPeliculaVista(unaPelicula);

            Assert.IsTrue(unPerfil.PeliculasVistas.Contains(unaPelicula));
        }

        [TestMethod]
        public void EstaPeliculaVistaTest()
        {

            Perfil unPerfil = new Perfil();
            Pelicula unaPelicula = new Pelicula();

            unPerfil.AgregarPeliculaVista(unaPelicula);

            Assert.IsTrue(unPerfil.EstaPeliculaVista(unaPelicula));
        }

        [TestMethod]
        public void NoEstaPeliculaVistaTest()
        {
            Perfil unPerfil = new Perfil();
            Pelicula unaPelicula = new Pelicula();

            Assert.IsFalse(unPerfil.EstaPeliculaVista(unaPelicula));
        }

        [TestMethod]
        public void DevolverNombreTest()
        {
            Perfil unPerfil = new Perfil()
            {
                Alias = "nano"
            };

            Assert.AreEqual(unPerfil.ToString(), "nano");
        }
    }
}
