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
    public partial class SeleccionarPerfil : UserControl
    {

        private Threat_Level_Midnight_Entertainment _ventanaPrincipal;
        private Usuario _usuario;
        private ILogicaUsuario _logicaUsuario;
        public SeleccionarPerfil(Usuario usuario, ILogicaUsuario logicaUsuario, Threat_Level_Midnight_Entertainment ventanaPrincipal)
        {
            InitializeComponent();
            _usuario = usuario;
            _logicaUsuario = logicaUsuario;
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
            foreach (Perfil perfil in _usuario.Perfiles)
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
                index++;
            }
        }

        private void AccederPerfil(object sender, EventArgs e)
        {
            FlowLayoutPanel perfilSeleccionado = sender as FlowLayoutPanel;
            int index = perfilSeleccionado.TabIndex;
            Perfil perfil = _usuario.Perfiles[index];
            if (perfil.EsInfantil)
            {
                _ventanaPrincipal.CambiarMenuPeliculas(_usuario, perfil);
            }
            _ventanaPrincipal.CambiarPedirPin(_usuario, perfil, perfil);
        }
    }
}
