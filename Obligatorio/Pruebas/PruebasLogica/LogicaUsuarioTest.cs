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
    }
}
