using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dominio;
using Dominio.Exceptions;
using Repositorio.EnDataBase;
using System.Diagnostics.Contracts;

namespace Pruebas.PruebasDominio
{

    [TestClass]
    public class PeliculaTest
    {
        Pelicula unaPelicula = new Pelicula();
        Genero unGenero = new Genero() { Nombre = "comedia" };
        Genero generoVacio = null;

        [TestMethod]
        public void NombrePeliculaValidoTest()
        {
            unaPelicula.Nombre = "Harry Potter";

            Assert.AreEqual(unaPelicula.Nombre, "Harry Potter");
        }

        [TestMethod]
        [ExpectedException(typeof(DatoVacioException))]
        public void NombrePeliculaInvalidoTest()
        {
            unaPelicula.Nombre = "";
        }

        [TestMethod]
        public void GeneroPrincipalValidoTest()
        {
            unaPelicula.GeneroPrincipal = unGenero;

            Assert.AreEqual(unaPelicula.GeneroPrincipal, unGenero);
        }

        [TestMethod]
        [ExpectedException(typeof(DatoVacioException))]
        public void GeneroPrincipalInvalidoTest()
        {
            unaPelicula.GeneroPrincipal = generoVacio;
        }

        [TestMethod]
        public void GeneroPrincipalNoIncluidoEnSecundariosTest()
        {
            Genero generoSecundario = new Genero() { Nombre = "suspenso" };
            unaPelicula.AgregarGeneroSecundario(generoSecundario);

            unaPelicula.GeneroPrincipal = unGenero;
            Assert.IsFalse(unaPelicula.GenerosSecundarios.Contains(unGenero));
        }

        [TestMethod]
        [ExpectedException(typeof(GeneroInvalidoException))]
        public void GeneroPrincipalIncluidoEnSecundariosTest()
        {
            unaPelicula.AgregarGeneroSecundario(unGenero);

            unaPelicula.GeneroPrincipal = unGenero;
        }

        [TestMethod]
        public void GeneroSecundarioValidoTest()
        {
            unaPelicula.AgregarGeneroSecundario(unGenero);

            Assert.IsTrue(unaPelicula.GenerosSecundarios.Contains(unGenero));
        }

        [TestMethod]
        [ExpectedException(typeof(DatoVacioException))]
        public void GeneroSecundarioInvalidoTest()
        {
            unaPelicula.AgregarGeneroSecundario(generoVacio);

            Assert.IsFalse(unaPelicula.GenerosSecundarios.Contains(generoVacio));
        }

        [TestMethod]
        public void GeneroSecundarioNoIncluyeGeneroPrincipalTest()
        {
            Genero generoPrincipal = new Genero() { Nombre = "accion" };
            unaPelicula.GeneroPrincipal = generoPrincipal;

            unaPelicula.AgregarGeneroSecundario(unGenero);
            Assert.IsFalse(unaPelicula.GenerosSecundarios.Contains(unaPelicula.GeneroPrincipal));
        }

        [TestMethod]
        [ExpectedException(typeof(GeneroInvalidoException))]
        public void GeneroSecundarioIncluyeGeneroPrincipalTest()
        {
            unaPelicula.GeneroPrincipal = unGenero;

            unaPelicula.AgregarGeneroSecundario(unGenero);
        }

        [TestMethod]
        public void AgregarVariosGenerosTest()
        {
            Genero otroGenero = new Genero() { Nombre = "terror" };
            List<Genero> generos = new List<Genero>();

            generos.Add(unGenero);
            generos.Add(otroGenero);
            unaPelicula.GenerosSecundarios = generos;

            Assert.IsTrue(unaPelicula.GenerosSecundarios.Contains(unGenero)
                && unaPelicula.GenerosSecundarios.Contains(otroGenero));
        }

        [TestMethod]
        public void PeliculaSinGenerosSecundariosValidaTest()
        {
            bool noTieneGenerosSecundarios = unaPelicula.GenerosSecundarios.Count == 0;
            Assert.IsTrue(noTieneGenerosSecundarios);
        }

        [TestMethod]
        public void DescripcionValidaTest()
        {
            unaPelicula.Descripcion = "Descripcion de prueba";

            Assert.AreEqual(unaPelicula.Descripcion, "Descripcion de prueba");
        }

        [TestMethod]
        public void PeliculaAptaParaTodoPublicoTest()
        {
            unaPelicula.AptaTodoPublico = true;

            Assert.IsTrue(unaPelicula.AptaTodoPublico);
        }

        [TestMethod]
        public void PeliculaNoAptaTest()
        {
            unaPelicula.AptaTodoPublico = false;

            Assert.IsFalse(unaPelicula.AptaTodoPublico); 
        }

        [TestMethod]
        public void PeliculaPatrocinadaTest()
        {
            unaPelicula.EsPatrocinada = true;

            Assert.IsTrue(unaPelicula.EsPatrocinada);
        }

        [TestMethod]
        public void PeliculaNoPatrocinadaTest()
        {
            unaPelicula.EsPatrocinada = false;

            Assert.IsFalse(unaPelicula.EsPatrocinada);
        }

        [TestMethod]
        public void IdentificadorPeliculaTest()
        {
            Assert.AreEqual(unaPelicula.Identificador, Pelicula.ContadorPeliculas);
        }

        [TestMethod]
        public void IdentificadorVariasPeliculasTest()
        {
            Pelicula otraPelicula = new Pelicula();

            Assert.AreNotEqual(unaPelicula.Identificador, otraPelicula.Identificador);
        }

        [TestMethod]
        public void PosterPeliculaValidoTest()
        {
            unaPelicula.Poster = "ruta/archivo.jpg";

            Assert.AreEqual(unaPelicula.Poster, "ruta/archivo.jpg");
        }

        [TestMethod]
        [ExpectedException(typeof(DatoVacioException))]
        public void PosterPeliculaInvalidoTest()
        {
            unaPelicula.Poster = "";
        }

        [TestMethod]
        [ExpectedException(typeof(NullException))]
        public void PosterPeliculaNullTest()
        {
            unaPelicula.Poster = null;
        }

        [TestMethod]
        public void DevolverNombreTest()
        {
            unaPelicula.Nombre = "Harry Potter";

            Assert.AreEqual(unaPelicula.ToString(), "Harry Potter");
        }

        [TestMethod]
        public void AgregarPapelTest()
        {
            Papel papel = new Papel();
            unaPelicula.Papeles.Add(papel);
            Assert.IsTrue(unaPelicula.Papeles.Contains(papel));
        }

        [TestMethod]
        public void QuitarPapelTest()
        {
            Papel papel = new Papel();
            unaPelicula.Papeles.Add(papel);

            unaPelicula.Papeles.Remove(papel);
            Assert.IsFalse(unaPelicula.Papeles.Contains(papel));
        }

        [TestMethod]
        public void AgregarDirectorTest()
        {
            Persona director = new Persona();
            unaPelicula.Directores.Add(director);
            Assert.IsTrue(unaPelicula.Directores.Contains(director));
        }

        [TestMethod]
        public void QuitarDirectorTest()
        {
            Persona director = new Persona();
            unaPelicula.Directores.Add(director);

            unaPelicula.Directores.Remove(director);
            Assert.IsFalse(unaPelicula.Directores.Contains(director));
        }
    }
}
