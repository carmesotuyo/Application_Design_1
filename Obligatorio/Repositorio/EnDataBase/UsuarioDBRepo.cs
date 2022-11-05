using Dominio;
using Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.EnDataBase
{
    public class UsuarioDBRepo : IRepoUsuarios
    {
        public void AgregarUsuario(Usuario usuario)
        {
            using (ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                tlmeContext.Usuarios.Add(usuario);
                tlmeContext.SaveChanges();
            }
        }

        public List<Usuario> Usuarios()
        {
            using (ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                return tlmeContext.Usuarios.ToList();
            };
        }
    }
}
