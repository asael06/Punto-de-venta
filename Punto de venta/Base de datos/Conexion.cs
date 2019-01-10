using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punto_de_venta.Clases
{
    class Conexion
    {
        public static SQLiteConnection conectar = null;
        public static SQLiteConnection ObtenerConexion()
        {
            if (conectar == null)
            {
                //conectar = new SQLiteConnection("Data Source=C:/Users/asael/OneDrive/Documentos/Visual Studio 2015/Projects/Punto de venta/Punto de venta/Punto de venta.db");
                conectar = new SQLiteConnection("Data Source=Punto de venta.db");
                conectar.Open();
                return conectar;
            }
            else if (conectar.State != System.Data.ConnectionState.Open)
            {
                conectar.Open();
                return conectar;
            }
            else return conectar;
        }

        
    }

}