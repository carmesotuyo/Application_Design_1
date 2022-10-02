using System;
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
    }
}
