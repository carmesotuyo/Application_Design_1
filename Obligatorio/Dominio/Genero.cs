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

        public string Nombre { get => CorregirFormato(_nombre); set
            {
                ChequearStringVacio(value);
                _nombre = value;
            }
        }

        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        
        private void ChequearStringVacio(string value)
        {
            if (value.Length == 0)
            {
                throw new DatoVacioException();
            }
        }

        private string CorregirFormato(string texto)
        {
            ChequearStringVacio(texto);
            return char.ToUpper(texto[0]) + texto.ToLower().Substring(1);
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
