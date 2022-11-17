using Dominio;
using Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography.X509Certificates;
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
                tlmeContext.Generos.Attach(pelicula.GeneroPrincipal);
                foreach (var generosEnMemoria in pelicula.GenerosSecundarios)
                {
                    tlmeContext.Generos.Attach(generosEnMemoria);
                }
                tlmeContext.Peliculas.Add(pelicula);
                tlmeContext.SaveChanges();
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
                return tlmeContext.Peliculas.Include(x=> x.GeneroPrincipal).Include(x=> x.GenerosSecundarios).Include(x =>x.Papeles).ToList();
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
                Pelicula peliculaBuscada = tlmeContext.Peliculas.Include(x=>x.Directores).Include(x=>x.Papeles).FirstOrDefault(p => p.Identificador == pelicula.Identificador);
                List<Papel> papelesDePelicula = tlmeContext.Papeles.Include(x=>x.Actor).Include(x=>x.Pelicula).Where(p => p.Pelicula.Equals(peliculaBuscada)).ToList();
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
                Pelicula peliEncontrada = tlmeContext.Peliculas.Include(x=>x.Directores).FirstOrDefault(x => x.Identificador == pelicula.Identificador);
                Persona personaEncontrada = tlmeContext.Personas.Include(x=>x.PeliculasQueDirige).FirstOrDefault(x => x.Id == persona.Id);
                if (peliEncontrada.Directores.Contains(personaEncontrada))
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
                Pelicula encontrada = tlmeContext.Peliculas.Include(x=> x.Papeles.Select(p=>p.Actor)).FirstOrDefault(x => x.Identificador == pelicula.Identificador);
                for(int i=0; i < cantAMostrar && i < encontrada.Papeles.Count(); i++)
                {
                    actores += encontrada.Papeles[i].Actor.Nombre +". ";
                }
                return actores;
            }
        }

        public string MostrarDirectores(Pelicula pelicula, int cantAMostrar)
        {
            using (ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                string directores = "";
                Pelicula encontrada = tlmeContext.Peliculas.Include(x=> x.Directores).FirstOrDefault(x => x.Identificador == pelicula.Identificador);
                for (int i = 0; i < cantAMostrar && i < encontrada.Directores.Count(); i++)
                {
                    directores += encontrada.Directores[i].Nombre + ". ";
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
                return tlmeContext.Peliculas.Include(x => x.Papeles).Where(p => p.Papeles.Any(x=> x.Actor.Id == actor.Id)).ToList();
            };
        }

        public List<Pelicula> BuscarPorDirector(Persona director)
        {
            using (ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                return tlmeContext.Peliculas.Include(x=>x.Directores).Where(p => p.Directores.Any(x=> x.Id == director.Id)).ToList();
            };
        }

        public List<Papel> Actores(Pelicula pelicula)
        {
            using (ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                return tlmeContext.Papeles.Include(x => x.Actor).Include(x=>x.Pelicula).Where(p => p.Pelicula.Identificador == pelicula.Identificador).ToList();
            };
        }

        public List<Persona> Directores(Pelicula pelicula)
        {
            using (ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                tlmeContext.Peliculas.Attach(pelicula);
                return tlmeContext.Personas.Include(x => x.PeliculasQueDirige).Where(x => x.PeliculasQueDirige.Any(p => p.Identificador == pelicula.Identificador)).ToList();
            };
        }
    }
}
