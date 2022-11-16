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
    public class PapelDBRepo : IPapelRepo
    {
        public void AgregarPapel(Papel papel)
        {
            using (ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                //tlmeContext.Papeles.Attach(papel);

                //Pelicula pelicula = tlmeContext.Peliculas.FirstOrDefault(p => p.Identificador == papel.Pelicula.Identificador);
                tlmeContext.Peliculas.Attach(papel.Pelicula);
                //Persona actor = tlmeContext.Personas.FirstOrDefault(p => p.Id == papel.Actor.Id);
                tlmeContext.Personas.Attach(papel.Actor);

                //tlmeContext.Entry(papel.Actor).State = EntityState.Unchanged;
                //tlmeContext.Entry(papel.Pelicula).State = EntityState.Unchanged;
                //tlmeContext.Entry(papel.Pelicula.GeneroPrincipal).State = EntityState.Unchanged;
                //foreach (var generosEnMemoria in papel.Pelicula.GenerosSecundarios)
                //{
                //    tlmeContext.Entry(generosEnMemoria).State = EntityState.Unchanged;
                //}
                tlmeContext.Papeles.Add(papel);
                tlmeContext.SaveChanges();
            }
        }

        public void EliminarPapel(Papel papel)
        {
            using (ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                Papel papelABorrar = tlmeContext.Papeles
                    .FirstOrDefault(p => p.Nombre == papel.Nombre && p.Actor.Id == papel.Actor.Id 
                    && p.Pelicula.Identificador == papel.Pelicula.Identificador);
                tlmeContext.Papeles.Remove(papelABorrar);
                tlmeContext.SaveChanges();
            }
        }

        public bool ExistePapel(Papel papel)
        {
            using (ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                return tlmeContext.Papeles.FirstOrDefault(p => p.Nombre == papel.Nombre 
                    && p.Actor.Id == papel.Actor.Id
                    && p.Pelicula.Identificador == papel.Pelicula.Identificador) != null;
            }
        }

        public List<Papel> Papeles()
        {
            using (ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                return tlmeContext.Papeles.Include(p=>p.Pelicula).Include(p=>p.Actor).ToList();
            }
        }
    }
}
