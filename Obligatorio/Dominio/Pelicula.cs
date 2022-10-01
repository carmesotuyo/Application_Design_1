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
                if (value.Length == 0)
                {
                    throw new DatoVacioException();
                }
                _nombre = value;
            } 
        }

        private string _generoPrincipal;

        public string GeneroPrincipal { get => _generoPrincipal; set => _generoPrincipal = value; }
    }
}
