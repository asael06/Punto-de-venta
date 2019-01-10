using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punto_de_venta.Clases
{
    class Datos
    {
        public string Nombre { get; set; }
        public string Local { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }        
        public Datos() { }
        public Datos(string DNombre,string DLocal,string DDireccion,string DTelefono)
        {
            Nombre = DNombre;
            Local = DLocal;
            Direccion = DDireccion;
            Telefono = DTelefono;            
        }
    }
}
