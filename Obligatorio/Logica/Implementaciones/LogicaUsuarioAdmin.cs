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
            if (!admin.EsAdministrador)
            {
                throw new UsuarioNoPermitidoException();
            }
            logicaGenero.AgregarGenero(unGenero, repo);
        }

        public void AltaPelicula(Usuario admin, Pelicula unaPelicula, PeliculaRepo repo)
        {
            if (!admin.EsAdministrador)
            {
                throw new UsuarioNoPermitidoException();
            }
            logicaPelicula.AltaPelicula(unaPelicula, repo);
            
        }

        public void BajaGenero(Usuario admin, Genero unGenero, GeneroRepo repo)
        {
            if (!admin.EsAdministrador)
            {
                throw new UsuarioNoPermitidoException();
            }
            logicaGenero.EliminarGenero(unGenero, repo);
        }

        public void BajaPelicula(Usuario admin, Pelicula unaPelicula, PeliculaRepo repo)
        {
            if (!admin.EsAdministrador)
            {
                throw new UsuarioNoPermitidoException();
            }
            logicaPelicula.BajaPelicula(unaPelicula, repo);
        }
    }
}
