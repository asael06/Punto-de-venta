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
    public partial class Confirmar : Form
    {
        public bool cierto { get; set; }
        ClassValidation Validation = new ClassValidation();
        public Confirmar()
        {
            InitializeComponent();
            agregarnombre();
        }
        public void agregarnombre()
        {
            string[] nombres = BDUsuario.NombreUsuario().ToArray();
            cmbUsuario.Items.Add("Seleccionar Usuario");
            for (int i = 0; i < nombres.Length; i++) cmbUsuario.Items.Add(nombres[i]);
            cmbUsuario.SelectedIndex = 0;
        }        
        public void aceptar()
        {
            try
            {
                autentificar();
                cierto = true;                          
                MessageBox.Show("Usuario correcto");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void autentificar()
        {
            Validation.validationCmb(cmbUsuario);
            Validation.errorActive(txtContrasena);
            if (!BDUsuario.rol(cmbUsuario.Text, txtContrasena.Text).Equals("Administrador"))
            {
                txtContrasena.Text = "";
                throw new Exception("Este usuario no es administrador");
            }
        }       
        private void btnAceptar_MouseUp(object sender, EventArgs e)
        {
            aceptar();
        }
        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
                aceptar();
        }
        private void btnCancelar_MouseUp(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cmbUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {                
                if (e.KeyValue == (char)Keys.Enter)
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
    }
}
