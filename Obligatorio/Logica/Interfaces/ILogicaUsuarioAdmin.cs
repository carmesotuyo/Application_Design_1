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
        void AltaPelicula(Usuario admin, Pelicula unaPelicula);
        void BajaPelicula(Usuario admin, Pelicula unaPelicula);
        void AltaGenero(Usuario admin, Genero unGenero);
        void BajaGenero(Usuario admin, Genero unGenero);
        List<Pelicula> OrdenarPorGenero(Usuario admin);
        List<Pelicula> OrdenarPorPatrocinio(Usuario admin);

    }
}
