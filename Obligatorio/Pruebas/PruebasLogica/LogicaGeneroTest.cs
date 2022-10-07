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

namespace Pruebas.PruebasLogica
{
    [TestClass]
    public class LogicaGeneroTest
    {
        Genero unGenero = new Genero();
        Genero otroGenero = new Genero();
        GeneroRepo repo = new GeneroRepo();
        LogicaGenero logica = new LogicaGenero();

        [TestMethod]
        public void AgregarGeneroTest()
        {
            unGenero.Nombre = "Suspenso";
            unGenero.Descripcion = "Descripcion de suspenso";

            logica.AgregarGenero(unGenero, repo);
        }

        [TestMethod]
        [ExpectedException(typeof(GeneroIncompletoException))]
        public void AgregarGeneroSinDatosTest()
        {
            logica.AgregarGenero(unGenero, repo);
        }

        [TestMethod]
        public void NombreUnicoTest()
        {
            unGenero.Nombre = "Accion";
            otroGenero.Nombre = "Comedia";

            logica.AgregarGenero(unGenero, repo);
            logica.AgregarGenero(otroGenero, repo);

            Assert.IsTrue(repo.EstaGenero(unGenero) && repo.EstaGenero(otroGenero));
        }

        [TestMethod]
        [ExpectedException(typeof(GeneroDuplicadoException))]
        public void NombreNoUnicoTest()
        {
            unGenero.Nombre = "Accion";
            otroGenero.Nombre = "acciON";

            logica.AgregarGenero(unGenero, repo);
            logica.AgregarGenero(otroGenero, repo);
        }

        [TestMethod]
        public void EliminarGeneroTest()
        {
            unGenero.Nombre = "Comedia";

            logica.AgregarGenero(unGenero, repo);
            logica.EliminarGenero(unGenero, repo);

            Assert.IsFalse(repo.EstaGenero(unGenero));
        }

        [TestMethod]
        [ExpectedException(typeof(GeneroInexistenteException))]
        public void EliminarGeneroInexistenteTest()
        {
            logica.EliminarGenero(unGenero, repo);
        }
    }
}
