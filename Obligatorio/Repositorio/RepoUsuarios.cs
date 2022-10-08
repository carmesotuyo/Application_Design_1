using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Repositorio
{
    public class RepoUsuarios
    {
        public List<Usuario> usuarios = new List<Usuario>();
        public bool EstaUsuario(Usuario usuario)
        {
            return usuarios.Contains(usuario);
        }
        public void AgregarUsuario(Usuario usuario)
        {
            usuarios.Add(usuario);
        }
        public void QuitarUsuario(Usuario usuario)
        {
            if (EstaUsuario(usuario))
            {
                usuarios.Remove(usuario);
            }
        }
    }
}
