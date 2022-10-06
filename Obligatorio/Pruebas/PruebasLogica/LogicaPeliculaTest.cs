using Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio;
using Logica.Implementaciones;

namespace Pruebas.PruebasLogica
{
    [TestClass]
    public class LogicaPeliculaTest
    {
        Pelicula unaPelicula = new Pelicula();
        PeliculaRepo repo = new PeliculaRepo();
        LogicaPelicula logica = new LogicaPelicula();

        [TestMethod]
        public void AltaPeliculaTest()
        {
            logica.AltaPelicula(unaPelicula, repo);

            Assert.IsTrue(repo.EstaPelicula(unaPelicula));
        }
    }
}
