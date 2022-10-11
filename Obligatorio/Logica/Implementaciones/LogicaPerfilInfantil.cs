using Dominio;
using Logica.Exceptions;
using Logica.Interfaces;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Implementaciones
{
    public class LogicaPerfilInfantil : LogicaPerfil, ILogicaPerfil
    {
        public override Perfil AccederAlPerfil(Perfil unPerfil, int pin)
        {
            if (!unPerfil.EsInfantil)
            {
                throw new PerfilNoInfantilException();
            }
            return unPerfil;
        }

        public override List<Pelicula> MostrarPeliculas(ILogicaPelicula logicaPelicula)
        {
            return FiltrarPeliculasNoAptas(logicaPelicula.Peliculas());
        }

        private List<Pelicula> FiltrarPeliculasNoAptas(List<Pelicula> peliculas)
        {
            return peliculas.Where(x => x.AptaTodoPublico == true).ToList();
        }
    }
}
