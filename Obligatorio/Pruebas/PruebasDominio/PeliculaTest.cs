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
            Pelicula unaPelicula = new Pelicula()
            {
                Nombre = "Harry Potter"
            };
            Assert.AreEqual(unaPelicula.Nombre, "Harry Potter");
        }

        [TestMethod]
        [ExpectedException(typeof(DatoVacioException))]
        public void NombrePeliculaInvalidoTest()
        {
            Pelicula unaPelicula = new Pelicula()
            {
                Nombre = ""
            };

        }

        [TestMethod]
        public void GeneroPrincipalValidoTest()
        {
            Genero unGenero = new Genero();
            Pelicula unaPelicula = new Pelicula()
            {
                GeneroPrincipal = unGenero
            };
            Assert.AreEqual(unaPelicula.GeneroPrincipal, unGenero);
        }

        [TestMethod]
        [ExpectedException(typeof(DatoVacioException))]
        public void GeneroPrincipalInvalidoTest()
        {
            Genero generoVacio = null;
            Pelicula unaPelicula = new Pelicula()
            {
                GeneroPrincipal = generoVacio
            };

        }

        [TestMethod]
        public void GeneroSecundarioValidoTest()
        {
            Genero unGenero = new Genero();
            Pelicula unaPelicula = new Pelicula();

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

        [TestMethod]
        public void DescripcionValidaTest()
        {
            Pelicula unaPelicula = new Pelicula()
            {
                Descripcion = "Descripcion de prueba"
            };

            Assert.AreEqual(unaPelicula.Descripcion, "Descripcion de prueba");
        }

        [TestMethod]
        public void PeliculaAptaParaTodoPublicoTest()
        {
            Pelicula unaPelicula = new Pelicula()
            {
                AptaTodoPublico = true
            };
            Assert.IsTrue(unaPelicula.AptaTodoPublico);
        }

        [TestMethod]
        public void PeliculaNoAptaTest()
        {
            Pelicula unaPelicula = new Pelicula()
            {
                AptaTodoPublico = false
            };

            Assert.IsFalse(unaPelicula.AptaTodoPublico); 
        }

        [TestMethod]
        public void PeliculaPatrocinadaTest()
        {
            Pelicula unaPelicula = new Pelicula()
            {
                EsPatrocinada = true
            };

            Assert.IsTrue(unaPelicula.EsPatrocinada);
        }

        [TestMethod]
        public void PeliculaNoPatrocinadaTest()
        {
            Pelicula unaPelicula = new Pelicula()
            {
                EsPatrocinada = false
            };

            Assert.IsFalse(unaPelicula.EsPatrocinada);
        }

        [TestMethod]
        public void IdentificadorPeliculaTest()
        {
            Pelicula unaPelicula = new Pelicula();

            Assert.AreEqual(unaPelicula.Identificador, Pelicula.ContadorPeliculas);
        }

        [TestMethod]
        public void PosterPeliculaValidoTest()
        {
            Pelicula unaPelicula = new Pelicula()
            {
                Poster = "ruta/archivo.jpg"
            };

            Assert.AreEqual(unaPelicula.Poster, "ruta/archivo.jpg");
        }

        [TestMethod]
        [ExpectedException(typeof(DatoVacioException))]
        public void PosterPeliculaInvalidoTest()
        {
            Pelicula unaPelicula = new Pelicula()
            {
                Poster = ""
            };
        }
    }
}
