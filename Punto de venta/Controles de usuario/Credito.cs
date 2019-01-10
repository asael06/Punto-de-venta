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
using Punto_de_venta.Base_de_datos;

namespace Punto_de_venta.Controles_de_Usuario
{
    public partial class Credito : UserControl
    {
        List<Cliente> lista;
        public List<ArticuloVendido> av { get; set; }
        int c;
        public Credito()
        {
            InitializeComponent();
            
        }
        public bool cierto = false;
        public decimal total, efectivo, cambio;
        Cobrar cob;
        #region //Métodos
        public void recorrertabla(int n)
        {
            c = dgvClientes.SelectedRows[0].Index;
            try
            {
                dgvClientes.Rows[c + n].Selected = true;
            }
            catch (Exception ex)
            {

            }
        }
        public void buscar(string txt)
        {
            dgvClientes.Rows.Clear();
            foreach (Cliente cli in lista)
            {
                if (cli.Nombre.ToUpper().IndexOf(txt) != -1)
                {
                    dgvClientes.Rows.Add(cli.Id, cli.Nombre);
                }
            }
        }
        public void cargar()
        {
            lista = BDCliente.Tabla();
            foreach (Cliente item in lista)
            {
                dgvClientes.Rows.Add(item.Id, item.Nombre);
            }
        }
        public void cobrarConTicket()
        {
            cob = new Cobrar();

            try
            {
                if (!cierto)
                {
                    total = Convert.ToDecimal(lblTotal.Text);
                    efectivo = 0;
                    cambio = 0;                    
                    cob.imprimirticket(total, efectivo, cambio, dgvClientes[1,c].Value.ToString(), av);
                    Cobrar.aceptar = true;                    
                    this.ParentForm.Close();
                }
                cierto = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void soloCobrar()
        {
            Cobrar cob = new Cobrar();

            try
            {
                if (!cierto)
                {
                    total = Convert.ToDecimal(lblTotal.Text);                    
                    Cobrar.aceptar = true;
                    this.ParentForm.Close();
                }
                cierto = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void generaCuenta()
        {
            try
            {                
                int id = int.Parse(dgvClientes[0, c].Value+"");
                double cu = BDCuenta.RetornarCuenta(id),total=0;
                string fecha = DateTime.Now.ToString("yyyy-MM-dd");

                foreach  (ArticuloVendido item in av)
                {
                    BDCuenta.CuentaNueva(id,item,fecha);
                    total += Convert.ToDouble(item.total);
                }
                BDCuenta.CuentaActualizar(id,(total+cu));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        #endregion
     
        #region //Eventos
        private void txtBuscarcliente_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Enter:
                    btnCobrar.Select();
                    break;
                case Keys.Up: { recorrertabla(-1); c -= 1; }
                    break;
                case Keys.Down: { recorrertabla(1); c += 1; }
                    break;
                case Keys.Escape: { this.ParentForm.Close(); }
                    break;
                default: { }
                    break;
            }
        }
        private void txtBuscarcliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter|| e.KeyChar == (char)Keys.Escape) e.Handled = true;
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
        private void btnCobrar_Click(object sender, EventArgs e)
        {
            if (!cierto)
            {
                cobrarConTicket();
                generaCuenta();
                Cobrar.aceptar = true;
                Ventas.cierto = true;
                this.ParentForm.Close();
            }
            cierto = false;
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!cierto)
            {
                soloCobrar();                
                generaCuenta();
                Cobrar.aceptar = true;
                Ventas.cierto = true;
                this.ParentForm.Close();
            }
            cierto = false;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (!cierto)
                this.ParentForm.Close();
            cierto = false;
        }
        private void btnCobrar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Space) { }
            else if (e.KeyValue == (char)Keys.Escape) this.ParentForm.Close();
        }
        private void btnRegistrar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Space) cierto = true;
            else if (e.KeyValue == (char)Keys.Escape) this.ParentForm.Close();
        }
        private void dgvClientes_Click(object sender, EventArgs e)
        {
            c = dgvClientes.CurrentRow.Index;
            txtBuscarcliente.Focus();
        }
        private void Credito_Load(object sender, EventArgs e)
        {
            cargar();
        }
        private void btnCancelar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Space) cierto = true;
            else if (e.KeyValue == (char)Keys.Escape) this.ParentForm.Close();
        }
        private void txtBuscarcliente_TextChanged(object sender, EventArgs e)
        {
            try
            {
                buscar(txtBuscarcliente.Text);
            }
            catch (Exception ex)
            {
                cargar();                
            }
        }
        #endregion
    } 
}
