using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Punto_de_venta.Clases;

namespace Punto_de_venta.Base_de_datos
{
    public class BDCuenta
    {
        public static int CuentaNueva(int id, ArticuloVendido c, string fecha)
        {
            int r = 0;
            SQLiteCommand comando = new SQLiteCommand(string.Format("insert into Ticket values('{0}','{1}','{2}','{3}','{4}','{5}')", id, c.Nombre, c.precio, c.Cantidad, c.total, fecha), Conexion.ObtenerConexion());
            r = comando.ExecuteNonQuery();
            Conexion.ObtenerConexion().Close();
            return r;
        }
        public static int CuentaNueva(int id, double total)
        {
            int r = 0;
            SQLiteCommand comando = new SQLiteCommand(string.Format("insert into Cuenta values('{0}','{1}')", id, total), Conexion.ObtenerConexion());
            r = comando.ExecuteNonQuery();
            Conexion.ObtenerConexion().Close();
            return r;
        }
        public static int CuentaEliminar(int id)
        {
            int r = 0;
            SQLiteCommand comando = new SQLiteCommand(string.Format("delete from Cuenta where idCuenta_idCliente = '{0}'", id),Conexion.ObtenerConexion());
            r = comando.ExecuteNonQuery();
            Conexion.ObtenerConexion().Close();
            return r;
        }        
        public static int TicketEliminar(int id)
        {
            int r = 0;
            SQLiteCommand comando = new SQLiteCommand(string.Format("delete from Ticket where idTicket_idCliente = '{0}'", id), Conexion.ObtenerConexion());
            r = comando.ExecuteNonQuery();
            Conexion.ObtenerConexion().Close();
            return r;
        }
        public static int CuentaActualizar(int id,double total)
        {
            int r = 0;
            SQLiteCommand comando = new SQLiteCommand(string.Format("update Cuenta set Total = '{1}' where idCuenta_idCliente ='{0}'", id, total), Conexion.ObtenerConexion());
            r = comando.ExecuteNonQuery();
            Conexion.ObtenerConexion().Close();
            return r;
        }
        public static double RetornarCuenta(int id)
        {
            double t = 0;
            SQLiteCommand comando = new SQLiteCommand(string.Format("select Total from Cuenta where idCuenta_idCliente = '{0}'",id),Conexion.ObtenerConexion());
            SQLiteDataReader leer = comando.ExecuteReader();
            while (leer.Read())
            {
                t = leer.GetDouble(0);
            }
            Conexion.ObtenerConexion().Close();
            return t;
        }
        public static List<string> fechas(int id)
        {
            List<string> fecha = new List<string>();
            SQLiteCommand comando = new SQLiteCommand(string.Format("SELECT DISTINCT fecha FROM Ticket WHERE idTicket_idCliente = '{0}'",id), Conexion.ObtenerConexion());
            SQLiteDataReader leer = comando.ExecuteReader();
            while (leer.Read())
            {
                DateTime fe = Convert.ToDateTime(leer.GetString(0));
                fecha.Add(fe.ToString("dd-MM-yyyy"));

            }
            leer.Close();
            Conexion.ObtenerConexion().Close();
            return fecha;
        }
        public static List<Cuenta> cuenta(int id)
        {
            List<Cuenta> cu = new List<Cuenta>();            
            SQLiteCommand comando = new SQLiteCommand(string.Format("SELECT * FROM Ticket WHERE idTicket_idCliente = '{0}'", id), Conexion.ObtenerConexion());
            SQLiteDataReader leer = comando.ExecuteReader();
            while (leer.Read())
            {
                Cuenta fec = new Cuenta();
                fec.Id = leer.GetInt32(0);
                fec.Articulo = leer.GetString(1);
                fec.Importe = leer.GetDouble(2);
                fec.Cantidad = leer.GetDouble(3);
                fec.Monto = leer.GetDouble(4);
                fec.Fecha = leer.GetString(5);
                cu.Add(fec);
            }
            leer.Close();
            Conexion.ObtenerConexion().Close();            
            return cu;
        }


    }
}
