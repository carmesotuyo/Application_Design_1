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
using Repositorio.Interfaces;
using Repositorio.EnDataBase;
using Logica.Interfaces;

namespace Pruebas.PruebasLogica
{
    [TestClass]
    public class LogicaUsuarioTest
    {
        Usuario usuario1 = new Usuario() 
        { 
            Nombre = "nombreDeUsuario1", 
            Email = "juan@da1.com", 
            Clave = "1234567890", 
            ConfirmarClave = "1234567890" 
        };
        Usuario usuario2 = new Usuario() 
        { 
            Nombre = "nombreDeUsuario2", 
            Email = "juancho@da1.com", 
            Clave = "1234567890", 
            ConfirmarClave = "1234567890" 
        };
        ILogicaUsuario logica = new LogicaUsuario(new UsuarioDBRepo(), new PerfilDBRepo());
        Perfil unPerfil = new Perfil() { Alias = "carme", Pin = 12345, ConfirmarPin = 12345 };

        [TestInitialize]
        public void Setup()
        {
            DBCleanUp.CleanUp();
        }

        [TestMethod]
        public void RegistrarUsuarioTest()
        {
            logica.RegistrarUsuario(usuario1);
            Assert.IsTrue(logica.Usuarios().Contains(usuario1));
        }

        [TestMethod]
        [ExpectedException(typeof(NombreUsuarioExistenteException))]
        public void RegistrarUsuarioNombreRepetidoTest()
        {
            usuario2.Nombre = usuario1.Nombre;
            logica.RegistrarUsuario(usuario1);
            logica.RegistrarUsuario(usuario2);
        }

        [TestMethod]
        [ExpectedException(typeof(EmailExistenteException))]
        public void RegistrarUsuarioEmailRepetidoTest()
        {
            usuario2.Email = usuario1.Email;
            logica.RegistrarUsuario(usuario1);
            logica.RegistrarUsuario(usuario2);
        }

        [TestMethod]
        public void IniciarSesionConNombreTest()
        {
            string cuenta = usuario1.Nombre;
            string clave = usuario1.Clave;
            logica.RegistrarUsuario(usuario1);
            Usuario usuarioLogueado = logica.IniciarSesion(cuenta, clave);
            Assert.AreEqual(usuario1, usuarioLogueado);
        }

        [TestMethod]
        public void IniciarSesionConEmailTest()
        {
            string cuenta = usuario1.Email;
            string clave = usuario1.Clave;
            logica.RegistrarUsuario(usuario1);
            Usuario usuarioLogueado = logica.IniciarSesion(cuenta, clave);
            Assert.AreEqual(usuario1, usuarioLogueado);
        }

        [TestMethod]
        [ExpectedException(typeof(ClaveIncorrectaException))]
        public void IniciarSesionClaveIncorrectaTest()
        {
            string cuenta = usuario1.Email;
            string clave = "";
            logica.RegistrarUsuario(usuario1);
            Usuario usuarioLogueado = logica.IniciarSesion(cuenta, clave);
        }

        [TestMethod]
        [ExpectedException(typeof(ClaveIncorrectaException))]
        public void IniciarSesionNombreClaveIncorrectaTest()
        {
            string cuenta = usuario1.Nombre;
            string clave = "";
            logica.RegistrarUsuario(usuario1);
            Usuario usuarioLogueado = logica.IniciarSesion(cuenta, clave);
        }

        [TestMethod]
        [ExpectedException(typeof(NombreOEmailIncorrectoException))]
        public void IniciarSesionNombreIncorrectoTest()
        {
            string cuenta = "";
            string clave = "";
            logica.RegistrarUsuario(usuario1);
            Usuario usuarioLogueado = logica.IniciarSesion(cuenta, clave);
        }

        [TestMethod]
        [ExpectedException(typeof(NombreOEmailIncorrectoException))]
        public void IniciarSesionEmailIncorrectoTest()
        {
            string cuenta = "algo@algo.com";
            string clave = "";
            logica.RegistrarUsuario(usuario1);
            Usuario usuarioLogueado = logica.IniciarSesion(cuenta, clave);
        }

