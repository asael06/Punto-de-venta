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
    public partial class CajaInicial : Form
    {
        public CajaInicial()
        {
            InitializeComponent();
        }

        public bool cierto { get; set; }
        private void btnAceptar_MouseUp(object sender, EventArgs e)
        {
            aceptar();
        }
        public void aceptar()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtContrasena.Text)) this.Close();
                else
                {
                    int[] ids = BDIngresos.ArrIngresosId().ToArray();
                    Ingresos ing = new Ingresos(regresarId(ids, BDIngresos.idMax()), "Caja", Convert.ToDouble(txtContrasena.Text), DateTime.Now.Date.ToString("yyyy-MM-dd"), BDLogeado.retornaLogeado());
                    BDIngresos.IngresoNuevo(ing);
                    cierto = true;
                    MessageBox.Show("Se registró la transacción con éxito");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void txtContrasena_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) aceptar();            
        }
    }
}
