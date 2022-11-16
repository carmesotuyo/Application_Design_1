using Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.ConfiguracionesDominio
{
    public static class ConfigGenero
    {
        public static void ConfigurarEntidad(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genero>().ToTable("generos");
            modelBuilder.Entity<Genero>().HasKey(g => g.Nombre);
        }
    }
}
