﻿using Dominio;
using Dominio.Exceptions;
using Logica.Exceptions;
using Logica.Interfaces;
using Repositorio;
using Repositorio.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Implementaciones
{
    public class LogicaPelicula : ILogicaPelicula
    {
        private IPeliculaRepo _repo;
        private int _criterioElegido;
        public enum Criterios
        {
            OrdenarPorGenero = 0,
            OrdenarPorPatrocinio = 1,
            OrdenarPorPuntaje = 2
        }

        public LogicaPelicula(IPeliculaRepo peliculaRepo)
        {
            _repo = peliculaRepo;
            CriterioElegido = (int)Criterios.OrdenarPorGenero;
        }
        public void AltaPelicula(Pelicula pelicula, Usuario admin)
        {
            BloquearUsuarioNoAdmin(admin);
            _repo.AgregarPelicula(pelicula);
        }

        public void BajaPelicula(Pelicula pelicula, Usuario admin)
        {
            BloquearUsuarioNoAdmin(admin);
            ChequearNull(pelicula);
            _repo.QuitarPelicula(pelicula);
        }
        private void ChequearNull(Pelicula pelicula)
        {
            if (pelicula == null)
            {
                throw new NullException();
            }
        }

        private void BloquearUsuarioNoAdmin(Usuario admin)
        {
            if (!admin.EsAdministrador)
            {
                throw new UsuarioNoPermitidoException();
            }
        }

        public List<Pelicula> Peliculas()
        {
            return _repo.Peliculas();
        }

        public int CriterioElegido { get => _criterioElegido; set
            {
                ExisteCriterio(value);
                _criterioElegido = value;
            }
        }

        private void ExisteCriterio(int criterio)
        {
            if (!Enum.IsDefined(typeof(Criterios), criterio))
            {
                throw new CriterioInexistenteException();
            }
        }

        public void ElegirCriterioOrden(Usuario admin, int criterio)
        {
            BloquearUsuarioNoAdmin(admin);
            CriterioElegido = criterio;
        }

        private List<Pelicula> OrdenarPorGenero(List<Pelicula> peliculas)
        {
            return peliculas.OrderBy(p => p.GeneroPrincipal.Nombre)
                            .ThenBy(p => p.Nombre)
                            .ThenByDescending(p => p.Identificador).ToList();
        }

        private List<Pelicula> OrdenarPorPatrocinio(List<Pelicula> peliculas)
        {
            return peliculas.OrderBy(p => p.EsPatrocinada = true)
                              .ThenBy(p => p.GeneroPrincipal.Nombre)
                              .ThenBy(p => p.Nombre).ThenByDescending(p => p.Identificador).ToList();
        }

        private List<Pelicula> OrdenarPorPuntaje(Perfil unPerfil, List<Pelicula> peliculas)
        {
            List<string> generos = unPerfil.PuntajeGeneros.OrderByDescending(g => g.Puntaje)
                                                          .Select(g => g.Genero).ToList();

            return peliculas.OrderBy(p => generos.IndexOf(p.GeneroPrincipal.Nombre))
                            .ThenBy(p => p.Nombre).ThenByDescending(p => p.Identificador).ToList();
        }

        public List<Pelicula> MostrarPeliculas(Perfil unPerfil)
        {
            List<Pelicula> peliculasAMostrar = FiltrarPeliculasSiEsInfantil(unPerfil);

            switch (CriterioElegido)
            {
                case 0:
                    peliculasAMostrar = OrdenarPorGenero(peliculasAMostrar);
                    break;
                case 1:
                    peliculasAMostrar = OrdenarPorPatrocinio(peliculasAMostrar);
                    break;
                case 2:
                    peliculasAMostrar = OrdenarPorPuntaje(unPerfil, peliculasAMostrar);
                    break;
            }
            return peliculasAMostrar;
        }

        public string CriterioSeleccionado()
        {
            return Enum.GetName(typeof(Criterios), _criterioElegido);
        }

        public List<Pelicula> FiltrarPeliculasSiEsInfantil(Perfil unPerfil)
        {
            List<Pelicula> peliculas = Peliculas();

            if (unPerfil.EsInfantil)
            {
                peliculas = Peliculas().Where(x => x.AptaTodoPublico == true).ToList();
            }
            return peliculas;
        }
    }
}
