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
    public partial class MenuAdmin : UserControl
    {
        private Usuario _usuario;
        private Perfil _perfil;
        private ILogicaGenero _logicaGenero;
        private ILogicaPelicula _logicaPelicula;
        private ILogicaPersona _logicaPersona;
        public Threat_Level_Midnight_Entertainment _ventanaPrincipal;
        public MenuAdmin(Usuario usuario, Perfil perfil, ILogicaGenero logicaGenero, ILogicaPelicula logicaPelicula, ILogicaPersona logicaPersona, Threat_Level_Midnight_Entertainment ventanaPrincipal)
        {
            InitializeComponent();
            flpAdministrador.Controls.Clear();
            _ventanaPrincipal = ventanaPrincipal;
            _logicaGenero = logicaGenero;
            _logicaPelicula = logicaPelicula;
            _usuario = usuario;
            _perfil = perfil;
            _logicaPersona = logicaPersona;
            flpAdministrador.Controls.Add(new AgregarPelicula(_usuario, _logicaPelicula, _logicaGenero, this));
        }

        public void CambiarAgregarPeli()
        {
            flpAdministrador.Controls.Clear();
            flpAdministrador.Controls.Add(new AgregarPelicula(_usuario, _logicaPelicula, _logicaGenero, this));
        }
        public void CambiarQuitarPeli()
        {
            flpAdministrador.Controls.Clear();
            flpAdministrador.Controls.Add(new QuitarPelicula(_usuario, _logicaPelicula, this));
        }
        public void CambiarOrdenarPelis()
        {
            flpAdministrador.Controls.Clear();
            flpAdministrador.Controls.Add(new OrdenarPeliculas(_usuario, _logicaPelicula, this));
        }
        public void CambiarAgregarGenero()
        {
            flpAdministrador.Controls.Clear();
            flpAdministrador.Controls.Add(new AgregarGenero(_usuario, _logicaGenero, this));
        }
        public void CambiarQuitarGenero()
        {
            flpAdministrador.Controls.Clear();
            flpAdministrador.Controls.Add(new QuitarGenero(_usuario, _logicaGenero, _logicaPelicula, this));
        }
        public void CambiarAgregarPersona()
        {
            flpAdministrador.Controls.Clear();
            flpAdministrador.Controls.Add(new AgregarPersona(_usuario, _logicaPersona, this));
        }
        public void CambiarEditarPersona()
        {
            flpAdministrador.Controls.Clear();
            flpAdministrador.Controls.Add(new EditarPersona(_usuario, _logicaPersona, this));
        }

        private void btnAltaPeli_Click(object sender, EventArgs e)
        {
            CambiarAgregarPeli();
        }

        private void btnSorting_Click(object sender, EventArgs e)
        {
            CambiarOrdenarPelis();
        }

        private void btnAltaGenero_Click(object sender, EventArgs e)
        {
            CambiarAgregarGenero();
        }

        private void btnBajaGenero_Click(object sender, EventArgs e)
        {
            CambiarQuitarGenero();
        }

        private void btnBajaPeli_Click_1(object sender, EventArgs e)
        {
            CambiarQuitarPeli();
        }
        private void btnAgregarPersona_Click(object sender, EventArgs e)
        {
            CambiarAgregarPersona();
        }

        private void lblAtras_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _ventanaPrincipal.CambiarMenuPeliculas(_usuario, _perfil);
        }

        private void lblPerfil_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _ventanaPrincipal.CambiarListaPerfiles(_usuario, _perfil);
        }

        private void btnQuitarPersona_Click(object sender, EventArgs e)
        {
            CambiarEditarPersona();
        }
    }
}
