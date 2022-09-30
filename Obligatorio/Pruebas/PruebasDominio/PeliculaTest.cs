﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dominio;
using Dominio.Exceptions;

namespace Pruebas.PruebasDominio
{
    [TestClass]
    public class PeliculaTest
    {
        [TestMethod]
        public void NombrePeliculaValidoTest()
        {
            //arrange
            Pelicula unaPelicula = new Pelicula();

            //act
            unaPelicula.Nombre = "Harry Potter";

            //assert
            Assert.AreEqual(unaPelicula.Nombre, "Harry Potter");
        }

        [TestMethod]
        [ExpectedException(typeof(DatoVacioException))]
        public void NombrePeliculaInvalidoTest()
        {
            //arrange
            Pelicula unaPelicula = new Pelicula();

            //act
            string nombreVacio = "";
            unaPelicula.Nombre = nombreVacio;

            //assert
            //Assert.ThrowsException<DatoVacioException>(() => unaPelicula.Nombre = nombreVacio);
        }

    }
}
