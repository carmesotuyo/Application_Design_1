using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Repositorio
{
    public class PeliculaRepo
    {
        public List<Pelicula> peliculas = new List<Pelicula>();
        public bool EstaPelicula(Pelicula pelicula)
        {
            return peliculas.Contains(pelicula);
        }
        public void AgregarPelicula(Pelicula pelicula)
        {
            peliculas.Add(pelicula);
        }
    }
}
