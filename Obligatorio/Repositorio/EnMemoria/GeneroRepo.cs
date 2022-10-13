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
        private List<Genero> _generos = new List<Genero>();

        public GeneroRepo()
        {
            _generos = new List<Genero>();
        }

        public bool EstaGenero(Genero genero)
        {
            bool esta = false;
            foreach (Genero generoGuardado in _generos)
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
            _generos.Add(genero);
        }

        public void EliminarGenero(Genero genero)
        {
            _generos.Remove(genero);
        }

        public List<Genero> Generos()
        {
            return _generos;
        }
    }
}
