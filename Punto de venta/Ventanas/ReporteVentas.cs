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
    public partial class ReporteVentas : Form
    {
        public List<Ingresos> ar { get; set; }
        public ReporteVentas()
        {
            InitializeComponent();
        }

        private void ReporteVentas_Load(object sender, EventArgs e)
        {
            rvVentas.SetDisplayMode(DisplayMode.PrintLayout);
            rvVentas.ZoomMode = ZoomMode.Percent;
            rvVentas.ZoomPercent = 100;
            ReportDataSource da = new ReportDataSource("dsVentas", ar);
            rvVentas.LocalReport.DataSources.Clear();
            rvVentas.LocalReport.DataSources.Add(da);
            this.rvVentas.RefreshReport();
        }

        private void btnAgregar_MouseUp(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
