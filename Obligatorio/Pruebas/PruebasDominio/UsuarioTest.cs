using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Dominio;
using Dominio.Exceptions;

namespace Pruebas.PruebasDominio
{
    [TestClass]
    public class UsuarioTest
    {

        [TestMethod]
        public void NombreUsuarioValido()
        {
            //arrange8
            Usuario unUsuario = new Usuario()
            {
                Nombre = "johnyPro123"
            };


            //assert
            Assert.AreEqual(unUsuario.Nombre, "johnyPro123");
        }



        [TestMethod]
        [ExpectedException(typeof(NombreUsuarioException))]
        public void NombreUsuarioInvalido()
        {
            //arrange
            Usuario unUsuario = new Usuario();

            //act
            unUsuario.Nombre = "John";
        }

        [TestMethod]
        [ExpectedException(typeof(NombreUsuarioException))]
        public void NombreVacio()
        {
            //arrange
            Usuario unUsuario = new Usuario();

            //act
            unUsuario.Nombre = "";
        }

        [TestMethod]
        [ExpectedException(typeof(NombreUsuarioException))]
        public void Nombre9caracteres()
        {
            //arrange
            Usuario unUsuario = new Usuario();

            //act
            unUsuario.Nombre = "aaaaaaaaa";
        }

        [TestMethod]
        [ExpectedException(typeof(NombreUsuarioException))]
        public void Nombre21caracteres()
        {
            //arrange
            Usuario unUsuario = new Usuario();

            //act
            unUsuario.Nombre = "aaaaaaaaaaaaaaaaaaaaa";
        }

        [TestMethod]
        public void EmailValido()
        {
            //arrange
            Usuario unUsuario = new Usuario();

            //act
            unUsuario.Email = "johny@da1.com";

            //assert
            Assert.AreEqual(unUsuario.Email, "johny@da1.com");
        }

        [TestMethod]
        [ExpectedException(typeof(EmailInvalidoException))]
        public void EmailInvalido()
        {
            //arrange
            Usuario unUsuario = new Usuario();

            //act
            unUsuario.Email = "johnyPro";
        }

        [TestMethod]
        [ExpectedException(typeof(EmailInvalidoException))]
        public void EmailInvalido2()
        {
            //arrange
            Usuario unUsuario = new Usuario();

            //act
            unUsuario.Email = "johnyPro@";
        }

        [TestMethod]
        [ExpectedException(typeof(EmailInvalidoException))]
        public void EmailInvalido3()
        {
            //arrange
            Usuario unUsuario = new Usuario();

            //act
            unUsuario.Email = "@.com";
        }

        [TestMethod]
        public void ClaveValida()
        {
            //arrange
            Usuario unUsuario = new Usuario();

            //act
            unUsuario.Clave = "admin12345678";

            //assert
            Assert.AreEqual(unUsuario.Clave, "admin12345678");
        }

        [TestMethod]
        [ExpectedException(typeof(ClaveInvalidaException))]
        public void ClaveInvalida()
        {
            //arrange
            Usuario unUsuario = new Usuario();

            //act
            unUsuario.Clave = "1234";
        }

        [TestMethod]
        [ExpectedException(typeof(ClaveInvalidaException))]
        public void ClaveVacia()
        {
            //arrange
            Usuario unUsuario = new Usuario();

            //act
            unUsuario.Clave = "";
        }

        [TestMethod]
        [ExpectedException(typeof(ClaveInvalidaException))]
        public void Clave9Caracteres()
        {
            //arrange
            Usuario unUsuario = new Usuario();

            //act
            unUsuario.Clave = "123456789";
        }

        [TestMethod]
        [ExpectedException(typeof(ClaveInvalidaException))]
        public void Clave31Caracteres()
        {
            //arrange
            Usuario unUsuario = new Usuario();

            //act
            unUsuario.Clave = "0123456789012345678901234567890";
        }

    }
}
