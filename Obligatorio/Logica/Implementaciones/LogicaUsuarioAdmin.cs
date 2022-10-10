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
        //===================================================================
        // Las logicas se instancian una sola vez en program, una vez que se instancia la logica usuarioadmin no se actualizan las otras logicas que tienen los repos
        // Las opciones para los metodos de admin se pueden administrar desde la UI que se vean o no
        //
        //La solución tal vez seria pasar por parametro la logica pelis o genero en cada metodo
        //===================================================================
        private LogicaPelicula _logicaPelicula;
        private LogicaGenero _logicaGenero;

        public LogicaUsuarioAdmin(LogicaPelicula logicaPelicula, LogicaGenero logicaGenero)
        {
            _logicaPelicula = logicaPelicula;
            _logicaGenero = logicaGenero;
        }

        public void AltaGenero(Usuario admin, Genero unGenero)
        {
            BloquearUsuarioNoAdmin(admin);
            _logicaGenero.AgregarGenero(unGenero);
        }

        public void AltaPelicula(Usuario admin, Pelicula unaPelicula)
        {
            BloquearUsuarioNoAdmin(admin);
            _logicaPelicula.AltaPelicula(unaPelicula);
            
        }

        public void BajaGenero(Usuario admin, Genero unGenero)
        {
            BloquearUsuarioNoAdmin(admin);
            _logicaGenero.EliminarGenero(unGenero, _logicaPelicula);
        }

        public void BajaPelicula(Usuario admin, Pelicula unaPelicula)
        {
            BloquearUsuarioNoAdmin(admin);
            _logicaPelicula.BajaPelicula(unaPelicula);
        }

        private static void BloquearUsuarioNoAdmin(Usuario admin)
        {
            if (!admin.EsAdministrador)
            {
                throw new UsuarioNoPermitidoException();
            }
        }

        //Se pretende cambiar el orden de la lista general?
        //pasar por parametro a la logica de pelis, tal; vez que logica de pelis tenga un atributo que sea pelis para mostrar
        public List<Pelicula> OrdenarPorGenero(Usuario admin)
        {
            BloquearUsuarioNoAdmin(admin);
            return _logicaPelicula.Peliculas().OrderBy(p => p.GeneroPrincipal.Nombre).ThenBy(p => p.Nombre).ToList();
        }

        
        public List<Pelicula> OrdenarPorPatrocinio(Usuario admin)
        {
            BloquearUsuarioNoAdmin(admin);
            return _logicaPelicula.Peliculas().OrderBy(p => p.EsPatrocinada = true)
                                 .ThenBy(p => p.GeneroPrincipal.Nombre)
                                 .ThenBy(p => p.Nombre).ToList();
        }
    }
}
