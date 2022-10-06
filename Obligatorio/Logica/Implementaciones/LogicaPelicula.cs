using Dominio;
using Logica.Interfaces;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Implementaciones
{
    public class LogicaPelicula : ILogicaPelicula
    {
        public void AltaPelicula(Pelicula pelicula, PeliculaRepo repo)
        {
            //deberia validar los campos de pelicula nuevamente?
            repo.peliculas.Add(pelicula);
        }

        public void BajaPelicula(Pelicula pelicula, PeliculaRepo repo)
        {
            throw new NotImplementedException();
        }

        public void MarcarComoVista(Pelicula pelicula)
        {
            throw new NotImplementedException();
        }

        public void VerInformacionDePelicula(Pelicula pelicula)
        {
            throw new NotImplementedException();
        }
    }
}
