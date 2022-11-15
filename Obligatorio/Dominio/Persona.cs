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
        public int Id { get; set; }
        private string _nombre;
        public string FotoPerfil { get; set; }
        private DateTime _fechaNacimiento;
        private DateTime hoy = DateTime.Today;

        public string Nombre
        {
            get => _nombre;
            set
            {
                ChequearNombreValido(value);
                _nombre = value;
            }
        }

        private static void ChequearNombreValido(string value)
        {
            if (value == "")
            {
                throw new NombrePersonaVacioException();
            }
        }

        public DateTime FechaNacimiento { get => _fechaNacimiento; set
            {
                ChequearFechaPasada(value);
                _fechaNacimiento = value;
            } 
        } 

        private void ChequearFechaPasada(DateTime fechaNacimiento)
        {
            if(fechaNacimiento > hoy)
            {
                throw new FechaInvalidaException();
            }
        }
    }
}
