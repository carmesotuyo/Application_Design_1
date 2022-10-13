using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Repositorio.Interfaces;

namespace Repositorio
{
    public class RepoUsuarios : IRepoUsuarios
    {
        private List<Usuario> _usuarios = new List<Usuario>();

        public RepoUsuarios()
        {
            _usuarios = new List<Usuario>();
        }

        public void AgregarUsuario(Usuario usuario)
        {
            _usuarios.Add(usuario);
        }

        public List<Usuario> Usuarios()
        {
            return _usuarios;
        }
    }
}
