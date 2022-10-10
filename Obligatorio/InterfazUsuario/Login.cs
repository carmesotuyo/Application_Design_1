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
        public Login(ILogicaUsuario logica)
        {
            _logica = logica;
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                _logica.IniciarSesion(txtCuenta.Text, txtClave.Text);
                MessageBox.Show("Inicio de sesión exitosa");
            } catch(NombreOEmailIncorrectoException)
            {
                MessageBox.Show("Nombre o email incorrecto");
            }catch(ClaveIncorrectaException)
            {
                MessageBox.Show("Clave incorrecta");
            }
            
        }
    }
}
