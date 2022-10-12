using Dominio;
using Logica.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfazUsuario
{
    public partial class MenuPeliculas : UserControl
    {
        private Threat_Level_Midnight_Entertainment _ventanaPrincipal;
        private Usuario _usuario;
        private Perfil _perfil;
        private ILogicaPelicula _logicaPelicula;
        public MenuPeliculas(Threat_Level_Midnight_Entertainment ventanaPrincipal, Usuario usuario, Perfil perfil, ILogicaPelicula logicaPelicula)
        {
            _ventanaPrincipal = ventanaPrincipal;
            _usuario = usuario;
            _perfil = perfil;
            _logicaPelicula = logicaPelicula;
            
            InitializeComponent();
            botonAdmin(_usuario, _perfil);
        }

        void botonAdmin(Usuario usuario, Perfil perfil)
        {
            if (!usuario.EsAdministrador || !perfil.EsOwner)
            {
                btnAdmin.Visible = false;
            }
        }

        private void lblPerfil_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _ventanaPrincipal.CambiarListaPerfiles(_usuario, _perfil);
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            _ventanaPrincipal.CambiarLogin();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            _ventanaPrincipal.CambiarMenuAdmin(_usuario, _perfil);
        }
    }
}
