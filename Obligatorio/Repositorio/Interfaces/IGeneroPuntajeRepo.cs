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
        bool EstaGeneroPuntaje(GeneroPuntaje generoPuntaje);
        void AgregarGeneroPuntaje(GeneroPuntaje generoPuntaje);
        void EliminarGeneroPuntaje(GeneroPuntaje generoPuntaje);
        List<GeneroPuntaje> GenerosPuntajes();
    }
}
