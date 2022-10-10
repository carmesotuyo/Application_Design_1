using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Repositorio.Interfaces;

namespace Repositorio
{
    public class PeliculaRepo : IPeliculaRepo
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
        public void QuitarPelicula(Pelicula pelicula)
        {
            if (EstaPelicula(pelicula))
            {
                peliculas.Remove(pelicula);
            }
        }
    }
}
