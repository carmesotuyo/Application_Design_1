using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class GeneroPuntaje
    {
        private int _puntaje;
        private string _genero;

        public string Genero
        {
            get => _genero; set { _genero = value; }
        }

        public GeneroPuntaje()
        {
            _puntaje = 0;
        }

        public int Puntaje
        {
            get => _puntaje; set { _puntaje = value; }
        }

        public void ModificarPuntaje(int value)
        {
            this.Puntaje += value;
        }
    }
}
