using Microsoft.Reporting.WinForms;
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
    public partial class Reporte : Form
    {
        public List<Articulo> ar;
        public Reporte()
        {
            InitializeComponent();
        }

        private void Reporte_Load(object sender, EventArgs e)
        {
            rvInventario.SetDisplayMode(DisplayMode.PrintLayout);
            rvInventario.ZoomMode = ZoomMode.Percent;
            rvInventario.ZoomPercent = 100;
            ReportDataSource da = new ReportDataSource("dsInventario",ar);
            rvInventario.LocalReport.DataSources.Clear();
            rvInventario.LocalReport.DataSources.Add(da);
            this.rvInventario.RefreshReport();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
