using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Punto_de_venta.Clases;

namespace Punto_de_venta.Ventanas
{
    public partial class Cantidad : Form
    {
        ClassValidation Validation = new ClassValidation();
        public Articulo a { get; set; }
        public double canti { get; set; }

        #region Métodos
        public Cantidad()
        {
            InitializeComponent();
        }
        public void aceptar()
        {
            try
            {
                canti = Convert.ToDouble(txtCantidd.Text);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public double cantidad(double cantidad)
        {
            double ca = 0;
            if (!string.IsNullOrWhiteSpace(txtCantidd.Text))
                ca = Convert.ToDouble(txtCantidd.Text);
            ca += cantidad;
            return ca;
        }
        public double precio(double precio)
        {
            double pr = 0;
            if (!string.IsNullOrWhiteSpace(txtPrecio.Text))
                pr = Convert.ToDouble(txtPrecio.Text);
            pr += precio;
            return pr;
        }
        public void carga()
        {
            lblProducto.Text = a.Descripcion;
            txtPrecio.Text = a.Precio.ToString("N2");
            lblStock.Text = a.Stock.ToString("N3");
        }
        public void inicia()
        {
            tmContador.Stop();
            tmContador.Start();
        }
        public void inicia2()
        {
            tmContador2.Stop();
            tmContador2.Start();
        }
        #endregion

        #region Eventos
        private void Cantidad_Load(object sender, EventArgs e)
        {
            carga();
            lblProducto.Left = (panel1.Width - lblProducto.Width) / 2;
            lblStock.Left = (panel1.Width - lblStock.Width) / 2;
        }
        private void tmContador_Tick(object sender, EventArgs e)
        {
            try
            {
                if (tmContador.Interval == 1000)
                {
                    txtCantidd.Text = (Convert.ToDouble(txtPrecio.Text) / a.Precio).ToString("N3");
                    txtPrecio.Text = Convert.ToDouble(txtPrecio.Text).ToString("N2");
                    txtPrecio.Select(0, txtPrecio.Text.Length);
                    tmContador.Stop();
                }
            }
            catch (Exception ex)
            {


            }
        }
        private void tmContador2_Tick(object sender, EventArgs e)
        {
            try
            {
                double pre, can;
                if (tmContador2.Interval == 1000)
                {
                    pre = a.Precio;
                    can = double.Parse(txtCantidd.Text);
                    txtPrecio.Text = (pre * can).ToString("N2");
                    txtCantidd.Text = can.ToString("N3");
                    txtCantidd.Select(0, txtCantidd.Text.Length);
                    tmContador2.Stop();
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void btnGuardar_MouseUp(object sender, EventArgs e)
        {
            aceptar();
        }
        private void txtCantidd_KeyDown(object sender, KeyEventArgs e)
        {
            inicia2();
            switch (e.KeyData)
            {
                case Keys.Enter:
                    { aceptar(); }
                    break;
                case Keys.Up:
                    {
                        double cantida = cantidad(0.25);
                        txtCantidd.Text = cantida.ToString("N3");
                        txtPrecio.Text = (a.Precio * cantida).ToString("N2");
                        txtCantidd.SelectAll();
                    }
                    break;
                case Keys.Down:
                    {
                        double cantida = cantidad(-0.25);
                        txtCantidd.Text = cantida.ToString("N3");
                        txtPrecio.Text = (a.Precio * cantida).ToString("N2");
                    }
                    break;
                case Keys.Escape:
                    { this.Close(); }
                    break;
                default:
                    break;
            }
        }
        private void txtPrecio_KeyDown(object sender, KeyEventArgs e)
        {
            inicia();
            switch (e.KeyData)
            {
                case Keys.Enter:
                    { txtCantidd.Select(); }
                    break;
                case Keys.Up:
                    {
                        double cantida = precio(0.50);
                        txtPrecio.Text = cantida.ToString("N2");
                        txtCantidd.Text = (Convert.ToDouble(txtPrecio.Text) / a.Precio).ToString("N3");
                    }
                    break;
                case Keys.Down:
                    {
                        double cantida = precio(-0.5);
                        txtPrecio.Text = cantida.ToString("N2");
                        txtCantidd.Text = (Convert.ToDouble(txtPrecio.Text) / a.Precio).ToString("N3");
                    }
                    break;
                case Keys.Escape:
                    { this.Close(); }
                    break;
                default:
                    { }
                    break;
            }
        }
        private void txtPrecio_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtPrecio.Text))
                {
                    txtCantidd.Text = (Convert.ToDouble(txtPrecio.Text) / a.Precio).ToString("N3");
                    txtPrecio.Text = Convert.ToDouble(txtPrecio.Text).ToString("N2");
                }
                else txtPrecio.Text = (Convert.ToDouble(txtCantidd.Text) * a.Precio).ToString("N2");
            }
            catch (Exception ex)
            {
            }

        }
        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validation.validationNumber(e);
            Validation.DesactivarTeclado(txtPrecio, 10, e);
        }
        private void txtCantidd_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validation.validationNumber(e);
            Validation.DesactivarTeclado(txtCantidd, 10, e);
        }
        private void txtCantidd_TextChanged(object sender, EventArgs e)
        {
            if (txtCantidd.Focused && !string.IsNullOrWhiteSpace(txtCantidd.Text))
            {
                double cantida = double.Parse(txtCantidd.Text);
                txtPrecio.Text = (a.Precio * cantida).ToString("N2");
                //txtCantidd.SelectAll();
            }
        }
        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {
            if (txtPrecio.Focused && !string.IsNullOrWhiteSpace(txtPrecio.Text))
            {
                double cantidad = double.Parse(txtCantidd.Text);
                txtCantidd.Text = (Convert.ToDouble(txtPrecio.Text) / a.Precio).ToString("N3");
            }
        } 
        #endregion
    }
}
