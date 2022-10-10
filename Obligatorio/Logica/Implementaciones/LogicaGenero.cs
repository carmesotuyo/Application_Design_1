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
using Repositorio.Interfaces;

namespace Logica.Implementaciones
{
    public class LogicaGenero : ILogicaGenero
    {
        private IGeneroRepo _repo;
        public LogicaGenero(IGeneroRepo generoRepo)
        {
            _repo = generoRepo;
        }
        
        public void AgregarGenero(Genero genero)
        {
            EvaluarSiEsDuplicado(genero);
            _repo.AgregarGenero(genero);
        }


        private void EvaluarSiEsDuplicado(Genero genero)
        {
            if (_repo.EstaGenero(genero))
            {
                throw new GeneroDuplicadoException();
            }
        }

        public void EliminarGenero(Genero genero, ILogicaPelicula logicaPelicula)
        {
            EvaluarSiNoExiste(genero);
            BuscarSiTienePeliculasAsociadas(genero, logicaPelicula);
            _repo.EliminarGenero(genero);
        }

        private void EvaluarSiNoExiste(Genero genero)
        {
            if (!_repo.EstaGenero(genero))
            {
                throw new GeneroInexistenteException();
            }
        }

        private void BuscarSiTienePeliculasAsociadas(Genero genero, ILogicaPelicula logicaPelicula)
        {
            List<Pelicula> EsGeneroPrincipal = logicaPelicula.Peliculas().Where(p => p.GeneroPrincipal.Equals(genero)).ToList();
            List<Pelicula> EsGeneroSecundario = logicaPelicula.Peliculas().Where(p => p.GenerosSecundarios.Contains(genero)).ToList();
            if (EsGeneroPrincipal.Count() > 0 || EsGeneroSecundario.Count() > 0)
            {
                throw new GeneroConPeliculaAsociadaException();
            }
        }

        public List<Genero> Generos()
        {
            return _repo.Generos();
        }
    }
}
