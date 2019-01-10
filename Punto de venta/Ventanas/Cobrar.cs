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
    public partial class Cobrar : Form
    {        
        public void cerrar() { this.Close(); }
        public bool cierto = false;
        public static bool aceptar { get; set; }
        public List<ArticuloVendido> ar { get; set; }
        public decimal total { get; set; }        
        public Cobrar()
        {
            //Ventas efe = new Ventas();
            InitializeComponent();            
            btnEfectivo.Select();
            aceptar = false;
            //ar = efe.av;           
        }
        #region //Eventos        
        private void btnEfectivo_Enter(object sender, EventArgs e)
        {
            btnEfectivo.BackColor = Color.FromArgb(40, 86, 182);
            btnCredito.BackColor = Color.WhiteSmoke;
            efectivo1.Visible = true;
            credito1.Visible = false;
            
        }
        private void btnCredito_Enter(object sender, EventArgs e)
        {
            btnCredito.BackColor = Color.FromArgb(40, 86, 182);
            btnEfectivo.BackColor = Color.WhiteSmoke;
            credito1.Visible = true;
            efectivo1.Visible = false;
        }      
        private void btnEfectivo_Click(object sender, EventArgs e)
        {
            if (ar == null) MessageBox.Show("Error");
            else
                    if (!cierto)
                efectivo1.txtEfectivo.Focus();
            cierto = false;
        }
        private void btnEfectivo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Space) cierto = true;
            else if (e.KeyValue == (char)Keys.Escape) cerrar();
        }
        private void btnCredito_Click(object sender, EventArgs e)
        {
            if (!cierto)
                credito1.txtBuscarcliente.Focus();
            cierto = false;
        }
        private void btnCredito_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Space) cierto = true;
            else if (e.KeyValue == (char)Keys.Escape) cerrar();
        }
        private void efectivo1_VisibleChanged(object sender, EventArgs e)
        {
            efectivo1.lblTotal.Text = total.ToString("N2");
            efectivo1.txtEfectivo.Text = total.ToString("N2");
            efectivo1.av = ar;
            //efectivo1.lblTotal.Left = (panel3.Width - efectivo1.lblTotal.Width) / 2;
        }
        private void credito1_VisibleChanged(object sender, EventArgs e)
        {
            credito1.lblTotal.Text = total.ToString("N2");
            credito1.lblTotal.Location = new Point(efectivo1.lblTotal.Location.X, efectivo1.lblTotal.Location.Y);
            credito1.av = ar;
        }
        #endregion
        public void imprimirticket(decimal total,decimal efectivo,decimal cambio,string cliente,List<ArticuloVendido> av)
        {
            //Creamos una instancia d ela clase CrearTicket
            CrearTicket ticket = new CrearTicket();
            //Ya podemos usar todos sus metodos
            //ticket.AbreCajon();//Para abrir el cajon de dinero.
            Datos datos = BDDatos.retornarDatos();
            //De aqui en adelante pueden formar su ticket a su gusto... Les muestro un ejemplo
            if (BDDatos.haydatos())
            {
                if (!string.IsNullOrWhiteSpace(datos.Nombre)) ticket.TextoCentro(datos.Nombre.ToUpper());
                else ticket.TextoCentro("NOMBRE DE LA EMPRESA");
                ticket.TextoIzquierda(datos.Local);
                ticket.TextoIzquierda("DIRECCIÓN: " + datos.Direccion.ToUpper());
                ticket.TextoIzquierda("TELÉFONO: " + datos.Telefono);
            }
            else
            {
                //Datos de la cabecera del Ticket.
                ticket.TextoCentro("NOMBRE DE LA EMPRESA");
                ticket.TextoIzquierda("LOCAL PRINCIPAL");
                ticket.TextoIzquierda("DIREC: DIRECCION DE LA EMPRESA");
                ticket.TextoIzquierda("TELEF: 4530000");
            }
            //Datos de la cabecera del Ticket.
            //ticket.TextoCentro("BUGATTIGYM");
            //ticket.TextoIzquierda("LIMPIA TU MENTE DEL NO PUEDO");
            //ticket.TextoIzquierda("VILLAS DE LA CANTERA");
            //ticket.TextoIzquierda("TEPIC NAYARIT");

            //ticket.TextoIzquierda("R.F.C: XXXXXXXXX-XX");
            //ticket.TextoIzquierda("EMAIL: asaelmb@gmail.com");//Es el mio por si me quieren contactar...
            ticket.TextoIzquierda("");
            ticket.TextoExtremos("Caja # 1", "Ticket # " + BDIngresos.idMax());
            ticket.lineasAsteriscos();

            //Sub cabecera.
            ticket.TextoIzquierda("");
            ticket.TextoIzquierda("ATENDIÓ: " + BDLogeado.retornaLogeado());
            ticket.TextoIzquierda("CLIENTE: " + cliente);
            ticket.TextoIzquierda("");
            ticket.TextoExtremos("FECHA: " + DateTime.Now.ToShortDateString(), "HORA: " + DateTime.Now.ToShortTimeString());
            ticket.lineasAsteriscos();

            //Articulos a vender.
            ticket.EncabezadoVenta();//NOMBRE DEL ARTICULO, CANT, PRECIO, IMPORTE
            ticket.lineasAsteriscos();
            //Si tiene una DataGridView donde estan sus articulos a vender pueden usar esta manera para agregarlos al ticket.
            //foreach (DataGridViewRow fila in dgvLista.Rows)//dgvLista es el nombre del datagridview
            //{
            //ticket.AgregaArticulo(fila.Cells[2].Value.ToString(), int.Parse(fila.Cells[5].Value.ToString()),
            //decimal.Parse(fila.Cells[4].Value.ToString()), decimal.Parse(fila.Cells[6].Value.ToString()));
            //}
            /*ticket.AgregaArticulo("Articulo A", 2, 20, 40);
            ticket.AgregaArticulo("Articulo B", 1, 10, 10);
            ticket.AgregaArticulo("Este es un nombre largo del articulo, para mostrar como se bajan las lineas", 1, 30, 30);*/
            int ta = 0;
            foreach (ArticuloVendido arven in av)
            {
                ticket.AgregaArticulo(arven.Nombre, arven.Cantidad, arven.precio, arven.total);
                ta++;
            }
            ticket.lineasIgual();
            //Resumen de la venta. Sólo son ejemplos
            //ticket.AgregarTotales("         SUBTOTAL......$", 100);
            //ticket.AgregarTotales("         IVA...........$", 10.04M);//La M indica que es un decimal en C#
            ticket.AgregarTotales("         TOTAL.........$", total);
            //ticket.TextoIzquierda("");
            if (efectivo > 0)
            {
                ticket.AgregarTotales("         EFECTIVO......$", efectivo);
                ticket.AgregarTotales("         CAMBIO........$", cambio);
            }

            //Texto final del Ticket.
            ticket.TextoIzquierda("");
            ticket.TextoIzquierda("ARTÍCULOS VENDIDOS: " + ta);
            ticket.TextoIzquierda("");
            ticket.TextoCentro("¡GRACIAS POR SU COMPRA!");
            ticket.CortaTicket();
            ticket.ImprimirTicket(BDDatos.retornaImpresora());//Nombre de la impresora ticketera          
        }
    }
}
