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
        string MostrarActores(Pelicula pelicula, int cantAMostrar);
        string MostrarDirectores(Pelicula pelicula, int cantAMostrar);
        void AsociarDirector(Persona director, Pelicula pelicula);
        void DesasociarDirector(Persona director, Pelicula pelicula);
    }
}