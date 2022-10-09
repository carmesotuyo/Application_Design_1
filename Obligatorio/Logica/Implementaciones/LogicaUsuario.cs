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
    }
}
