using Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.ConfiguracionesDominio
{
    public static class ConfigPelicula
    {
        public static void ConfigurarEntidad(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pelicula>().ToTable("peliculas");
            modelBuilder.Entity<Pelicula>().HasKey(p => p.Identificador);
            modelBuilder.Entity<Pelicula>().HasMany<Genero>(p => p.GenerosSecundarios);
            modelBuilder.Entity<Pelicula>().HasRequired<Genero>(p => p.GeneroPrincipal);
        }
    }
}
