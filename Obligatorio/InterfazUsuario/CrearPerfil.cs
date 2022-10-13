﻿using Dominio;
using Dominio.Exceptions;
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
    public partial class CrearPerfil : UserControl
    {
        private Threat_Level_Midnight_Entertainment _ventanaPrincipal;
        private ILogicaUsuario _logicaUsuario;
        private Usuario _usuario;

        public CrearPerfil(Usuario usuario, ILogicaUsuario logicaUsuario, Threat_Level_Midnight_Entertainment ventanaPrincipal)
        {
            _usuario = usuario;
            _logicaUsuario = logicaUsuario;
            _ventanaPrincipal = ventanaPrincipal;
            InitializeComponent();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                Perfil perfil = new Perfil()
                {
                    Alias = txtAlias.Text,
                    Pin = int.Parse(txtPin.Text),
                    ConfirmarPin = int.Parse(txtPinConfirm.Text)
                };
                _logicaUsuario.AgregarPerfil(_usuario, perfil);
                MessageBox.Show($"Se creó el perfil {perfil} del usuario {_usuario}");
                _ventanaPrincipal.CambiarMenuPeliculas(_usuario, perfil);
            }
            catch (AliasInvalidoException)
            {
                MessageBox.Show("Alias inválido");
            }
            catch (PinInvalidoException)
            {
                MessageBox.Show("El pin debe contener 5 digitos numericos");
            }
            catch (PinNoCoincideException)
            {
                MessageBox.Show("El pin y su confirmación no son iguales");
            }
            catch (System.FormatException)
            {
                MessageBox.Show("El pin solo debe contener numeros");
            }
            catch (LimiteDePerfilesException)
            {
                MessageBox.Show("Solo puede tener hasta 4 perfiles");
            }
        }
    }
}
