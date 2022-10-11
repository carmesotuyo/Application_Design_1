using Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio;
using Logica.Implementaciones;
using Logica.Interfaces;

namespace Pruebas.PruebasLogica
{
    [TestClass]
    public class LogicaPeliculaTest
    {
        Pelicula unaPelicula = new Pelicula();
        LogicaPelicula logica = new LogicaPelicula(new PeliculaRepo());

        [TestMethod]
        public void AltaPeliculaTest()
        {
            logica.AltaPelicula(unaPelicula);

            Assert.IsTrue(logica.Peliculas().Contains(unaPelicula));
        }

        [TestMethod]
        public void BajaPeliculaTest()
        {
            logica.BajaPelicula(unaPelicula);

            Assert.IsFalse(logica.Peliculas().Contains(unaPelicula));
        }


        [TestMethod]
        public void FiltrarPeliculasNoAptasTest()
        {
            Pelicula peliculaApta = new Pelicula() { AptaTodoPublico = true };
            Pelicula peliculaNoApta = new Pelicula() { AptaTodoPublico = false };

            logica.AltaPelicula(peliculaApta);
            logica.AltaPelicula(peliculaNoApta);

            Perfil unPerfil = new Perfil() { EsInfantil = true };

            List<Pelicula> soloAptas = logica.MostrarPeliculas(unPerfil);

            Assert.IsTrue(soloAptas.Count == 1);
        }

        [TestMethod]
        public void NoFiltrarSiNoEsInfantilTest()
        {
            Pelicula peliculaApta = new Pelicula() { AptaTodoPublico = true };
            Pelicula peliculaNoApta = new Pelicula() { AptaTodoPublico = false };

            logica.AltaPelicula(peliculaApta);
            logica.AltaPelicula(peliculaNoApta);

            Perfil unPerfil = new Perfil() { EsInfantil = false };

            List<Pelicula> todas = logica.MostrarPeliculas(unPerfil);

            Assert.AreEqual(todas, logica.Peliculas());
        }
    }
}
