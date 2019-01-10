using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Punto_de_venta
{
    public partial class cerrar : Form
    {
        public cerrar()
        {
            InitializeComponent();
        }
        public bool cierto { get; set; }
    

       

        private void cerrar_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuFlatButton2_MouseUp(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuFlatButton1_MouseUp(object sender, EventArgs e)
        {
            cierto = true;
            this.Close();
        }
    }
}
