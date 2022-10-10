﻿using Dominio;
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

        [TestMethod]
        public void AgregarPerfilTest()
        {
            Usuario unUsuario = new Usuario();
            Perfil unPerfil = new Perfil();
            logica.AgregarPerfil(unUsuario, unPerfil);
            Assert.IsTrue(unUsuario.Perfiles.Contains(unPerfil));
        }

        [TestMethod]
        [ExpectedException(typeof(LimiteDePerfilesException))]
        public void AgregarMasDe4PerfilesTest()
        {
            Usuario unUsuario = new Usuario();
            Perfil unPerfil = new Perfil();
            Perfil unPerfil2 = new Perfil();
            Perfil unPerfil3 = new Perfil();
            Perfil unPerfil4 = new Perfil();
            Perfil unPerfil5 = new Perfil();
            logica.AgregarPerfil(unUsuario, unPerfil);
            logica.AgregarPerfil(unUsuario, unPerfil2);
            logica.AgregarPerfil(unUsuario, unPerfil3);
            logica.AgregarPerfil(unUsuario, unPerfil4);
            logica.AgregarPerfil(unUsuario, unPerfil5);
        }

        [TestMethod]
        public void AgregarPrimerPerfilTest()
        {
            Usuario unUsuario = new Usuario();
            Perfil unPerfil = new Perfil();

            logica.AgregarPerfil(unUsuario, unPerfil);

            Assert.IsTrue(unPerfil.EsOwner);
        }

        [TestMethod]
        public void AgregarPerfilIntermedioTest()
        {
            Usuario unUsuario = new Usuario();
            Perfil unPerfil = new Perfil();
            Perfil otroPerfil = new Perfil();

            logica.AgregarPerfil(unUsuario, unPerfil);
            logica.AgregarPerfil(unUsuario, otroPerfil);

            Assert.IsFalse(otroPerfil.EsOwner);
        }

        [TestMethod]
        public void QuitarPerfilTest()
        {
            Usuario usuario = new Usuario();
            Perfil unPerfil = new Perfil();
            Perfil otroPerfil = new Perfil();

            logica.AgregarPerfil(usuario, unPerfil);
            logica.AgregarPerfil(usuario, otroPerfil);
            logica.QuitarPerfil(usuario, otroPerfil);

            Assert.IsFalse(usuario.Perfiles.Contains(otroPerfil));
        }

        [TestMethod]
        [ExpectedException(typeof(NoExistePerfilException))]
        public void QuitarPerfilInexistenteTest()
        {
            Usuario unUsuario = new Usuario();
            Perfil perfil = new Perfil();
            logica.QuitarPerfil(unUsuario, perfil);
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
            logica.AgregarPerfil(unUsuario, perfil);
            logica.QuitarPerfil(unUsuario, perfil);
        }
    }
}
