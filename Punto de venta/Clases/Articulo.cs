using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punto_de_venta.Clases
{
    public class Articulo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double Costo { get; set; }
        public double Precio { get; set; }
        public double Stock { get; set; }        
        public double StockMin { get; set; }
        public string Unidad { get; set; }
        public Articulo() { }
        public Articulo(int id, string nombre, string descripcion, double costo, double precio, double stock, double stockMin, string unidad)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            Costo = costo;
            Precio = precio;
            Stock = stock;
            StockMin = stockMin;
            Unidad = unidad;
        }
    }
}
