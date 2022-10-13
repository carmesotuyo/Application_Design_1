using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Interfaces
{
    public interface IGeneroRepo
    {
        bool EstaGenero(Genero genero);
        void AgregarGenero(Genero genero);
        void EliminarGenero(Genero genero);
        List<Genero> Generos();
    }
}