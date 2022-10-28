using Dominio;
using Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.EnDataBase
{
    public class GeneroDBRepo : IGeneroRepo
    {
        public void AgregarGenero(Genero genero)
        {
            using (ThreatLevelMidnightEntertainmentDBContext tlmeContext = new ThreatLevelMidnightEntertainmentDBContext())
            {
                tlmeContext.Generos.Add(genero);
                tlmeContext.SaveChanges();
            }
        }

        public void EliminarGenero(Genero genero)
        {
            throw new NotImplementedException();
        }

        public bool EstaGenero(Genero genero)
        {
            throw new NotImplementedException();
        }

        public List<Genero> Generos()
        {
            throw new NotImplementedException();
        }
    }
}
