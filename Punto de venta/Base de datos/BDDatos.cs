using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Punto_de_venta.Clases;

namespace Punto_de_venta.Base_de_datos
{
    class BDDatos
    {
        public static Datos retornarDatos()
        {
            Datos data = new Datos();
            SQLiteCommand comando = new SQLiteCommand("select*from datosempresa", Conexion.ObtenerConexion());
            SQLiteDataReader leer = comando.ExecuteReader();
            while (leer.Read())
            {
                data.Nombre = leer.GetString(1);
                data.Direccion = leer.GetString(2);
                data.Local = leer.GetString(3);
                data.Telefono = leer.GetString(4);                
            }
            
            leer.Close();
            return data;
        }
        public static int GuardarDatos(Datos data)
        {
            int r = 0;
            SQLiteCommand comando = new SQLiteCommand(string.Format("update datosempresa set NombreLocal = '{0}',DireccionLocal = '{1}',Local = '{2}',TelefonoLocal = '{3}' where idLocal = 1",
                data.Nombre, data.Direccion,data.Local,data.Telefono),Conexion.ObtenerConexion());
            r = comando.ExecuteNonQuery();
            
            return 0;
        }
        public static int guardarImpresora(string imp)
        {
            int r = 0;
            SQLiteCommand comando = new SQLiteCommand(string.Format("update datosempresa set impresoralocal = '{0}' where idLocal = 1",
                imp),Conexion.ObtenerConexion());
            r = comando.ExecuteNonQuery();
            
            return r;
        }
        public static string retornaImpresora()
        {
            string imp = "";
            SQLiteCommand comanod = new SQLiteCommand("select impresoralocal from datosempresa",Conexion.ObtenerConexion());
            SQLiteDataReader leer = comanod.ExecuteReader();
            while (leer.Read())
            {
                imp = leer.GetString(0);
            }
            
            leer.Close();
            return imp;
        }
        public static bool haydatos()
        {
            SQLiteCommand comando = new SQLiteCommand(string.Format("select * from datosempresa"), Conexion.ObtenerConexion());
            SQLiteDataReader leer = comando.ExecuteReader();
            if (leer.Read()) { leer.Close();  return true; }
            else { leer.Close();  return false; }
        }

    }
}
