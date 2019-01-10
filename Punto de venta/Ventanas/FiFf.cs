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
    public partial class FiFf : Form
    {
        public bool cierto { get; set; }
        public DateTime Fi { get; set; }
        public DateTime Ff { get; set; }
        public FiFf()
        {
            InitializeComponent();
            cargar();
        }        
        public void cargar()
        {
            dtpFin.MinDate = DateTime.Now;
            dtpInicio.MaxDate = dtpFin.MaxDate = DateTime.Now;
        }
        public void aceptar()
        {
            cierto = true;
            Fi = new DateTime(dtpInicio.Value.Year, dtpInicio.Value.Month, dtpInicio.Value.Day, 0, 0, 0);
            Ff = new DateTime(dtpFin.Value.Year, dtpFin.Value.Month, dtpFin.Value.Day, 23, 59, 59);
            this.Close();
        }
        private void dtpInicio_ValueChanged(object sender, EventArgs e)
        {
            dtpFin.MinDate = dtpInicio.Value;
        }
        private void btnAceptar_MouseUp(object sender, EventArgs e)
        {
            aceptar();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dtpInicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Escape || e.KeyChar == (char)Keys.Tab|| e.KeyChar == (char)Keys.Space) e.Handled = true;
        }
        private void dtpFin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Escape || e.KeyChar == (char)Keys.Tab || e.KeyChar == (char)Keys.Space) e.Handled = true;
        }
        private void dtpInicio_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:dtpFin.Focus();
                    break;
                case Keys.Escape:this.Close();
                    break;
                default:break;
            }
        }
        private void dtpFin_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter: aceptar();
                    break;
                case Keys.Escape: this.Close();
                    break;
                default: break;
            }
        }
    }
}
