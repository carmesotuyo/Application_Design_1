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
    public partial class Threat_Level_Midnight_Entertainment : Form
    {
        public Threat_Level_Midnight_Entertainment()
        {
            InitializeComponent();
            flpPanelPrincipal.Controls.Clear();
            flpPanelPrincipal.Controls.Add(new Login());
        }
    }
}
