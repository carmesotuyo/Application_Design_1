using Dominio;
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
    public partial class AsociarPersona : UserControl
    {
        private MenuAdmin _menuAdmin;
        private Usuario _usuario;
        private Perfil _perfil;
        private ILogicaPelicula _logicaPelicula;
        private ILogicaPersona _logicaPersona;
        public AsociarPersona(Usuario usuario, ILogicaPelicula ilogicaPelicula, ILogicaPersona logicaPersona, MenuAdmin menuAdmin)
        {
            InitializeComponent();
            _usuario = usuario;
            _logicaPelicula = ilogicaPelicula;
            _logicaPersona = logicaPersona;
            _menuAdmin = menuAdmin;

        }

        private void RBDirector_CheckedChanged(object sender, EventArgs e)
        {
            label5.Visible = false;
            txtPapel.Visible = false;
        }

        private void RBActor_CheckedChanged(object sender, EventArgs e)
        {
            label5.Visible = true;
            txtPapel.Visible = true;
        }
    }
}
