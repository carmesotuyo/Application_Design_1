using Dominio;
using Dominio.Exceptions;
using Logica.Implementaciones;
using Logica.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfazUsuario
{
    public partial class AgregarPersona : UserControl
    {
        private MenuAdmin _menuAdmin;
        private ILogicaPersona _logicaPersona;
        private Usuario _usuario;
        private string _foto = "";
        public AgregarPersona(Usuario usuario, ILogicaPersona ilogicaPersona, MenuAdmin menuAdmin)
        {
            _logicaPersona = ilogicaPersona;
            _menuAdmin = menuAdmin;
            _usuario = usuario;
            InitializeComponent();
        }

        private void btnFoto_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Image Files | *.jpg; *.jpeg; *.png;";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                        imgPoster.Image = new Bitmap(openFileDialog.FileName);

                    }
                    _foto = filePath;
                }
            }
        }

        private void Limpiar()
        {
            txtNombre.Text = "";
            imgPoster.Image = null;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            try
            {
                Persona persona = new Persona()
                {
                    Nombre = txtNombre.Text,
                    FechaNacimiento = DTFechaNac.Value,
                    FotoPerfil = _foto
                };
                _logicaPersona.AltaPersona(persona, _usuario);
                MessageBox.Show($"{persona.Nombre} se agregó correctamente");
                Limpiar();
            }
            catch (NombrePersonaVacioException)
            {
                MessageBox.Show("El nombre no puede estar vacío");
            }
            catch (FechaInvalidaException)
            {
                MessageBox.Show("La fecha de nacimiento no es correcta");
            }
            catch (DatoVacioException)
            {
                MessageBox.Show("Se debe cargar una foto de perfil");
            }
            catch (NullException)
            {
                MessageBox.Show("Se debe cargar una foto de perfil");
            }
        }
    }
}
