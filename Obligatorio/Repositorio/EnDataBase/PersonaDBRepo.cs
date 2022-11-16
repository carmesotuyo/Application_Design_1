using Dominio;
using Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.EnDataBase
{
    public class PersonaDBRepo : IPersonaRepo
    {
        public void AgregarPersona(Persona persona)
        {
            using (ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                tlmeContext.Personas.Add(persona);
                tlmeContext.SaveChanges();
            }
        }

        public void EliminarPersona(Persona persona)
        {
            using (ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                Persona personaABorrar = tlmeContext.Personas.FirstOrDefault(p => p.Id == persona.Id);
                tlmeContext.Personas.Remove(personaABorrar);
                tlmeContext.SaveChanges();
            }
        }

        public void ModificarPersona(Persona persona)
        {
            using (ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                Persona personaAnterior = tlmeContext.Personas.FirstOrDefault(p => p.Id == persona.Id);
                personaAnterior.Modificar(persona);
                tlmeContext.Entry(personaAnterior).State = EntityState.Modified;
                tlmeContext.SaveChanges();
            }
        }

        public bool EstaPersona(Persona persona)
        {
            using (ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                bool esta = false;
                Persona personaSeleccionada = tlmeContext.Personas.FirstOrDefault(p => p.Id == persona.Id);
                if(personaSeleccionada != null)
                {
                    esta = true;
                }
                return esta;
            }
        }

        public List<Persona> Personas()
        {
            using (ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                return tlmeContext.Personas.ToList();
            }
        }

        public void AsociarDirector(Persona director, Pelicula pelicula)
        {
            using (ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                Persona directorEncontrado = tlmeContext.Personas.FirstOrDefault(p => p.Id == director.Id);
                Pelicula peliculaEncontrada = tlmeContext.Peliculas.FirstOrDefault(p => p.Identificador == pelicula.Identificador);
                peliculaEncontrada.Directores.Add(directorEncontrado);

                //tlmeContext.Entry(directorEncontrado).State = EntityState.Unchanged;
                tlmeContext.Entry(peliculaEncontrada).State = EntityState.Modified;
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
