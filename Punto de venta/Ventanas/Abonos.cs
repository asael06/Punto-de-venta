using Punto_de_venta.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Punto_de_venta.Ventanas
{
    public partial class Abonos : Form
    {
        public Abonos()
        {
            InitializeComponent();
            txtAbono.Select();
        }
        public string abo { get; set; }
        ClassValidation valida = new ClassValidation();
        public void aceptar()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtAbono.Text))
                {
                    abo = txtAbono.Text;
                    this.Close();
                }
                else this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region //Eventos
        private void btnAceptar_MouseUp(object sender, EventArgs e)
        {
            aceptar();
        }
        private void txtAbono_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.validationNumber(e);
        }
        private void txtAbono_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) aceptar();
            else if (e.KeyData == Keys.Escape) this.Close();
        }
        #endregion

    }
}
