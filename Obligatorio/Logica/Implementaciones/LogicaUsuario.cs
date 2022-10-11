﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Dominio.Exceptions;
using Logica.Interfaces;
using Logica.Exceptions;
using Repositorio;
using Repositorio.Interfaces;

namespace Logica.Implementaciones
{
    public class LogicaUsuario : ILogicaUsuario
    {
        private IRepoUsuarios _repoUsuarios;
        private static int cantMaximaDePerfiles = 4;

        public LogicaUsuario(IRepoUsuarios repoUsuarios)
        {
            _repoUsuarios = repoUsuarios;
        }
        public void RegistrarUsuario(Usuario usuario)
        {
            ValidarDatos(usuario);
            _repoUsuarios.AgregarUsuario(usuario);
        }

        private void ValidarDatos(Usuario usuario)
        {
            ValidarNombreUnico(usuario.Nombre);
            ValidarEmailUnico(usuario.Email);
        }

        private void ValidarNombreUnico(string nombre)
        {
            bool repetido = _repoUsuarios.Usuarios().Any(n => n.Nombre == nombre);
            if (repetido)
            {
                throw new NombreUsuarioExistenteException();
            }
        }

        private void ValidarEmailUnico(string email)
        {
            bool repetido = _repoUsuarios.Usuarios().Any(n => n.Email == email);
            if (repetido)
            {
                throw new EmailExistenteException();
            }
        }

        public Usuario IniciarSesion(string cuenta, string clave)
        {
            Usuario usuarioLogueado = ValidarNombreOEmail(cuenta);
            AutenticarClave(usuarioLogueado, clave);
            return usuarioLogueado;
        }

        private Usuario ValidarNombreOEmail(string cuenta)
        {
            List<Usuario> usuario = _repoUsuarios.Usuarios().Where(u => u.Nombre == cuenta).ToList();
            if (usuario.Count == 0)
            {
                usuario = _repoUsuarios.Usuarios().Where(u => u.Email == cuenta).ToList();
                if (usuario.Count == 0) { throw new NombreOEmailIncorrectoException(); }
            }
            Usuario usuarioLogueado = usuario[0];
            return usuarioLogueado;
        }

        private void AutenticarClave(Usuario usuario, string clave)
        {
            if(usuario.Clave != clave) { throw new ClaveIncorrectaException(); }
        }

        public void AgregarPerfil(Usuario usuario, Perfil perfil)
        {
            MaximoDePerfiles(usuario);
            EsElPrimero(usuario, perfil);
            usuario.Perfiles.Add(perfil);
        }

        private void MaximoDePerfiles(Usuario usuario)
        {
            if (usuario.Perfiles.Count == cantMaximaDePerfiles)
            {
                throw new LimiteDePerfilesException();
            }
        }

        private void EsElPrimero(Usuario usuario, Perfil perfil)
        {
            if (usuario.Perfiles.Count == 0)
            {
                perfil.EsOwner = true;
            }
        }
     
        public void QuitarPerfil(Usuario usuario, Perfil perfil)
        {
            NoExistePerfil(usuario, perfil);
            EsPerfilOwner(perfil);
            usuario.Perfiles.Remove(perfil);
        }

        private void NoExistePerfil(Usuario usuario, Perfil perfil)
        {
            if (!usuario.Perfiles.Contains(perfil))
            {
                throw new NoExistePerfilException();
            }
        }

        private void EsPerfilOwner(Perfil perfil)
        {
            if (perfil.EsOwner)
            {
                throw new EliminarOwnerException();
            }
        }

        public List<Usuario> Usuarios()
        {
            return _repoUsuarios.Usuarios();
        }
    }
}
