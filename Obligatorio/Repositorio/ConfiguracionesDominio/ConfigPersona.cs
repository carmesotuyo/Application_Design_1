using Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.ConfiguracionesDominio
{
    public static class ConfigPersona
    {
        public static void ConfigurarEntidad(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>().ToTable("personas");
            modelBuilder.Entity<Persona>().HasKey(p => p.Id);
        }
    }
}
