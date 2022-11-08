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
    public class GeneroPuntajeDBRepo : IGeneroPuntajeRepo
    {
        public void AgregarGeneroPuntaje(GeneroPuntaje generoPuntaje)
        {
            using (ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                tlmeContext.GenerosPuntajes.Add(generoPuntaje);
                tlmeContext.SaveChanges();
            }
        }

        public void EliminarGeneroPuntaje(GeneroPuntaje generoPuntaje)
        {
            using(ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                GeneroPuntaje generoABorrar = tlmeContext.GenerosPuntajes
                    .FirstOrDefault(g => g.Perfil == generoPuntaje.Perfil && g.Genero == generoPuntaje.Genero);
                tlmeContext.GenerosPuntajes.Remove(generoABorrar);
                tlmeContext.SaveChanges();
            }
        }

        public bool EstaGeneroPuntaje(Genero genero, Perfil perfil)
        {
            bool esta = false;
            using (ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                GeneroPuntaje generoBuscado = tlmeContext.GenerosPuntajes
                    .FirstOrDefault(g => g.Perfil == perfil && g.Genero == genero);
                if (generoBuscado != null)
                {
                    esta = true;
                }
            }
            return esta;
        }

        public void ModificarPuntaje(Genero genero, Perfil perfil, int puntaje)
        {
            using (ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                EncontrarGeneroPuntaje(genero, perfil).ModificarPuntaje(puntaje);
                tlmeContext.SaveChanges();
            }
        }

        public List<GeneroPuntaje> GenerosPuntajes()
        {
            using (ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                return tlmeContext.GenerosPuntajes.Include(x => x.Genero)
                    .Include(x=> x.Perfil).ToList();
            }
        }

        private GeneroPuntaje EncontrarGeneroPuntaje(Genero genero, Perfil perfil)
        {
            using (ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                return tlmeContext.GenerosPuntajes.FirstOrDefault(g => g.Perfil == perfil && g.Genero == genero);//.Include(x => x.Genero)
                    //.Include(x => x.Perfil);
            };
        }
    }
}
