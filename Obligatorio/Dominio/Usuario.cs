﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        private string _nombreUsuario;
        public string Nombre { get => _nombreUsuario; set => _nombreUsuario = value; }

        private string _email;
        public string Email { get => _email; set => _email = value; }

        private string _clave;
        public string Clave { get => _clave; set => _clave = value; }
    }
}
