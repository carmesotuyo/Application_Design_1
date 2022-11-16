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
        private ILogicaPersona _logicaPersona;
        public MenuPeliculas(Threat_Level_Midnight_Entertainment ventanaPrincipal, Usuario usuario, Perfil perfil, ILogicaGenero logicaGenero, ILogicaPersona logicaPersona, ILogicaPerfil logicaPerfil, ILogicaPelicula logicaPelicula)
        {
            _ventanaPrincipal = ventanaPrincipal;
            _usuario = usuario;
            _perfil = perfil;
            _logicaPelicula = logicaPelicula;
            _logicaPerfil = logicaPerfil;
            _logicaGenero = logicaGenero;
            _logicaPersona = logicaPersona;
            
            InitializeComponent();
            botonAdmin(_usuario, _perfil);
            ActualizarGenerosPerfiles();
            MostrarTodas();
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

        private void MostrarVistas()
        {
            int index = 0;
            int anchoPelicula = (int)(flpListaPelis.Width * 0.3);
            foreach (Pelicula pelicula in _logicaPerfil.MostrarPeliculasVistas(_perfil))
            {
                FlowLayoutPanel flpPelicula = new System.Windows.Forms.FlowLayoutPanel();
                flpPelicula.BackColor = SystemColors.Control;
                flpPelicula.FlowDirection = FlowDirection.TopDown;
                flpPelicula.Size = new Size(anchoPelicula, 250);
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

                Label directores = new Label();
                directores.AutoSize = true;
                directores.Text = "Director(es): Robert de Nilo, Brad Pit, fernando spillere, carmela sotuyo";//pelicula.Nombre;
                directores.TabIndex = index;
                flpPelicula.Controls.Add(directores);

                Label actores = new Label();
                actores.AutoSize = true;
                actores.Text = "Actor(es): Robert de Nilo, Brad Pit";//pelicula.Nombre;
                actores.TabIndex = index;
                flpPelicula.Controls.Add(actores);

                index++;
            }
        }

        private void MostrarTodas()
        {
            flpListaPelis.Controls.Clear();
            MostrarPeliculas();

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

        private void btnTodas_Click(object sender, EventArgs e)
        {
            MostrarTodas();
        }

        private void btnVistas_Click(object sender, EventArgs e)
        {
            flpListaPelis.Controls.Clear();
            MostrarVistas();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            flpListaPelis.Controls.Clear();
            flpListaPelis.Controls.Add(LBPersonas);
            flpListaPelis.Controls.Add(btnBuscarDirector);
            flpListaPelis.Controls.Add(btnBuscarActor);
            ActualizarBoxPersonas();

        }

        private void ActualizarBoxPersonas()
        {
            LBPersonas.Items.Clear();
            LBPersonas.Items.AddRange(_logicaPersona.Personas().ToArray());
        }

        private void btnBuscarDirector_Click(object sender, EventArgs e)
        {
            MostrarVistas();
        }

        private void btnBuscarActor_Click(object sender, EventArgs e)
        {
            MostrarTodas();
        }
    }
}
