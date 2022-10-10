using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Dominio.Exceptions;
using Logica.Interfaces;
using Logica.Exceptions;
using Repositorio;

namespace Logica.Implementaciones
{
    public class LogicaUsuario : ILogicaUsuario
    {
        private static int cantMaximaDePerfiles = 4;
        public void RegistrarUsuario(Usuario usuario, RepoUsuarios repo)
        {
            ValidarDatos(usuario, repo);
            repo.AgregarUsuario(usuario);
        }

        private static void ValidarDatos(Usuario usuario, RepoUsuarios repo)
        {
            ValidarNombreUnico(usuario.Nombre, repo);
            ValidarEmailUnico(usuario.Email, repo);
        }

        private static void ValidarNombreUnico(string nombre, RepoUsuarios repo)
        {
            bool repetido = repo.usuarios.Where(n => n.Nombre == nombre).Any();
            if (repetido)
            {
                throw new NombreUsuarioExistenteException();
            }
        }

        private static void ValidarEmailUnico(string email, RepoUsuarios repo)
        {
            bool repetido = repo.usuarios.Where(n => n.Email == email).Any();
            if (repetido)
            {
                throw new EmailExistenteException();
            }
        }

        public Usuario IniciarSesion(string cuenta, string clave, RepoUsuarios repo)
        {
            Usuario usuarioLogueado = ValidarNombreOEmail(cuenta, repo);
            AutenticarClave(usuarioLogueado, clave);
            return usuarioLogueado;
        }

        private Usuario ValidarNombreOEmail(string cuenta, RepoUsuarios repo)
        {
            List<Usuario> usuario = repo.usuarios.Where(u => u.Nombre == cuenta).ToList();
            if (usuario.Count == 0)
            {
                usuario = repo.usuarios.Where(u => u.Email == cuenta).ToList();
                if (usuario.Count == 0) { throw new NombreOEmailIncorrectoException(); }
            }
            Usuario usuarioLogueado = usuario[0];
            return usuarioLogueado;
        }

        private void AutenticarClave(Usuario usuario, string clave)
        {
            if(usuario.Clave != clave) { throw new ClaveIncorrectaException(); }
        }


        //================ARREGLAR==============

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
    }
}
