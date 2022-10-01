using Dominio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Pelicula
    {
        private string _nombre;
        public string Nombre { get => _nombre; set
            {
                chequearValorNoVacio(value);
                _nombre = value;
            }
        }

        private string _generoPrincipal;
        public string GeneroPrincipal { get => _generoPrincipal; set
            {
                chequearValorNoVacio(value);
                _generoPrincipal = value;
            } 
        }

        private static void chequearValorNoVacio(string value)
        {
            if (value.Length == 0)
            {
                throw new DatoVacioException();
            }
        }
    }
}
