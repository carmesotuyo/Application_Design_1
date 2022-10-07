using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class GeneroRepo
    {
        public List<Genero> generos = new List<Genero>();

        public bool EstaGenero(Genero genero)
        {
            return generos.Contains(genero);
        }
        public void AgregarGenero(Genero genero)
        {
            generos.Add(genero);
        }
    }
}
