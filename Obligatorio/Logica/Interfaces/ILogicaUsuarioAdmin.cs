﻿using Dominio;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Interfaces
{
    public interface ILogicaUsuarioAdmin
    {
        void AltaPelicula(Usuario admin, Pelicula unaPelicula, PeliculaRepo repo);
        void BajaPelicula(Usuario admin, Pelicula unaPelicula, PeliculaRepo repo);
        void AltaGenero(Genero unGenero);
        void BajaGenero(Genero unGenero);
        //void SeleccionarCriterioSorting(Criterio unCriterio);

    }
}
