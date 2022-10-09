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
        private bool _esOwner;
        private List<GeneroPuntaje> _puntajeGeneros;
        private List<Pelicula> _peliculasVistas; 

        public Perfil()
        {
            _puntajeGeneros = new List<GeneroPuntaje>();
            _peliculasVistas = new List<Pelicula>();
        }
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
            if (value < 0 || value > 99999) {
                throw new PinInvalidoException();
            }
            
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
            get => _pin; set {
                ValidarPin(value);
                _pin = value;
            }
        }

        public List<GeneroPuntaje> PuntajeGeneros
        {
            get => _puntajeGeneros; set
            {
                _puntajeGeneros = value;
            }
        }

        public bool EsInfantil { 
            get => _esInfantil; 
            set 
            {
                ValidarPerfilOwner();
                _esInfantil = value; 
            } 
        }

        private void ValidarPerfilOwner()
        {
            if (EsOwner)
            {
                throw new NoInfantilException();
            }

        }

        public bool EsOwner { get => _esOwner; set => _esOwner = value; }

        public void AgregarGeneroPuntaje(GeneroPuntaje generoPuntaje)
        {
            _puntajeGeneros.Add(generoPuntaje);
        }

        public void QuitarGeneroPuntaje(GeneroPuntaje generoPuntaje)
        {
            _puntajeGeneros.Remove(generoPuntaje);
        }

        public void ModificarPuntajeGenero(Genero unGenero, int puntaje)
        {
            int index = EncontrarGeneroEnLista(unGenero);
            PuntajeGeneros[index].ModificarPuntaje(puntaje);
        }

        private int EncontrarGeneroEnLista(Genero unGenero)
        {
            GeneroPuntaje genero = PuntajeGeneros.FirstOrDefault(x => x.Genero == unGenero.Nombre);
            return PuntajeGeneros.IndexOf(genero);
        }

        public List<Pelicula> PeliculasVistas { get => _peliculasVistas; set => _peliculasVistas = value; }
        public void AgregarPeliculaVista(Pelicula unaPelicula)
        {
            ChequearQueNoEsteYaVista(unaPelicula);
            _peliculasVistas.Add(unaPelicula);
        }

        public void ChequearQueNoEsteYaVista(Pelicula unaPelicula)
        {
            if (this.VioPelicula(unaPelicula))
            {
                throw new PeliculaYaVistaException();
            }
        }

        public bool VioPelicula(Pelicula unaPelicula)
        {
            return _peliculasVistas.Contains(unaPelicula);
        }
    }
}
