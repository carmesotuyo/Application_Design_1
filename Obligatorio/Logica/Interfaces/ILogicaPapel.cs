using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Interfaces
{
    public interface ILogicaPapel
    {
        void AsociarActorPelicula(Papel papel, Usuario admin);
        void DesasociarActorPelicula(Papel papel, Usuario admin);
        List<Papel> Papeles();
    }
}
