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
        public void NombreUsuarioValidoTest()
        {
            Usuario unUsuario = new Usuario()
            {
                Nombre = "johnyPro123"
            };
            Assert.AreEqual(unUsuario.Nombre, "johnyPro123");
        }



        [TestMethod]
        [ExpectedException(typeof(NombreUsuarioException))]
        public void NombreUsuarioInvalidoTest()
        {
            Usuario unUsuario = new Usuario()
            {
                Nombre = "John"
            };
        }

        [TestMethod]
        [ExpectedException(typeof(NombreUsuarioException))]
        public void NombreVacioTest()
        {
            Usuario unUsuario = new Usuario()
            {
                Nombre = ""
            };
        }

        [TestMethod]
        [ExpectedException(typeof(NombreUsuarioException))]
        public void Nombre9caracteresTest()
        {
            Usuario unUsuario = new Usuario()
            {
                Nombre = "aaaaaaaaa"
            };
        }

        [TestMethod]
        [ExpectedException(typeof(NombreUsuarioException))]
        public void Nombre21caracteresTest()
        {
            Usuario unUsuario = new Usuario()
            {
                Nombre = "aaaaaaaaaaaaaaaaaaaaa"
            };
        }

        [TestMethod]
        public void EmailValidoTest()
        {
            Usuario unUsuario = new Usuario()
            {
                Email = "johny@da1.com"
            };
            Assert.AreEqual(unUsuario.Email, "johny@da1.com");
        }

        [TestMethod]
        [ExpectedException(typeof(EmailInvalidoException))]
        public void EmailInvalidoTest()
        {
            Usuario unUsuario = new Usuario()
            {
                Email = "johnyPro"
            };
        }

        [TestMethod]
        [ExpectedException(typeof(EmailInvalidoException))]
        public void EmailSinComTest()
        {
            Usuario unUsuario = new Usuario()
            {
                Email = "johnyPro@"
            };
        }

        [TestMethod]
        [ExpectedException(typeof(EmailInvalidoException))]
        public void EmailSinNombreTest()
        {
            Usuario unUsuario = new Usuario()
            {
                Email = "@.com"
            };
        }

        [TestMethod]
        public void ClaveValidaTest()
        {
            Usuario unUsuario = new Usuario()
            {
                Clave = "admin12345678"
            };
            Assert.AreEqual(unUsuario.Clave, "admin12345678");
        }

        [TestMethod]
        [ExpectedException(typeof(ClaveInvalidaException))]
        public void ClaveInvalidaTest()
        {
            Usuario unUsuario = new Usuario()
            {
                Clave = "1234"
            };
        }

        [TestMethod]
        [ExpectedException(typeof(ClaveInvalidaException))]
        public void ClaveVaciaTest()
        {
            Usuario unUsuario = new Usuario()
            {
                Clave = ""
            };
        }

        [TestMethod]
        [ExpectedException(typeof(ClaveInvalidaException))]
        public void Clave9CaracteresTest()
        {
            Usuario unUsuario = new Usuario()
            {
                Clave = "123456789"
            };
        }

        [TestMethod]
        [ExpectedException(typeof(ClaveInvalidaException))]
        public void Clave31CaracteresTest()
        {
            Usuario unUsuario = new Usuario()
            {
                Clave = "0123456789012345678901234567890"
            };
        }

        [TestMethod]
        public void AgregarPerfilTest()
        {
            Usuario unUsuario = new Usuario();
            Perfil unPerfil = new Perfil();
            unUsuario.AgregarPerfil(unPerfil);
            Assert.IsTrue(unUsuario.Perfiles.Contains(unPerfil));
        }

        [TestMethod]
        public void QuitarPerfilTest()
        {
            Usuario usuario = new Usuario();
            Perfil unPerfil = new Perfil();
            usuario.AgregarPerfil(unPerfil);
            usuario.QuitarPerfil(unPerfil);
            Assert.IsFalse(usuario.Perfiles.Contains(unPerfil));
        }

        [TestMethod]
        [ExpectedException(typeof(NoExistePerfilException))]
        public void QuitarPerfilInexistenteTest()
        {
            Usuario unUsuario = new Usuario();
            Perfil perfil = new Perfil();
            unUsuario.QuitarPerfil(perfil);
        }

        [TestMethod]
        [ExpectedException(typeof(EliminarOwnerException))]
        public void QuitarPerfilOwnerTest()
        {
            Usuario unUsuario = new Usuario();
            Perfil perfil = new Perfil()
            {
                EsOwner = true
            };
            unUsuario.QuitarPerfil(perfil);
        }

    }
}
