using Dominio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Genero
    {
        private string _nombre;
        private string _descripcion;

        public string Nombre { get => _nombre; set
            {
                if (value.Length == 0)
                {
                    throw new DatoVacioException();
                }
                _nombre = value;
            } 
        }

        public string Descripcion { get => _descripcion; set => _descripcion = value; }
    }
}
