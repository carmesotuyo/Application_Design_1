using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Perfil
    {
        private string _alias;
        private int _pin;
        private bool _esInfantil;
        private List<GeneroPuntaje> _puntajeGeneros;

        private void ValidarAlias(string value)
        {

        }

        private void ValidarPin(int value)
        {

        }

        public void FiltrarPelisNoAptas()
        {

        }
        public string Alias
        {
            get => _alias; set => _alias = value; 
        }
    }

}
