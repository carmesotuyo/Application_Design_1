using Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.ConfiguracionesDominio
{
    public static class ConfigUsuario
    {
        public static void ConfigurarEntidad(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("usuarios");
            modelBuilder.Entity<Usuario>().HasKey(u => u.Nombre);
        }
    }
}
