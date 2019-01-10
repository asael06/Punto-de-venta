using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Punto_de_venta.Clases;
using Punto_de_venta.Base_de_datos;
using Punto_de_venta.Ventanas;

namespace Punto_de_venta
{
    public partial class Registro : UserControl
    {
        public Registro()
        {
            InitializeComponent();
        }
        ClassValidation validar = new ClassValidation();
        DateTime inicio, fin;
        List<Ingresos> ing;
        int c;
        #region Métodos
        public void cargar()
        {
            dgvRegistro.Rows.Clear();
            ing = BDIngresos.TablaIngresos();
            foreach (Ingresos item in ing)
            {                
                dgvRegistro.Rows.Add(item.Id, item.Concepto, item.Monto, Convert.ToDateTime(item.Fecha).ToString("dd-MM-yyyy"), item.Vendedor);
            }
            calcular();
        }
        public void cargarActual()
        {
            dgvRegistro.Rows.Clear();
            DateTime fecha = new DateTime(DateTime.Now.Year, DateTime.Now.Month,DateTime.Now.Day);
            foreach (Ingresos item in ing)
            {
                if (DateTime.Compare(Convert.ToDateTime(item.Fecha),fecha) == 0)
                 dgvRegistro.Rows.Add(item.Id, item.Concepto, item.Monto, Convert.ToDateTime(item.Fecha).ToString("dd-MM-yyyy"), item.Vendedor);
            }
            calcular();
        }
        public void agregarPorFecha()
        {
            dgvRegistro.Rows.Clear();
            foreach (var item in ing)
            {
                if (DateTime.Compare(Convert.ToDateTime(item.Fecha), inicio) >= 0 && DateTime.Compare(Convert.ToDateTime(item.Fecha), fin) <= 0) dgvRegistro.Rows.Add(item.Id, item.Concepto, item.Monto, Convert.ToDateTime(item.Fecha).ToString("dd-MM-yyyy"), item.Vendedor);
            }
        }        
        public void buscarId(string id)
        {
            dgvRegistro.Rows.Clear();
            foreach (var item in ing)
            {
                if (item.Id.ToString().IndexOf(id) != -1) dgvRegistro.Rows.Add(item.Id, item.Concepto, item.Monto, Convert.ToDateTime(item.Fecha).ToString("dd-MM-yyyy"), item.Vendedor);
            }
        }
        public void eliminarRegistro()
        {
            if(dgvRegistro.RowCount>0)
            if (MessageBox.Show("¿Está seguro de eliminar este registro?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (!BDLogeado.retorarRol().Equals("Administrador"))
                {
                    Confirmar confi = new Confirmar();
                    confi.ShowDialog();
                    if (confi.cierto)
                    {
                        BDIngresos.IngresoEliminar(dgvRegistro.CurrentRow.Cells[0].Value + "");
                        MessageBox.Show("Registro eliminado con éxito");
                        cargar();
                    }
                }
                else
                {
                    BDIngresos.IngresoEliminar(dgvRegistro.CurrentRow.Cells[0].Value + "");
                    MessageBox.Show("Registro eliminado con éxito");
                    cargar();
                }
            }
        }
        public void eliminarTodo()
        {
            if (dgvRegistro.RowCount > 0)
                if (MessageBox.Show("¿Está seguro de eliminar todo el registro?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (!BDLogeado.retorarRol().Equals("Administrador"))
                {
                    Confirmar confi = new Confirmar();
                    confi.ShowDialog();
                    if (confi.cierto)
                    {
                        BDIngresos.eliminarregistro();
                        MessageBox.Show("Se eliminó todo el registro con éxito");
                        cargar();
                    }
                }
                else
                {
                    BDIngresos.eliminarregistro();
                    MessageBox.Show("Se eliminó todo el registro con éxito");
                    cargar();
                }
            }
        }
        public void recorrertabla(int n)
        {
            try
            {
                c = dgvRegistro.SelectedRows[0].Index;
                dgvRegistro.Rows[c + n].Selected = true;
            }
            catch (Exception ex)
            {

            }
        }
        public void fechas()
        {
            FiFf f = new FiFf();
            f.ShowDialog();
            if (f.cierto)
            {
                inicio = f.Fi;
                fin = f.Ff;
                agregarPorFecha();
                
            }
            calcular();
        }
        public void exportar()
        {
            if (dgvRegistro.RowCount > 0)
            {
                ReporteVentas rv = new ReporteVentas();
                rv.ar = ing;
                rv.ShowDialog();
                txtBuscarId.Focus(); 
            }
        }
        public void calcular()
        {
            double suma = 0;
            for (int i = 0; i < dgvRegistro.Rows.Count; i++)
            {
                suma += float.Parse(dgvRegistro[2,i].Value+"");
            }
            lblTotal.Text = suma + "";
        }
        #endregion
        #region Eventos
        private void Registro_Load(object sender, EventArgs e)
        {
            cargar();            
        }
        private void btnRecargar_MouseUp(object sender, EventArgs e)
        {
            cargar();           
        }
        private void btnEliminar_MouseUp(object sender, EventArgs e)
        {
            eliminarRegistro();
            txtBuscarId.Focus();
        }
        private void btnEliminarTodo_MouseUp(object sender, EventArgs e)
        {
            eliminarTodo();
            txtBuscarId.Focus();
        }
        private void btnExportara_MouseUp(object sender, EventArgs e)
        {
            exportar();
        }
        private void btnAceptar_MouseUp(object sender, EventArgs e)
        {
            fechas();
            txtBuscarId.Focus();
        }
        private void dgvRegistro_Click(object sender, EventArgs e)
        {
            if (dgvRegistro.RowCount>0)
            {
                c = dgvRegistro.CurrentRow.Index;
                txtBuscarId.Focus(); 
            }
        }
        private void txtBuscarId_TextChanged(object sender, EventArgs e)
        {
            buscarId(txtBuscarId.Text);
        }
        private void txtBuscarId_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Enter:
                    {
                        fechas();
                    }
                    break;
                case Keys.Escape:
                    {
                        cargar();
                        btnAceptar.Enabled = true;
                        btnRecargar.Enabled = false;
                    }
                    break;
                case Keys.Up:
                    {
                        try
                        {
                            recorrertabla(-1);
                            c -= 1;
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
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    break;
                case Keys.Delete:
                    {
                        if (dgvRegistro.RowCount > 0)
                            eliminarTodo();
                    }
                    break;
                case Keys.Subtract:
                    {
                        if (dgvRegistro.RowCount > 0)
                            eliminarRegistro();
                    }
                    break;
                case Keys.F12:
                    {
                        exportar();
                    }
                    break;
                default:
                    { }
                    break;
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true) cargarActual();
            else cargar();
        }
        private void txtBuscarId_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.validationOnlyNumber(e);
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Escape || e.KeyChar == (char)Keys.Add || e.KeyChar == (char)Keys.Tab) e.Handled = true;
        } 
        #endregion

    }
}
