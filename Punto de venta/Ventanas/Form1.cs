using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.Lib;
using System.Runtime.InteropServices;
using Punto_de_venta.Base_de_datos;

namespace Punto_de_venta
{
    public partial class Home : Form
    {        
        public Home()
        {
            InitializeComponent();
            btnVentas.selected = true;
            ventas1.txtCB.Select();
            
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0x112, 0xf012, 0);                
            }
        }      
        //Ventana******************************************************************************************************
        #region
        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {           
            cerrar c = new cerrar();            
            c.ShowDialog();
            if (c.cierto) Application.Exit();
        }
        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;           
        }
        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;
        }
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        public void animate()
        {
            usuarios2.Visible = false;
            clientes1.Visible = false;
            productos1.Visible = false;
            inventario1.Visible = false;
            registro1.Visible = false;
            configuración1.Visible = false;
            ventas1.Visible = true;
        }        
        public void animate2()
        {
            ventas1.Visible = false;
            clientes1.Visible = false;
            productos1.Visible = false;
            inventario1.Visible = false;
            registro1.Visible = false;
            configuración1.Visible = false;
            usuarios2.Visible = true;
        }         
        public void animate3()
        {
            ventas1.Visible = false;
            clientes1.Visible = true;
            usuarios2.Visible = false;
            productos1.Visible = false;
            inventario1.Visible = false;
            registro1.Visible = false;
            configuración1.Visible = false;
        }
        public void animate4()
        {
            ventas1.Visible = false;
            clientes1.Visible = false;
            usuarios2.Visible = false;
            inventario1.Visible = false;
            registro1.Visible = false;
            configuración1.Visible = false;
            productos1.Visible = true;
        }
        public void animate5()
        {
            ventas1.Visible = false;
            clientes1.Visible = false;
            usuarios2.Visible = false;
            productos1.Visible = false;
            registro1.Visible = false;
            configuración1.Visible = false;
            inventario1.Visible = true;
        }
        public void animate6()
        {
            ventas1.Visible = false;
            clientes1.Visible = false;
            usuarios2.Visible = false;
            productos1.Visible = false;
            inventario1.Visible = false;
            configuración1.Visible = false;
            registro1.Visible = true;
        }
        public void animate7()
        {
            ventas1.Visible = false;
            clientes1.Visible = false;
            usuarios2.Visible = false;
            productos1.Visible = false;
            inventario1.Visible = false;
            registro1.Visible = false;
            configuración1.Visible = true;
        }
        public void recargar()
        {
            inventario1.recargar();
        }
        private void btnVentas_Click(object sender, EventArgs e)
        {
            animate();
            ventas1.txtCB.Enabled = true;
            ventas1.txtCB.Focus();
        }
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {            
            animate2();
            usuarios2.txtBuscar.Focus();
        }
        private void bunifuFlatButton2_Click_1(object sender, EventArgs e)
        {
            panel3.Width = 48;
            btnCerrar.Visible = false;
            btnAbrir.Visible = true;

        }
        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            panel3.Width = 210;
            btnAbrir.Visible = false;
            btnCerrar.Visible = true;
        }
        private void btnProductos_Click(object sender, EventArgs e)
        {
            animate4();
            productos1.cargartabla();
            productos1.txtBuscarProducto.Focus();
        }
        private void btnInventario_Click(object sender, EventArgs e)
        {         
            animate5();
            inventario1.recargar();
            inventario1.txtBuscarInventario.Focus();
        }
        private void btnRegistro_Click(object sender, EventArgs e)
        {
            animate6();
            registro1.cargar();
            registro1.txtBuscarId.Focus();
        }
        private void btnConfiguración_Click(object sender, EventArgs e)
        {         
            animate7();
        }
        private void btnClientes_Click(object sender, EventArgs e)
        {            
            animate3();
            clientes1.txtBuscarCliente.Focus();
        }
        #endregion
        private void ventas1_VisibleChanged(object sender, EventArgs e)
        {
            ventas1.txtCB.Select();
        }
        private void Home_Load(object sender, EventArgs e)
        {
            if (BDLogeado.retorarRol().Equals("Vendedor"))
            {
                btnConfiguracion.Enabled = false;
                btnUsuarios.Enabled = false;
            }
        }

        private void btnCerrarCesion_MouseUp(object sender, EventArgs e)
        {
            cerrar c = new cerrar();
            c.ShowDialog();
            if (c.cierto) Application.Restart();
        }
    }    
}
