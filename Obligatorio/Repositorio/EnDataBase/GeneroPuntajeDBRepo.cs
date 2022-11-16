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
                //MantenerEntidadesSinCambios(generoPuntaje, tlmeContext);
                tlmeContext.Generos.Attach(generoPuntaje.Genero);
                tlmeContext.Perfiles.Attach(generoPuntaje.Perfil);
                tlmeContext.GenerosPuntajes.Add(generoPuntaje);
                tlmeContext.SaveChanges();
            }
        }

        private static void MantenerEntidadesSinCambios(GeneroPuntaje generoPuntaje, ThreatLevelMidnightEntertainmentDBContext tlmeContext)
        {
            tlmeContext.Entry(generoPuntaje.Genero).State = EntityState.Unchanged;
            tlmeContext.Entry(generoPuntaje.Perfil).State = EntityState.Unchanged;
        }

        public void EliminarGeneroPuntaje(GeneroPuntaje generoPuntaje)
        {
            using(ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                GeneroPuntaje generoABorrar = tlmeContext.GenerosPuntajes.FirstOrDefault(g => g.AliasPerfil == generoPuntaje.AliasPerfil 
                            && g.Perfil.NombreUsuario == generoPuntaje.Perfil.NombreUsuario && g.NombreGenero == generoPuntaje.NombreGenero);
                if(generoABorrar != null)
                {
                    tlmeContext.GenerosPuntajes.Remove(generoABorrar);
                    tlmeContext.SaveChanges();
                }
            }
        }

        public bool EstaGeneroPuntaje(Genero genero, Perfil perfil)
        {
            bool esta = false;
            using (ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                GeneroPuntaje generoBuscado = tlmeContext.GenerosPuntajes.FirstOrDefault(g => g.Perfil.Alias == perfil.Alias 
                                        && g.Perfil.NombreUsuario == perfil.NombreUsuario && g.Genero.Nombre == genero.Nombre);
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
                GeneroPuntaje encontrado = EncontrarGeneroPuntaje(genero, perfil);
                encontrado.ModificarPuntaje(puntaje);
                tlmeContext.Entry(encontrado).State = EntityState.Modified;
                MantenerEntidadesSinCambios(encontrado, tlmeContext);
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

        public GeneroPuntaje EncontrarGeneroPuntaje(Genero genero, Perfil perfil)
        {
            using (ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                return tlmeContext.GenerosPuntajes.Include(g => g.Genero).Include(g => g.Perfil).FirstOrDefault(g => g.Perfil.Alias == perfil.Alias 
                                                            && g.Perfil.NombreUsuario == perfil.NombreUsuario && g.Genero.Nombre == genero.Nombre);
            };
        }
    }
}
