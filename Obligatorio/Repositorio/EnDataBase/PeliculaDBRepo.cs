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
                Pelicula peliculaBuscada = tlmeContext.Peliculas.FirstOrDefault(p => p.Identificador == pelicula.Identificador);
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
                return tlmeContext.Peliculas.Include(x=> x.GeneroPrincipal).Include(x=> x.GenerosSecundarios).ToList();
            }
        }

        public void QuitarPelicula(Pelicula pelicula)
        {
            using (ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                if (EstaPelicula(pelicula))
                {
                    Pelicula peliculaABorrar = tlmeContext.Peliculas.FirstOrDefault(p => p.Identificador == pelicula.Identificador);
                    tlmeContext.Peliculas.Remove(peliculaABorrar);
                    tlmeContext.SaveChanges();
                }
            }
        }

        public List<Genero> DevolverGenerosAsociados(Pelicula pelicula)
        {
            using (ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                return tlmeContext.Peliculas.Where(p => p.Identificador == pelicula.Identificador).SelectMany(p => p.GenerosSecundarios).ToList();
            }
        }

        public void AgregarGeneroSecundario(Pelicula pelicula, Genero genero)
        {
            using (ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                Pelicula peliculaBuscada = tlmeContext.Peliculas.FirstOrDefault(p => p.Identificador == pelicula.Identificador);
                peliculaBuscada.GenerosSecundarios.Add(genero);
                tlmeContext.Entry(genero).State = EntityState.Unchanged;
                tlmeContext.SaveChanges();
            }
        }

        public bool EsActor(Pelicula pelicula, Persona persona)
        {
            using (ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                bool ret = false;
                Pelicula peliculaBuscada = tlmeContext.Peliculas.FirstOrDefault(p => p.Identificador == pelicula.Identificador);
                List<Papel> papelesDePelicula = tlmeContext.Papeles.Where(p => p.Pelicula.Equals(peliculaBuscada)).ToList();
                foreach (Papel papel in papelesDePelicula)
                {
                    if (papel.Actor.Equals(persona))
                    {
                        ret = true;
                    }
                }

                return ret;
            }
        }

        public bool EsDirector(Pelicula pelicula, Persona persona)
        {
            using (ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                bool ret = false;
                Pelicula peliculaBuscada = tlmeContext.Peliculas.FirstOrDefault(p => p.Identificador == pelicula.Identificador);
                foreach (Persona director in peliculaBuscada.Directores)
                {
                    if (director.Equals(persona))
                    {
                        ret = true;
                    }
                }

                return ret;
            }
        }

        public string MostrarActores(Pelicula pelicula, int cantAMostrar)
        {
            using (ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                string actores = "";
                Pelicula peliculaBuscada = tlmeContext.Peliculas.FirstOrDefault(p => p.Identificador == pelicula.Identificador);
                for(int i=0; i < cantAMostrar || i < peliculaBuscada.Papeles.Count; i++)
                {
                    actores += peliculaBuscada.Papeles[i].Actor.Nombre;
                }
                return actores;
            }
        }

        public string MostrarDirectores(Pelicula pelicula, int cantAMostrar)
        {
            using (ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                string directores = "";
                Pelicula peliculaBuscada = tlmeContext.Peliculas.FirstOrDefault(p => p.Identificador == pelicula.Identificador);
                for (int i = 0; i < cantAMostrar || i < peliculaBuscada.Directores.Count; i++)
                {
                    directores += peliculaBuscada.Directores[i].Nombre + ". ";
                }
                return directores;
            }
        }

        public void AsociarDirector(Persona director, Pelicula pelicula)
        {
            using (ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                Persona directorEncontrado = tlmeContext.Personas.FirstOrDefault(p => p.Id == director.Id);
                tlmeContext.Personas.Attach(directorEncontrado);
                Pelicula peliculaEncontrada = tlmeContext.Peliculas.FirstOrDefault(p => p.Identificador == pelicula.Identificador);
                tlmeContext.Peliculas.Attach(peliculaEncontrada);
                peliculaEncontrada.Directores.Add(directorEncontrado);

                //tlmeContext.Entry(directorEncontrado).State = EntityState.Unchanged;
                //tlmeContext.Entry(peliculaEncontrada).State = EntityState.Modified;
                //tlmeContext.Entry(peliculaEncontrada.Directores).State = EntityState.Modified;
                tlmeContext.SaveChanges();
            }
        }

        public void DesasociarDirector(Persona director, Pelicula pelicula)
        {
            using (ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                Persona directorEncontrado = tlmeContext.Personas.FirstOrDefault(p => p.Id == director.Id);
                Pelicula peliculaEncontrada = tlmeContext.Peliculas.FirstOrDefault(p => p.Identificador == pelicula.Identificador);
                peliculaEncontrada.Directores.Remove(directorEncontrado);

                //tlmeContext.Entry(directorEncontrado).State = EntityState.Unchanged;
                tlmeContext.Entry(peliculaEncontrada).State = EntityState.Modified;
                tlmeContext.SaveChanges();
            };
        }
    }
}
