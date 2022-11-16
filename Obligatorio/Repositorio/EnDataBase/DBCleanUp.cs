using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.EnDataBase
{
    public static class DBCleanUp
    {
        public static void CleanUp()
        {
            using (ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                tlmeContext.Database.ExecuteSqlCommand("DELETE FROM papeles");
                tlmeContext.Database.ExecuteSqlCommand("DELETE FROM personas");
                tlmeContext.Database.ExecuteSqlCommand("DELETE FROM generos_puntajes");
                tlmeContext.Database.ExecuteSqlCommand("DELETE FROM PeliculaGeneroes");
                tlmeContext.Database.ExecuteSqlCommand("DELETE FROM PerfilPeliculas");
                tlmeContext.Database.ExecuteSqlCommand("DELETE FROM peliculas");
                tlmeContext.Database.ExecuteSqlCommand("DELETE FROM generos");
                tlmeContext.Database.ExecuteSqlCommand("DELETE FROM perfiles");
                tlmeContext.Database.ExecuteSqlCommand("DELETE FROM usuarios");
                tlmeContext.SaveChanges();
            }
        }
    }
}
