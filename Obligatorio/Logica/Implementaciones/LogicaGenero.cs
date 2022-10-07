using Dominio;
using Logica.Interfaces;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Exceptions;
using System.Linq.Expressions;

namespace Logica.Implementaciones
{
    public class LogicaGenero : ILogicaGenero
    {
        public void AgregarGenero(Genero genero, GeneroRepo repo)
        {
            EvaluarSiEsDuplicado(genero, repo);
            repo.AgregarGenero(genero);
        }


        private static void EvaluarSiEsDuplicado(Genero genero, GeneroRepo repo)
        {
            if (repo.EstaGenero(genero))
            {
                throw new GeneroDuplicadoException();
            }
        }

        public void EliminarGenero(Genero genero, GeneroRepo repo)
        {
            EvaluarSiNoExiste(genero, repo);
            repo.EliminarGenero(genero);
        }

        private static void EvaluarSiNoExiste(Genero genero, GeneroRepo repo)
        {
            if (!repo.EstaGenero(genero))
            {
                throw new GeneroInexistenteException();
            }
        }
    }
}
