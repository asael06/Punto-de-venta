using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punto_de_venta.Clases
{
    public class ArticuloVendido
    {
        public string Nombre { get; set; }
        public decimal Cantidad { get; set; }
        public decimal precio { get; set; }
        public decimal total { get; set; }        
        public ArticuloVendido() { }
        public ArticuloVendido(string nombre, decimal cantidad, decimal precio, decimal total)
        {
            Nombre = nombre;
            Cantidad = cantidad;
            this.precio = precio;
            this.total = total;
        }
    }
}
