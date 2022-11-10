using Dominio.Exceptions;
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
        private Genero _genero;
        private string _nombreGenero;
        private Perfil _perfil;
        private string _aliasPerfil;

        public GeneroPuntaje()
        {
            _puntaje = 0;
        }

        public Genero Genero
        {
            get => _genero; 
            set 
            { 
                if (value.Nombre.Length == 0)
                {
                    throw new DatoVacioException();
                }
                _genero = value; 
            }
        }

        public int Puntaje
        {
            get => _puntaje; set { _puntaje = value; }
        }

        public Perfil Perfil
        {
            get => _perfil; set 
            {
                if (value.Alias.Length == 0)
                {
                    throw new DatoVacioException();
                }
                _perfil = value;  
            }
        }

        public string NombreGenero { get => _nombreGenero; set => _nombreGenero = value; }
        public string AliasPerfil { get => _aliasPerfil; set => _aliasPerfil = value; }

        public void ModificarPuntaje(int value)
        {
            this.Puntaje += value;
        }
    }
}
