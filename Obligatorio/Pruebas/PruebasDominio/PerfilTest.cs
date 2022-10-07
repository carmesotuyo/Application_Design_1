using Dominio;
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
    }
}
