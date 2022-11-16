using Dominio;
using Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.EnDataBase
{
    public class PapelDBRepo : IPapelRepo
    {
        public void AgregarPapel(Papel papel, Usuario admin)
        {
            throw new NotImplementedException();
        }

        public void EliminarPapel(Papel papel, Usuario admin)
        {
            throw new NotImplementedException();
        }

        public List<Papel> Papeles()
        {
            throw new NotImplementedException();
        }
    }
}
