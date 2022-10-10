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
        bool EstaUsuario(Usuario usuario);
        void AgregarUsuario(Usuario usuario);
        void QuitarUsuario(Usuario usuario);
    }
}
