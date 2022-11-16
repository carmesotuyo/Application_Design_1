using Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.ConfiguracionesDominio
{
    public class ConfigPapel
    {
        public static void ConfigurarEntidad(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Papel>().ToTable("papeles");
            modelBuilder.Entity<Papel>().HasKey(p => p.Nombre)
                .HasRequired(p => p.Pelicula)
                .WithMany(p => p.Papeles);
            modelBuilder.Entity<Papel>().HasRequired(p => p.Actor)
                .WithMany(p => p.PapelesQueActua);
        }
    }
}
