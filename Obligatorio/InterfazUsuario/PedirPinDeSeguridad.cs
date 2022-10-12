using Dominio;
using Logica.Exceptions;
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
    public partial class PedirPinDeSeguridad : UserControl
    {
        private Threat_Level_Midnight_Entertainment _ventanaPrincipal;
        private Usuario _usuario;
        private Perfil _perfil;
        ILogicaPerfil _logicaPerfil;
        public PedirPinDeSeguridad(Perfil perfil, Usuario usuario,ILogicaPerfil logicaPerfil, Threat_Level_Midnight_Entertainment ventanaPrincipal)
        {
            _logicaPerfil = logicaPerfil;
            _perfil = perfil;
            _usuario = usuario;
            _ventanaPrincipal = ventanaPrincipal;
            InitializeComponent();
            lblTitulo.Text = $"Hola {_perfil.Alias}";

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                int pin = int.Parse(txtPin.Text);
                _logicaPerfil.AccederAlPerfil(_perfil, pin);
                _ventanaPrincipal.CambiarMenuPeliculas(_usuario, _perfil);
            }
            catch(PinIncorrectoException)
            {
                MessageBox.Show("Pin incorrecto");
            }
        }

        private void lblAtras_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _ventanaPrincipal.CambiarListaPerfiles(_usuario, _perfil);
        }
    }
}
