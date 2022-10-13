using Dominio;
using Dominio.Exceptions;
using Logica.Exceptions;
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
        Threat_Level_Midnight_Entertainment _ventanaPrincipal;

        public Registro(ILogicaUsuario logica, Threat_Level_Midnight_Entertainment ventanaPrincipal)
        {
            _logica = logica;
            _ventanaPrincipal = ventanaPrincipal;
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
                    ConfirmarClave = txtConfClave.Text
                };
                _logica.RegistrarUsuario(usuario);
                MessageBox.Show($"El usuario {usuario} se registró con exito!");
                _ventanaPrincipal.CambiarRegistroPerfil(usuario);
            } 
            catch (NombreUsuarioException)
            {
                MessageBox.Show("Ese nombre de usuario debe contener entre 10 y 20 caracteres");
            }
            catch (EmailInvalidoException)
            {
                MessageBox.Show("Email inválido");
            }
            catch (ClaveInvalidaException)
            {
                MessageBox.Show("Clave inválida");
            }
            catch (NombreUsuarioExistenteException)
            {
                MessageBox.Show("El nombre de usuario ya está en uso");
            }
            catch (EmailExistenteException)
            {
                MessageBox.Show("El email ya está en uso");
            }
            catch (ClaveNoCoincideException)
            {
                MessageBox.Show("Las contraseñas no coinciden");
            }
        }

        private void lblLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _ventanaPrincipal.CambiarLogin();
        }

    }
}
