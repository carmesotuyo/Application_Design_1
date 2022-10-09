using Dominio;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Interfaces
{
    public interface ILogicaUsuarioAdmin
    {
        void AltaPelicula(Usuario admin, Pelicula unaPelicula, PeliculaRepo repo);
        void BajaPelicula(Usuario admin, Pelicula unaPelicula, PeliculaRepo repo);
        void AltaGenero(Usuario admin, Genero unGenero, GeneroRepo repo);
        void BajaGenero(Usuario admin, Genero unGenero, GeneroRepo repo, PeliculaRepo repoPelis);
        List<Pelicula> OrdenarPorGenero(Usuario admin, PeliculaRepo repo);
        List<Pelicula> OrdenarPorPatrocinio(Usuario admin, PeliculaRepo repo);

    }
}
