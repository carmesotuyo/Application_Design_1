using Dominio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Papel
    {
        private string _nombre;
        private Persona _actor;
        private Pelicula _pelicula;

        public string Nombre
        {
            get => _nombre; set
            {
                ChequearStringVacio(value);
                _nombre = value;
            }
        }

        public Persona Actor { get => _actor; set 
            {
                ChequearNull(value);
                _actor = value;
            } 
        }
        public Pelicula Pelicula { get => _pelicula; set
            {
                ChequearNull(value);
                _pelicula = value;
            } 
        }

        private void ChequearStringVacio(string value)
        {
            if (value.Length == 0)
            {
                throw new DatoVacioException();
            }
        }

        private void ChequearNull(Object value)
        {
            if (value == null)
            {
                throw new NullException();
            }
        }

        public override bool Equals(Object obj)
        {
            bool ret = obj != null && obj.GetType() == this.GetType();
            if (ret)
            {
                Papel papel = (Papel)obj;
                ret = papel.Nombre == this.Nombre && papel.Actor.Equals(this.Actor) && papel.Pelicula.Equals(this.Pelicula);
            }
            return ret;
        }

        public override string ToString()
        {
            return this.Nombre;
        }
    }
}
