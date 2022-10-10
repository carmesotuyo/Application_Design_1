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
            ModificarPuntajeGenero(unPerfil, unaPelicula.GeneroPrincipal, (int) Puntajes.PuntajeMuyPositivo);
            foreach(Genero genero in unaPelicula.GenerosSecundarios)
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
            PertenecenAlMismoUsuario(perfilInfantil, perfilOwner, usuario);
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

        private void PertenecenAlMismoUsuario(Perfil perfilInfantil, Perfil perfilOwner, Usuario usuario)
        {
            usuario.NoExistePerfil(perfilInfantil);
            usuario.NoExistePerfil(perfilOwner);
        }

        public void AgregarPeliculaVista(Pelicula unaPelicula, Perfil unPerfil)
        {
            ChequearQueNoEsteYaVista(unaPelicula, unPerfil);
            unPerfil.AgregarPeliculaVista(unaPelicula);
        }
        public void ChequearQueNoEsteYaVista(Pelicula unaPelicula, Perfil unPerfil)
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
            int index = EncontrarGeneroEnLista(unPerfil, unGenero);
            unPerfil.PuntajeGeneros[index].ModificarPuntaje(puntaje);
        }

        private int EncontrarGeneroEnLista(Perfil unPerfil, Genero unGenero)
        {
            GeneroPuntaje genero = unPerfil.PuntajeGeneros.FirstOrDefault(x => x.Genero == unGenero.Nombre);
            return unPerfil.PuntajeGeneros.IndexOf(genero);
        }

        public void ActualizarListadoGeneros(Perfil unPerfil, GeneroRepo repo)
        {
            QuitarGenerosEliminados(unPerfil, repo);
            AgregarNuevosGeneros(unPerfil, repo);
        }

        private void AgregarNuevosGeneros(Perfil unPerfil, GeneroRepo repo)
        {
            foreach (Genero genero in repo.generos)
            {
                if(!EstaGenero(unPerfil, genero))
                {
                    AgregarGenero(unPerfil, genero);
                }
            }
        }

        private void QuitarGenerosEliminados(Perfil unPerfil, GeneroRepo repo)
        {
            List<GeneroPuntaje> paraEliminar = BuscarGenerosEliminados(unPerfil, repo);

            foreach (GeneroPuntaje genero in paraEliminar)
            {
                unPerfil.QuitarGeneroPuntaje(genero);
            }
        }

        private List<GeneroPuntaje> BuscarGenerosEliminados(Perfil unPerfil, GeneroRepo repo)
        {
            List<GeneroPuntaje> paraEliminar = new List<GeneroPuntaje>();

            foreach (GeneroPuntaje genero in unPerfil.PuntajeGeneros)
            {
                if (GeneroEliminado(repo, genero))
                {
                    paraEliminar.Add(genero);
                }
            }

            return paraEliminar;
        }

        public void AgregarGenero(Perfil unPerfil, Genero unGenero)
        {
            GeneroPuntaje nuevo = new GeneroPuntaje() { Genero = unGenero.Nombre };
            unPerfil.AgregarGeneroPuntaje(nuevo);
        }

        public bool EstaGenero(Perfil unPerfil, Genero unGenero)
        {
            List<GeneroPuntaje> busco = unPerfil.PuntajeGeneros.Where(x => x.Genero == unGenero.Nombre).ToList();
            return busco.Count > 0;
        }

        public bool GeneroEliminado(GeneroRepo repo, GeneroPuntaje unGenero)
        {
            List<Genero> busco = repo.generos.Where(x => x.Nombre != unGenero.Genero).ToList();
            return busco.Count == repo.generos.Count;
        }
    }
}
