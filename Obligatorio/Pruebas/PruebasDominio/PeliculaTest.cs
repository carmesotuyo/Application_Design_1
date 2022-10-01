using System;
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
            Pelicula unaPelicula = new Pelicula();

            string nombreVacio = "";

            unaPelicula.Nombre = nombreVacio;

        }

        [TestMethod]
        public void GeneroPrincipalValidoTest()
        {
            Pelicula unaPelicula = new Pelicula();
            Genero unGenero = new Genero();

            unaPelicula.GeneroPrincipal = unGenero;

            Assert.AreEqual(unaPelicula.GeneroPrincipal, unGenero);
        }

        [TestMethod]
        [ExpectedException(typeof(DatoVacioException))]
        public void GeneroPrincipalInvalidoTest()
        {
            Pelicula unaPelicula = new Pelicula();

            Genero generoVacio = null;

            unaPelicula.GeneroPrincipal = generoVacio;

        }

        [TestMethod]
        public void GeneroSecundarioValidoTest()
        {
            Pelicula unaPelicula = new Pelicula();
            Genero unGenero = new Genero();

            unaPelicula.GenerosSecundarios.Add(unGenero);

            Assert.IsTrue(unaPelicula.GenerosSecundarios.Contains(unGenero));
        }

    }
}
