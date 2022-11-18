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
            modelBuilder.Entity<Pelicula>().ToTable("peliculas")
                .HasKey(p => p.Identificador)
                .HasMany(p => p.GenerosSecundarios)
                .WithMany(g => g.PeliculasAsociadas);
            modelBuilder.Entity<Pelicula>().HasMany(p => p.Directores)
                .WithMany(d => d.PeliculasQueDirige);
        }
    }
}
