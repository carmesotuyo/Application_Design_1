using Dominio;
using Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                //MantenerEntidadesSinCambios(usuario, tlmeContext);
                tlmeContext.Usuarios.Add(usuario);
                tlmeContext.SaveChanges();
            }
        }

        //public void MantenerEntidadesSinCambios(Usuario usuario, ThreatLevelMidnightEntertainmentDBContext tlmeContext)
        //{
        //    foreach (var perfil in usuario.Perfiles)
        //    {
        //        tlmeContext.Entry(perfil).State = EntityState.Unchanged;
        //    }
        //}

        public bool EstaUsuario(Usuario usuario)
        {
            bool esta = false;
            using (ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                Usuario usuarioBuscado = tlmeContext.Usuarios.FirstOrDefault(u => u.Nombre == usuario.Nombre);
                if (usuarioBuscado != null)
                {
                    esta = true;
                }
            }
            return esta;
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
