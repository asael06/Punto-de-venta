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

namespace Punto_de_venta
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            
        }
        Home h = new Home();

        ClassValidation Validation = new ClassValidation();

        public void agregarnombre()
        {
            string[] nombres = BDUsuario.NombreUsuario().ToArray();
            for (int i = 0; i < nombres.Length; i++) cmbUsuario.Items.Add(nombres[i]);
        }
        public void autentificar()
        {
            Validation.validationCmb(cmbUsuario);
            if (BDUsuario.Autentificar(cmbUsuario.Text, txtContrasena.Text) < 0)
            {
                txtContrasena.Text = "";
                throw new Exception("Usuario y/o contraseña incorrectos, favor de verificar los datos");
            }
        }
        public void logear()
        {
            if (BDLogeado.Logearse(cmbUsuario.Text, BDUsuario.rol(cmbUsuario.Text, txtContrasena.Text)) <= 0)
            {
                throw new Exception("No se registró el ingreso");
            }
        }
        public void aceptar()
        {
            try
            {
                autentificar();
                logear();
                this.Hide();
                h.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAceptar_MouseUp(object sender, EventArgs e)
        {
            aceptar();
        }
        private void Login_Load(object sender, EventArgs e)
        {
            agregarnombre();
        }
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void txtContrasena_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) aceptar();
        }
        private void cmbUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Validation.validationCmb(cmbUsuario);
                    txtContrasena.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cmbUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Escape || e.KeyChar == (char)Keys.Tab) e.Handled = true;
        }
        private void txtContrasena_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Escape || e.KeyChar == (char)Keys.Tab) e.Handled = true;
        }
    }
}
