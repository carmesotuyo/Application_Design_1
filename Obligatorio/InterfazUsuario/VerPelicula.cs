using Dominio;
using InterfazUsuario;
using Logica.Implementaciones;
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
    public partial class VerPelicula : UserControl
    {
        private Threat_Level_Midnight_Entertainment _ventanaPrincipal;
        private Usuario _usuario;
        private Perfil _perfil;
        private Pelicula _pelicula;
        private ILogicaPerfil _logicaPerfil;
        private ILogicaGenero _logicaGenero;

        public VerPelicula(Pelicula pelicula, Usuario usuario, Perfil perfil, ILogicaPerfil logicaPerfil, ILogicaGenero logicaGenero, Threat_Level_Midnight_Entertainment ventanaPrincipal)
        {
            InitializeComponent();
            _pelicula = pelicula;
            _perfil = perfil;
            _usuario = usuario;
            _logicaPerfil = logicaPerfil;
            _logicaGenero = logicaGenero;
            _ventanaPrincipal = ventanaPrincipal;
            ActualizarGenerosPerfiles();
            MostrarPelicula();
        }

        private void ActualizarGenerosPerfiles()
        {
            _logicaPerfil.ActualizarListadoGeneros(_perfil, _logicaGenero);
        }

        private void MostrarPelicula()
        {
            imgPelicula.Image = new Bitmap(_pelicula.Poster); 
            lblNombre.Text = _pelicula.Nombre;
            lblGenero.Text = _pelicula.GeneroPrincipal.ToString();
            if (!_pelicula.AptaTodoPublico)
            {
                lblApta.Text = "No es apta para todo público";
            }
            txtDescripcion.Text = _pelicula.Descripcion;
            if (_logicaPerfil.VioPelicula(_pelicula, _perfil))
            {
                btnVista.Enabled = false;
            }
        }

        private void btnNegativo_Click(object sender, EventArgs e)
        {
            _logicaPerfil.PuntuarNegativo(_pelicula, _perfil);
        }

        private void btnPositivo_Click(object sender, EventArgs e)
        {
            _logicaPerfil.PuntuarPositivo(_pelicula, _perfil);
        }

        private void btnMuyPositivo_Click(object sender, EventArgs e)
        {
            _logicaPerfil.PuntuarMuyPositivo(_pelicula, _perfil);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _logicaPerfil.MarcarComoVista(_pelicula, _perfil);
            btnVista.Enabled = false;
        }
    }
}