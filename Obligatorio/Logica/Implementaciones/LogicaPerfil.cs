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
            int index = EncontrarGeneroEnLista(unPerfil, unGenero);
            unPerfil.PuntajeGeneros[index].ModificarPuntaje(puntaje);
        }

        private int EncontrarGeneroEnLista(Perfil unPerfil, Genero unGenero)
        {
            GeneroPuntaje genero = unPerfil.PuntajeGeneros.FirstOrDefault(x => x.Genero == unGenero.Nombre);
            return unPerfil.PuntajeGeneros.IndexOf(genero);
        }

        public void ActualizarListadoGeneros(Perfil unPerfil, ILogicaGenero logicaGenero)
        {
            QuitarGenerosEliminados(unPerfil, logicaGenero);
            AgregarNuevosGeneros(unPerfil, logicaGenero);
        }

        private void AgregarNuevosGeneros(Perfil unPerfil, ILogicaGenero logicaGenero)
        {
            foreach (Genero genero in logicaGenero.Generos())
            {
                if(!EstaGenero(unPerfil, genero))
                {
                    AgregarGenero(unPerfil, genero);
                }
            }
        }

        private void QuitarGenerosEliminados(Perfil unPerfil, ILogicaGenero logicaGenero)
        {
            List<GeneroPuntaje> paraEliminar = BuscarGenerosEliminados(unPerfil, logicaGenero);

            foreach (GeneroPuntaje genero in paraEliminar)
            {
                unPerfil.QuitarGeneroPuntaje(genero);
            }
        }

        private List<GeneroPuntaje> BuscarGenerosEliminados(Perfil unPerfil, ILogicaGenero logicaGenero)
        {
            List<GeneroPuntaje> paraEliminar = new List<GeneroPuntaje>();

            foreach (GeneroPuntaje genero in unPerfil.PuntajeGeneros)
            {
                if (GeneroEliminado(logicaGenero, genero))
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

        private bool GeneroEliminado(ILogicaGenero logicaGenero, GeneroPuntaje unGenero)
        {
            List<Genero> busco = logicaGenero.Generos().Where(x => x.Nombre != unGenero.Genero).ToList();
            return busco.Count == logicaGenero.Generos().Count;
        }
    }
}
