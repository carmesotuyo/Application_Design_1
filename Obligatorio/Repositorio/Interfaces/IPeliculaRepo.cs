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
        List<Genero> DevolverGenerosAsociados(Pelicula pelicula);
        void AgregarGeneroSecundario(Pelicula pelicula, Genero genero);
        List<Pelicula> Peliculas();
        bool EsActor(Pelicula pelicula, Persona persona);
        bool EsDirector(Pelicula pelicula, Persona persona);
    }
}