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
                chequearSiEsVacio(value);
                _generoPrincipal = value;
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
        public int Identificador { get => _idPelicula; set
            {
                _contadorPeliculas += 1;
                _idPelicula = _contadorPeliculas;
            } 
        }
        public int ContadorPeliculas { get => _contadorPeliculas; set => _contadorPeliculas = value; }
        public string Poster { get => _poster; set
            {
                ChequearStringVacio(value);
                _poster = value;
            }
        }

        private static void ChequearStringVacio(string value)
        {
            if (value.Length == 0)
            {
                throw new DatoVacioException();
            }
        }
        public void agregarGeneroSecundario(Genero genero)
        {
            chequearSiEsVacio(genero);
            GenerosSecundarios.Add(genero);
        }

        private static void chequearSiEsVacio(Genero genero)
        {
            if (genero == null)
            {
                throw new DatoVacioException();
            }
        }
    }
}
