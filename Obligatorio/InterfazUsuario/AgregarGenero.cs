using Dominio;
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
    public partial class AgregarGenero : UserControl
    {
        private MenuAdmin _menuAdmin;
        private ILogicaGenero _logicaGenero;
        private Usuario _usuario;
        public AgregarGenero(Usuario usuario,ILogicaGenero logicaGenero, MenuAdmin menuAdmin)
        {
            _menuAdmin = menuAdmin;
            _logicaGenero = logicaGenero;
            _usuario = usuario;
            InitializeComponent();
            
        }
        private void Limpiar()
        {
            txtNombre.Text = "";
            txtDescripcion.Text = "";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Genero genero = new Genero()
                {
                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                };
                _logicaGenero.AgregarGenero(_usuario, genero);
                MessageBox.Show($"Se agregó el genero {genero}, correctamente");
                Limpiar();
            }
            catch (GeneroDuplicadoException)
            {
                MessageBox.Show($"El género ya existe");
            }
            catch (GeneroInvalidoException)
            {
                MessageBox.Show($"El género no es valido");
            }
            catch (DatoVacioException)
            {
                MessageBox.Show($"Debe ingresar el nombre");
            }
            
        }
    }
}
