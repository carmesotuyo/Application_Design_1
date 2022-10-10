using Dominio;
using Dominio.Exceptions;
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
    public partial class Registro : UserControl
    {
        private ILogicaUsuario _logica;
        public Registro(ILogicaUsuario logica)
        {
            _logica = logica;
            InitializeComponent();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = new Usuario()
                {
                    Nombre = txtUserName.Text,
                    Email = txtEmail.Text,
                    Clave = txtClave.Text,
                };
                _logica.RegistrarUsuario(usuario);
                MessageBox.Show("Usuario Registrado con exito!");
            } catch (NombreUsuarioException)
            {
                MessageBox.Show("Ese nombre de usuario no da");
            }
            catch (EmailInvalidoException)
            {
                MessageBox.Show("Ese mail no");
            }
            catch (ClaveInvalidaException)
            {
                MessageBox.Show("Con esa clave te hackean");
            }
        }

        private void lblLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void Registro_Load(object sender, EventArgs e)
        {
            //flpPanelPrincipal.Controls.Clear();
            //flpPanelPrincipal.Controls.Add(new Login(_logicaUsuario));
            //flpPanelPrincipal.Controls.Add(new Registro(_logicaUsuario));
        }
    }
}
