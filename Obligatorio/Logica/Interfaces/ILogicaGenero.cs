using Dominio;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Interfaces
{
    public interface ILogicaGenero
    {
        void AgregarGenero(Genero genero, GeneroRepo repo);
    }
}
