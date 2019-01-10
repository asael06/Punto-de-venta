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
using System.Drawing.Printing;
using System.Data.SQLite;

namespace Punto_de_venta
{
    public partial class Configuración : UserControl
    {
        public Configuración()
        {
            InitializeComponent();
        }
        ClassValidation valida = new ClassValidation();
        Datos data;
        string impresora;
        public void cargarImpresorar(string cad)
        {
            string imin;
            int indice=0;
            //cmbImpresora.SelectedIndex = 0;
            for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {
                imin = PrinterSettings.InstalledPrinters[i];
                if (imin.Equals(cad)) indice = i;
                cmbImpresora.Items.Add(imin);
            }
            cmbImpresora.SelectedIndex = indice;
        }
        public void limpiar()
        {
            txtLocal.Clear();
            txtLocal.Enabled = false;
            txtLocal.TabStop = false;
            txtTexto.Clear();
            txtTexto.Enabled = false;
            txtTexto.TabStop = false;
            txtDireccion.Clear();
            txtDireccion.Enabled = false;
            txtDireccion.TabStop = false;
            txtTelefono.Clear();
            txtTelefono.Enabled = false;
            txtTelefono.TabStop = false;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            errorInput.Clear();
        }
        public void activar()
        {
            txtLocal.Enabled = txtLocal.TabStop = true;
            txtTexto.Enabled = txtTexto.TabStop = true;
            txtDireccion.Enabled = txtDireccion.TabStop = true;
            txtTelefono.Enabled = txtTelefono.TabStop = true;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            txtLocal.Focus();
        }
        public void validar()
        {
            valida.validationTxtField(txtLocal, valida.letterRGX);
            valida.validationTxtField(txtTexto, valida.defaultRGX);
            valida.validationTxtField(txtDireccion, valida.defaultRGX);
            valida.validationTxtField(txtTelefono, valida.numberRGX);            
        }
        public void error()
        {
            valida.errorActive(txtLocal, valida.letterRGX, errorInput);
            valida.errorActive(txtTexto, valida.defaultRGX, errorInput);
            valida.errorActive(txtDireccion, valida.defaultRGX, errorInput);
            valida.errorActive(txtTelefono, valida.numberRGX, errorInput);
            
        }
        public void guardar()
        {
            try
            {
                error();
                validar();
                if (MessageBox.Show("¿Está seguro de guardar esta configuración?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Datos d = new Datos();
                    d.Nombre = txtLocal.Text;
                    d.Local = txtTexto.Text;
                    d.Direccion = txtDireccion.Text;
                    d.Telefono = txtTelefono.Text;
                    BDDatos.GuardarDatos(d);
                    MessageBox.Show("Configuración guardada correctamente");
                    limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void guardarImpresora()
        {
            try
            {
                if (MessageBox.Show("¿Desea usar esta impresora?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    BDDatos.guardarImpresora(cmbImpresora.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }        

        private void btnGuardar_MouseUp(object sender, EventArgs e)
        {
            guardar();
        }
        private void btnEditar_MouseUp(object sender, EventArgs e)
        {
            activar();
        }
        private void btnCancelar_MouseUp(object sender, EventArgs e)
        {
            limpiar();
        }
        private void Configuración_Load(object sender, EventArgs e)
        {
            impresora = BDDatos.retornaImpresora();
            cargarImpresorar(impresora);
            data = BDDatos.retornarDatos();
            lblLocal.Text = data.Nombre;
            lblTexto.Text = data.Local;
            lblDireccion.Text = data.Direccion;
            lblTelefono.Text = data.Telefono;

        }
        private void btnGuardarImpresora_MouseUp(object sender, EventArgs e)
        {
            guardarImpresora();
        }

        private void txtLocal_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:  txtTexto.Select(); 
                    break;
                case Keys.Down: txtTexto.Select();
                    break;
                case Keys.Up: txtTelefono.Select();
                    break;
            }

        }
        private void txtLocal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Escape || e.KeyChar == (char)Keys.Tab) e.Handled = true;
        }
        private void txtTexto_KeyDown(object sender, KeyEventArgs e)
        {            
                switch (e.KeyCode)
                {
                    case Keys.Enter: txtDireccion.Select();
                        break;
                    case Keys.Down: txtDireccion.Select();
                        break;
                    case Keys.Up: txtLocal.Select();
                        break;
                }
            }
        private void txtTexto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Escape || e.KeyChar == (char)Keys.Tab) e.Handled = true;
        }
        private void txtDireccion_KeyDown(object sender, KeyEventArgs e)
        {            
                switch (e.KeyCode)
                {
                    case Keys.Enter: txtTelefono.Select();
                        break;
                    case Keys.Down: txtTelefono.Select();
                        break;
                    case Keys.Up: txtTexto.Select();
                        break;
                }
            }
        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Escape || e.KeyChar == (char)Keys.Tab) e.Handled = true;
        }
        private void txtTelefono_KeyDown(object sender, KeyEventArgs e)
        {           
                switch (e.KeyCode)
                {
                    case Keys.Enter: guardar();
                        break;
                    case Keys.Down: txtLocal.Select();
                        break;
                    case Keys.Up: txtDireccion.Select();
                        break;
                }
            }
        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Escape || e.KeyChar == (char)Keys.Tab) e.Handled = true;
        }
    }
}
