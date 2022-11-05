﻿using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Interfaces
{
    public interface IPerfilRepo
    {
        bool EstaPerfil(Perfil perfil);
        void AgregarPerfil(Perfil perfil);
        void EliminarPerfil(Perfil perfil);
        List<Perfil> Perfiles();
    }
}
