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
        private List<Pelicula> _peliculas = new List<Pelicula>();

        public PeliculaRepo()
        {
            _peliculas = new List<Pelicula>();
        }
        public bool EstaPelicula(Pelicula pelicula)
        {
            return _peliculas.Contains(pelicula);
        }
        public void AgregarPelicula(Pelicula pelicula)
        {
            _peliculas.Add(pelicula);
        }
        public void QuitarPelicula(Pelicula pelicula)
        {
            if (EstaPelicula(pelicula))
            {
                _peliculas.Remove(pelicula);
            }
        }

        public List<Pelicula> Peliculas()
        {
            return _peliculas;
        }
    }
}
