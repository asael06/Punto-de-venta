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
using Punto_de_venta.Ventanas;

namespace Punto_de_venta
{
    public partial class Ventas : UserControl
    {
        public void columnas()
        {
            dgvVentas.Columns[0].Width = 30;
            dgvVentas.Columns[1].Width = 100;
            dgvVentas.Columns[2].Width = 150;
            dgvVentas.Columns[3].Width = 50;
            dgvVentas.Columns[4].Width = 100;
        }
        public Ventas()
        {
            InitializeComponent();           
        }
        public List<ArticuloVendido> av;
        int c;
        public static bool cierto;
        ClassValidation Validation = new ClassValidation();
        #region //Métodos
        public void agregar()
        {
            if (BDArticulo.haydatos())
            {
                AgregarVentas v = new AgregarVentas();
                v.ShowDialog();
                if (v.art != null)
                {
                    Art articuloActual = v.art;
                    int e = existe(articuloActual.Nombre);
                    if (e < 0)
                    {
                        dgvVentas.Rows.Add(articuloActual.Nombre, articuloActual.Descripcion, articuloActual.Cantidad, articuloActual.Precio, (articuloActual.Cantidad * articuloActual.Precio), articuloActual.existencia);
                        txtCB.Focus();
                    }
                    else
                    {
                        if (Convert.ToDouble(dgvVentas[2, e].Value) + articuloActual.Cantidad <= Convert.ToDouble(dgvVentas[5, e].Value))
                        {
                            dgvVentas[2, e].Value = Convert.ToDouble(dgvVentas[2, e].Value) + articuloActual.Cantidad;
                        }
                        else MessageBox.Show("Inventario insuficiente");
                    } 
                }
            }
        }
        public void venta()
        {

            try
            {
                Cobrar co = new Cobrar();
                co.total = Convert.ToDecimal(txtTotal.Text);
                cobra();
                co.ar = av;
                co.ShowDialog();
                if (Cobrar.aceptar)
                {
                    MessageBox.Show("Venta realizada con éxito");
                    actualizarStock();
                    cancelar();
                }
                txtCB.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void quitar()
        {        
            if(dgvVentas.RowCount>0)    
            try
            {
                if (MessageBox.Show("¿Seguro que desea quitar este producto?", "Salir", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    dgvVentas.Rows.RemoveAt(dgvVentas.SelectedRows[0].Index);                        
                    total();
                    if (dgvVentas.RowCount == 0)
                    {
                        cancelar();
                    }
                    dgvVentas[0, 0].Selected = true;
                    txtCB.Focus();
                }
            }
            catch (Exception)
            {

            }
        }
        public void cobra()
        {
            av = new List<ArticuloVendido>();
            for (int i=0;i<dgvVentas.RowCount;i++)
            {
                ArticuloVendido ac = new ArticuloVendido(dgvVentas[1, i].Value.ToString(), Convert.ToDecimal(dgvVentas[2, i].Value), Convert.ToDecimal(dgvVentas[3, i].Value), Convert.ToDecimal(dgvVentas[4, i].Value));
                av.Add(ac);
            }            
        }
        public void total()
        {
            int ren = dgvVentas.RowCount;
            double suma = 0;
            for (int i = 0; i < ren; i++)
            {
                suma += (Convert.ToDouble(dgvVentas[4, i].Value));
            }
            txtTotal.Text = suma.ToString("N2") + "";            
        }
        public void cancelar()
        {
            txtTotal.Text = "0.00";                 
            dgvVentas.Rows.Clear();
            txtCB.Focus();
        }
        public void agregarCB()
        {
            try
            {
                Validation.noExiste(txtCB.Text);
                Cantidad c = new Cantidad();
                Articulo a = BDArticulo.obtenerArticulo(txtCB.Text);
                c.a = a;
                int e = existe(a.Nombre);
                if (e == -1)
                {  
                    c.ShowDialog();
                    if (c.canti > 0)
                    {
                        if (c.canti <= a.Stock)
                        {
                            dgvVentas.Rows.Add(a.Nombre, a.Descripcion, c.canti, a.Precio, c.canti * a.Precio, a.Stock);
                            txtCB.Focus();
                        }
                        else MessageBox.Show("Inventario insuficiente");
                    }
                }
                else
                {
                    c.ShowDialog();
                    if (c.canti > 0)
                        if(c.canti + Convert.ToDouble(dgvVentas[2, e].Value) <= a.Stock)
                        dgvVentas[2, e].Value = Convert.ToDouble(dgvVentas[2, e].Value) + c.canti;
                        else MessageBox.Show("Inventario insuficiente");
                } 

                txtCB.Clear();
        }
            catch (Exception ex)
            {
                    MessageBox.Show(ex.Message);
                    txtCB.Clear();
                    txtCB.Focus();
            }

}
        public void actualizarStock()
        {
            double sa, ca, resta;
            int rows = dgvVentas.RowCount;
            for (int i = 0; i < rows; i++)
            {
                sa = 0;
                ca = 0;
                resta = 0;
                sa = BDArticulo.mostrarStock(dgvVentas[0, i].Value+"");
                ca = Convert.ToInt32(dgvVentas[2, i].Value);
                resta = sa - ca;
                BDArticulo.actualizarStock(resta, dgvVentas[0, i].Value+"");
            }
        }
        public int existe(string id)
        {
            int c = -1;
            if (dgvVentas != null)
            {
                for (int i = 0; i < dgvVentas.RowCount; i++)
                    if (id.Equals(dgvVentas[0, i].Value.ToString())) { c = i; break; }
            }
            return c;

        }
        public void recorrertabla(int n)
        {            
            try
            {
                c = dgvVentas.SelectedRows[0].Index;
                dgvVentas.Rows[c + n].Selected = true;                              
            }
            catch (Exception ex)
            {

            }
        }        
        #endregion
        #region //Eventos
        private void btnAgregar_MouseUp(object sender, EventArgs e)
        {
            agregar();            
        }
        private void btnQuitar_MouseUp(object sender, EventArgs e)
        {
            quitar();
        }
        private void dgvVentas_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {                    
            total();
            txtTotal.Left = (panel2.Width - txtTotal.Width) / 2;
        }
        private void btnCancelar_MouseUp(object sender, EventArgs e)
        {
            cancelar();     
        }
        private void btnAceptar_MouseUp(object sender, EventArgs e)
        {
            if (dgvVentas.RowCount > 0)            
                venta();        
        }
        private void txtCB_KeyDown(object sender, KeyEventArgs e)
        {             
            switch (e.KeyData)
            {
                case Keys.Enter: { agregarCB(); }
                    break;
                case Keys.Up: { recorrertabla(-1); }
                    break;
                case Keys.Down: { recorrertabla(1); }
                    break;
                case Keys.Delete: { quitar(); }
                    break;
                case Keys.Escape: { cancelar(); }
                    break;
                case Keys.Add: { agregar(); }
                    break;
                case Keys.F12: { if (dgvVentas.RowCount > 0) venta(); }
                    break;               
                default: { }
                    break;
            }
        }       
        private void txtCB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) { e.Handled = true; }
            else if (e.KeyChar == (char)Keys.Escape) { e.Handled = true; }
            else if (e.KeyChar == (char)Keys.F12) { txtCB.Focus(); }
            else if (!char.IsLetterOrDigit(e.KeyChar)) { e.Handled = e.KeyChar != (char)Keys.Back; }            
            else { }
        }
        private void btnSalida_MouseUp(object sender, EventArgs e)
        {
            Caja c = new Caja();
            c.ShowDialog();            
        }
        private void bunifuFlatButton1_MouseUp(object sender, EventArgs e)
        {
            CajaInicial c = new CajaInicial();
            c.ShowDialog();            
        }
        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void dgvVentas_Click(object sender, EventArgs e)
        {
            if(dgvVentas.RowCount>0)
            c = dgvVentas.CurrentRow.Index;
            txtCB.Focus();
        }
        private void btnAceptar_Enter(object sender, EventArgs e)
        {
            btnAceptar.BackColor = Color.FromArgb(178, 186, 187);
            btnAgregar.BackColor = Color.WhiteSmoke;
            btnCancelar.BackColor = Color.WhiteSmoke;
            btnQuitar.BackColor = Color.WhiteSmoke;
        }
        private void btnCancelar_Enter(object sender, EventArgs e)
        {
            btnCancelar.BackColor = Color.FromArgb(178, 186, 187);
            btnAgregar.BackColor = Color.WhiteSmoke;
            btnAceptar.BackColor = Color.WhiteSmoke;
            btnQuitar.BackColor = Color.WhiteSmoke;
        }
        private void btnQuitar_Enter(object sender, EventArgs e)
        {
            btnQuitar.BackColor = Color.FromArgb(178, 186, 187);
            btnAgregar.BackColor = Color.WhiteSmoke;
            btnCancelar.BackColor = Color.WhiteSmoke;
            btnAceptar.BackColor = Color.WhiteSmoke;
        }
        private void btnAgregar_Enter(object sender, EventArgs e)
        {
            btnAgregar.BackColor = Color.FromArgb(178, 186, 187);
            btnAceptar.BackColor = Color.WhiteSmoke;
            btnCancelar.BackColor = Color.WhiteSmoke;
            btnQuitar.BackColor = Color.WhiteSmoke;
        }
        private void btnCajaInicial_MouseUp(object sender, EventArgs e)
        {
            CajaInicial c = new CajaInicial();
            c.ShowDialog();
        }
        private void btnSalida_MouseUp_1(object sender, EventArgs e)
        {
            Caja c = new Caja();
            c.ShowDialog();
        }
        #endregion
    }
}
