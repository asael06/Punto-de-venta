using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punto_de_venta.Clases
{
    public class Abono
    {
        public int Id { get; set; }
        public double Monto { get; set; }
        public string Fecha { get; set; }
        public Abono() { }
        public Abono(int id, double monto, string fecha)
        {
            Id = id;
            Monto = monto;
            Fecha = fecha;
        }
    }
}
