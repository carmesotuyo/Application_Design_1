using Dominio;
using Repositorio.ConfiguracionesDominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.EnDataBase
{
    public class ThreatLevelMidnightEntertainmentDBContext : DbContext
    {
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<GeneroPuntaje> GenerosPuntajes { get; set; }
        public DbSet<Perfil> Perfiles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Papel> Papeles { get; set; }

        public ThreatLevelMidnightEntertainmentDBContext() : base("ThreatLevelMidnightEntertainmentDB")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ConfigGenero.ConfigurarEntidad(modelBuilder);
            ConfigPelicula.ConfigurarEntidad(modelBuilder);
            ConfigGeneroPuntaje.ConfigurarEntidad(modelBuilder);
            ConfigPerfil.ConfigurarEntidad(modelBuilder);
            ConfigUsuario.ConfigurarEntidad(modelBuilder);
            ConfigPersona.ConfigurarEntidad(modelBuilder);
            ConfigPapel.ConfigurarEntidad(modelBuilder);
        }
    }
}
