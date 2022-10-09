﻿using System;
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
        void RegistrarUsuario(Usuario usuario, RepoUsuarios repo);

        Usuario IniciarSesion(string cuenta, string clave, RepoUsuarios repo);
    }
}
