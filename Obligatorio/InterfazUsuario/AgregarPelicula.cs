using Dominio;
using Dominio.Exceptions;
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
    public partial class AgregarPelicula : UserControl
    {
        private MenuAdmin _menuAdmin;
        private ILogicaPelicula _logicaPelicula;
        private ILogicaGenero _logicaGenero;
        private Usuario _usuario;
        private string _imgPelicula;
        public AgregarPelicula(Usuario usuario, ILogicaPelicula ilogicaPelicula, ILogicaGenero logicaGenero, MenuAdmin menuAdmin)
        {
            _logicaGenero = logicaGenero;
            _logicaPelicula = ilogicaPelicula;
            _menuAdmin = menuAdmin;
            _usuario = usuario;
            InitializeComponent();
        }

        
        private void ActualizarComboGeneros()
        {
            cbGeneros.Text = "";
            cbGeneros.Items.Clear();
            cbGeneros.Items.AddRange(_logicaGenero.Generos().ToArray());
        }

        private void ActualizarBoxGeneros()
        {
            lbGeneros.Items.Clear();
            lbGeneros.Items.AddRange(_logicaGenero.Generos().ToArray());
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Genero generoPrincipal = cbGeneros.SelectedItem as Genero;
                List<Genero> generosSecundarios = new List<Genero>();
                foreach(Genero genero in lbGeneros.SelectedItems)
                {
                    generosSecundarios.Add(genero);
                }

                Pelicula pelicula = new Pelicula()
                {
                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                    GenerosSecundarios = generosSecundarios,
                    GeneroPrincipal = generoPrincipal,
                    Poster = _imgPelicula,
                    EsPatrocinada = ckbEsPatrocinada.Checked,
                    AptaTodoPublico = ckbEsApta.Checked
                };
                _logicaPelicula.AltaPelicula(pelicula, _usuario);
                MessageBox.Show($"Pelicula {pelicula.Nombre} se agregó correctamente");
                Limpiar();
            }
            catch (GeneroInvalidoException)
            {
                MessageBox.Show("El genero principal no puede esta en el secundario");
            }
            catch (DatoVacioException)
            {
                MessageBox.Show("Todavia quedan campos vacios");
            }
            catch (NullException)
            {
                MessageBox.Show("Debe seleccionar una imagen");
            }

        }

        private void Limpiar()
        {
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            imgPoster.Image = null;
            ckbEsApta.Checked = false;
            ckbEsPatrocinada.Checked = false;
            ActualizarComboGeneros();
            ActualizarBoxGeneros();
        }

        private void btnPoster_Click(object sender, EventArgs e)
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
                    _imgPelicula = filePath;
                }
            }
        }

        private void AgregarPelicula_Load(object sender, EventArgs e)
        {
            ActualizarComboGeneros();
            ActualizarBoxGeneros();
        }
    }
}
