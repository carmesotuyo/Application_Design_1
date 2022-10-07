using Dominio.Exceptions;
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

        private void ValidarAliasMinMaxChars(string value)
        {
            value.Trim();
            if (!(value.Length > 0) || !(value.Length < 16))
            {
                throw new AliasInvalidoException();
            }
        }

        private void ValidarAliasSinNumeros(string value)
        {
            int largoAntes = value.Length;
            char[] numeros = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ' ' };
            value = value.Trim(numeros);
            int largoDespues = value.Length;
            if (largoAntes > largoDespues)
            {
                throw new AliasInvalidoException();
            }
        }

        private void ValidarPin(int value)
        {

        }

        public void FiltrarPelisNoAptas()
        {

        }
        public string Alias
        {
            get => _alias; set {
                ValidarAliasMinMaxChars(value);
                ValidarAliasSinNumeros(value);
                _alias = value;
            }
        }

        public int Pin
        {
            get => _pin; set => _pin = value;
        }
    }

}
