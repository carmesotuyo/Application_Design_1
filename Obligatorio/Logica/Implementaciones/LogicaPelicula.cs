using Dominio;
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
        private List<Pelicula> _pelisAMostrar;
        private int _criterioElegido;
        enum _criterios
        {
            OrdenarPorGenero = 1,
            OrdenarPorPatrocinio = 2,
            OrdenarPorPuntaje = 3
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

        public List<Pelicula> PeliculasAMostrar { get => _pelisAMostrar; set => _pelisAMostrar = value; }

        public int CriterioElegido { get => _criterioElegido; set => _criterioElegido = value; }

        public void ElegirCriterioOrden(Usuario admin, int criterio)
        {
            BloquearUsuarioNoAdmin(admin);
            ExisteCriterio(criterio);
            CriterioElegido = criterio;
        }

        private void ExisteCriterio(int criterio)
        {
            if (!Enum.IsDefined(typeof(_criterio), criterio))
            {
                throw new CriterioInexistenteException();
            }
        }

        public List<Pelicula> OrdenarPorGenero()
        {
            return Peliculas().OrderBy(p => p.GeneroPrincipal.Nombre).ThenBy(p => p.Nombre).ToList();
        }

        public List<Pelicula> OrdenarPorPatrocinio()
        {
            return Peliculas().OrderBy(p => p.EsPatrocinada = true)
                              .ThenBy(p => p.GeneroPrincipal.Nombre)
                              .ThenBy(p => p.Nombre).ToList();
        }

        public List<Pelicula> OrdenarPorPuntaje(Perfil unPerfil)
        {

            //string algo = unPerfil.PuntajeGeneros[0].Genero;

            //List<GeneroPuntaje> generosPuntuados = unPerfil.PuntajeGeneros.OrderByDescending(g => g.Puntaje).ToList();

            List<string> generos = unPerfil.PuntajeGeneros.OrderByDescending(g => g.Puntaje).Select(g => g.Genero).ToList();

            //return Peliculas().OrderBy(p => p.GeneroPrincipal.Nombre = unPerfil.PuntajeGeneros.Genero)
            //                    .ThenBy(p => p.Nombre).ToList();

            return Peliculas().OrderBy(p => generos.IndexOf(p.GeneroPrincipal.Nombre)).ToList();
            //var sortedSamples = listB.OrderBy(x => listA.IndexOf(x.Letter));
        }

        public List<Pelicula> MostrarPeliculas(Perfil unPerfil)
        {
            switch (CriterioElegido)
            {
                case 1:
                    return OrdenarPorGenero();
                    break;
                case 2:
                    return OrdenarPorPatrocinio();
                    break;
                case 3:
                    return OrdenarPorPuntaje(unPerfil);
                    break;
            }
        }
    }
}
