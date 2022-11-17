using Dominio;
using Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
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
                //MantenerGenerosSinCambios(pelicula, tlmeContext);
                tlmeContext.Generos.Attach(pelicula.GeneroPrincipal);
                foreach (var generosEnMemoria in pelicula.GenerosSecundarios)
                {
                    tlmeContext.Generos.Attach(generosEnMemoria);
                }
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
                tlmeContext.Peliculas.Attach(pelicula);
                tlmeContext.Personas.Attach(persona);
                if (pelicula.Directores.Contains(persona))
                {
                    ret = true;
                }

                return ret;
            }
        }

        public string MostrarActores(Pelicula pelicula, int cantAMostrar)
        {
            using (ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                string actores = "";
                tlmeContext.Peliculas.Attach(pelicula);
                for(int i=0; i < cantAMostrar && i < pelicula.Papeles.Count(); i++)
                {
                    actores += pelicula.Papeles[i].Actor.Nombre +". ";
                }
                return actores;
            }
        }

        public string MostrarDirectores(Pelicula pelicula, int cantAMostrar)
        {
            using (ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                string directores = "";
                tlmeContext.Peliculas.Attach(pelicula);
                for (int i = 0; i < cantAMostrar && i < pelicula.Directores.Count(); i++)
                {
                    directores += pelicula.Directores[i].Nombre + ". ";
                }
                return directores;
            }
        }   

        public void AsociarDirector(Persona director, Pelicula pelicula)
        {
            using (ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                tlmeContext.Personas.Attach(director);
                tlmeContext.Peliculas.Attach(pelicula);
                pelicula.Directores.Add(director);
                tlmeContext.SaveChanges();
            }
        }

        public void DesasociarDirector(Persona director, Pelicula pelicula)
        {
            using (ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                tlmeContext.Personas.Attach(director);
                tlmeContext.Peliculas.Attach(pelicula);
                pelicula.Directores.Remove(director);
                tlmeContext.SaveChanges();
            };
        }

        public List<Pelicula> BuscarPorActor(Persona actor)
        {
            using (ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                return tlmeContext.Peliculas.Where(p => p.Papeles.Any(x=> x.Actor.Id == actor.Id)).ToList();
            };
        }

        public List<Pelicula> BuscarPorDirector(Persona director)
        {
            using (ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                return tlmeContext.Peliculas.Where(p => p.Directores.Any(x=> x.Id == director.Id)).ToList();
            };
        }

        public List<Papel> Actores(Pelicula pelicula)
        {
            using (ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                return tlmeContext.Papeles.Where(p => p.Pelicula.Identificador == pelicula.Identificador).ToList();
            };
        }

        public List<Persona> Directores(Pelicula pelicula)
        {
            using (ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                tlmeContext.Peliculas.Attach(pelicula);
                //return tlmeContext.Personas.Where(x => pelicula.Directores.ToList().Any(d=> d.Id == x.Id)).ToList();
                //return tlmeContext.Personas.Where(x=> x.PeliculasQueDirige.Contains(pelicula)).ToList();
                return tlmeContext.Personas.Where(x => x.PeliculasQueDirige.Any(p=> p.Identificador == pelicula.Identificador)).ToList();
            };
        }
    }
}
