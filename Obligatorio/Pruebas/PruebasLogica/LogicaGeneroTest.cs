using Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio;
using Repositorio.EnDataBase;
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
        ILogicaGenero logica = new LogicaGenero(new GeneroDBRepo());
        ILogicaPelicula logicaPeli = new LogicaPelicula(new PeliculaDBRepo(), new PerfilDBRepo());
        Usuario admin = new Usuario() { EsAdministrador = true };
        Usuario comun = new Usuario() { EsAdministrador = false };
        static Genero suspenso = new Genero() { Nombre = "Suspenso", Descripcion = "Descripcion de suspenso" };
        static Genero accion = new Genero() { Nombre = "Accion" };
        static Genero comedia = new Genero() { Nombre = "Comedia" };
        Pelicula unaPelicula = new Pelicula() { 
            Identificador = 1, 
            Nombre = "nombre", 
            GeneroPrincipal = comedia, 
            Descripcion = "algo",
            Poster = "ruta"
        };
        
        [TestInitialize]
        public void Setup()
        {
            DBCleanUp.CleanUp();
        }

        [TestMethod]
        public void AgregarGeneroTest()
        { 
            logica.AgregarGenero(admin, suspenso);

            Assert.IsTrue(logica.Generos().Contains(suspenso));
        }

        [TestMethod]
        [ExpectedException(typeof(UsuarioNoPermitidoException))]
        public void AgregarGeneroSinPermisoTest()
        {
            logica.AgregarGenero(comun, suspenso);
        }

        [TestMethod]
        public void NombreUnicoTest()
        {
            logica.AgregarGenero(admin, accion);
            logica.AgregarGenero(admin, suspenso);

            Assert.IsTrue(logica.Generos().Contains(accion) && logica.Generos().Contains(suspenso));
        }

        [TestMethod]
        [ExpectedException(typeof(GeneroDuplicadoException))]
        public void NombreNoUnicoTest()
        {
            Genero otroGenero = new Genero() { Nombre = "acciON" };

            logica.AgregarGenero(admin, accion);
            logica.AgregarGenero(admin, otroGenero);
        }

        [TestMethod]
        public void EliminarGeneroTest()
        {
            logica.AgregarGenero(admin, comedia);
            logica.EliminarGenero(admin, comedia, logicaPeli);

            Assert.IsFalse(logica.Generos().Contains(comedia));
        }

        [TestMethod]
        [ExpectedException(typeof(UsuarioNoPermitidoException))]
        public void EliminarGeneroSinPermisoTest()
        {
            logica.AgregarGenero(admin, comedia);
            logica.EliminarGenero(comun, comedia, logicaPeli);
        }

        [TestMethod]
        [ExpectedException(typeof(GeneroInexistenteException))]
        public void EliminarGeneroInexistenteTest()
        {
            logica.EliminarGenero(admin, comedia, logicaPeli);
        }

        [TestMethod]
        [ExpectedException(typeof(NullException))]
        public void EliminarGeneroNullTest()
        {
            Genero unGenero = null;

            logica.EliminarGenero(admin, unGenero, logicaPeli);
        }

        [TestMethod]
        [ExpectedException(typeof(GeneroConPeliculaAsociadaException))]
        public void EliminarGeneroConPeliculasAsociadasComoPrincipalTest()
        {
            logica.AgregarGenero(admin, comedia);
            logicaPeli.AltaPelicula(unaPelicula, admin);
            logica.EliminarGenero(admin, comedia, logicaPeli);
        }

        [TestMethod]
        [ExpectedException(typeof(GeneroConPeliculaAsociadaException))]
        public void EliminarGeneroConPeliculasAsociadasComoSecundarioTest()
        {
            logica.AgregarGenero(admin, comedia);
            logica.AgregarGenero(admin, accion); 
            
            unaPelicula.AgregarGeneroSecundario(accion);
            logicaPeli.AltaPelicula(unaPelicula, admin);

            logica.EliminarGenero(admin, accion, logicaPeli);
        }
    }
}
