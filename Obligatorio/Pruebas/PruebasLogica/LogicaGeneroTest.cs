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
using Logica.Exceptions;

namespace Pruebas.PruebasLogica
{
    [TestClass]
    public class LogicaGeneroTest
    {
        LogicaGenero logica = new LogicaGenero(new GeneroRepo());
        Usuario admin = new Usuario() { EsAdministrador = true };

        [TestMethod]
        public void AgregarGeneroTest()
        {
            Genero unGenero = new Genero() { Nombre = "Suspenso", Descripcion = "Descripcion de suspenso" };

            logica.AgregarGenero(admin, unGenero);

            Assert.IsTrue(logica.Generos().Contains(unGenero));
        }

        [TestMethod]
        [ExpectedException(typeof(UsuarioNoPermitidoException))]
        public void AgregarGeneroSinPermisoTest()
        {
            Usuario comun = new Usuario() { EsAdministrador = false };
            Genero unGenero = new Genero() { Nombre = "Suspenso", Descripcion = "Descripcion de suspenso" };

            logica.AgregarGenero(comun, unGenero);
        }

        [TestMethod]
        public void NombreUnicoTest()
        {
            Genero unGenero = new Genero() { Nombre = "Accion" };
            Genero otroGenero = new Genero() { Nombre = "Comedia" };

            logica.AgregarGenero(admin, unGenero);
            logica.AgregarGenero(admin, otroGenero);

            Assert.IsTrue(logica.Generos().Contains(unGenero) && logica.Generos().Contains(otroGenero));
        }

        [TestMethod]
        [ExpectedException(typeof(GeneroDuplicadoException))]
        public void NombreNoUnicoTest()
        {
            Genero unGenero = new Genero() { Nombre = "Accion" };
            Genero otroGenero = new Genero() { Nombre = "acciON" };

            logica.AgregarGenero(admin, unGenero);
            logica.AgregarGenero(admin, otroGenero);
        }

        [TestMethod]
        public void EliminarGeneroTest()
        {
            ILogicaPelicula logicaPeli = new LogicaPelicula(new PeliculaRepo());
            Genero unGenero = new Genero() { Nombre = "Comedia" };

            logica.AgregarGenero(admin, unGenero);
            logica.EliminarGenero(admin, unGenero, logicaPeli);

            Assert.IsFalse(logica.Generos().Contains(unGenero));
        }

        [TestMethod]
        [ExpectedException(typeof(UsuarioNoPermitidoException))]
        public void EliminarGeneroSinPermisoTest()
        {
            Usuario comun = new Usuario() { EsAdministrador = false };
            ILogicaPelicula logicaPeli = new LogicaPelicula(new PeliculaRepo());
            Genero unGenero = new Genero() { Nombre = "Comedia" };

            logica.AgregarGenero(admin, unGenero);
            logica.EliminarGenero(comun, unGenero, logicaPeli);
        }

        [TestMethod]
        [ExpectedException(typeof(GeneroInexistenteException))]
        public void EliminarGeneroInexistenteTest()
        {
            ILogicaPelicula logicaPeli = new LogicaPelicula(new PeliculaRepo());
            Genero unGenero = new Genero() { Nombre = "Comedia" };

            logica.EliminarGenero(admin, unGenero, logicaPeli);
        }

        [TestMethod]
        [ExpectedException(typeof(NullException))]
        public void EliminarGeneroNullTest()
        {
            ILogicaPelicula logicaPeli = new LogicaPelicula(new PeliculaRepo());
            Genero unGenero = null;

            logica.EliminarGenero(admin, unGenero, logicaPeli);
        }

        [TestMethod]
        [ExpectedException(typeof(GeneroConPeliculaAsociadaException))]
        public void EliminarGeneroConPeliculasAsociadasComoPrincipalTest()
        {
            ILogicaPelicula logicaPeli = new LogicaPelicula(new PeliculaRepo());
            Genero unGenero = new Genero() { Nombre = "Comedia" };

            Pelicula unaPelicula = new Pelicula() { GeneroPrincipal = unGenero };
            logicaPeli.AltaPelicula(unaPelicula, admin);

            logica.AgregarGenero(admin, unGenero);
            logica.EliminarGenero(admin, unGenero, logicaPeli);
        }

        [TestMethod]
        [ExpectedException(typeof(GeneroConPeliculaAsociadaException))]
        public void EliminarGeneroConPeliculasAsociadasComoSecundarioTest()
        {
            ILogicaPelicula logicaPeli = new LogicaPelicula(new PeliculaRepo());
            Genero unGenero = new Genero() { Nombre = "Comedia" };
            Genero otroGenero = new Genero() { Nombre = "Terror" };

            Pelicula unaPelicula = new Pelicula() { GeneroPrincipal = unGenero };
            unaPelicula.AgregarGeneroSecundario(otroGenero);
            logicaPeli.AltaPelicula(unaPelicula, admin);

            logica.AgregarGenero(admin, otroGenero);
            logica.EliminarGenero(admin, otroGenero, logicaPeli);
        }
    }
}
