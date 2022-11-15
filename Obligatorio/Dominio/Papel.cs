using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Papel
    {
        public string Nombre { get; set; }
        public Persona Actor { get; set; }
        public Pelicula Pelicula { get; set; }
    }
}
