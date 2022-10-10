﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Repositorio;

namespace Logica.Interfaces
{
    public interface ILogicaPelicula
    {
        void AltaPelicula(Pelicula pelicula);
        void BajaPelicula(Pelicula pelicula);
        void VerInformacionDePelicula(Pelicula pelicula);
        List<Pelicula> Peliculas();
    }
}
