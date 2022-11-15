using Dominio;
using Logica.Implementaciones;
using Logica.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositorio.EnDataBase;
using Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pruebas.PruebasLogica
{
    [TestClass]
    public class LogicaPersonaTest
    {
        ILogicaPersona logicaPersona = new LogicaPersona(new PersonaDBRepo());
        Persona persona = new Persona() { Id = 1, Nombre = "Juan" };
        Usuario admin = new Usuario() { EsAdministrador = true };

        [TestInitialize]
        public void Setup()
        {
            DBCleanUp.CleanUp();
        }

        [TestMethod]
        public void AgregarPersonaTest()
        {
            logicaPersona.AltaPersona(persona, admin);
            Assert.IsTrue(logicaPersona.Personas().Contains(persona));
        }
    }
}
