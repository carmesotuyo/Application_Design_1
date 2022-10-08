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
        public void AltaGenero(Genero unGenero)
        {
            throw new NotImplementedException();
        }

        public void AltaPelicula(Usuario admin, Pelicula unaPelicula, PeliculaRepo repo)
        {
            if (!admin.EsAdministrador)
            {
                throw new UsuarioNoPermitidoException();
            }
            logicaPelicula.AltaPelicula(unaPelicula, repo);
            
        }

        public void BajaGenero(Genero unGenero)
        {
            throw new NotImplementedException();
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
