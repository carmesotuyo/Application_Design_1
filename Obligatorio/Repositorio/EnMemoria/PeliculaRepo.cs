using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Repositorio.Interfaces;

namespace Repositorio
{
    public class PeliculaRepo : IPeliculaRepo
    {
        private List<Pelicula> _peliculas = new List<Pelicula>();

        public PeliculaRepo()
        {
            _peliculas = new List<Pelicula>();
        }
        public bool EstaPelicula(Pelicula pelicula)
        {
            return _peliculas.Contains(pelicula);
        }
        public void AgregarPelicula(Pelicula pelicula)
        {
            _peliculas.Add(pelicula);
        }
        public void QuitarPelicula(Pelicula pelicula)
        {
            if (EstaPelicula(pelicula))
            {
                _peliculas.Remove(pelicula);
            }
        }

        public List<Pelicula> Peliculas()
        {
            return _peliculas;
        }

        public List<Genero> DevolverGenerosAsociados(Pelicula pelicula)
        {
            throw new NotImplementedException();
        }

        public void AgregarGeneroSecundario(Pelicula pelicula, Genero genero)
        {
            throw new NotImplementedException();
        }

        public bool EsActor(Pelicula pelicula, Persona persona)
        {
            throw new NotImplementedException();
        }

        public bool EsDirector(Pelicula pelicula, Persona persona)
        {
            throw new NotImplementedException();
        }

        public string MostrarActores(Pelicula pelicula, int cantAMostrar)
        {
            throw new NotImplementedException();
        }

        public string MostrarDirectores(Pelicula pelicula, int cantAMostrar)
        {
            throw new NotImplementedException();
        }

        public void AsociarDirector(Persona director, Pelicula pelicula)
        {
            throw new NotImplementedException();
        }

        public void DesasociarDirector(Persona director, Pelicula pelicula)
        {
            throw new NotImplementedException();
        }
    }
}
