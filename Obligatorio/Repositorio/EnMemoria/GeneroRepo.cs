using Dominio;
using Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class GeneroRepo : IGeneroRepo
    {
        public List<Genero> generos = new List<Genero>();
        public bool EstaGenero(Genero genero)
        {
            bool esta = false;
            foreach (Genero generoGuardado in generos)
            {
                if(generoGuardado.Nombre == genero.Nombre)
                {
                    esta = true;
                }
            }
            return esta;
        }
        public void AgregarGenero(Genero genero)
        {
            generos.Add(genero);
        }

        public void EliminarGenero(Genero genero)
        {
            generos.Remove(genero);
        }
    }
}
