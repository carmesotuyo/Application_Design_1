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
        private ILogicaPelicula _logicaPelicula;
        private ILogicaGenero _logicaGenero;
        private Threat_Level_Midnight_Entertainment _ventanaPrincipal;
        public MenuAdmin(Usuario usuario, Perfil perfil, ILogicaPelicula logicaPelicula, ILogicaGenero logicaGenero, Threat_Level_Midnight_Entertainment ventanaPrincipal)
        {
            InitializeComponent();
            flpAdministrador.Controls.Clear();
            flpAdministrador.Controls.Add(new AgregarPelicula(_usuario, _logicaPelicula, _logicaGenero, this));
            _ventanaPrincipal = ventanaPrincipal;
            _usuario = usuario;
            _perfil = perfil;
        }

        public void CambiarAgregarPeli()
        {
            flpAdministrador.Controls.Clear();
            flpAdministrador.Controls.Add(new AgregarPelicula(_usuario, _logicaPelicula, _logicaGenero, this));
        }
        public void CambiarQuitarPeli()
        {
            flpAdministrador.Controls.Clear();
            flpAdministrador.Controls.Add(new QuitarPelicula(this));
        }
        public void CambiarOrdenarPelis()
        {
            flpAdministrador.Controls.Clear();
            flpAdministrador.Controls.Add(new OrdenarPeliculas(this));
        }
        public void CambiarAgregarGenero()
        {
            flpAdministrador.Controls.Clear();
            flpAdministrador.Controls.Add(new AgregarGenero(this));
        }
        public void CambiarQuitarGenero()
        {
            flpAdministrador.Controls.Clear();
            flpAdministrador.Controls.Add(new QuitarGenero(this));
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

        private void lblAtras_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _ventanaPrincipal.CambiarMenuPeliculas(_usuario, _perfil);
        }

        private void lblPerfil_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _ventanaPrincipal.CambiarListaPerfiles(_usuario, _perfil);
        }
    }
}
