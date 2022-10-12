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

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            _ventanaPrincipal.CambiarRegistroPerfil(_usuario);
        }
    }
}
