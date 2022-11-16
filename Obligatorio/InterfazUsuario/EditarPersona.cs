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
    public partial class EditarPersona : UserControl
    {
        private MenuAdmin _menuAdmin;
        private ILogicaPersona _logicaPersona;
        private Usuario _usuario;
        private string _foto = "";

        public EditarPersona(Usuario usuario, ILogicaPersona logicaPersona, MenuAdmin menuAdmin)
        {
            InitializeComponent();
            _logicaPersona = logicaPersona;
            _menuAdmin = menuAdmin;
            _usuario = usuario;
            ActualizarComboPersonas();
        }
        private void ActualizarComboPersonas()
        {
            cbPersonas.Items.Clear();
            cbPersonas.Items.AddRange(_logicaPersona.Personas().ToArray());
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Persona persona = cbPersonas.SelectedItem as Persona;
                _logicaPersona.BajaPersona(persona, _usuario);
                MessageBox.Show($"{persona.Nombre} se eliminó con éxito");
                _menuAdmin.CambiarEditarPersona();
            }
            catch (NullException)
            {
                MessageBox.Show("Seleccione una persona");
            }
        }

        private void btnDatos_Click(object sender, EventArgs e)
        {
            Persona persona = cbPersonas.SelectedItem as Persona;
            txtNombre.Text = persona.Nombre;
            DTFechaNac.Value = persona.FechaNacimiento;
            _foto = persona.FotoPerfil;
            fotoPerfil.Image = new Bitmap(persona.FotoPerfil);
        }

        private void button1_Click(object sender, EventArgs e)
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
                        fotoPerfil.Image = new Bitmap(openFileDialog.FileName);

                    }
                    _foto = filePath;
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Persona persona = cbPersonas.SelectedItem as Persona;
                if (persona != null)
                {
                    persona.Nombre = txtNombre.Text;
                    persona.FechaNacimiento = DTFechaNac.Value;
                    persona.FotoPerfil = _foto;
                    _logicaPersona.ModificarPersona(persona, _usuario);
                    MessageBox.Show($"{persona.Nombre} se modificó con éxito");
                    _menuAdmin.CambiarEditarPersona();
                }
            }
            catch (NullException)
            {
                MessageBox.Show("Debe seleccionar una persona");
            }
            catch (NombrePersonaVacioException)
            {
                MessageBox.Show("El nombre no puede quedar vacío");
            }
            catch (FechaInvalidaException)
            {
                MessageBox.Show("La fecha no es correcta");
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Debe seleccionar una persona");
            }
        }

        private void cbPersonas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Persona persona = cbPersonas.SelectedItem as Persona;
            if(persona != null)
            {
                txtNombre.Text = persona.Nombre;
                DTFechaNac.Value = persona.FechaNacimiento;
                if(persona.FotoPerfil != null || persona.FotoPerfil != "")
                {
                    fotoPerfil.Image = new Bitmap(persona.FotoPerfil);
                }
                
                _foto = persona.FotoPerfil;
            }
            
        }

    }
}
