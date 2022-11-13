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
    public partial class ListaPerfiles : UserControl
    {
        private Threat_Level_Midnight_Entertainment _ventanaPrincipal;
        private Usuario _usuario;
        private Perfil _perfil;
        private ILogicaUsuario _logicaUsuario;
        private ILogicaPerfil _logicaPerfil;
        public ListaPerfiles(Perfil perfil, Usuario usuario, ILogicaUsuario logicaUsuario, ILogicaPerfil logicaPerfil, Threat_Level_Midnight_Entertainment ventanaPrincipal)
        {
            InitializeComponent();
            _perfil = perfil;
            _usuario = usuario;
            _logicaUsuario = logicaUsuario;
            _logicaPerfil = logicaPerfil;
            _ventanaPrincipal = ventanaPrincipal;
            CargarPerfiles();


        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            _ventanaPrincipal.CambiarRegistroPerfil(_usuario);
        }
        private void CargarPerfiles()
        {
            flpListaPerfiles.Controls.Clear();
            int index = 0;
            bool esOwner = _perfil.EsOwner;
            foreach(Perfil perfil in _logicaUsuario.PerfilesAsociados(_usuario))
            {
                FlowLayoutPanel flpPerfil = new System.Windows.Forms.FlowLayoutPanel();
                flpPerfil.BackColor = SystemColors.Control;
                flpPerfil.FlowDirection = FlowDirection.TopDown;
                flpPerfil.Size = new Size(150, 223);
                flpListaPerfiles.Controls.Add(flpPerfil);

                FlowLayoutPanel flpPerfilImagen = new FlowLayoutPanel();
                flpPerfilImagen.Size = new Size(145, 75);
                flpPerfilImagen.BorderStyle = BorderStyle.FixedSingle;
                flpPerfilImagen.BackColor = SystemColors.Control;
                flpPerfilImagen.TabIndex = index;
                flpPerfilImagen.Click += new EventHandler(AccederPerfil);
                flpPerfil.Controls.Add(flpPerfilImagen);

                Label alias = new Label();
                alias.Text = perfil.Alias;
                flpPerfil.Controls.Add(alias);

                if (!perfil.EsOwner)
                {
                    CheckBox esInfantil = new CheckBox();
                    esInfantil.Text = "Es infantil";
                    esInfantil.Checked = perfil.EsInfantil;
                    esInfantil.TabIndex = index;
                    if (!esOwner) { esInfantil.Visible = false; };
                    esInfantil.Click += new EventHandler(EsInfantil);
                    flpPerfil.Controls.Add(esInfantil);

                    LinkLabel eliminar = new LinkLabel();
                    eliminar.Text = "Eliminar";
                    eliminar.TabIndex = index;
                    if (!esOwner) { eliminar.Visible = false; };
                    eliminar.Click += new EventHandler(EliminarPerfil);
                    flpPerfil.Controls.Add(eliminar);
                }
                index++;
            }
        }

        private void EliminarPerfil(object sender, EventArgs e)
        {
            LinkLabel perfilSeleccionado = sender as LinkLabel;
            int index = perfilSeleccionado.TabIndex;
            Perfil perfil = _logicaUsuario.PerfilesAsociados(_usuario)[index];
            _logicaUsuario.QuitarPerfil(_usuario, perfil);
            CargarPerfiles();
        }

        private void EsInfantil(object sender, EventArgs e)
        {
            CheckBox perfilSeleccionado = sender as CheckBox;
            int index = perfilSeleccionado.TabIndex;
            Perfil perfil = _logicaUsuario.PerfilesAsociados(_usuario)[index];
            if (perfilSeleccionado.Checked) { _logicaPerfil.MarcarComoInfantil(perfil, _perfil); };
        }

        private void AccederPerfil(object sender, EventArgs e)
        {
            FlowLayoutPanel perfilSeleccionado = sender as FlowLayoutPanel;
            int index = perfilSeleccionado.TabIndex;
            Perfil perfil = _logicaUsuario.PerfilesAsociados(_usuario)[index];
            if (perfil.EsInfantil)
            {
                _ventanaPrincipal.CambiarMenuPeliculas(_usuario, perfil);
            }
            _ventanaPrincipal.CambiarPedirPin(_usuario, perfil, _perfil);
        }

        private void lblVolver_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _ventanaPrincipal.CambiarMenuPeliculas(_usuario, _perfil);
        }
    }
}
