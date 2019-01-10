using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Punto_de_venta.Base_de_datos;
using Punto_de_venta.Clases;

namespace Punto_de_venta.Ventanas
{
    public partial class Efectivo : UserControl
    {
        ClassValidation validar = new ClassValidation();
        public List<ArticuloVendido> av { get; set; }
        private bool cierto = false;
        public bool aceptar { get; set; }
        public bool acepta { get; set; }
        decimal total,efectivo,cambio;
        public bool verdad { get; set; }       
        public Efectivo()
        {
            InitializeComponent();            
        }
        public void ingreso()
        {
            int[] ids = BDIngresos.ArrIngresosId().ToArray();
            Ingresos ing = new Ingresos(regresarId(ids, BDIngresos.idMax()), "Venta", Convert.ToDouble(lblTotal.Text), DateTime.Now.Date.ToString("yyyy-MM-dd"), BDLogeado.retornaLogeado());
            BDIngresos.IngresoNuevo(ing);
        }
        public int regresarId(int[] tabla, int idmax)
        {
            if (tabla.Length == 0) return 1;
            else if (tabla[0] != 1) { return 1; }
            else if (idmax == tabla.Length) return idmax + 1;
            else
            {
                int i = 0;
                do { i++; }
                while (tabla[i] == i + 1);
                return i + 1;
            }
        }        

        #region //Eventos
        private void txtEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.validationNumber(e);
            if (e.KeyChar == (char)Keys.Enter|| e.KeyChar == (char)Keys.Escape)
            {
                e.Handled = true;
            }          
        }
        private void txtEfectivo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {                
                if (e.KeyData == Keys.Enter)
                {
                    validar.validationTxtField(txtEfectivo, validar.numberDecimalRGX);
                    double t, ef;
                    t = Convert.ToDouble(lblTotal.Text);
                    ef = Convert.ToDouble(txtEfectivo.Text);
                    if (ef >= t)
                    {
                        btnCobrar.Focus();
                    }
                    else MessageBox.Show("El efectivo no puede ser menor que el total");
                }
                else if (e.KeyData == Keys.Up)
                {
                    txtEfectivo.Text = (Convert.ToDouble(txtEfectivo.Text) + 0.50).ToString("N2") + "";
                }
                else if (e.KeyData == Keys.Down)
                {
                    txtEfectivo.Text = (Convert.ToDouble(txtEfectivo.Text) - 0.50).ToString("N2") + "";
                }
                else if (e.KeyData == Keys.Escape) this.ParentForm.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Necesita ingresar el precio");
            }
            
            
        }
        private void btnCobrar_Enter(object sender, EventArgs e)
        {
            btnCobrar.BackColor = Color.FromArgb(178, 186, 187);
            btnRegistrar.BackColor = Color.WhiteSmoke;
            btnCancelar.BackColor = Color.WhiteSmoke;
        }        
        private void btnRegistrar_Enter(object sender, EventArgs e)
        {
            btnCobrar.BackColor = Color.WhiteSmoke;
            btnRegistrar.BackColor = Color.FromArgb(178, 186, 187);
            btnCancelar.BackColor = Color.WhiteSmoke;
        }
        private void btnCancelar_Enter(object sender, EventArgs e)
        {
            btnCobrar.BackColor = Color.WhiteSmoke;
            btnRegistrar.BackColor = Color.WhiteSmoke;
            btnCancelar.BackColor = Color.FromArgb(178, 186, 187);
        }
        private void btnCobrar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Space) cierto = true;            
            else if (e.KeyValue == (char)Keys.Escape) this.ParentForm.Close();
        }
        private void btnRegistrar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Space) cierto = true;
            else if (e.KeyValue == (char)Keys.Escape) this.ParentForm.Close();
        }
        private void btnCancelar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Space) cierto = true;
            else if (e.KeyValue == (char)Keys.Escape) this.ParentForm.Close();
        }
        private void txtEfectivo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double total, efectivo;
                total = Convert.ToDouble(lblTotal.Text);
                efectivo = Convert.ToDouble(txtEfectivo.Text);
                if (efectivo >= total)
                {
                    lblCambio.Text = (efectivo - total).ToString("N2");
                    btnCobrar.Enabled = true;
                    btnRegistrar.Enabled = true;
                    btnCancelar.Enabled = true;
                }
                else
                {
                    lblCambio.Text = "0.00";
                    btnCobrar.Enabled = false;
                    btnRegistrar.Enabled = false;
                    btnCancelar.Enabled = false;
                }

            }
            catch (Exception ex) 
            {
                btnCobrar.Enabled = false;
                btnRegistrar.Enabled = false;
                btnCancelar.Enabled = false;
            }
        }
        private void btnCobrar_Click(object sender, EventArgs e)
        {
            Cobrar cob = new Cobrar();

            try
            {
                if (!cierto)
                {
                    total = Convert.ToDecimal(lblTotal.Text);
                    efectivo = Convert.ToDecimal(txtEfectivo.Text);
                    cambio = Convert.ToDecimal(lblCambio.Text);
                    cob.imprimirticket(total, efectivo, cambio, "AL CONTADO", av);
                    Cobrar.aceptar = true;
                    ingreso();
                    Ventas.cierto = true;
                    this.ParentForm.Close();                    
                }                
                cierto = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Cobrar cob = new Cobrar();
            try
            {
                if (!cierto)
                {
                    total = Convert.ToDecimal(lblTotal.Text);
                    efectivo = Convert.ToDecimal(txtEfectivo.Text);
                    cambio = Convert.ToDecimal(lblCambio.Text);
                    ingreso();
                    Cobrar.aceptar = true;
                    Ventas.cierto = true;
                    this.ParentForm.Close();
                }                
                cierto = false;
            }            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (!cierto)
                this.ParentForm.Close();
            cierto = false;
        }
        private void lblTotal_TextChanged(object sender, EventArgs e)
        {
            lblTotal.Left = (panel3.Width - lblTotal.Width) / 2;
        }
        private void btnCobrar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Tab)
            {
                btnCobrar.BackColor = Color.WhiteSmoke;
                txtEfectivo.Focus();
            }
        }
        #endregion
    }
}
