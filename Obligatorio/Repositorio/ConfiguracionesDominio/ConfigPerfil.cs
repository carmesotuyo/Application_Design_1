using Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.ConfiguracionesDominio
{
    public static class ConfigPerfil
    {
        public static void ConfigurarEntidad(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Perfil>().ToTable("perfiles");
            modelBuilder.Entity<Perfil>().HasKey(p => new { p.Alias, p.Usuario });
        }
    }
}
