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
            BuscarSiTienePeliculasAsociadas(unGenero, repoPelis);
            logicaGenero.EliminarGenero(unGenero, repo);
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

        private static void BuscarSiTienePeliculasAsociadas(Genero unGenero, PeliculaRepo repoPelis)
        {
            foreach(Pelicula pelicula in repoPelis.peliculas)
            {
                bool EsGeneroPrincipal = pelicula.GeneroPrincipal.Equals(unGenero);
                bool EsGeneroSecundario = pelicula.GenerosSecundarios.Contains(unGenero);
                if (EsGeneroPrincipal || EsGeneroSecundario)
                {
                    throw new GeneroConPeliculaAsociadaException();
                }
            }
        }
    }
}
