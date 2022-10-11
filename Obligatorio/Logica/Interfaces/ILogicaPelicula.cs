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
        List<Pelicula> MostrarPeliculas(Perfil unPerfil);
        List<Pelicula> Peliculas();
    }
}
