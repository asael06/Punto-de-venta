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
    public partial class AgregarUsuario : Form
    {
        ClassValidation valida = new ClassValidation();
        Usuario a;
        public bool cierto { get; set; }
        public AgregarUsuario()
        {
            InitializeComponent();
            cmbRol.SelectedIndex = 0;
        }
        public void setLbl(string txt,Usuario u)
        {
            a = u;
            lblVentana.Text = txt;
            txtNombre.Text = u.Nombre;
            txtTelefono.Text = u.Telefono;            
            txtConfirmar.Text = txtContrasena.Text = u.Contrasena;
            for(int i = 0; i < cmbRol.Items.Count; i++)
            {
                if (u.Rol.Equals(cmbRol.Items[i].ToString())) cmbRol.SelectedIndex = i;
            }
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
        public void guardar()
        {
            Usuario u = new Usuario();
            u.id = regresarId(Usuarios.ids(), BDUsuario.mayor());
            u.Nombre = txtNombre.Text;
            u.Telefono = txtTelefono.Text;            
            u.Contrasena = txtContrasena.Text;
            u.Rol = cmbRol.SelectedItem.ToString();
            BDUsuario.UsuarioNuevo(u);
        }
        public void validar()
        {
            valida.validationTxtField(txtNombre, valida.letterRGX);
            valida.validationTxtField(txtTelefono, valida.numberRGX);
            valida.validationTxtField(txtContrasena, valida.defaultRGX);
            valida.validationTxtField(txtConfirmar, valida.defaultRGX);
            valida.validationCmb(cmbRol);
            if (!txtContrasena.Text.Equals(txtConfirmar.Text))
            {
                txtContrasena.Focus();
                throw new Exception("Verifique ambas contraseñas");
            }
        }
        public void error()
        {
            valida.errorActive(txtNombre, valida.letterRGX, errorInput);
            valida.errorActive(txtTelefono, valida.numberRGX, errorInput);
            valida.errorActive(txtContrasena, valida.defaultRGX, errorInput);
            valida.errorActive(txtConfirmar, valida.defaultRGX, errorInput);
        }
        public void aceptar()
        {
            try
            {
                error();
                validar();
                if (lblVentana.Text == "Editar Usuario") actualizar();
                else guardar();
                cierto = true;
                MessageBox.Show("Datos guardados");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void actualizar()
        {          
            a.Nombre = txtNombre.Text;
            a.Telefono = txtTelefono.Text;            
            a.Contrasena = txtContrasena.Text;
            a.Rol = cmbRol.SelectedItem.ToString();
            BDUsuario.UsuarioActualizar(a);
        }               
        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {

                case Keys.Enter:                   
                    txtTelefono.Select();
                    break;
                case Keys.Up:
                    cmbRol.Select();
                    break;
                case Keys.Down:
                    txtTelefono.Select();
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
                default:
                    break;
            }
        }
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {            
            valida.validationText(e);
            valida.DesactivarTeclado(txtNombre, 50, e);
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Escape)
            {
                e.Handled = true;
            }
        }
        private void txtTelefono_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Enter:
                    txtContrasena.Select();
                    break;
                case Keys.Up:
                    txtNombre.Select();
                    break;
                case Keys.Down:
                    txtContrasena.Select();
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
                default:
                    break;
            }
        }
        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.validationOnlyNumber(e);
            valida.DesactivarTeclado(txtTelefono, 10, e);
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Escape)
            {
                e.Handled = true;
            }
        }        
        private void txtContrasena_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {

                case Keys.Enter:
                    txtConfirmar.Select();
                    break;
                case Keys.Up:
                    txtTelefono.Select();
                    break;
                case Keys.Down:
                    txtConfirmar.Select();
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
                default:
                    break;
            }
        }
        private void txtContrasena_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==(char)Keys.Enter|| e.KeyChar == (char)Keys.Escape)
            {
                e.Handled = true;
            }
        }
        private void txtConfirmar_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {

                case Keys.Enter:
                    cmbRol.Select();
                    break;
                case Keys.Up:
                    txtContrasena.Select();
                    break;
                case Keys.Down:
                    cmbRol.Select();
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
                default:
                    break;
            }
        }
        private void txtConfirmar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Escape)
            {
                e.Handled = true;
            }
        }
        private void btnAceptar_MouseUp(object sender, EventArgs e)
        {
            aceptar();
        }
        private void cmbRol_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
                aceptar();
        }
        private void btnCancelar_MouseUp(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
