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
using Logica.Exceptions;

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

        public void EliminarGenero(Genero genero, GeneroRepo repo, PeliculaRepo repoPelis)
        {
            EvaluarSiNoExiste(genero, repo);
            BuscarSiTienePeliculasAsociadas(genero, repoPelis);
            repo.EliminarGenero(genero);
        }

        private static void EvaluarSiNoExiste(Genero genero, GeneroRepo repo)
        {
            if (!repo.EstaGenero(genero))
            {
                throw new GeneroInexistenteException();
            }
        }

        private static void BuscarSiTienePeliculasAsociadas(Genero genero, PeliculaRepo repoPelis)
        {
            List<Pelicula> EsGeneroPrincipal = repoPelis.peliculas.Where(p => p.GeneroPrincipal.Equals(genero)).ToList();
            List<Pelicula> EsGeneroSecundario = repoPelis.peliculas.Where(p => p.GenerosSecundarios.Contains(genero)).ToList();
            if (EsGeneroPrincipal.Count() > 0 || EsGeneroSecundario.Count() > 0)
            {
                throw new GeneroConPeliculaAsociadaException();
            }
        }
    }
}
