using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Repositorio;

namespace Logica.Interfaces
{
    public interface ILogicaUsuario
    {
        void RegistrarUsuario(Usuario usuario);

        Usuario IniciarSesion(string cuenta, string clave);

        void AgregarPerfil(Usuario usuario, Perfil perfil);

        void QuitarPerfil(Usuario usuario, Perfil perfil);

        List<Usuario> Usuarios();
    }
}
