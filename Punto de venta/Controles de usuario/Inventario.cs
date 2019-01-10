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
using Punto_de_venta.Ventanas;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace Punto_de_venta
{
    public partial class Inventario : UserControl
    {
        List<Articulo> ar;
        int c;
        ClassValidation validar = new ClassValidation();
        public Inventario()
        {
            InitializeComponent();           
        }
        #region //Métodos
        public void cargartabla()
        {
            dgvInventario.Rows.Clear();
            ar = BDArticulo.tabla();
            foreach (Articulo item in ar)
            {
                dgvInventario.Rows.Add(item.Id, item.Nombre, item.Descripcion, item.Costo, item.Precio, item.Stock, item.StockMin);
            }
        }
        public void colorRojo()
        {
            for (int i = 0; i < dgvInventario.RowCount; i++)
            {
                if (double.Parse(dgvInventario[5, i].Value + "") < double.Parse(dgvInventario[6, i].Value + ""))
                {
                    dgvInventario.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                    dgvInventario.Rows[i].DefaultCellStyle.SelectionForeColor = Color.Red;
                }
                if (double.Parse(dgvInventario[5, i].Value + "") > double.Parse(dgvInventario[6, i].Value + ""))
                {
                    dgvInventario.Rows[i].DefaultCellStyle.ForeColor = Color.DimGray;
                    dgvInventario.Rows[i].DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
                }
            }
        }
        public void recargar()
        {
            cargartabla();
            colorRojo();
        }
        public void agregar()
        {
            if(dgvInventario.RowCount>0)
            try
            {
                if (c < 0) c = 0;
                else if (c >= dgvInventario.RowCount) c = dgvInventario.RowCount - 1;
                AgregarInventario ai = new AgregarInventario();
                double canti = double.Parse(dgvInventario[5, c].Value + "");
                string art = dgvInventario[2, c].Value + "";
                ai.setValues(canti,art);
                ai.ShowDialog();
                if (ai.cierto)
                {
                    canti += ai.can;
                    BDArticulo.actualizarStock(canti, dgvInventario[1, c].Value + "");
                    recargar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void recorrertabla(int n)
        {
            try
            {
                c = dgvInventario.SelectedRows[0].Index;
                dgvInventario.Rows[c + n].Selected = true;
            }
            catch (Exception ex)
            {

            }
        }
        public void buscar(string txt)
        {
            dgvInventario.Rows.Clear();
            foreach (Articulo cli in ar)
            {
                if (cli.Nombre.ToUpper().IndexOf(txt) != -1)
                {
                    dgvInventario.Rows.Add(cli.Id, cli.Nombre, cli.Descripcion, cli.Costo, cli.Precio, cli.Stock, cli.StockMin);
                }
            }
        }
        public void converExcel(DataGridView tbl)
        {
            Excel.Application excel = new Excel.Application();
            Excel._Workbook libro = null;
            Excel._Worksheet hoja = null;
            Excel.Range rango = null;
            libro = (Excel._Workbook)excel.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            hoja = (Excel._Worksheet)libro.Worksheets.Add();
            hoja.Name = "EJEMPLO";
            ((Excel.Worksheet)excel.ActiveWorkbook.Sheets["Hoja1"]).Delete();
            hoja.Cells[4] = "Inventario del día " + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            rango = hoja.Range["A1", "G1"];
            rango.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            rango.MergeCells = true;
            rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            int fila = 2;
            for (int i = 0; i < tbl.ColumnCount; i++)
            {
                hoja.Cells[3, i + 1] = tbl.Columns[i].HeaderText;
            }
            for (int i = 0; i < tbl.RowCount; i++)
            {
                //Asignamos los datos a las celdas de la fila
                hoja.Cells[fila + i, 1] = tbl[0, i].Value;
                hoja.Cells[fila + i, 2] = tbl[1, i].Value;
                hoja.Cells[fila + i, 3] = tbl[2, i].Value;
                hoja.Cells[fila + i, 4] = tbl[3, i].Value;
                hoja.Cells[fila + i, 5] = tbl[4, i].Value;
                hoja.Cells[fila + i, 6] = tbl[5, i].Value;
                hoja.Cells[fila + i, 7] = tbl[6, i].Value;
                //Definimos la fila y la columna del rango 
                string x = "A" + (fila + i).ToString();
                string y = "G" + (fila + i).ToString();
                rango = hoja.Range[x, y];
                rango.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                for (int j = 1; j < 7; j++)
                {
                    rango = hoja.Columns[j];
                    rango.ColumnWidth = tbl.Columns[j - 1].Width / 9;
                    //rango.RowHeight = 15;
                    rango.VerticalAlignment = Excel.XlVAlign.xlVAlignTop;
                    rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                }
            }
            libro.Saved = true;
            //libro.SaveAs(Environment.CurrentDirectory + @"\Ejemplo.xlsx");
            excel.WindowState = Excel.XlWindowState.xlMaximized;
            excel.Visible = true;
        }
        public void convertPdf(DataGridView tabla)
        {
            SaveFileDialog a = new SaveFileDialog();
            a.Filter = "Archivos pdf(*.pdf)|*.pdf";
            a.Title = "Guardar";
            string b = "";
            if (a.ShowDialog() == DialogResult.OK)
            {
                b = a.FileName;
                a.Dispose();
                Document doc = new Document(PageSize.LETTER, 10, 10, 42, 35);
                PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(b, FileMode.Create));
                doc.Open();
                Paragraph linea = new Paragraph("Primer línea");
                PdfPTable table = new PdfPTable(tabla.Columns.Count);
                PdfPCell cell = new PdfPCell(new Phrase("Inventario del día " + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year, new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 11, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.DARK_GRAY)));
                cell.Colspan = 8;
                cell.HorizontalAlignment = 1;
                table.AddCell(cell);
                for (int i = 0; i < tabla.Columns.Count; i++) table.AddCell(new Phrase(tabla.Columns[i].HeaderText, new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 8f, iTextSharp.text.Font.BOLDITALIC, iTextSharp.text.BaseColor.DARK_GRAY)));
                table.HeaderRows = 1;
                for (int i = 0; i < tabla.RowCount; i++)
                    for (int j = 0; j < tabla.ColumnCount; j++)
                        table.AddCell(new Phrase(tabla[j, i].Value + "", new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 8f, iTextSharp.text.Font.BOLDITALIC, iTextSharp.text.BaseColor.DARK_GRAY)));

                doc.Add(table);
                doc.Close();
            }
        }
        public void generarReporte()
        {
            Reporte r = new Reporte();
            r.ar = ar;
            r.ShowDialog();
        }
        #endregion

        #region //Eventos
        private void btnAgregar_MouseUp(object sender, EventArgs e)
        {
            agregar();
            txtBuscarInventario.Focus();
        }
        private void txtBuscarInventario_TextChanged(object sender, EventArgs e)
        {
            try
            {
                buscar(txtBuscarInventario.Text);
                colorRojo();
            }
            catch (Exception ex)
            {

            }
        }
        private void txtBuscarInventario_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Enter:
                    agregar();
                    break;
                case Keys.Up:
                    {
                        try
                        {
                            recorrertabla(-1);
                            c--;
                        }
                        catch (Exception ex)
                        {
                            c++;
                        }
                    }
                    break;
                case Keys.Down:
                    {
                        try
                        {
                            recorrertabla(1);
                            c++;
                        }
                        catch (Exception ex)
                        {
                            c--;
                        }
                    }
                    break;
                default:
                    break;
            }
        }
        private void txtBuscarInventario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Escape || e.KeyChar == (char)Keys.Add || e.KeyChar == (char)Keys.Tab) e.Handled = true;
        }
        private void dgvInventario_Click(object sender, EventArgs e)
        {
            txtBuscarInventario.Focus();
            if (dgvInventario.RowCount > 0)
                c = dgvInventario.CurrentRow.Index;
        }
        private void btnExcel_MouseUp(object sender, EventArgs e)
        {
            txtBuscarInventario.Focus();
            if (dgvInventario.RowCount > 0)
                converExcel(dgvInventario);
        }
        private void btnPdf_MouseUp(object sender, EventArgs e)
        {
            txtBuscarInventario.Focus();
            //convertPdf(dgvInventario);
            if (dgvInventario.RowCount > 0)
                generarReporte();
        }
        private void Inventario_Load(object sender, EventArgs e)
        {
            cargartabla();
            colorRojo();
        }
        #endregion
    }
    
}