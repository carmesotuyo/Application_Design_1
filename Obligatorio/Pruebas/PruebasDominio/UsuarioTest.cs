using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Dominio;

namespace Pruebas.PruebasDominio
{
    [TestClass]
    public class UsuarioTest
    {

        [TestMethod]
        public void NombreUsuarioValido()
        {
            //arrange8
            Usuario unUsuario = new Usuario();

            //act
            unUsuario.Nombre = "johnyPro123";

            //assert
            Assert.AreEqual(unUsuario.Nombre, "johnyPro123");
        }

        [TestMethod]
        [ExpectedException(typeof(NombreInvalidoException))]
        public void NombreUsuarioInvalido()
        {
            //arrange8
            Usuario unUsuario = new Usuario();

            //act
            unUsuario.Nombre = "John";

        }

        [TestMethod]
        public void EmailValido()
        {
            //arrange8
            Usuario unUsuario = new Usuario();

            //act
            unUsuario.Email = "johny@da1.com";

            //assert
            Assert.AreEqual(unUsuario.Email, "johny@da1.com");
        }

        [TestMethod]
        public void ClaveValida()
        {
            //arrange8
            Usuario unUsuario = new Usuario();

            //act
            unUsuario.Clave = "1234";

            //assert
            Assert.AreEqual(unUsuario.Clave, "1234");
        }

    }
}
