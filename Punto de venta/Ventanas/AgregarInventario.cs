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
    public partial class AgregarInventario : Form
    {
        public AgregarInventario()
        {
            InitializeComponent();
        }
        ClassValidation validar = new ClassValidation();
        public double can { get; set; }
        public bool cierto { get; set; }
        public void aceptar()
        {

            if (!string.IsNullOrWhiteSpace(txtCantidad.Text))
            {
                try
                {
                    validar.errorActive(txtCantidad, validar.numberDecimalRGX, Error);
                    validar.validationTxtField(txtCantidad, validar.numberDecimalRGX);
                    can = double.Parse(txtCantidad.Text);
                    cierto = true;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else this.Close();
        }
        public void setValues(double ac,string art)
        {
            lblExistente.Text = ac.ToString("N3");
            lblTotal.Text = ac.ToString("N3");
            lblArticulo.Text = art;
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            aceptar();
        }
        private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Enter: aceptar();
                    break;
                case Keys.Escape:this.Close();
                    break;
                default:
                    break;
            }
        }
        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.validationNumber(e);            
        }
    }
}
