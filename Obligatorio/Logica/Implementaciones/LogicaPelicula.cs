﻿using Dominio;
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
        }
        public void AltaPelicula(Pelicula pelicula, Usuario admin)
        {
            BloquearUsuarioNoAdmin(admin);
            _repo.AgregarPelicula(pelicula);
        }

        public void BajaPelicula(Pelicula pelicula, Usuario admin)
        {
            BloquearUsuarioNoAdmin(admin);
            _repo.QuitarPelicula(pelicula);
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

        private List<Pelicula> OrdenarPorGenero()
        {
            return Peliculas().OrderBy(p => p.GeneroPrincipal.Nombre).ThenBy(p => p.Nombre).ToList();
        }

        private List<Pelicula> OrdenarPorPatrocinio()
        {
            return Peliculas().OrderBy(p => p.EsPatrocinada = true)
                              .ThenBy(p => p.GeneroPrincipal.Nombre)
                              .ThenBy(p => p.Nombre).ToList();
        }

        private List<Pelicula> OrdenarPorPuntaje(Perfil unPerfil)
        {
            List<string> generos = unPerfil.PuntajeGeneros.OrderByDescending(g => g.Puntaje)
                                                          .Select(g => g.Genero).ToList();

            return Peliculas().OrderBy(p => generos.IndexOf(p.GeneroPrincipal.Nombre))
                              .ThenBy(p => p.Nombre).ToList();
        }

        public List<Pelicula> MostrarPeliculas(Perfil unPerfil)
        {
            switch (CriterioElegido)
            {
                case 0:
                    return OrdenarPorGenero();
                case 1:
                    return OrdenarPorPatrocinio();
                case 2:
                    return OrdenarPorPuntaje(unPerfil);
                default:
                    throw new CriterioInexistenteException();
            }
        }

        public List<Pelicula> MostrarPeliculas(Perfil unPerfil)
        {
            return FiltrarPeliculasSiEsInfantil(unPerfil);
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
