using Dominio;
using Dominio.Exceptions;
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
    public partial class QuitarGenero : UserControl
    {
        private MenuAdmin _menuAdmin;
        private ILogicaGenero _logicaGenero;
        private ILogicaPelicula _logicaPelicula;
        private Usuario _usuario;
        public QuitarGenero(Usuario usuario, ILogicaGenero logicaGenero, ILogicaPelicula logicaPelicula, MenuAdmin menuAdmin)
        {
            InitializeComponent();
            _logicaPelicula = logicaPelicula;
            _menuAdmin = menuAdmin;
            _logicaGenero = logicaGenero;
            _usuario = usuario;
            ActualizarComboGeneros();
        }
        private void ActualizarComboGeneros()
        {
            cbGeneros.Items.Clear();
            cbGeneros.Items.AddRange(_logicaGenero.Generos().ToArray());
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Genero genero = cbGeneros.SelectedItem as Genero;
                _logicaGenero.EliminarGenero(_usuario, genero, _logicaPelicula);
                MessageBox.Show($"El genero {genero}, se eliminó con éxito");
                _menuAdmin.CambiarQuitarGenero();
            }
            catch(GeneroInexistenteException)
            {
                MessageBox.Show("Seleccione un genero");
            }
            catch (GeneroConPeliculaAsociadaException)
            {
                MessageBox.Show($"El genero seleccionado no se puede eliminar");
            }
            catch (NullException)
            {
                MessageBox.Show("Debe seleccionar un genero");
            }
        }
        


    }
}
