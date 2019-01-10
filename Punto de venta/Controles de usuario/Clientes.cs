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
    public partial class Clientes : UserControl
    {
        public Clientes()
        {
            InitializeComponent();            
        }
        static List<Cliente> cl;
        AgregarCliente ac;
        int c;
        ClassValidation validar = new ClassValidation();

        #region //Métodos       
        public void carga()
        {
            dgvClientes.Rows.Clear();
            cl = BDCliente.Tabla();
            foreach (Cliente item in cl)
            {
                dgvClientes.Rows.Add(item.Id, item.Nombre, item.Direccion, item.Telefono);
            }
            
        }
        public void recorrertabla(int n)
        {
            try
            {
                c = dgvClientes.SelectedRows[0].Index;
                dgvClientes.Rows[c + n].Selected = true;      
            }
            catch (Exception ex)
            {   
                            
            }
        }
        public static int[] ids()
        {
            int[] ids = new int[cl.Count];
            int c = 0;
            cl = cl.OrderBy(x => x.Id).ToList();
            foreach (var id in cl)
            {
                ids[c] = id.Id;
                c++;
            }
            return ids;
        }
        public void buscar(string txt)
        {
            dgvClientes.Rows.Clear();
            foreach  (Cliente cli in cl)
            {
                if (cli.Nombre.ToUpper().IndexOf(txt)!=-1)
                {
                    dgvClientes.Rows.Add(cli.Id,cli.Nombre,cli.Direccion,cli.Telefono);
                }
            }
        }
        public void quitarV()
        {
            Confirmar c = new Confirmar();
            c.ShowDialog();
            if (c.cierto)
            {
                try
                {                    
                    int id = int.Parse(dgvClientes.CurrentRow.Cells[0].Value + "");
                    BDCliente.EliminarCliente(id);
                    BDAbono.AbonoEliminar(id);
                    BDCuenta.CuentaEliminar(id);
                    BDCuenta.TicketEliminar(id);               
                    carga();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void quitarA()
        {            
            if (MessageBox.Show("¿Está seguro de eliminar este cliente?","Eliminar",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                try
                {
                    int id = int.Parse(dgvClientes.CurrentRow.Cells[0].Value + "");
                    BDCliente.EliminarCliente(id);
                    BDAbono.AbonoEliminar(id);
                    BDCuenta.CuentaEliminar(id);
                    BDCuenta.TicketEliminar(id);
                    carga();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void agregar()
        {
            ac = new AgregarCliente();
            ac.ShowDialog();
            if (ac.cierto)
            {
                carga();
            }
        }
        public void cuenta()
        {
            if (c < 0) c = 0;
            else if (c >= dgvClientes.RowCount) c = dgvClientes.RowCount - 1;
            try
            {
                EstadoCuenta ec = new EstadoCuenta();
                ec.id = int.Parse(dgvClientes[0,c].Value.ToString());
                ec.ShowDialog();
            }
            catch (Exception ex)
            {
                    
            }
        }
        public void editar()
        {

            if (c < 0) c = 0;
            else if (c >= dgvClientes.RowCount) c = dgvClientes.RowCount - 1;
            try
            {
                ac = new AgregarCliente();                
                ac.setTexto(int.Parse(dgvClientes[0,c].Value.ToString()));
                ac.ShowDialog();
                if (ac.cierto)
                {
                    carga();
                }                

            }
            catch (Exception ex)
            {
                
            }
        }
        public void quitar()
        {
            if (BDLogeado.retorarRol().Equals("Vendedor")) quitarV();
            else quitarA();
        }
        #endregion 
        //Continuar aquí

        #region //Eventos
        private void txtBuscarCliente_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter: { cuenta(); }
                    break;
                case Keys.F12: { editar(); }
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
                        if (dgvClientes.RowCount > 0)
                            quitar();
                    }
                    break;                
                case Keys.Add:
                    { agregar(); }
                    break;                            
                default:
                    { }
                    break;
            }
        }
        private void txtBuscarCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.validationText(e);
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Escape || e.KeyChar==(char)Keys.Add || e.KeyChar == (char)Keys.Tab) e.Handled = true;
        }
        private void txtBuscarCliente_TextChanged(object sender, EventArgs e)
        {
            try
            {
                buscar(txtBuscarCliente.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnAgregar_MouseUp(object sender, EventArgs e)
        {
            agregar();
        }
        private void btnQuitar_MouseUp(object sender, EventArgs e)
        {
            if(dgvClientes.RowCount>0)
                quitar();           
        }
        private void btnEditar_MouseUp(object sender, EventArgs e)
        {

            editar();           
        }
        private void dgvClientes_Click(object sender, EventArgs e)
        {
            if (dgvClientes.RowCount>0)
            {
                c = dgvClientes.CurrentRow.Index;
                txtBuscarCliente.Focus(); 
            }
        }
        private void btnCuenta_MouseUp(object sender, EventArgs e)
        {
            cuenta();
        }
        private void Clientes_Load(object sender, EventArgs e)
        {
            carga();
        }
        #endregion
        

    }
}