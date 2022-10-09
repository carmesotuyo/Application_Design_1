using Dominio;
using Logica.Interfaces;
using Logica.Exceptions;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Implementaciones
{
    public class LogicaPerfil : ILogicaPerfil
    {
        enum Puntajes
        {
            PuntajeNegativo = -1,
            PuntajePositivo = 1,
            PuntajeMuyPositivo = 2
        }

        public virtual Perfil AccederAlPerfil(Perfil unPerfil, int pin)
        {
            ValidarPin(unPerfil, pin);
            return unPerfil;
        }

        private void ValidarPin(Perfil unPerfil, int pin)
        {
            if(unPerfil.Pin != pin)
            {
                throw new PinIncorrectoException();
            }
        }

        public virtual List<Pelicula> MostrarPeliculas(PeliculaRepo repo)
        {
            return repo.peliculas;
        }

        public void MarcarComoVista(Pelicula unaPelicula, Perfil unPerfil)
        {
            unPerfil.AgregarPeliculaVista(unaPelicula);
            PuntuarPositivo(unaPelicula, unPerfil);
        }

        public void PuntuarMuyPositivo(Pelicula unaPelicula, Perfil unPerfil)
        {
            unPerfil.ModificarPuntajeGenero(unaPelicula.GeneroPrincipal, (int) Puntajes.PuntajeMuyPositivo);
            foreach(Genero genero in unaPelicula.GenerosSecundarios)
            {
                unPerfil.ModificarPuntajeGenero(genero, (int)Puntajes.PuntajePositivo);
            }
        }

        public void PuntuarNegativo(Pelicula unaPelicula, Perfil unPerfil)
        {
            unPerfil.ModificarPuntajeGenero(unaPelicula.GeneroPrincipal, (int) Puntajes.PuntajeNegativo);
        }

        public void PuntuarPositivo(Pelicula unaPelicula, Perfil unPerfil)
        {
            unPerfil.ModificarPuntajeGenero(unaPelicula.GeneroPrincipal, (int) Puntajes.PuntajePositivo);
        }
    }
}
