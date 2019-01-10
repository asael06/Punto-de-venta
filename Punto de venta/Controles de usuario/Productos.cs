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
using WindowsFormsApplication1.Ventanas;
using Punto_de_venta;

namespace Punto_de_venta
{
    public partial class Productos : UserControl
    {
        public Productos()
        {
            InitializeComponent();
            
        }
        static List<Articulo> ar;
        AgregarArticulo aa;
        Home h;
        int c;
        ClassValidation validar = new ClassValidation();


        #region //Métodos
        public void cargartabla()
        {
            dgvProductos.Rows.Clear();
            ar = BDArticulo.tabla();
            foreach (Articulo item in ar)
            {
                dgvProductos.Rows.Add(item.Id, item.Nombre, item.Descripcion, item.Costo, item.Precio, item.Stock);
            }
        }
        public static int[] ids()
        {
            int[] ids = new int[ar.Count];
            int c = 0;
            foreach (var id in ar)
            {
                ids[c] = id.Id;
                c++;
            }
            return ids;
        }
        public void eliminar()
        {
            try
            {
                h = new Home();
                if (dgvProductos.RowCount > 0)
                    if (MessageBox.Show("¿Está seguro de elimiar este producto?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        BDArticulo.EliminarArticulo(int.Parse(dgvProductos[0, c].Value + ""));
                        cargartabla();
                        h.recargar();
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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
        public void agregar()

        {
            h = new Home();
            aa = new AgregarArticulo();
            aa.ShowDialog();
            if (aa.cierto)
            {
                cargartabla();
                h.recargar();
            }
        }
        public void editar()
        {
            if (dgvProductos.RowCount>0)
            {
                h = new Home();
                if (c < 0) c = 0;
                else if (c > dgvProductos.RowCount - 1) c = dgvProductos.RowCount - 1;
                Articulo arti = BDArticulo.obtenerArticulo(int.Parse(dgvProductos[0, c].Value.ToString()));
                aa = new AgregarArticulo();
                aa.setTexto(arti);
                aa.ShowDialog();
                if (aa.cierto)
                {
                    cargartabla();
                    h.recargar();
                } 
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
            eliminar();
        }
        private void btnEditar_MouseUp(object sender, EventArgs e)
        {
            editar();
        }
        private void txtBuscarProducto_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Add: agregar();
                    break;
                case Keys.F12: editar();
                    break;
                case Keys.Delete: eliminar();
                    break;
                case Keys.Up:
                    {
                        try
                        {
                            recorrertabla(-1);
                            c --;
                        }
                        catch (Exception ex)
                        {
                            c++;
                        }
                    }
                    break;
                case Keys.Down:
                    {
                        try
                        {
                            recorrertabla(1);
                            c++;
                        }
                        catch (Exception ex)
                        {
                            c--;                            
                        }
                    }
                    break;
            }
        }
        private void txtBuscarProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.validationTextandNumber(e);
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Escape || e.KeyChar == (char)Keys.Add || e.KeyChar == (char)Keys.Tab) e.Handled = true;
        }
        private void txtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            dgvProductos.Rows.Clear();
            foreach (var item in ar)
            {
                if (item.Descripcion.ToUpper().IndexOf(txtBuscarProducto.Text.ToUpper()) !=-1) dgvProductos.Rows.Add(item.Id,item.Nombre,item.Descripcion,item.Costo,item.Precio,item.Stock);
            }
        }
        private void dgvProductos_Click(object sender, EventArgs e)
        {
            if (dgvProductos.RowCount>0)
            {
                c = dgvProductos.CurrentRow.Index;
                txtBuscarProducto.Focus(); 
            }
        }
        private void Productos_Load(object sender, EventArgs e)
        {
            //cargartabla();
        }

        #endregion

    }
}
