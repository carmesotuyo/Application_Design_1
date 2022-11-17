using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Interfaces
{
    public interface IGeneroPuntajeRepo
    {
        bool EstaGeneroPuntaje(Genero genero, Perfil perfil);
        void AgregarGeneroPuntaje(GeneroPuntaje generoPuntaje);
        void EliminarGeneroPuntaje(GeneroPuntaje generoPuntaje);
        void ModificarPuntaje(Genero genero, Perfil perfil, int puntaje);
        GeneroPuntaje EncontrarGeneroPuntaje(Genero genero, Perfil perfil);
        List<GeneroPuntaje> GenerosPuntajes();
    }
}
