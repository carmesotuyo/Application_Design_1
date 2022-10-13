using Dominio;
using Dominio.Exceptions;
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
    public partial class QuitarPelicula : UserControl
    {
        private MenuAdmin _menuAdmin;
        private Usuario _usuario;
        private ILogicaPelicula _logicaPelicula;
        public QuitarPelicula(Usuario usuario, ILogicaPelicula logicaPelicula, MenuAdmin menuAdmin)
        {
            _menuAdmin = menuAdmin;
            InitializeComponent();
            _logicaPelicula = logicaPelicula;
            _menuAdmin = menuAdmin;
            _usuario = usuario;
            ActualizarComboPeliculas();
        }

        private void ActualizarComboPeliculas()
        {
            cbPeliculas.Items.Clear();
            cbPeliculas.Items.AddRange(_logicaPelicula.Peliculas().ToArray());
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
           try
            {
                Pelicula pelicula = cbPeliculas.SelectedItem as Pelicula;
                _logicaPelicula.BajaPelicula(pelicula, _usuario);
                MessageBox.Show($"La pelicula {pelicula} se eliminó con éxito");
                _menuAdmin.CambiarQuitarPeli();
            }
            catch(NullException)
            {
                MessageBox.Show("Debe seleccionar una pelicula");
            }
            
            
        }
    }
}
