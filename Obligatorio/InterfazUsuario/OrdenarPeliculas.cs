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
    public partial class OrdenarPeliculas : UserControl
    {
        private MenuAdmin _menuAdmin;
        private ILogicaPelicula _logicaPelicula;
        private Usuario _usuario;
        public OrdenarPeliculas(Usuario usuario, ILogicaPelicula logicaPelicula, MenuAdmin menuAdmin)
        {
            InitializeComponent();
            _menuAdmin = menuAdmin;
            _logicaPelicula = logicaPelicula;
            _usuario = usuario;
            CargarComboCriterio();
        }

        private void CargarComboCriterio()
        {
            cbCriterio.Items.Clear();
            cbCriterio.Items.Add("Por género");
            cbCriterio.Items.Add("Por patrocinio");
            cbCriterio.Items.Add("Por puntaje");
            lblCriterio.Text = _logicaPelicula.CriterioSeleccionado();
        }

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            try
            {
                int criterio = cbCriterio.SelectedIndex;
                _logicaPelicula.ElegirCriterioOrden(_usuario, criterio);
                lblCriterio.Text = _logicaPelicula.CriterioSeleccionado();
            }
            catch(CriterioInexistenteException)
            {
                MessageBox.Show("Debe seleccionar un criterio");
            }

        }
    }
    
}
