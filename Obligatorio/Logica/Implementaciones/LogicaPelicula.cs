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
        public void AltaPelicula(Pelicula pelicula, PeliculaRepo repo)
        {
            repo.AgregarPelicula(pelicula);
        }

        public void BajaPelicula(Pelicula pelicula, PeliculaRepo repo)
        {
            repo.QuitarPelicula(pelicula);
        }

        public List<Pelicula> Peliculas()
        {
            return _repo.Peliculas();
        }

        public void VerInformacionDePelicula(Pelicula pelicula)
        {
            throw new NotImplementedException();
        }
    }
}
