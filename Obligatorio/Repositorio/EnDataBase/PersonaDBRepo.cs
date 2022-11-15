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
                Persona personaSeleccionada = tlmeContext.Personas.FirstOrDefault(p => p.Id == persona.Id);
                personaSeleccionada = persona;
                tlmeContext.Entry(personaSeleccionada).State = EntityState.Modified;
                tlmeContext.SaveChanges();
            }
        }

        public List<Persona> Personas()
        {
            using (ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                return tlmeContext.Personas.ToList();
            }
        }
    }
}
