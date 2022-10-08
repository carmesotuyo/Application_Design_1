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
        public void AliasValidoTest()
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
        public void AliasInvalidoTest()
        {
            //arrange
            Perfil unPerfil = new Perfil()
            {
                Alias = ""
            };
        }


        [TestMethod]
        [ExpectedException(typeof(AliasInvalidoException))]
        public void AliasCon16CaracteresTest()
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
        public void AliasSoloNumeroTest()
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
        public void AliasEspaciosEnBalncoTest()
        {
            //arrange
            string aliasEspaciosEnBlanco = "         ";
            Perfil unPerfil = new Perfil()
            {
                Alias = aliasEspaciosEnBlanco
            };
        }

        [TestMethod]
        public void PinValidoTest()
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
        public void PinInvalidoTest()
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
        [ExpectedException(typeof(NoInfantilException))]
        public void OwnerInfantilTest()
        {
            //arrange
            Perfil unPerfil = new Perfil()
            {
                EsOwner = true
            };
            unPerfil.EsInfantil = true;
        }
    }
}
