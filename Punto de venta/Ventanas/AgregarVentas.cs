using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Punto_de_venta.Base_de_datos;
using Punto_de_venta.Clases;

namespace Punto_de_venta
{
    public partial class AgregarVentas : Form
    {
        public double canti { get; set; }
        List<Articulo> ar;
        ClassValidation Validation = new ClassValidation();
        public Art artsele = new Art();
        public Art art { get; set; }
        private String CellValue;
        int c;

        #region //Métodos
        public AgregarVentas()
        {
            InitializeComponent();
            cargartabla();
            txtCantidad.Select();
        }
        public void cargartabla()
        {
            ar = BDArticulo.tabla();
            foreach (Articulo item in ar)
            {
                dgvProductos.Rows.Add(item.Id, item.Nombre, item.Descripcion, item.Precio, item.Stock);
            }
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
        public void aceptar()
        {
            try
            {
                if (Convert.ToDouble(txtCantidad.Text) == 0)
                    throw new Exception("El campo cantidad no debe ser cero");
                else if (Convert.ToDouble(txtCantidad.Text) > Convert.ToDouble(dgvProductos[4, c].Value))
                    throw new Exception("Inventario insuficiente");
                artsele.Nombre = dgvProductos[1, c].Value.ToString();
                artsele.Descripcion = dgvProductos[2, c].Value.ToString();
                artsele.Cantidad = Convert.ToDouble(txtCantidad.Text);
                artsele.Precio = Convert.ToDouble(dgvProductos[3, c].Value);
                artsele.existencia = Convert.ToDouble(dgvProductos[4, c].Value);
                art = artsele;
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
            if (!string.IsNullOrWhiteSpace(txtCantidad.Text))
                ca = Convert.ToDouble(txtCantidad.Text);
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
        public void recorrertabla(int n)
        {
            try
            {
                c = dgvProductos.SelectedRows[0].Index;
                dgvProductos.Rows[c + n].Selected = true;
            }
            catch (Exception ex)
            {

            }
        } 
        #endregion

        #region //Eventos
        private void btnCancelar_MouseUp(object sender, EventArgs e)
        {            
            this.Close();
        }
        private void btnGuardar_MouseUp(object sender, EventArgs e)
        {
            aceptar();
        }        
        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) e.Handled = true;
            Validation.validationNumber(e);
            Validation.DesactivarTeclado(txtCantidad, 10, e);
        }
        private void dgvVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvProductos.CurrentRow;
            CellValue = Convert.ToString(row.Cells["Stock"].Value);
        }        
        private void tmContador2_Tick(object sender, EventArgs e)
        {
            try
            {
                double pre, can;
                if (tmContador2.Interval == 1000)
                {
                    pre = Convert.ToDouble(dgvProductos[3, c].Value);
                    can = double.Parse(txtCantidad.Text);
                    txtPrecio.Text = (pre * can).ToString("N2");
                    txtCantidad.Text = can.ToString("N3");
                    txtCantidad.Select(0, txtCantidad.Text.Length);
                    tmContador2.Stop();
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void tmContador_Tick(object sender, EventArgs e)
        {
            try
            {
                if (tmContador.Interval == 1000)
                {
                    txtCantidad.Text = (Convert.ToDouble(txtPrecio.Text) / Convert.ToDouble(dgvProductos[3,c].Value)).ToString("N3");
                    txtPrecio.Text = Convert.ToDouble(txtPrecio.Text).ToString("N2");
                    txtPrecio.Select(0, txtPrecio.Text.Length);
                    tmContador.Stop();
                }
            }
            catch (Exception ex)
            {


            }
        }
        private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            inicia2();
            switch (e.KeyData)
            {
                case Keys.Enter:
                    { aceptar(); }
                    break;
                case Keys.Up:
                    {
                        try
                        {
                            recorrertabla(-1);
                            txtCantidad.Text = "1.000";
                            c -= 1;
                            txtPrecio.Text = Convert.ToDouble(dgvProductos[3,c].Value).ToString("N2");
                            txtCantidad.Select(0,txtCantidad.Text.Length);
                        }                        
                        catch(Exception ex) { c++; }
                        
                    }
                    break;
                case Keys.Down:
                    {
                        try
                        {
                            recorrertabla(1);
                            txtCantidad.Text = "1.000";
                            c += 1;
                            txtPrecio.Text = Convert.ToDouble(dgvProductos[3,c].Value).ToString("N2");
                            txtCantidad.Select(0, txtCantidad.Text.Length);
                        }                       
                        catch (Exception ex) { c--; }
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
                    { txtCantidad.Select(); }
                    break;
                case Keys.Up:
                    {
                        try
                        {
                            recorrertabla(-1);
                            c -= 1;
                            double cantida = Convert.ToDouble(dgvProductos[3, c].Value);
                            txtPrecio.Text = cantida.ToString("N2");
                            txtCantidad.Text = "1.000";
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    break;
                case Keys.Down:
                    {
                        try
                        {
                            recorrertabla(1);
                            c += 1;
                            double cantida = Convert.ToDouble(dgvProductos[3, c].Value);
                            txtPrecio.Text = cantida.ToString("N2");
                            txtCantidad.Text = "1.000";
                        }
                        catch (Exception ex)
                        {

                        }
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
        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) e.Handled = true;
            Validation.validationNumber(e);
            Validation.DesactivarTeclado(txtPrecio, 10, e);
        }
        private void dgvProductos_Click(object sender, EventArgs e)
        {
            c = dgvProductos.CurrentRow.Index;
            double precio = double.Parse(dgvProductos[3,c].Value+"");
            txtPrecio.Text = precio.ToString("N2");
            txtCantidad.Focus();
        }
        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            if (txtCantidad.Focused && !string.IsNullOrWhiteSpace(txtCantidad.Text))
            {
                double cantida = double.Parse(txtCantidad.Text);
                txtPrecio.Text = (double.Parse(dgvProductos[3,c].Value+"") * cantida).ToString("N2");
                //txtCantidd.SelectAll();
            }
        }
        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {
            if (txtPrecio.Focused && !string.IsNullOrWhiteSpace(txtPrecio.Text))
            {
                double cantidad = double.Parse(txtCantidad.Text);
                txtCantidad.Text = (Convert.ToDouble(txtPrecio.Text) / double.Parse(dgvProductos[3, c].Value + "")).ToString("N3");
            }
        }
        #endregion

    }
}