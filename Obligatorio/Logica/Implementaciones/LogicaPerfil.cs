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
        //los repos deberian pasarse por parametro, no estar aca (creo)
        private IPerfilRepo _repoPerfil;
        private IGeneroPuntajeRepo _repoGeneroPuntaje;
        private IPeliculaRepo _repoPelicula;
        private IGeneroRepo _repoGenero;
        enum Puntajes
        {
            PuntajeNegativo = -1,
            PuntajePositivo = 1,
            PuntajeMuyPositivo = 2
        }

        //Horrible esto ya se muchos parametros
        public LogicaPerfil(IPerfilRepo perfilRepo, IGeneroPuntajeRepo generoPuntajeRepo, IPeliculaRepo repoPeli, IGeneroRepo repoGenero)
        {
            _repoPerfil = perfilRepo;
            _repoGeneroPuntaje = generoPuntajeRepo;
            _repoPelicula = repoPeli;
            _repoGenero = repoGenero;
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

        public void PuntuarMuyPositivo(Pelicula unaPelicula, Perfil unPerfil)
        {
            ModificarPuntajeGenero(unPerfil, unaPelicula.GeneroPrincipal, (int) Puntajes.PuntajeMuyPositivo);
            
            foreach(Genero genero in _repoPelicula.DevolverGenerosAsociados(unaPelicula))
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
            unPerfil.AgregarPeliculaVista(unaPelicula);
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
            return unPerfil.EstaPeliculaVista(unaPelicula);
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

        public void ActualizarListadoGeneros(Perfil unPerfil)
        {
            QuitarGenerosEliminados(unPerfil);
            AgregarNuevosGeneros(unPerfil);
        }

        private void AgregarNuevosGeneros(Perfil unPerfil)
        {
            foreach (Genero genero in _repoGenero.Generos())
            {
                if(!EstaGeneroPuntuado(unPerfil, genero))
                {
                    AgregarGenero(unPerfil, genero);
                }
            }
        }

        private void QuitarGenerosEliminados(Perfil unPerfil)
        {
            List<GeneroPuntaje> paraEliminar = BuscarGenerosEliminados(unPerfil);

            foreach (GeneroPuntaje genero in paraEliminar)
            {
                _repoGeneroPuntaje.EliminarGeneroPuntaje(genero);
            }
        }

        private List<GeneroPuntaje> BuscarGenerosEliminados(Perfil unPerfil)
        {
            List<GeneroPuntaje> paraEliminar = new List<GeneroPuntaje>();

            foreach (GeneroPuntaje genero in _repoPerfil.GenerosPuntuados(unPerfil))
            {
                if (GeneroEliminado(genero))
                {
                    paraEliminar.Add(genero);
                }
            }

            return paraEliminar;
        }

        public void AgregarGenero(Perfil unPerfil, Genero unGenero)
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

        public bool EstaGeneroPuntuado(Perfil unPerfil, Genero unGenero)
        {
            return _repoGeneroPuntaje.EstaGeneroPuntaje(unGenero, unPerfil);
        }

        private bool GeneroEliminado(GeneroPuntaje unGenero)
        {
            return !_repoGenero.EstaGenero(unGenero.Genero);
        }
    }
}
