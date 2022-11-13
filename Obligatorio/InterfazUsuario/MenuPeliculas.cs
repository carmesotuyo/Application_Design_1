using Dominio;
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
    public partial class MenuPeliculas : UserControl
    {
        private Threat_Level_Midnight_Entertainment _ventanaPrincipal;
        private Usuario _usuario;
        private Perfil _perfil;
        private ILogicaPelicula _logicaPelicula;
        private ILogicaPerfil _logicaPerfil;
        private ILogicaGenero _logicaGenero;
        public MenuPeliculas(Threat_Level_Midnight_Entertainment ventanaPrincipal, Usuario usuario, Perfil perfil, ILogicaGenero logicaGenero, ILogicaPerfil logicaPerfil, ILogicaPelicula logicaPelicula)
        {
            _ventanaPrincipal = ventanaPrincipal;
            _usuario = usuario;
            _perfil = perfil;
            _logicaPelicula = logicaPelicula;
            _logicaPerfil = logicaPerfil;
            _logicaGenero = logicaGenero;
            
            InitializeComponent();
            botonAdmin(_usuario, _perfil);
            ActualizarGenerosPerfiles();
            MostrarPeliculas();
        }

        private void ActualizarGenerosPerfiles()
        {
            _logicaPerfil.ActualizarListadoGeneros(_perfil);
        }

        void botonAdmin(Usuario usuario, Perfil perfil)
        {
            if (!usuario.EsAdministrador || !perfil.EsOwner)
            {
                btnAdmin.Visible = false;
            }
        }

        private void MostrarPeliculas()
        {
            flpListaPelis.Controls.Clear();
            int index = 0;
            int anchoPelicula = (int)(flpListaPelis.Width*0.3);
            int alturaPelicula = flpListaPelis.Height;
            foreach (Pelicula pelicula in _logicaPelicula.MostrarPeliculas(_perfil))
            {
                FlowLayoutPanel flpPelicula = new System.Windows.Forms.FlowLayoutPanel();
                flpPelicula.BackColor = SystemColors.Control;
                flpPelicula.FlowDirection = FlowDirection.TopDown;
                flpPelicula.Size = new Size(anchoPelicula, 170);
                flpListaPelis.Controls.Add(flpPelicula);

                PictureBox poster = new PictureBox();
                poster.Size = new Size(anchoPelicula, 130);
                poster.BorderStyle = BorderStyle.FixedSingle;
                poster.BackColor = SystemColors.Control;
                poster.TabIndex = index;
                poster.Image = new Bitmap(pelicula.Poster);
                poster.SizeMode = PictureBoxSizeMode.StretchImage;
                poster.Click += new EventHandler(AccederPelicula);
                flpPelicula.Controls.Add(poster);

                Label nombre = new Label();
                nombre.Text = pelicula.Nombre;
                nombre.TabIndex = index;
                flpPelicula.Controls.Add(nombre);

                index++;
            }
        }

        private void AccederPelicula(object sender, EventArgs e)
        {
            PictureBox peliculaSeleccionada = sender as PictureBox;
            int index = peliculaSeleccionada.TabIndex;
            Pelicula pelicula = _logicaPelicula.MostrarPeliculas(_perfil)[index] ;
            _ventanaPrincipal.CambiarVerPelicula(pelicula, _perfil, _logicaPerfil, _logicaGenero, _usuario);
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
