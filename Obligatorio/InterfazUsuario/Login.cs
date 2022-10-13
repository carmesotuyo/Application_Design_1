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
    public partial class Login : UserControl
    {
        private ILogicaUsuario _logica;
        Threat_Level_Midnight_Entertainment _ventanaPrincipal;

        public Login(ILogicaUsuario logica, Threat_Level_Midnight_Entertainment ventanaPrincipal)
        {
            _logica = logica;
            _ventanaPrincipal = ventanaPrincipal;
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _ventanaPrincipal.CambiarRegistroUsuario();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = _logica.IniciarSesion(txtCuenta.Text, txtClave.Text);
                MessageBox.Show($"Has iniciado sesión con {usuario}");
                _ventanaPrincipal.CambiarSeleccionarPerfil(usuario);
            } 
            catch(NombreOEmailIncorrectoException)
            {
                MessageBox.Show("Nombre o email incorrecto");
            }
            catch(ClaveIncorrectaException)
            {
                MessageBox.Show("Clave incorrecta");
            }
            
        }
    }
}
