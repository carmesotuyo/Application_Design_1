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
    public class LogicaGeneroTest
    {
        Genero unGenero = new Genero();
        Genero otroGenero = new Genero();
        GeneroRepo repo = new GeneroRepo();
        LogicaGenero logica = new LogicaGenero();

        [TestMethod]
        public void NombreUnicoTest()
        {
            unGenero.Nombre = "Accion";
            otroGenero.Nombre = "Comedia";

            logica.AgregarGenero(unGenero, repo);
            logica.AgregarGenero(otroGenero, repo);

            Assert.IsTrue(repo.EstaGenero(unGenero) && repo.EstaGenero(otroGenero));
        }

    }
}
