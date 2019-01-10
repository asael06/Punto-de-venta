using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Punto_de_venta.Clases;

namespace Punto_de_venta.Base_de_datos
{
    public class BDLogeado
    {
        public static int Logearse(string nombre,string rol)
        {
            int r = 0;
            SQLiteCommand comando = new SQLiteCommand(string.Format("update logeado set LNombre = '{0}',LRol = '{1}' where idLogeado = 1",nombre,rol),Conexion.ObtenerConexion());
            r = comando.ExecuteNonQuery();
            
            return r;
        }
        public static string retornaLogeado()
        {
            string nombre="";
            SQLiteCommand comando = new SQLiteCommand(string.Format("select LNombre from Logeado where idLogeado=1"),Conexion.ObtenerConexion());
            SQLiteDataReader leer = comando.ExecuteReader();
            while (leer.Read()) nombre = leer.GetString(0);
            
            leer.Close();
            return nombre;
        }
        public static string retorarRol()
        {
            string nombre = "";
            SQLiteCommand comando = new SQLiteCommand(string.Format("select LRol from Logeado where idLogeado=1"), Conexion.ObtenerConexion());
            SQLiteDataReader leer = comando.ExecuteReader();
            while (leer.Read()) nombre = leer.GetString(0);
            
            leer.Close();
            return nombre;
        }
    }
}
