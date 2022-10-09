using Dominio;
using Logica.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Implementaciones
{
    public class LogicaPerfil : ILogicaPerfil
    {
        private static int PuntajeNegativo = -1;
        private static int PuntajePositivo = 1;
        private static int PuntajeMuyPositivo = 2;

        public List<Pelicula> FiltrarPeliculasNoAptas()
        {
            throw new NotImplementedException();
        }

        public void MarcarComoVista(Pelicula unaPelicula, Perfil unPerfil)
        {
            throw new NotImplementedException();
        }

        public void PuntuarMuyPositivo(Pelicula unaPelicula, Perfil unPerfil)
        {
            throw new NotImplementedException();
        }

        public void PuntuarNegativo(Pelicula unaPelicula, Perfil unPerfil)
        {
            unPerfil.ModificarPuntajeGenero(unaPelicula.GeneroPrincipal, PuntajeNegativo);

        }

        public void PuntuarPositivo(Pelicula unaPelicula, Perfil unPerfil)
        {
            throw new NotImplementedException();
        }
    }
}
