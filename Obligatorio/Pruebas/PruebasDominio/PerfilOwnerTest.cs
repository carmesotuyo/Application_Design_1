using Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Pruebas.PruebasDominio
{
    [TestClass]
    public class PerfilOwnerTest
    {
        [TestMethod]
        public void CrearPerfilTest()
        {
            //Arrange
            Usuario usuario = new Usuario();
            PerfilOwner perfilOwner = new PerfilOwner();
            usuario.AgregarPerfil(perfilOwner);

            //Act
           //perfilOwner.CrearPerfil("Pepe", 1234);
           //usuario.Perfiles

            //Assert
            //Assert.IsTrue(usuario.Perfiles, "johnyPro123");

        }
    }
}
