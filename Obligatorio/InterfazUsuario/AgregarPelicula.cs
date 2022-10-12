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
        private string _imgPelicula;
        public AgregarPelicula(MenuAdmin menuAdmin)
        {
            _menuAdmin = menuAdmin;
            InitializeComponent();
        }

       

        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        private void btnPoster_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Image Files | *.jpg; *.png;";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
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
    }
}
