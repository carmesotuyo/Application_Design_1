using Dominio;
using Dominio.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Pruebas.PruebasDominio
{
    [TestClass]
    public class PerfilTest
    {
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
                Pin = 1234
            };
            Assert.AreEqual(unPerfil.Pin, 1234);
        }

        [TestMethod]
        [ExpectedException(typeof(PinInvalidoException))]
        public void PinInvalidoTest()
        {
            int PinInvalido = 123456;
            Perfil unPerfil = new Perfil()
            {
                Pin = PinInvalido
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
        public void AgregarGeneroPuntajeTest()
        {
            Perfil unPerfil = new Perfil();
            GeneroPuntaje generoPuntaje = new GeneroPuntaje();
            unPerfil.AgregarGeneroPuntaje(generoPuntaje);
            Assert.IsTrue(unPerfil.PuntajeGeneros.Contains(generoPuntaje));
        }

        [TestMethod]
        public void QuitarGeneroPuntajeTest()
        {
            Perfil unPerfil = new Perfil();
            GeneroPuntaje generoPuntaje = new GeneroPuntaje();
            unPerfil.AgregarGeneroPuntaje(generoPuntaje);
            unPerfil.QuitarGeneroPuntaje(generoPuntaje);
            Assert.IsFalse(unPerfil.PuntajeGeneros.Contains(generoPuntaje));
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
