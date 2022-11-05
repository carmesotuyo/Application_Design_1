using Dominio;
using Repositorio.Interfaces;
using System;
using System.Collections.Generic;
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

        public bool EstaGeneroPuntaje(GeneroPuntaje generoPuntaje)
        {
            bool esta = false;
            using (ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                GeneroPuntaje generoBuscado = tlmeContext.GenerosPuntajes
                    .FirstOrDefault(g => g.Perfil == generoPuntaje.Perfil && g.Genero == generoPuntaje.Genero);
                if (generoBuscado != null)
                {
                    esta = true;
                }
            }
            return esta;
        }

        public List<GeneroPuntaje> GenerosPuntajes()
        {
            using (ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                return tlmeContext.GenerosPuntajes.ToList();
            }
        }
    }
}
