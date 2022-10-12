using Dominio;
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
        public ListaPerfiles(Perfil perfil, Usuario usuario, Threat_Level_Midnight_Entertainment ventanaPrincipal)
        {
            InitializeComponent();
            _perfil = perfil;
            _usuario = usuario;
            _ventanaPrincipal = ventanaPrincipal;
            CargarPerfiles();


        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            _ventanaPrincipal.CambiarRegistroPerfil(_usuario);
        }
        //flpListaPerfiles - flp con size 198, 222  --  flpImagen con size 193, 120
        private void CargarPerfiles()
        {
            foreach(Perfil perfil in _usuario.Perfiles)
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
                flpPerfil.Controls.Add(flpPerfilImagen);

                Label alias = new Label();
                alias.Text = perfil.Alias;
                flpPerfil.Controls.Add(alias);

                if (!perfil.EsOwner)
                {
                    CheckBox esInfantil = new CheckBox();
                    esInfantil.Text = "Es infantil";
                    esInfantil.Checked = perfil.EsInfantil;
                    flpPerfil.Controls.Add(esInfantil);

                    LinkLabel eliminar = new LinkLabel();
                    eliminar.Text = "Eliminar";
                    flpPerfil.Controls.Add(eliminar);
                }

            }
        }

    }
}
