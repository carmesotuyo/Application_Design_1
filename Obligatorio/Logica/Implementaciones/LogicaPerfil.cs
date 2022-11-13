using Dominio;
using Logica.Interfaces;
using Logica.Exceptions;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Exceptions;
using Repositorio.Interfaces;
using Repositorio.EnDataBase;

namespace Logica.Implementaciones
{
    public class LogicaPerfil : ILogicaPerfil
    {
        private IPerfilRepo _repoPerfil;
        private IGeneroPuntajeRepo _repoGeneroPuntaje;
        enum Puntajes
        {
            PuntajeNegativo = -1,
            PuntajePositivo = 1,
            PuntajeMuyPositivo = 2
        }

        public LogicaPerfil(IPerfilRepo perfilRepo, IGeneroPuntajeRepo generoPuntajeRepo)
        {
            _repoPerfil = perfilRepo;
            _repoGeneroPuntaje = generoPuntajeRepo;
        }

        public virtual Perfil AccederAlPerfil(Perfil unPerfil, int pin)
        {
            if (!unPerfil.EsInfantil)
            {
                ValidarPin(unPerfil, pin);
            }
            return unPerfil;
        }

        private void ValidarPin(Perfil unPerfil, int pin)
        {
            if(unPerfil.Pin != pin)
            {
                throw new PinIncorrectoException();
            }
        }

        public void MarcarComoVista(Pelicula unaPelicula, Perfil unPerfil)
        {
            AgregarPeliculaVista(unaPelicula, unPerfil);
            PuntuarPositivo(unaPelicula, unPerfil);
        }

        public void PuntuarMuyPositivo(Pelicula unaPelicula, Perfil unPerfil, IPeliculaRepo repoPeli)
        {
            ModificarPuntajeGenero(unPerfil, unaPelicula.GeneroPrincipal, (int) Puntajes.PuntajeMuyPositivo);
            
            foreach(Genero genero in repoPeli.DevolverGenerosAsociados(unaPelicula))
            {
                ModificarPuntajeGenero(unPerfil, genero, (int)Puntajes.PuntajePositivo);
            }
        }

        public void PuntuarPositivo(Pelicula unaPelicula, Perfil unPerfil)
        {
            ModificarPuntajeGenero(unPerfil, unaPelicula.GeneroPrincipal, (int) Puntajes.PuntajePositivo);
        }

        public void PuntuarNegativo(Pelicula unaPelicula, Perfil unPerfil)
        {
            ModificarPuntajeGenero(unPerfil, unaPelicula.GeneroPrincipal, (int)Puntajes.PuntajeNegativo);
        }

        public void MarcarComoInfantil(Perfil perfilInfantil, Perfil perfilOwner, Usuario usuario)
        {
            ValidarPerfilOwner(perfilOwner);
            ChequearQueNoEsOwner(perfilInfantil);
            perfilInfantil.EsInfantil = true;
        }

        private void ValidarPerfilOwner(Perfil unPerfil)
        {
            if (!unPerfil.EsOwner)
            {
                throw new PerfilNoOwnerException();
            }
        }

        private void ChequearQueNoEsOwner(Perfil unPerfil)
        {
            if (unPerfil.EsOwner)
            {
                throw new NoInfantilException();
            }
        }

        public void AgregarPeliculaVista(Pelicula unaPelicula, Perfil unPerfil)
        {
            ChequearQueNoEsteYaVista(unaPelicula, unPerfil);
            _repoPerfil.AgregarPeliculaVista(unPerfil, unaPelicula);
        }

        private void ChequearQueNoEsteYaVista(Pelicula unaPelicula, Perfil unPerfil)
        {
            if (VioPelicula(unaPelicula, unPerfil))
            {
                throw new PeliculaYaVistaException();
            }
        }

        public bool VioPelicula(Pelicula unaPelicula, Perfil unPerfil)
        {
           return _repoPerfil.PeliculasVistas(unPerfil).Contains(unaPelicula);
        }

        public void ModificarPuntajeGenero(Perfil unPerfil, Genero unGenero, int puntaje)
        {
            ValidarQueExisteGeneroPuntuado(unGenero, unPerfil);
            _repoGeneroPuntaje.ModificarPuntaje(unGenero, unPerfil, puntaje);
        }

        //agregar metodo que agarre esta excepcion
        private void ValidarQueExisteGeneroPuntuado(Genero unGenero, Perfil unPerfil)
        {
            if(!_repoGeneroPuntaje.EstaGeneroPuntaje(unGenero, unPerfil))
            {
                throw new GeneroInexistenteException();
            }
        }

        public void ActualizarListadoGeneros(Perfil unPerfil, IGeneroRepo repoGenero)
        {
            QuitarGenerosEliminados(unPerfil, repoGenero);
            AgregarNuevosGeneros(unPerfil, repoGenero);
        }

        private void AgregarNuevosGeneros(Perfil unPerfil, IGeneroRepo repoGenero)
        {
            foreach (Genero genero in repoGenero.Generos())
            {
                if(!_repoGeneroPuntaje.EstaGeneroPuntaje(genero, unPerfil))
                {
                    AgregarGeneroPuntuado(unPerfil, genero);
                }
            }
        }

        private void QuitarGenerosEliminados(Perfil unPerfil, IGeneroRepo repoGenero)
        {
            List<GeneroPuntaje> paraEliminar = BuscarGenerosEliminados(unPerfil, repoGenero);

            foreach (GeneroPuntaje genero in paraEliminar)
            {
                _repoGeneroPuntaje.EliminarGeneroPuntaje(genero);
            }
        }

        private List<GeneroPuntaje> BuscarGenerosEliminados(Perfil unPerfil, IGeneroRepo repoGenero)
        {
            List<GeneroPuntaje> paraEliminar = new List<GeneroPuntaje>();

            foreach (GeneroPuntaje genero in _repoPerfil.GenerosPuntuados(unPerfil))
            {
                if (!repoGenero.EstaGenero(genero.Genero))
                {
                    paraEliminar.Add(genero);
                }
            }

            return paraEliminar;
        }

        public void AgregarGeneroPuntuado(Perfil unPerfil, Genero unGenero)
        {
            GeneroPuntaje nuevo = new GeneroPuntaje() 
            { 
                Genero = unGenero, 
                Perfil = unPerfil, 
                AliasPerfil = unPerfil.Alias,
                NombreGenero = unGenero.Nombre
            };
            _repoGeneroPuntaje.AgregarGeneroPuntaje(nuevo);
        }
    }
}
