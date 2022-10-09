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
    public class LogicaUsuarioTest
    {
        Usuario usuario = new Usuario();
        RepoUsuarios repo = new RepoUsuarios();
        [TestMethod]
        public void RegistrarUsuarioTest()
        {
            repo.AgregarUsuario(usuario);
        }
    }
}
