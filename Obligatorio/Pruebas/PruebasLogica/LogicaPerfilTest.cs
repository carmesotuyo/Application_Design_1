using Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logica;
using Logica.Implementaciones;

namespace Pruebas.PruebasLogica
{
    [TestClass]
    public class LogicaPerfilTest
    {
        LogicaPerfil logica = new LogicaPerfil();

        [TestMethod]
        public void PuntuarPeliculaNegativoTest()
        {
            Genero comedia = new Genero() { Nombre = "comedia" };
            Pelicula unaPelicula = new Pelicula() { GeneroPrincipal = comedia };
            Perfil unPerfil = new Perfil();
            GeneroPuntaje generoPuntaje = new GeneroPuntaje() { Genero = comedia.Nombre };
            unPerfil.AgregarGeneroPuntaje(generoPuntaje);

            logica.PuntuarNegativo(unaPelicula, unPerfil);

            Assert.IsTrue(unPerfil.PuntajeGeneros[0].Puntaje == -1);
        }

        [TestMethod]
        public void PuntuarPeliculaPositivoTest()
        {
            Genero comedia = new Genero() { Nombre = "comedia" };
            Pelicula unaPelicula = new Pelicula() { GeneroPrincipal = comedia };
            Perfil unPerfil = new Perfil();
            GeneroPuntaje generoPuntaje = new GeneroPuntaje() { Genero = comedia.Nombre };
            unPerfil.AgregarGeneroPuntaje(generoPuntaje);

            logica.PuntuarPositivo(unaPelicula, unPerfil);

            Assert.IsTrue(unPerfil.PuntajeGeneros[0].Puntaje == 1);
        }

        [TestMethod]
        public void PuntuarPeliculaMuyPositivoTest()
        {
            Genero comedia = new Genero() { Nombre = "comedia" };
            Genero romance = new Genero() { Nombre = "Romance" };
            Pelicula unaPelicula = new Pelicula() { GeneroPrincipal = comedia };
            unaPelicula.AgregarGeneroSecundario(romance);
            Perfil unPerfil = new Perfil();
            GeneroPuntaje generoComedia = new GeneroPuntaje() { Genero = comedia.Nombre };
            GeneroPuntaje generoRomance = new GeneroPuntaje() { Genero = romance.Nombre };
            unPerfil.AgregarGeneroPuntaje(generoComedia);
            unPerfil.AgregarGeneroPuntaje(generoRomance);

            logica.PuntuarMuyPositivo(unaPelicula, unPerfil);

            Assert.IsTrue(unPerfil.PuntajeGeneros[0].Puntaje == 2 && unPerfil.PuntajeGeneros[1].Puntaje == 1);
        }
    }
}
