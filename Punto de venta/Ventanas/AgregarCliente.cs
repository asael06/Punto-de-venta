using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Punto_de_venta.Base_de_datos;
using Punto_de_venta.Clases;

namespace Punto_de_venta.Ventanas
{
    public partial class AgregarCliente : Form
    {
        public AgregarCliente()
        {
            InitializeComponent();
        }
        ClassValidation valida = new ClassValidation();
        public int[] ta { get; set; }
        public int id { get; set; }
        public bool cierto { get; set; }
        Cliente c;
        #region //Metodos
        public void aceptar()
        {
            try
            {
                error();
                validar();
                if (lblTexto.Text == "Editar Cliente") actualizar();
                else guardar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void guardar()
        {
            c = new Cliente();
            c.Id = regresarId(Clientes.ids(), BDCliente.mayor());
            c.Nombre = txtNombre.Text;
            c.Direccion = txtDireccion.Text;
            c.Telefono = txtTelefono.Text;
            BDCliente.ClienteNuevo(c);
            BDCuenta.CuentaNueva(c.Id, 0);
            cierto = true;
            MessageBox.Show("Cliente agregado con éxito");
            this.Close();
        }
        public void actualizar()
        {
            c = new Cliente();
            c.Id = id;
            c.Nombre = txtNombre.Text;
            c.Direccion = txtDireccion.Text;
            c.Telefono = txtTelefono.Text;
            BDCliente.EditarCliente(c);
            MessageBox.Show("Cliente actualizado con éxito");
            cierto = true;
            this.Close();
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
        public void setTexto(int id)
        {
            Cliente x = BDCliente.RetornaCliente(id);
            txtNombre.Text = x.Nombre;
            txtDireccion.Text = x.Direccion;
            txtTelefono.Text = x.Telefono;
        }
        public void validar()
        {
            valida.validationTxtField(txtNombre, valida.letterRGX);
            valida.validationTxtField(txtDireccion, valida.defaultRGX);
            valida.validationTxtField(txtTelefono, valida.numberRGX);
        }
        public void error()
        {
            valida.errorActive(txtNombre, valida.letterRGX, errorInput);
            valida.errorActive(txtDireccion, valida.defaultRGX, errorInput);
            valida.errorActive(txtTelefono, valida.numberRGX, errorInput);
        }
        #endregion

        #region //Eventos

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            aceptar();
        }
        private void btnCancelar_MouseUp(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.validationText(e);
            valida.DesactivarTeclado(txtNombre, 50, e);
        }
        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {            
            valida.DesactivarTeclado(txtDireccion, 100, e);
        }
        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.validationOnlyNumber(e);
            valida.DesactivarTeclado(txtTelefono, 10, e);
        }
        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {

                case Keys.Enter:
                    txtDireccion.Select();
                    break;
                case Keys.Up:
                    txtTelefono.Select();
                    break;
                case Keys.Down:
                    txtDireccion.Select();
                    break;
                case Keys.Escape: this.Close();
                    break;
                default:
                    break;
            }
        }
        private void txtDireccion_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {

                case Keys.Enter:
                    txtTelefono.Select();
                    break;
                case Keys.Up:
                    txtNombre.Select();
                    break;
                case Keys.Down:
                    txtTelefono.Select();
                    break;
                case Keys.Escape: this.Close();
                    break;
                default:
                    break;
            }
        }
        private void txtTelefono_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {

                case Keys.Enter:
                    aceptar();
                    break;
                case Keys.Up:
                    txtDireccion.Select();
                    break;
                case Keys.Down:
                    txtNombre.Select();
                    break;
                case Keys.Escape: this.Close();
                    break;
                default:
                    break;
            }
        }

        #endregion
    }
}
