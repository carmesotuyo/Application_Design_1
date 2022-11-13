using Dominio;
using Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.EnDataBase
{
    public class PeliculaDBRepo : IPeliculaRepo
    {
        public void AgregarPelicula(Pelicula pelicula)
        {
            using (ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                MantenerGenerosSinCambios(pelicula, tlmeContext);
                tlmeContext.Peliculas.Add(pelicula);
                tlmeContext.SaveChanges();
            }
        }

        private static void MantenerGenerosSinCambios(Pelicula pelicula, ThreatLevelMidnightEntertainmentDBContext tlmeContext)
        {
            tlmeContext.Entry(pelicula.GeneroPrincipal).State = EntityState.Unchanged;

            foreach (var generosEnMemoria in pelicula.GenerosSecundarios)
            {
                tlmeContext.Entry(generosEnMemoria).State = EntityState.Unchanged;
            }
        }

        public bool EstaPelicula(Pelicula pelicula)
        {
            bool esta = false;
            using (ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                Pelicula peliculaBuscada = tlmeContext.Peliculas.FirstOrDefault(p => p.Equals(pelicula));
                if (peliculaBuscada != null)
                {
                    esta = true;
                }
            }
            return esta;
        }

        public List<Pelicula> Peliculas()
        {
            using (ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                return tlmeContext.Peliculas.Include(x=> x.GeneroPrincipal).ToList();
            }
        }

        public void QuitarPelicula(Pelicula pelicula)
        {
            using (ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                if (EstaPelicula(pelicula))
                {
                    Pelicula peliculaABorrar = tlmeContext.Peliculas.FirstOrDefault(p => p.Equals(pelicula));
                    tlmeContext.Peliculas.Remove(peliculaABorrar);
                    tlmeContext.SaveChanges();
                }
            }
        }

        public List<Genero> DevolverGenerosAsociados(Pelicula pelicula)
        {
            using (ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                return tlmeContext.Peliculas.Where(p => p.Equals(pelicula)).SelectMany(p => p.GenerosSecundarios).ToList();
            }
        }
    }
}
