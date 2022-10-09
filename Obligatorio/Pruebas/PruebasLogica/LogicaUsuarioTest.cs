using Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio;
using Logica.Implementaciones;
using Dominio.Exceptions;
using Logica.Exceptions;

namespace Pruebas.PruebasLogica
{
    [TestClass]
    public class LogicaUsuarioTest
    {
        Usuario usuario1 = new Usuario() { Nombre = "nombreDeUsuario1", Email = "juan@da1.com", Clave = "1234567890" };
        Usuario usuario2 = new Usuario() { Nombre = "nombreDeUsuario2", Email = "juancho@da1.com", Clave = "1234567890" };
        Usuario usuario3 = new Usuario() { Nombre = "nombreDeUsuario3", Email = "juana@da1.com", Clave = "1234567890" };
        RepoUsuarios repo = new RepoUsuarios();
        LogicaUsuario logica = new LogicaUsuario();

        [TestMethod]
        public void RegistrarUsuarioTest()
        {
            logica.RegistrarUsuario(usuario1, repo);
            Assert.IsTrue(repo.EstaUsuario(usuario1));
        }

        [TestMethod]
        [ExpectedException(typeof(NombreUsuarioExistenteException))]
        public void RegistrarUsuarioNombreRepetidoTest()
        {
            usuario2.Nombre = usuario1.Nombre;
            logica.RegistrarUsuario(usuario1, repo);
            logica.RegistrarUsuario(usuario2, repo);
        }

        [TestMethod]
        [ExpectedException(typeof(EmailExistenteException))]
        public void RegistrarUsuarioEmailRepetidoTest()
        {
            usuario2.Email = usuario1.Email;
            logica.RegistrarUsuario(usuario1, repo);
            logica.RegistrarUsuario(usuario2, repo);
        }

        [TestMethod]
        public void IniciarSesionConNombreTest()
        {
            string cuenta = usuario1.Nombre;
            string clave = usuario1.Clave;
            logica.RegistrarUsuario(usuario1, repo);
            Usuario usuarioLogueado = logica.IniciarSesion(cuenta, clave, repo);
            Assert.AreEqual(usuario1, usuarioLogueado);
        }

        [TestMethod]
        public void IniciarSesionConEmailTest()
        {
            string cuenta = usuario1.Email;
            string clave = usuario1.Clave;
            logica.RegistrarUsuario(usuario1, repo);
            Usuario usuarioLogueado = logica.IniciarSesion(cuenta, clave, repo);
            Assert.AreEqual(usuario1, usuarioLogueado);
        }

        [TestMethod]
        [ExpectedException(typeof(ClaveIncorrectaException))]
        public void IniciarSesionClaveIncorrectaTest()
        {
            string cuenta = usuario1.Email;
            string clave = "";
            logica.RegistrarUsuario(usuario1, repo);
            Usuario usuarioLogueado = logica.IniciarSesion(cuenta, clave, repo);
        }

        [TestMethod]
        [ExpectedException(typeof(ClaveIncorrectaException))]
        public void IniciarSesionNombreClaveIncorrectaTest()
        {
            string cuenta = usuario1.Nombre;
            string clave = "";
            logica.RegistrarUsuario(usuario1, repo);
            Usuario usuarioLogueado = logica.IniciarSesion(cuenta, clave, repo);
        }

        [TestMethod]
        [ExpectedException(typeof(NombreOEmailIncorrectoException))]
        public void IniciarSesionNombreIncorrectoTest()
        {
            string cuenta = "";
            string clave = "";
            logica.RegistrarUsuario(usuario1, repo);
            Usuario usuarioLogueado = logica.IniciarSesion(cuenta, clave, repo);
        }

        [TestMethod]
        [ExpectedException(typeof(NombreOEmailIncorrectoException))]
        public void IniciarSesionEmailIncorrectoTest()
        {
            string cuenta = "algo@algo.com";
            string clave = "";
            logica.RegistrarUsuario(usuario1, repo);
            Usuario usuarioLogueado = logica.IniciarSesion(cuenta, clave, repo);
        }
    }
}
