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
    public partial class AgregarPelicula : UserControl
    {
        private MenuAdmin _menuAdmin;
        public AgregarPelicula(MenuAdmin menuAdmin)
        {
            _menuAdmin = menuAdmin;
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
