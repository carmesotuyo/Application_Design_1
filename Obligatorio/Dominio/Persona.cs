using Dominio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Persona
    {
        private string _nombre;

        private static void ChequearNombreValido(string value)
        {
            if (value == "")
            {
                throw new NombrePersonaVacioException();
            }
        }

        public int Id { get; set; }
        public string Nombre
        {
            get => _nombre;
            set
            {
                ChequearNombreValido(value);
                _nombre = value;
            }
        }
        public string FotoPerfil { get; set; }
        public string FechaNacimiento { get; set; }

        
    }
}
