using Dominio;
using Logica.Implementaciones;
using Logica.Interfaces;
using Repositorio;
using Repositorio.EnDataBase;
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
            _logicaPelicula = new LogicaPelicula(new PeliculaDBRepo());
            _logicaGenero = new LogicaGenero(new GeneroDBRepo());

            InitializeComponent();
            flpPanelPrincipal.Controls.Add(new Login(_logicaUsuario, this));
            CredencialesAdmin();
        }
        private void CredencialesAdmin()
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
        }

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
