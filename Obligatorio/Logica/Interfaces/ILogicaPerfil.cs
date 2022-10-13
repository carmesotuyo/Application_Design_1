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
        Perfil AccederAlPerfil(Perfil unPerfil, int pin);
        void ActualizarListadoGeneros(Perfil unPerfil, ILogicaGenero logicaGenero);
        bool VioPelicula(Pelicula unaPelicula, Perfil unPerfil);
        void MarcarComoVista(Pelicula unaPelicula, Perfil unPerfil);
        void PuntuarNegativo(Pelicula unaPelicula, Perfil unPerfil);
        void PuntuarPositivo(Pelicula unaPelicula, Perfil unPerfil);
        void PuntuarMuyPositivo(Pelicula unaPelicula, Perfil unPerfil);
    }
}
