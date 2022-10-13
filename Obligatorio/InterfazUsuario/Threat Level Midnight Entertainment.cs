using Dominio;
using Logica.Implementaciones;
using Logica.Interfaces;
using Repositorio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace InterfazUsuario
{
    public partial class Threat_Level_Midnight_Entertainment : Form
    {
        private ILogicaUsuario _logicaUsuario;
        private ILogicaPelicula _logicaPelicula;
        private ILogicaGenero _logicaGenero;
        private ILogicaPerfil _logicaPerfil;

        public Threat_Level_Midnight_Entertainment()
        {
            _logicaUsuario = new LogicaUsuario(new RepoUsuarios());
            _logicaPerfil = new LogicaPerfil();
            _logicaPelicula = new LogicaPelicula(new PeliculaRepo());
            _logicaGenero = new LogicaGenero(new GeneroRepo());

            InitializeComponent();
            //flpPanelPrincipal.Controls.Add(new Login(_logicaUsuario, this));
            //CredencialesAdmin();

            //==============================

            Usuario admin = CredencialesAdmin();
            Perfil perfilAdmin = Perfiladmin(admin);
            //Pelicula pelicula = AgregarPelicula(admin);
            AgregarPelicula1(admin);
            AgregarPelicula2(admin);
            AgregarPelicula3(admin);
            AgregarPelicula4(admin);
            AgregarPelicula5(admin);
            flpPanelPrincipal.Controls.Add(new MenuAdmin(admin, perfilAdmin, _logicaGenero, _logicaPelicula, this));
            //flpPanelPrincipal.Controls.Add(new VerPelicula(pelicula, admin, perfilAdmin, _logicaPerfil, _logicaGenero, this));
            //==============================

        }

        //====================Pelicula Prueba=================


        //====================================================

        //Cambiar para que sea void!!
        private Usuario CredencialesAdmin()
        {
            Usuario admin = new Usuario()
            {
                Nombre = "administrador",
                Email = "admin@admin.com",
                Clave = "admin12345",
                ConfirmarClave = "admin12345",
                EsAdministrador = true
            };
            _logicaUsuario.RegistrarUsuario(admin);
            return admin;
        }
        //===========================================================================
        //Borrar este metodo despues de terminar Lista Perfiles
        private Perfil Perfiladmin(Usuario usuario)
        {
            Perfil perfil = new Perfil()
            {
                Alias = "admin",
                Pin = 12345,
                ConfirmarPin = 12345,
                EsOwner = true
            };
            _logicaUsuario.AgregarPerfil(usuario, perfil);
            return perfil;
        }
        //======================================================================

        private void AgregarPelicula1(Usuario usuario)
        {
            Genero genero = new Genero()
            {
                Nombre = "Infantil",
            };
            _logicaGenero.AgregarGenero(usuario, genero);
            Pelicula pelicula = new Pelicula()
            {
                Nombre = "Madagascar",
                GeneroPrincipal = genero,
                Descripcion = "Esta es una descripción",
                AptaTodoPublico = false,
                Poster = "C:\\Users\\fe-fe\\Desktop\\Madagascar.jpg",
            };
            _logicaPelicula.AltaPelicula(pelicula, usuario);
        }

        private void AgregarPelicula2(Usuario usuario)
        {
            Genero genero = new Genero()
            {
                Nombre = "Fantasia",
            };
            _logicaGenero.AgregarGenero(usuario, genero);
            Pelicula pelicula = new Pelicula()
            {
                Nombre = "Harry Potter",
                GeneroPrincipal = genero,
                Descripcion = "Esta es una descripción",
                AptaTodoPublico = true,
                Poster = "C:\\Users\\fe-fe\\Desktop\\HarryPoter.jpeg",
            };
            _logicaPelicula.AltaPelicula(pelicula, usuario);
        }

        private void AgregarPelicula3(Usuario usuario)
        {
            Genero genero = new Genero()
            {
                Nombre = "Aventura",
            };
            _logicaGenero.AgregarGenero(usuario, genero);
            Pelicula pelicula = new Pelicula()
            {
                Nombre = "Jumanji",
                GeneroPrincipal = genero,
                Descripcion = "Esta es una descripción",
                AptaTodoPublico = true,
                Poster = "C:\\Users\\fe-fe\\Desktop\\jumanji.jpg",
            };
            _logicaPelicula.AltaPelicula(pelicula, usuario);
        }

        private void AgregarPelicula4(Usuario usuario)
        {
            Genero genero = new Genero()
            {
                Nombre = "Ciencia Ficción",
            };
            _logicaGenero.AgregarGenero(usuario, genero);
            Pelicula pelicula = new Pelicula()
            {
                Nombre = "Los Vengadores",
                GeneroPrincipal = genero,
                Descripcion = "Esta es una descripción",
                AptaTodoPublico = false,
                Poster = "C:\\Users\\fe-fe\\Desktop\\Vengadores.jpg",
            };
            _logicaPelicula.AltaPelicula(pelicula, usuario);
        }

        private void AgregarPelicula5(Usuario usuario)
        {
            Genero genero = new Genero()
            {
                Nombre = "Acción",
            };
            _logicaGenero.AgregarGenero(usuario, genero);
            Pelicula pelicula = new Pelicula()
            {
                Nombre = "Mi Villano Favorito",
                GeneroPrincipal = genero,
                Descripcion = "Esta es una descripción",
                AptaTodoPublico = false,
                Poster = "C:\\Users\\fe-fe\\Desktop\\Minions.jpg",
            };
            _logicaPelicula.AltaPelicula(pelicula, usuario);
        }

        //======================================================================

        public void CambiarRegistroUsuario()
        {
            flpPanelPrincipal.Controls.Clear();
            flpPanelPrincipal.Controls.Add(new Registro(_logicaUsuario, this));
        }
        public void CambiarLogin()
        {
            flpPanelPrincipal.Controls.Clear();
            flpPanelPrincipal.Controls.Add(new Login(_logicaUsuario, this));
        }
        public void CambiarRegistroPerfil(Usuario usuario)
        {
            flpPanelPrincipal.Controls.Clear();
            flpPanelPrincipal.Controls.Add(new CrearPerfil(usuario, _logicaUsuario, this));
        }
        public void CambiarListaPerfiles(Usuario usuario, Perfil perfil)
        {
            flpPanelPrincipal.Controls.Clear();
            flpPanelPrincipal.Controls.Add(new ListaPerfiles(perfil, usuario, _logicaUsuario, this));
        }
        public void CambiarMenuPeliculas(Usuario usuario, Perfil perfil)
        {
            flpPanelPrincipal.Controls.Clear();
            flpPanelPrincipal.Controls.Add(new MenuPeliculas(this, usuario, perfil, _logicaGenero, _logicaPerfil, _logicaPelicula));
        }
        public void CambiarMenuAdmin(Usuario usuario, Perfil perfil)
        {
            flpPanelPrincipal.Controls.Clear();
            flpPanelPrincipal.Controls.Add(new MenuAdmin(usuario, perfil, _logicaGenero, _logicaPelicula, this));
        }
        public void CambiarVerPelicula(Pelicula pelicula,Perfil perfil, ILogicaPerfil logicaPerfil, ILogicaGenero logicaGenero, Usuario usuario)
        {
            flpPanelPrincipal.Controls.Clear();
            flpPanelPrincipal.Controls.Add(new VerPelicula(pelicula, usuario, perfil, logicaPerfil, logicaGenero, this));
        }

        public void CambiarPedirPin(Usuario usuario, Perfil perfil, Perfil perfil1Anterior)
        {
            flpPanelPrincipal.Controls.Clear();
            flpPanelPrincipal.Controls.Add(new PedirPinDeSeguridad(perfil, perfil1Anterior, usuario, _logicaPerfil, this));
        }
        public void CambiarSeleccionarPerfil(Usuario usuario)
        {
            flpPanelPrincipal.Controls.Clear();
            flpPanelPrincipal.Controls.Add(new SeleccionarPerfil(usuario, _logicaUsuario, this));
        }
    }
}
