using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punto_de_venta.Clases
{
    public class Cuenta
    {
        public int Id { get; set; }
        public string Articulo { get; set; } 
        public double Importe { get; set; }
        public double Cantidad { get; set; }
        public double Monto { get; set; }
        public string Fecha { get; set; }
        public Cuenta() { }
        public Cuenta(int id, string articulo, double importe, double cantidad, double monto, string fecha)
        {
            Id = id;
            Articulo = articulo;
            Importe = importe;
            Cantidad = cantidad;
            Monto = monto;
            Fecha = fecha;
        }
    }
}
