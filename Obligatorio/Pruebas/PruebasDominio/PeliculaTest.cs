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

        [TestMethod]
        [ExpectedException(typeof(DatoVacioException))]
        public void GeneroSecundarioInvalidoTest()
        {
            Pelicula unaPelicula = new Pelicula();
            Genero unGenero = null;

            unaPelicula.agregarGeneroSecundario(unGenero);

            Assert.IsFalse(unaPelicula.GenerosSecundarios.Contains(unGenero));
        }

        [TestMethod]
        public void AgregarVariosGenerosTest()
        {
            Pelicula unaPelicula = new Pelicula();
            Genero unGenero = new Genero();
            Genero otroGenero = new Genero();

            List<Genero> generos = new List<Genero>();
            generos.Add(unGenero);
            generos.Add(otroGenero);
            unaPelicula.GenerosSecundarios = generos;

            //unaPelicula.agregarGeneroSecundario(unGenero);
            //unaPelicula.agregarGeneroSecundario(otroGenero);

            Assert.IsTrue(unaPelicula.GenerosSecundarios.Contains(unGenero)
                && unaPelicula.GenerosSecundarios.Contains(otroGenero));
        }

        [TestMethod]
        public void PeliculaSinGenerosSecundariosValidaTest()
        {
            Pelicula unaPelicula = new Pelicula();
            bool noTieneGenerosSecundarios = unaPelicula.GenerosSecundarios.Count == 0;
            Assert.IsTrue(noTieneGenerosSecundarios);
        }
    }
}
