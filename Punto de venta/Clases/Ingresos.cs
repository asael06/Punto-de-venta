using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punto_de_venta.Clases
{
    public class Ingresos
    {
        public int Id { get; set; }
        public string Concepto { get; set; }
        public double Monto { get; set; }
        public string Fecha { get; set; }
        public string Vendedor { get; set; }
        public Ingresos() { }
        public Ingresos(int IId,string IConcepto,double IMonto,string IFecha,string IVendedor)
        {
            Id = IId;
            Concepto = IConcepto;
            Monto = IMonto;
            Fecha = IFecha;
            Vendedor = IVendedor;
        }
    }
}
