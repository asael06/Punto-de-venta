using Punto_de_venta;
using Punto_de_venta.Base_de_datos;
using Punto_de_venta.Clases;
using System;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Ventanas
{
    public partial class AgregarArticulo : Form
    {
        public AgregarArticulo()
        {
            InitializeComponent();            
            cmbUnidades.SelectedIndex = 0;
        }
        public bool cierto { get; set; }
        int id;
        ClassValidation Validation = new ClassValidation();
        
        #region //Métodos
        private void exceptionArticle()
        {
            Validation.validationTxtField(txtNombre, Validation.defaultRGX);
            Validation.validationTxtField(txtDescripcion, Validation.defaultRGX);
            Validation.validationTxtField(txtCosto, Validation.numberDecimalRGX);
            Validation.validationTxtField(txtPrecio, Validation.numberDecimalRGX);
            Validation.validationTxtField(txtStock, Validation.numberDecimalRGX);
            Validation.validationTxtField(txtStockMin, Validation.numberDecimalRGX);
            Validation.validationCmb(cmbUnidades);

        }
        private void exceptionError()
        {
            Validation.errorActive(txtNombre, Validation.defaultRGX, errorInput);
            Validation.errorActive(txtDescripcion, Validation.defaultRGX, errorInput);
            Validation.errorActive(txtCosto, Validation.numberDecimalRGX, errorInput);
            Validation.errorActive(txtPrecio, Validation.numberDecimalRGX, errorInput);
            Validation.errorActive(txtStock, Validation.numberDecimalRGX, errorInput);
            Validation.errorActive(txtStockMin, Validation.numberDecimalRGX, errorInput);
            Validation.errorActiveCmb(cmbUnidades, errorInput);
        }
        public void aceptar()
        {
            try
            {
                exceptionError();
                exceptionArticle();
                if (lblNombre.Text.Equals("Actualizar artículo")) actualizar();
                else guardar();
                cierto = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void guardar()
        {
            Articulo a = new Articulo();
            a.Id = regresarId(Productos.ids(), BDArticulo.mayor());
            a.Nombre = txtNombre.Text;
            a.Descripcion = txtDescripcion.Text;
            a.Costo = double.Parse(txtCosto.Text);
            a.Precio = double.Parse(txtPrecio.Text);
            a.Stock = double.Parse(txtStock.Text);
            a.StockMin = double.Parse(txtStockMin.Text);
            a.Unidad = cmbUnidades.SelectedItem.ToString();
            BDArticulo.ArticuloNuevo(a);
        }
        public void actualizar()
        {
            Articulo a = new Articulo();
            a.Id = id;
            a.Nombre = txtNombre.Text;
            a.Descripcion = txtDescripcion.Text;
            a.Costo = double.Parse(txtCosto.Text);
            a.Precio = double.Parse(txtPrecio.Text);
            a.Stock = double.Parse(txtStock.Text);
            a.StockMin = double.Parse(txtStockMin.Text);
            a.Unidad = cmbUnidades.SelectedItem.ToString();
            BDArticulo.EditarArticulo(a);
        }
        public void setTexto(Articulo ar)
        {
            lblNombre.Text = "Actualizar artículo";
            id = ar.Id;
            txtNombre.Text = ar.Nombre;
            txtDescripcion.Text = ar.Descripcion;
            txtCosto.Text = ar.Costo.ToString("N2");
            txtPrecio.Text = ar.Precio.ToString("N2");
            txtStock.Text = ar.Stock.ToString("N3");
            txtStockMin.Text = ar.StockMin.ToString("N3");
            for (int i = 0; i < 3; i++)
            {
                if (ar.Unidad.Equals(cmbUnidades.Items[i])) cmbUnidades.SelectedIndex = i;
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

        #endregion

        #region //Eventos
        private void btnCancelar_MouseUp(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnGuardar_MouseUp(object sender, EventArgs e)
        {
            aceptar();
        }
        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Enter:
                    { txtDescripcion.Focus(); e.SuppressKeyPress = true; }
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
                case Keys.Left:
                    cmbUnidades.Focus();
                    break;
                case Keys.Up:
                    cmbUnidades.Focus();
                    break;
                case Keys.Right:
                    txtDescripcion.Focus();
                    break;
                case Keys.Down:
                    txtDescripcion.Focus();
                    break;
            }
        }
        private void txtDescripcion_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Enter:
                    { txtCosto.Focus(); e.SuppressKeyPress = true; }
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
                case Keys.Left:
                    txtNombre.Focus();
                    break;
                case Keys.Up:
                    txtNombre.Focus();
                    break;
                case Keys.Right:
                    txtStock.Focus();
                    break;
                case Keys.Down:
                    txtCosto.Focus();
                    break;
            }
        }
        private void txtCosto_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Enter:
                    { txtPrecio.Focus(); e.SuppressKeyPress = true; }
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
                case Keys.Left:
                    txtStock.Focus();
                    break;
                case Keys.Up:
                    txtDescripcion.Focus();
                    break;
                case Keys.Right:
                    txtStockMin.Focus();
                    break;
                case Keys.Down:
                    txtPrecio.Focus();
                    break;
            }
        }
        private void txtPrecio_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Enter:
                    { txtStock.Focus(); e.SuppressKeyPress = true; }
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
                case Keys.Left:
                    txtStockMin.Focus();
                    break;
                case Keys.Up:
                    txtCosto.Focus();
                    break;
                case Keys.Right:
                    cmbUnidades.Focus();
                    break;
                case Keys.Down:
                    txtStock.Focus();
                    break;
            }
        }
        private void txtStock_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Enter:
                    { txtStockMin.Focus(); e.SuppressKeyPress = true; }
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
                case Keys.Left:
                    txtDescripcion.Focus();
                    break;
                case Keys.Up:
                    txtNombre.Focus();
                    break;
                case Keys.Right:
                    txtCosto.Focus();
                    break;
                case Keys.Down:
                    txtStockMin.Focus();
                    break;
            }
        }
        private void txtStockMin_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Enter:
                    { cmbUnidades.Focus(); e.SuppressKeyPress = true; }
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
                case Keys.Left:
                    txtCosto.Focus();
                    break;
                case Keys.Up:
                    txtStock.Focus();
                    break;
                case Keys.Right:
                    txtPrecio.Focus();
                    break;
                case Keys.Down:
                    cmbUnidades.Focus();
                    break;
            }
        }
        private void cmbUnidades_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Enter:
                    aceptar();
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
                case Keys.Left:
                    txtPrecio.Focus();
                    break;
                case Keys.Right:
                    txtNombre.Focus();
                    break;
            }
        }
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validation.validationTextandNumber(e);
        }
        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validation.validationText(e);
        }
        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validation.validationNumber(e);
        }
        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validation.validationNumber(e);
        }
        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validation.validationNumber(e);
        }
        private void txtStockMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validation.validationNumber(e);
        } 
        #endregion

    }
}

