using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Punto_de_venta.Clases;

namespace Punto_de_venta.Base_de_datos
{
    public class BDIngresos
    {
        public static int IngresoNuevo(Ingresos nuevo)
        {
            int r = 0;
            SQLiteCommand comando = new SQLiteCommand(string.Format("insert into Ingresos(idIngresos,Concepto,Monto,Fecha,Vendedor) values('{0}','{1}','{2}','{3}','{4}')",
                nuevo.Id, nuevo.Concepto, nuevo.Monto, nuevo.Fecha, nuevo.Vendedor), Conexion.ObtenerConexion());
            r = comando.ExecuteNonQuery();
            
            return r;
        }
        public static int IngresoEliminar(string id)
        {
            int r = 0;
            SQLiteCommand comando = new SQLiteCommand(string.Format("delete from Ingresos where idIngresos = '{0}'", id), Conexion.ObtenerConexion());
            r = comando.ExecuteNonQuery();
            
            return r;
        }
        public static List<Ingresos> TablaIngresos()
        {
            List<Ingresos> ingreso = new List<Ingresos>();
            SQLiteCommand comando = new SQLiteCommand(string.Format("select * from Ingresos"), Conexion.ObtenerConexion());
            SQLiteDataReader leer = comando.ExecuteReader();
            while (leer.Read())
            {
                Ingresos ing = new Ingresos();
                ing.Id = leer.GetInt32(0);
                ing.Concepto = leer.GetString(1);
                ing.Monto = leer.GetDouble(2);
                ing.Fecha = leer.GetString(3).Substring(0, 10);
                ing.Vendedor = leer.GetString(4);               
                ingreso.Add(ing);
            }
            
            leer.Close();
            return ingreso;
        }
        public static List<Ingresos> TablaIngresos(int id)
        {
            List<Ingresos> ingreso = new List<Ingresos>();
            SQLiteCommand comando = new SQLiteCommand(string.Format("select * from Ingresos where idIngresos like '{0}%'", id), Conexion.ObtenerConexion());
            SQLiteDataReader leer = comando.ExecuteReader();
            while (leer.Read())
            {
                Ingresos ing = new Ingresos();
                ing.Id = leer.GetInt32(0);
                ing.Concepto = leer.GetString(1);
                ing.Monto = leer.GetDouble(2);
                ing.Fecha = leer.GetString(3).Substring(0, 10);
                ing.Vendedor = leer.GetString(4);               
                ingreso.Add(ing);
            }
            
            leer.Close();
            return ingreso;
        }
        public static List<Ingresos> TablaIngresos(string fecha)
        {
            List<Ingresos> ingreso = new List<Ingresos>();
            SQLiteCommand comando = new SQLiteCommand(string.Format("select * from Ingresos where Fecha = '{0}'", fecha), Conexion.ObtenerConexion());
            SQLiteDataReader leer = comando.ExecuteReader();
            while (leer.Read())
            {
                Ingresos ing = new Ingresos();
                ing.Id = leer.GetInt32(0);
                ing.Concepto = leer.GetString(1);
                ing.Monto = leer.GetDouble(2);
                ing.Fecha = leer.GetString(3).Substring(0, 10);
                ing.Vendedor = leer.GetString(4);
                ingreso.Add(ing);
            }
            
            leer.Close();
            return ingreso;
        }
        public static List<Ingresos> TablaIngresos(string fi,string ff)
        {
            List<Ingresos> ingreso = new List<Ingresos>();
            SQLiteCommand comando = new SQLiteCommand(string.Format("select*from ingresos where Fecha between '{0}' and '{1}'", fi,ff), Conexion.ObtenerConexion());
            SQLiteDataReader leer = comando.ExecuteReader();
            while (leer.Read())
            {
                Ingresos ing = new Ingresos();
                ing.Id = leer.GetInt32(0);
                ing.Concepto = leer.GetString(1);
                ing.Monto = leer.GetDouble(2);
                ing.Fecha = leer.GetString(3).Substring(0, 10);
                ing.Vendedor = leer.GetString(4);
                ingreso.Add(ing);
            }
            
            leer.Close();
            return ingreso;
        }
        public static List<int> ArrIngresosId()
        {
            List<int> ingreso = new List<int>();
            
            SQLiteCommand comando = new SQLiteCommand(string.Format("select idIngresos from Ingresos"), Conexion.ObtenerConexion());
            SQLiteDataReader leer = comando.ExecuteReader();
            while (leer.Read())
            {
                int ing=0;
                ing = leer.GetInt32(0);
                ingreso.Add(ing);
            }
            
            leer.Close();
            return ingreso;
        }
        public static bool haydatos()
        {
            SQLiteCommand comando = new SQLiteCommand(string.Format("select * from Ingresos"), Conexion.ObtenerConexion());
            SQLiteDataReader leer = comando.ExecuteReader();
            if (leer.Read()) { leer.Close();  return true; }
            else { leer.Close();  return false; }
        }
        public static int idMax()
        {
            int r = 0;
            if (haydatos())
            {
                SQLiteCommand comando = new SQLiteCommand("select max(idIngresos) from ingresos", Conexion.ObtenerConexion());
                SQLiteDataReader leer = comando.ExecuteReader();
                while (leer.Read()) r = leer.GetInt32(0);
                
                leer.Close();
                return r;
            }
            else return 0;
        }
        public static List<Ingresos> RegistroOrdenar(int columna)
        {
            string[] Ingreso = { "IdIngresos", "Concepto", "Monto", "Fecha", "Vendedor"};
            List<Ingresos> lista = new List<Ingresos>();
            SQLiteCommand comando = new SQLiteCommand(string.Format("select * from Ingresos order by " + Ingreso[columna]), Conexion.ObtenerConexion());
            SQLiteDataReader leer = comando.ExecuteReader();
            while (leer.Read())
            {
                Ingresos clt = new Ingresos();
                clt.Id = leer.GetInt32(0);
                clt.Concepto = leer.GetString(1);
                clt.Monto = leer.GetInt32(2);
                clt.Fecha = leer.GetString(3).Substring(0,10);
                clt.Vendedor = leer.GetString(4);                
                lista.Add(clt);
            }
            leer.Close();
            
            return lista;
        }
        public static int eliminarregistro()
        {
            int r = 0;
            SQLiteCommand comando = new SQLiteCommand("delete from ingresos", Conexion.ObtenerConexion());
            r = comando.ExecuteNonQuery();
            
            return r;
        }        

    }
}
