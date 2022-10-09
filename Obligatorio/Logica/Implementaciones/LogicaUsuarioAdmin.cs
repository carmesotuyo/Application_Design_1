using Dominio;
using Logica.Interfaces;
using Logica.Exceptions;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Implementaciones
{
    public class LogicaUsuarioAdmin : ILogicaUsuarioAdmin
    {
        LogicaPelicula logicaPelicula = new LogicaPelicula();
        LogicaGenero logicaGenero = new LogicaGenero();

        public void AltaGenero(Usuario admin, Genero unGenero, GeneroRepo repo)
        {
            BloquearUsuarioNoAdmin(admin);
            logicaGenero.AgregarGenero(unGenero, repo);
        }

        public void AltaPelicula(Usuario admin, Pelicula unaPelicula, PeliculaRepo repo)
        {
            BloquearUsuarioNoAdmin(admin);
            logicaPelicula.AltaPelicula(unaPelicula, repo);
            
        }

        public void BajaGenero(Usuario admin, Genero unGenero, GeneroRepo repo, PeliculaRepo repoPelis)
        {
            BloquearUsuarioNoAdmin(admin);
            logicaGenero.EliminarGenero(unGenero, repo, repoPelis);
        }

        public void BajaPelicula(Usuario admin, Pelicula unaPelicula, PeliculaRepo repo)
        {
            BloquearUsuarioNoAdmin(admin);
            logicaPelicula.BajaPelicula(unaPelicula, repo);
        }

        private static void BloquearUsuarioNoAdmin(Usuario admin)
        {
            if (!admin.EsAdministrador)
            {
                throw new UsuarioNoPermitidoException();
            }
        }

        public List<Pelicula> OrdenarPorGenero(Usuario admin, PeliculaRepo repo)
        {
            return repo.peliculas.OrderBy(p => p.GeneroPrincipal.Nombre).ThenBy(p => p.Nombre).ToList();
        }

        public List<Pelicula> OrdenarPorPatrocinio(Usuario admin, PeliculaRepo repo)
        {
            return repo.peliculas.OrderBy(p => p.EsPatrocinada = true)
                                 .ThenBy(p => p.GeneroPrincipal.Nombre)
                                 .ThenBy(p => p.Nombre).ToList();
        }
    }
}
