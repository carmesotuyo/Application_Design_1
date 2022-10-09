using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Repositorio;

namespace Logica.Interfaces
{
    public interface ILogicaPerfil
    {
        List<Pelicula> FiltrarPeliculasNoAptas(Perfil unPerfil, PeliculaRepo repo);
        void PuntuarNegativo(Pelicula unaPelicula, Perfil unPerfil);
        void PuntuarPositivo(Pelicula unaPelicula, Perfil unPerfil);
        void PuntuarMuyPositivo(Pelicula unaPelicula, Perfil unPerfil);
        void MarcarComoVista(Pelicula unaPelicula, Perfil unPerfil);
    }
}
