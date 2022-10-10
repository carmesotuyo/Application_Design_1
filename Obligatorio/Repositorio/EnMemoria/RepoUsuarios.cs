﻿using System;
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

        public bool EstaUsuario(Usuario usuario)
        {
            return _usuarios.Contains(usuario);
        }
        public void AgregarUsuario(Usuario usuario)
        {
            _usuarios.Add(usuario);
        }
        public void QuitarUsuario(Usuario usuario)
        {
            if (EstaUsuario(usuario))
            {
                _usuarios.Remove(usuario);
            }
        }
        public List<Usuario> Usuarios()
        {
            return _usuarios;
        }
    }
}
