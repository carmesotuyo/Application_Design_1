using Dominio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Pelicula
    {
        private string _nombre;
        private Genero _generoPrincipal;
        private List<Genero> _generosSecundarios;
        private string _descripcion;
        private bool _aptaTodoPublico;
        private bool _patrocinada;
        private static int _contadorPeliculas = 0;
        private int _idPelicula;
        private string _poster;

        public Pelicula()
        {
            _generosSecundarios = new List<Genero>();
            this.asignarIdentificador();
        }
        private void asignarIdentificador()
        {
            ContadorPeliculas += 1;
            Identificador = ContadorPeliculas;
        }

        public string Nombre { get => _nombre; set
            {
                ChequearStringVacio(value);
                _nombre = value;
            }
        }

        public Genero GeneroPrincipal { get => _generoPrincipal; set
            {
                ChequearGeneroVacio(value);
                ChequearNoIncluidoEnSecundarios(value);
                _generoPrincipal = value;
            } 
        }

        private void ChequearNoIncluidoEnSecundarios(Genero unGenero)
        {
            if (GenerosSecundarios.Contains(unGenero))
            {
                throw new GeneroInvalidoException();
            }
        }


        public List<Genero> GenerosSecundarios { get => _generosSecundarios; set
            {
                _generosSecundarios = value;
            } 
        }
        

        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public bool AptaTodoPublico { get => _aptaTodoPublico; set => _aptaTodoPublico = value; }
        public bool EsPatrocinada { get => _patrocinada; set => _patrocinada = value; }
        public int Identificador { get => _idPelicula; set => _idPelicula = value; }
        public static int ContadorPeliculas { get => _contadorPeliculas; set => _contadorPeliculas = value; }
        public string Poster { get => _poster; set
            {
                ChequearStringVacio(value);
                _poster = value;
            }
        }

        public void AgregarGeneroSecundario(Genero genero)
        {
            ChequearGeneroVacio(genero);
            ChequearNoCoincideConPrincipal(genero);
            _generosSecundarios.Add(genero);
        }

        private void ChequearNoCoincideConPrincipal(Genero unGenero)
        {
            if (unGenero.Equals(GeneroPrincipal))
            {
                throw new GeneroInvalidoException();
            }
        }

        private static void ChequearStringVacio(string value)
        {
            if (value.Length == 0)
            {
                throw new DatoVacioException();
            }
        }
        private static void ChequearGeneroVacio(Genero genero)
        {
            if (genero == null)
            {
                throw new DatoVacioException();
            }
        }
    }
}
