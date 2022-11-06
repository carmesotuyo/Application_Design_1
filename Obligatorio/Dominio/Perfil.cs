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
        private int _confirmarPin;
        private bool _esInfantil;
        private bool _esOwner;
        private List<GeneroPuntaje> _puntajeGeneros;
        private List<Pelicula> _peliculasVistas;
        private Usuario _usuario;
        private string _nombreUsuario;

        private static int _minCharsAlias = 1;
        private static int _maxCharsAlias = 15;
        private static int _cantDigitosPin = 5;

        public Perfil()
        {
            _puntajeGeneros = new List<GeneroPuntaje>();
            _peliculasVistas = new List<Pelicula>();
        }


        public string Alias
        {
            get => _alias; set
            {
                ValidarAliasMinMaxChars(value);
                ValidarAliasSinNumeros(value);
                _alias = value;
            }
        }

        private void ValidarAliasMinMaxChars(string value)
        {
            value.Trim();
            if (value.Length < _minCharsAlias || value.Length > _maxCharsAlias)
            {
                throw new AliasInvalidoException();
            }
        }

        private void ValidarAliasSinNumeros(string value)
        {
            int largoAntes = value.Length;
            value = QuitarNumeros(value);
            int largoDespues = value.Length;
            if (largoAntes > largoDespues)
            {
                throw new AliasInvalidoException();
            }
        }

        private string QuitarNumeros(string value)
        {
            char[] numeros = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ' ' };
            return value.Trim(numeros); ;
        }

        public int Pin { get => _pin; set { ValidarPin(value); _pin = value; } }

        private void ValidarPin(int value)
        {
            if (value.ToString().Length != _cantDigitosPin) {
                throw new PinInvalidoException();
            }
            
        }

        public int ConfirmarPin { get => _confirmarPin; set { ChequearConfirmacionPin(value); _confirmarPin = value; } }

        private void ChequearConfirmacionPin(int confirmacionPin)
        {
            if (!confirmacionPin.Equals(_pin))
            {
                throw new PinNoCoincideException();
            }
        }

        public bool EsOwner { get => _esOwner; set => _esOwner = value; }

        public bool EsInfantil { get => _esInfantil; set => _esInfantil = value; }

        public List<GeneroPuntaje> PuntajeGeneros { get => _puntajeGeneros; }

        public void AgregarGeneroPuntaje(GeneroPuntaje generoPuntaje)
        {
            _puntajeGeneros.Add(generoPuntaje);
        }

        public void QuitarGeneroPuntaje(GeneroPuntaje generoPuntaje)
        {
            _puntajeGeneros.Remove(generoPuntaje);
        }

        public List<Pelicula> PeliculasVistas { get => _peliculasVistas; }

        public void AgregarPeliculaVista(Pelicula unaPelicula)
        {
            _peliculasVistas.Add(unaPelicula);
        }

        public bool EstaPeliculaVista(Pelicula unaPelicula)
        {
            return _peliculasVistas.Contains(unaPelicula);
        }

        public Usuario Usuario { get => _usuario; set { _usuario = value; } }
        public string NombreUsuario { get => _nombreUsuario; set => _nombreUsuario = this.Usuario.Nombre; }

        public void AsociarUsuario(Usuario usuario)
        {
            Usuario = usuario;
            NombreUsuario = usuario.Nombre;
        }
        public override string ToString()
        {
            return Alias;
        }
    }
}
