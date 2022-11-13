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
    public class PerfilDBRepo : IPerfilRepo
    {
        public void AgregarPerfil(Perfil perfil)
        {
            using (ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                MantenerEntidadesPerfilSinCambios(perfil, tlmeContext);
                tlmeContext.Perfiles.Add(perfil);
                tlmeContext.SaveChanges();
            }
        }

        public void MantenerEntidadesPerfilSinCambios(Perfil perfil, ThreatLevelMidnightEntertainmentDBContext tlmeContext)
        {
            tlmeContext.Entry(perfil.Usuario).State = EntityState.Unchanged;

            foreach (var peliculaVista in perfil.PeliculasVistas)
            {
                tlmeContext.Entry(peliculaVista).State = EntityState.Unchanged;
            }

            foreach (var puntajeGenero in perfil.PuntajeGeneros)
            {
                tlmeContext.Entry(puntajeGenero).State = EntityState.Unchanged;
            }
        }

        public void EliminarPerfil(Perfil perfil)
        {
            using (ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                Perfil perfilABorrar = tlmeContext.Perfiles.FirstOrDefault(p => p.Equals(perfil));
                tlmeContext.Perfiles.Remove(perfilABorrar);
                tlmeContext.SaveChanges();
            }
        }

        public bool EstaPerfil(Perfil perfil)
        {
            bool esta = false;
            using (ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                Perfil perfilBuscado = tlmeContext.Perfiles.FirstOrDefault(p => p.Equals(perfil));
                if (perfilBuscado != null)
                {
                    esta = true;
                }
            }
            return esta;
        }

        public List<Perfil> Perfiles()
        {
            using (ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                return tlmeContext.Perfiles.Include(x => x.Usuario).Include(x => x.PeliculasVistas).ToList();
            }
        }

        public List<Perfil> PerfilesDeUsuario(Usuario usuario)
        {
            using (ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                return tlmeContext.Perfiles.Where(x => x.Usuario.Equals(usuario)).ToList();
            }
        }

        public List<GeneroPuntaje> GenerosPuntuados(Perfil perfil)
        {
            using (ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                return tlmeContext.GenerosPuntajes.Include(x => x.Genero).Include(x => x.Perfil)
                     .Where(x => x.Perfil.Equals(perfil)).ToList();
            }
        }

        public List<Pelicula> PeliculasVistas(Perfil perfil)
        {
            using (ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                //ver si funciona
                return tlmeContext.Perfiles.Include(p => p.PeliculasVistas).Where(p => p.Equals(perfil))
                    .SelectMany(p => p.PeliculasVistas).ToList();
            }
        }

        public void AgregarPeliculaVista(Perfil perfil, Pelicula pelicula)
        {
            using (ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                //tlmeContext.Entry(perfil).State = EntityState.Unchanged;
                tlmeContext.Entry(pelicula).State = EntityState.Unchanged;
                tlmeContext.Entry(pelicula.GeneroPrincipal).State = EntityState.Unchanged;
                //MantenerEntidadesPerfilSinCambios(perfil, tlmeContext);
                tlmeContext.Perfiles.FirstOrDefault(p => p.Equals(perfil)).PeliculasVistas.Add(pelicula);
                tlmeContext.SaveChanges();
            }
        }
    }
}
