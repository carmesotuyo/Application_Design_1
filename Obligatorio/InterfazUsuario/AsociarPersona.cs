using Dominio;
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

        private void ActualizarComboPeliculas()
        {
            CBPeliculas.Text = "";
            CBPeliculas.Items.Clear();
            CBPeliculas.Items.AddRange(_logicaPelicula.Peliculas().ToArray());
        }

        private void ActualizarComboDirectores()
        {
            CBDirectores.Text = "";
            CBDirectores.Items.Clear();
            //CBDirectores.Items.AddRange(_logicaPelicula.Peliculas().ToArray());
        }

        private void ActualizarComboPapeles()
        {
            CBPapeles.Text = "";
            CBPapeles.Items.Clear();
            //CBPapeles.Items.AddRange(_logicaPelicula.Peliculas().ToArray());
        }

        private void ActualizarComboPersonas()
        {
            CBPersonas.Text = "";
            CBPersonas.Items.Clear();
            CBPersonas.Items.AddRange(_logicaPersona.Personas().ToArray());
        }

        private void CBPeliculas_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ActualizarComboDirectores();
            //ActualizarComboPapeles();
        }

        private void AsociarPersona_Load(object sender, EventArgs e)
        {
            ActualizarComboPersonas();
            ActualizarComboPeliculas();
        }

        private void btnAsociar_Click(object sender, EventArgs e)
        {
            Pelicula pelicula = CBPeliculas.SelectedItem as Pelicula;
            Persona persona = CBPersonas.SelectedItem as Persona;
            if(RBActor.Checked)
            {
                Papel papel = new Papel()
                {
                    Nombre = txtPapel.Text,
                    Actor = persona,
                    Pelicula = pelicula
                };
            } else
            {
                //Asociar director
            }
        }
    }
}
