﻿using Dominio;
using Dominio.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Dominio.Exceptions;

namespace Pruebas.PruebasDominio
{
    [TestClass]
    public class PerfilTest
    {
        [TestMethod]
        public void AliasValido()
        {
            //arrange
            Perfil unPerfil = new Perfil()
            {
                Alias = "nano"
            };

            //assert
            Assert.AreEqual(unPerfil.Alias, "nano");
        }

        [TestMethod]
        [ExpectedException(typeof(AliasInvalidoException))]
        public void AliasInvalido()
        {
            //arrange
            Perfil unPerfil = new Perfil()
            {
                Alias = ""
            };
        }


        [TestMethod]
        [ExpectedException(typeof(AliasInvalidoException))]
        public void AliasInvalido2()
        {
            //arrange
            string alias16Caracteres = "aaaaaaaaaaaaaaaa";
            Perfil unPerfil = new Perfil()
            {
                Alias = alias16Caracteres
            };
        }

        [TestMethod]
        [ExpectedException(typeof(AliasInvalidoException))]
        public void AliasInvalido3()
        {
            //arrange
            string soloNumeros = "12345";
            Perfil unPerfil = new Perfil()
            {
                Alias = soloNumeros
            };
        }

        [TestMethod]
        [ExpectedException(typeof(AliasInvalidoException))]
        public void AliasInvalido4()
        {
            //arrange
            string aliasEspaciosEnBlanco = "         ";
            Perfil unPerfil = new Perfil()
            {
                Alias = aliasEspaciosEnBlanco
            };
        }

        [TestMethod]
        public void PinValido()
        {
            //arrange
            Perfil unPerfil = new Perfil()
            {
                Pin = 1234
            };

            //assert
            Assert.AreEqual(unPerfil.Pin, 1234);
        }

        [TestMethod]
        [ExpectedException(typeof(PinInvalidoException))]
        public void PinInvalido()
        {
            //arrange
            int PinInvalido = 123456;
            Perfil unPerfil = new Perfil()
            {
                Pin = 123456
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

            Assert.IsTrue(unPerfil.PuntajeGenero.Contains(generoPuntaje));
        }

        [TestMethod]
        public void QuitarGeneroPuntajeTest()
        {
            Perfil unPerfil = new Perfil();
            GeneroPuntaje generoPuntaje = new GeneroPuntaje();
            unPerfil.AgregarGeneroPuntaje(generoPuntaje);
            unPerfil.QuitarGeneroPuntaje(generoPuntaje);

            Assert.IsFalse(unPerfil.PuntajeGenero.Contains(generoPuntaje));
        }
    }
}
