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

        private Genero _generoPrincipal;
        public Genero GeneroPrincipal { get => _generoPrincipal; set
            {
                if (value == null)
                {
                    throw new DatoVacioException();
                }
                _generoPrincipal = value;
            } 
        }

        public Genero GeneroSecundario { get; set; }
    }
}
