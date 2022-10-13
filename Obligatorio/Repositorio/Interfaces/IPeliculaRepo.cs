using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Interfaces
{
    public interface IPeliculaRepo
    {
        bool EstaPelicula(Pelicula pelicula);
        void AgregarPelicula(Pelicula pelicula);
        void QuitarPelicula(Pelicula pelicula);
        List<Pelicula> Peliculas();
    }
}