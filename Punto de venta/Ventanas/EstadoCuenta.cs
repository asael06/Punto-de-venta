using Punto_de_venta.Base_de_datos;
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
    public partial class EstadoCuenta : Form
    {
        public int id { get; set; }
        List<string> fechas;
        List<Cuenta> c;
        string ab;
        double total;
        public EstadoCuenta()
        {
            InitializeComponent();                
        }

        #region //Métodos
        public void cargar()
        {
            total = BDCuenta.RetornarCuenta(id);
            dgvFechas.Rows.Clear();
            dgvProductos.Rows.Clear();
            fechas = BDCuenta.fechas(id);
            c = BDCuenta.cuenta(id);
            lblTotalX.Text = total.ToString("N2");
            foreach (var item in fechas)
            {
                dgvFechas.Rows.Add(item);
            }
            if(dgvFechas.RowCount>0)
                selecFecha(dgvFechas.CurrentRow.Cells[0].Value.ToString());
            dgvFechas.Select();
        }
        public void selecFecha(string f)
        {
            dgvProductos.Rows.Clear();            
            DateTime fe = Convert.ToDateTime(f);
            foreach (var item in c)
            {
                if (item.Fecha.Equals(fe.ToString("yyyy-MM-dd")))
                {
                    dgvProductos.Rows.Add(item.Articulo, item.Importe, item.Cantidad, item.Monto);
                }            
            }
            dgvProductos.Select();
            lblTotalX.Left = (panel4.Width - lblTotalX.Width) / 2;
        }
        public void liquidar()
        {
            if (dgvFechas.RowCount > 0)
                if (MessageBox.Show("¿Está seguro de liquidar esta cuenta?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                BDCuenta.TicketEliminar(id);
                BDCuenta.CuentaActualizar(id,0);
                BDAbono.AbonoEliminar(id);                
                ingreso("Liquidación",lblTotalX.Text);
                cargar();
            }
        }
        public void abonar()
        {
            if (dgvFechas.RowCount > 0)
                if (MessageBox.Show("¿Está seguro de confirmar este abono?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Abonos abc = new Abonos();
                abc.ShowDialog();
                //MessageBox.Show(abc.abo+"");
                if (abc.abo != null)
                {
                    ab = abc.abo;
                    ingreso("Abono", ab);
                    abono(ab);
                    cargar();
                }
            }
        }
        public void abono(string monto)
        {
            Abono a = new Abono();            
            a.Id = id;
            a.Monto = double.Parse(monto);
            a.Fecha = DateTime.Now.ToString("yyyy-MM-dd");
            BDCuenta.CuentaActualizar(id,(total-a.Monto));
            BDAbono.AbonoNuevo(a);
        }
        public void ingreso(string tipo,string monto)
        {
            int[] ids = BDIngresos.ArrIngresosId().ToArray();
            Ingresos ing = new Ingresos(regresarId(ids, BDIngresos.idMax()), tipo, Convert.ToDouble(monto), DateTime.Now.Date.ToString("yyyy-MM-dd"), BDLogeado.retornaLogeado());
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
        public void historial()
        {
            Historial h = new Historial();
            h.id = id;
            h.ShowDialog();
        }        
        #endregion

        #region //Eventos
        private void btnCerrar_MouseUp(object sender, EventArgs e)
        {            
            this.Close();
        }
        private void btnLiquidar_MouseUp(object sender, EventArgs e)
        {
            liquidar();
        }
        private void EstadoCuenta_Load(object sender, EventArgs e)
        {
            //if(fechas!=null)
                cargar();
        }
        private void dgvFechas_Click(object sender, EventArgs e)
        {
            if (dgvFechas.RowCount > 0)
                selecFecha(dgvFechas.CurrentRow.Cells[0].Value.ToString());
            dgvProductos.Select();
        }
        private void btnAbonar_MouseUp(object sender, EventArgs e)
        {            
                abonar();
        }
        private void btnHistorial_MouseUp(object sender, EventArgs e)
        {
            historial();
        }
        private void dgvFechas_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Left:
                    dgvProductos.Select();
                    break;
                case Keys.Right:
                    dgvProductos.Select();
                    break;
                case Keys.F12:
                    historial();
                    break;
                case Keys.Add:
                    abonar();
                    break;
                case Keys.Delete:
                    liquidar();
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
                case Keys.Enter:
                    {
                        e.SuppressKeyPress = true;
                        selecFecha(dgvFechas.CurrentRow.Cells[0].Value.ToString());
                        dgvFechas.Select();
                    }
                    break;
            }
        }
        private void dgvProductos_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Left:
                    dgvFechas.Select();
                    break;
                case Keys.Right:
                    dgvFechas.Select();
                    break;
                case Keys.F12:
                    historial();
                    break;
                case Keys.Add:
                    abonar();
                    break;
                case Keys.Delete:
                    liquidar();
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }        
        #endregion

    }
}
