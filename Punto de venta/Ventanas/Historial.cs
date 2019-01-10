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
    public partial class Historial : Form
    {
        List<Abono> lista;
        public Historial()
        {
            InitializeComponent();
        }
        public int id { get; set; }
        public void cargar()
        {
            lista = BDAbono.AbonoRetorna(id);
            foreach (var item in lista)
            {
                dgvFechas.Rows.Add(item.Monto,item.Fecha);
            }
        } 
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Historial_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void dgvFechas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Escape) this.Close();
        }
    }
}