        [TestMethod]
        public void AgregarPerfilTest()
        {
            logica.RegistrarUsuario(usuario1);
            logica.AgregarPerfil(usuario1, unPerfil);
            Assert.IsTrue(logica.PerfilesAsociados(usuario1).Contains(unPerfil));
        }

        [TestMethod]
        [ExpectedException(typeof(LimiteDePerfilesException))]
        public void AgregarMasDe4PerfilesTest()
        {
            logica.RegistrarUsuario(usuario1);

            Perfil unPerfil = new Perfil() { Alias = "carme", Pin = 12345, ConfirmarPin = 12345 };
            Perfil unPerfil2 = new Perfil() { Alias = "fer", Pin = 12345, ConfirmarPin = 12345 };
            Perfil unPerfil3 = new Perfil() { Alias = "carmela", Pin = 12345, ConfirmarPin = 12345 };
            Perfil unPerfil4 = new Perfil() { Alias = "fernando", Pin = 12345, ConfirmarPin = 12345 };
            Perfil unPerfil5 = new Perfil() { Alias = "ultimo", Pin = 12345, ConfirmarPin = 12345 };

            logica.AgregarPerfil(usuario1, unPerfil);
            logica.AgregarPerfil(usuario1, unPerfil2);
            logica.AgregarPerfil(usuario1, unPerfil3);
            logica.AgregarPerfil(usuario1, unPerfil4);
            logica.AgregarPerfil(usuario1, unPerfil5);
        }

        [TestMethod]
        public void AgregarPrimerPerfilTest()
        {
            logica.RegistrarUsuario(usuario1);
            logica.AgregarPerfil(usuario1, unPerfil);

            Assert.IsTrue(unPerfil.EsOwner);
        }

        [TestMethod]
        public void AgregarPerfilIntermedioTest()
        {
            logica.RegistrarUsuario(usuario1);
            Perfil unPerfil = new Perfil() { Alias = "carme", Pin = 12345, ConfirmarPin = 12345 };
            Perfil otroPerfil = new Perfil() { Alias = "fer", Pin = 12345, ConfirmarPin = 12345 };

            logica.AgregarPerfil(usuario1, unPerfil);
            logica.AgregarPerfil(usuario1, otroPerfil);

            Assert.IsFalse(otroPerfil.EsOwner);
        }

        [TestMethod]
        [ExpectedException(typeof(AliasRepetidoException))]
        public void AgregarPerfilAliasRepetidoTest()
        {
            logica.RegistrarUsuario(usuario1);
            Perfil unPerfil = new Perfil() { Alias = "carme", Pin = 12345, ConfirmarPin = 12345 };
            Perfil otroPerfil = new Perfil() { Alias = "carme", Pin = 12345, ConfirmarPin = 12345 };

            logica.AgregarPerfil(usuario1, unPerfil);
            logica.AgregarPerfil(usuario1, otroPerfil);
        }

        [TestMethod]
        public void QuitarPerfilTest()
        {
            logica.RegistrarUsuario(usuario1);
            Perfil unPerfil = new Perfil() { Alias = "carme", Pin = 12345, ConfirmarPin = 12345 };
            Perfil otroPerfil = new Perfil() { Alias = "fer", Pin = 12345, ConfirmarPin = 12345 };

            logica.AgregarPerfil(usuario1, unPerfil);
            logica.AgregarPerfil(usuario1, otroPerfil);
            logica.QuitarPerfil(usuario1, otroPerfil);

            Assert.IsFalse(logica.PerfilesAsociados(usuario1).Contains(otroPerfil));
        }

        [TestMethod]
        [ExpectedException(typeof(NoExistePerfilException))]
        public void QuitarPerfilInexistenteTest()
        {
            logica.RegistrarUsuario(usuario1);
            Perfil perfil = new Perfil();
            logica.QuitarPerfil(usuario1, perfil);
        }

        [TestMethod]
        [ExpectedException(typeof(EliminarOwnerException))]
        public void QuitarPerfilOwnerTest()
        {
            logica.RegistrarUsuario(usuario1);
            Perfil perfil = new Perfil()
            {
                Alias = "carme",
                Pin = 12345,
                ConfirmarPin = 12345, 
                EsOwner = true
            };
            logica.AgregarPerfil(usuario1, perfil);
            logica.QuitarPerfil(usuario1, perfil);
        }
    }
}
