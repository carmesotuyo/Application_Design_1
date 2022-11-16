using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Repositorio;

namespace Logica.Interfaces
{
    public interface ILogicaPelicula
    {
        void AltaPelicula(Pelicula pelicula, Usuario usuarioAdmin);
        void BajaPelicula(Pelicula pelicula, Usuario usuarioAdmin);
        void ElegirCriterioOrden(Usuario usuarioAdmin, int criterio);
        string CriterioSeleccionado();
        List<Pelicula> MostrarPeliculas(Perfil unPerfil);
        List<Pelicula> Peliculas();
        bool EsActor(Pelicula pelicula, Persona persona);
        bool EsDirector(Pelicula pelicula, Persona persona);
        string Actores(Pelicula pelicula, int cantAMostrar);
        string Directores(Pelicula pelicula, int cantAMostrar);
        void AsociarDirector(Persona director, Pelicula pelicula, Usuario admin);
        void DesasociarDirector(Persona director, Pelicula pelicula, Usuario admin);
    }
}
