using Dominio;
using Logica.Interfaces;
using Repositorio;
using Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Implementaciones
{
    public class LogicaPelicula : ILogicaPelicula
    {
        private IPeliculaRepo _repo;
        public LogicaPelicula(IPeliculaRepo peliculaRepo)
        {
            _repo = peliculaRepo;
        }
        public void AltaPelicula(Pelicula pelicula)
        {
            _repo.AgregarPelicula(pelicula);
        }

        public void BajaPelicula(Pelicula pelicula)
        {
            _repo.QuitarPelicula(pelicula);
        }

        public List<Pelicula> Peliculas()
        {
            return _repo.Peliculas();
        }

        public void VerInformacionDePelicula(Pelicula pelicula)
        {
            throw new NotImplementedException();
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
