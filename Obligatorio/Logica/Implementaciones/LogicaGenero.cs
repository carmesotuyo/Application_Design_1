using Dominio;
using Logica.Interfaces;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Implementaciones
{
    public class LogicaGenero : ILogicaGenero
    {
        public void AgregarGenero(Genero genero, GeneroRepo repo)
        {
            repo.AgregarGenero(genero);
        }
    }
}
