using Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio;
using Logica.Implementaciones;
using Dominio.Exceptions;
using Repositorio.Interfaces;
using Logica.Interfaces;

namespace Pruebas.PruebasLogica
{
    [TestClass]
    public class LogicaGeneroTest
    {
        Genero unGenero = new Genero();
        Genero otroGenero = new Genero();
        LogicaGenero logica = new LogicaGenero(new GeneroRepo());

        [TestMethod]
        public void AgregarGeneroTest()
        {
            unGenero.Nombre = "Suspenso";
            unGenero.Descripcion = "Descripcion de suspenso";

            logica.AgregarGenero(unGenero);
        }

        [TestMethod]
        public void NombreUnicoTest()
        {
            unGenero.Nombre = "Accion";
            otroGenero.Nombre = "Comedia";

            logica.AgregarGenero(unGenero);
            logica.AgregarGenero(otroGenero);

            Assert.IsTrue(logica.Generos().Contains(unGenero) && logica.Generos().Contains(otroGenero));
        }

        [TestMethod]
        [ExpectedException(typeof(GeneroDuplicadoException))]
        public void NombreNoUnicoTest()
        {
            unGenero.Nombre = "Accion";
            otroGenero.Nombre = "acciON";

            logica.AgregarGenero(unGenero);
            logica.AgregarGenero(otroGenero);
        }

        [TestMethod]
        public void EliminarGeneroTest()
        {
            PeliculaRepo repoPelis = new PeliculaRepo();
            ILogicaPelicula logicaPeli = new LogicaPelicula(repoPelis);
            unGenero.Nombre = "Comedia";

            logica.AgregarGenero(unGenero);
            logica.EliminarGenero(unGenero, logicaPeli);

            Assert.IsFalse(logica.Generos().Contains(unGenero));
        }

        [TestMethod]
        [ExpectedException(typeof(GeneroInexistenteException))]
        public void EliminarGeneroInexistenteTest()
        {
            PeliculaRepo repoPelis = new PeliculaRepo();
            ILogicaPelicula logicaPeli = new LogicaPelicula(repoPelis);

            logica.EliminarGenero(unGenero, logicaPeli);
        }
    }
}
