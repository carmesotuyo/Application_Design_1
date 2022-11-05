using Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.ConfiguracionesDominio
{
    public static class ConfigGeneroPuntaje
    {
        public static void ConfigurarEntidad(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GeneroPuntaje>().ToTable("generos_puntajes");
            modelBuilder.Entity<GeneroPuntaje>().HasKey(g => new { g.AliasPerfil, g.NombreGenero });
        }
    }
}
