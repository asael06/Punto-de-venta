using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punto_de_venta.Clases
{
    public class Usuario
    {
        public int id { get; set; }
        public string Nombre { get; set; }        
        public string Telefono { get; set; }        
        public string Contrasena { get; set; }
        public string Rol { get; set; }        
        public Usuario() { }
        public Usuario(int id, string nombre, string telefono, string contrasena, string rol)
        {
            this.id = id;
            Nombre = nombre;
            Telefono = telefono;            
            Contrasena = contrasena;
            Rol = rol;
        }
    }
}
