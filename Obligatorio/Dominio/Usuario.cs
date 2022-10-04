using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Exceptions;

namespace Dominio
{
    public class Usuario
    {
        private string _nombreUsuario;

        public string Nombre
        {
            get => _nombreUsuario;
            set
            {
                ChequearNombreValido(value);
                _nombreUsuario = value;
            }
        }

        private string _email;
        public string Email { get => _email; set => _email = value; }

        private string _clave;
        public string Clave
        {
            get => _clave;
            set
            {
                ChequearClaveValida(value);
                _clave = value;
            }
        }
        private static void ChequearClaveValida(string value)
        {
            if (value.Length < 10 || value.Length > 30)
            {
                throw new ClaveInvalidaException();
            }
        }

        private static void ChequearNombreValido(string value)
        {
            if (value.Length < 10 || value.Length > 20)
            {
                throw new NombreUsuarioException();
            }
        }
    }
}
