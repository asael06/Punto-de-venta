using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punto_de_venta.Clases
{
    public class Art
    {        
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double Cantidad { get; set; }
        public double Precio { get; set; }        
        public double existencia { get; set; }
        public Art() { }

        public Art(string nombre, string descripcion, double cantidad, double precio, double existencia)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            Cantidad = cantidad;
            Precio = precio;            
            this.existencia = existencia;
        }
    }
}
