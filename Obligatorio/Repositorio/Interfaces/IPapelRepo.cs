using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Interfaces
{
    public interface IPapelRepo
    {
        void AgregarPapel(Papel papel);
        void EliminarPapel(Papel papel);
        bool ExistePapel(Papel papel);
        List<Papel> Papeles();
    }
}
