using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Dominio;

namespace Pruebas.PruebasDominio
{
    [TestClass]
    public class UsuarioTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            //arrange
            Usuario unUsuario = new Usuario();

            //act
            unUsuario.Nombre = "John";

            //assert
            Assert.AreEqual(unUsuario.Nombre, "John");
        }
    }
}
