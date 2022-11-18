using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Interfaces
{
    public interface IRepoUsuarios
    {
        List<Usuario> Usuarios();
        void AgregarUsuario(Usuario usuario);
        bool EstaUsuario(Usuario usuario);
    }
}