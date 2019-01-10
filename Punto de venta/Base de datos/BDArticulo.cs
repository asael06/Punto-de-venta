using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Punto_de_venta.Clases;

namespace Punto_de_venta.Base_de_datos
{
    class BDArticulo
    {
        public static int ArticuloNuevo(Articulo articulo)
        {
            int r = 0;
            SQLiteCommand comando = new SQLiteCommand(string.Format("insert into Articulo values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}');",
                articulo.Id,articulo.Nombre,articulo.Descripcion,articulo.Costo,articulo.Precio,articulo.Stock,articulo.StockMin,articulo.Unidad),Conexion.ObtenerConexion());
            r = comando.ExecuteNonQuery();            
            return r;
        }
        public static int EditarArticulo(Articulo articulo)
        {
            int r = 0;
            SQLiteCommand comando = new SQLiteCommand(string.Format("update Articulo set ANCb = '{0}', ADescripcion = '{1}', ACosto = '{2}', APrecio = '{3}', AStock = '{4}', AStockMin = '{5}' , AUnidad = '{6}' where IdArticulo = '{7}'",
                articulo.Nombre, articulo.Descripcion, articulo.Costo, articulo.Precio, articulo.Stock, articulo.StockMin, articulo.Unidad, articulo.Id), Conexion.ObtenerConexion());
            r = comando.ExecuteNonQuery();            
            return r;
        }
        public static int EliminarArticulo(int id)
        {
            int r = 0;
            SQLiteCommand comando = new SQLiteCommand(string.Format("delete from Articulo where IdArticulo = '{0}'",id),Conexion.ObtenerConexion());
            r = comando.ExecuteNonQuery();
            return r;
        }
        public static List<Articulo> tabla(string articulo)
        {
            List<Articulo> lis=new List<Articulo>();
            SQLiteCommand contar = new SQLiteCommand(string.Format("select * from articulo where ANombre like '{0}%'",articulo),Conexion.ObtenerConexion());
            SQLiteDataReader leer = contar.ExecuteReader();
            while (leer.Read())
            {
                Articulo art = new Articulo();
                art.Id = leer.GetInt32(0);
                art.Nombre = leer.GetString(1);
                art.Descripcion = leer.GetString(2);
                art.Costo = leer.GetDouble(3);
                art.Precio = leer.GetDouble(4);
                art.Stock = leer.GetDouble(5);
                art.StockMin = leer.GetDouble(6);
                art.Unidad = leer.GetString(7);                
                lis.Add(art);
            }            
            leer.Close();
            return lis;
        }
        public static List<Articulo> tabla()
        {
            List<Articulo> lis = new List<Articulo>();
            SQLiteCommand contar = new SQLiteCommand(string.Format("select * from Articulo order by idArticulo"), Conexion.ObtenerConexion());            
            SQLiteDataReader leer = contar.ExecuteReader();
            while (leer.Read())
            {
                Articulo art = new Articulo();
                art.Id = leer.GetInt32(0);
                art.Nombre = leer.GetString(1);
                art.Descripcion = leer.GetString(2);
                art.Costo = leer.GetDouble(3);
                art.Precio = leer.GetDouble(4);
                art.Stock = leer.GetDouble(5);
                art.StockMin = leer.GetDouble(6);
                art.Unidad = leer.GetString(7);
                lis.Add(art);
            }
            leer.Close();
            return lis;
        }
        public static List<int> ta()
        {
            List<int> lis = new List<int>();
            SQLiteCommand contar = new SQLiteCommand(string.Format("select idArticulo from articulo"), Conexion.ObtenerConexion());
            SQLiteDataReader leer = contar.ExecuteReader();
            while (leer.Read())
            {
                int num = leer.GetInt32(0);
                lis.Add(num);
            }
            
            leer.Close();
            return lis;
        }        
        public static bool haydatos()
        {
            SQLiteCommand comando = new SQLiteCommand(string.Format("select * from Articulo"), Conexion.ObtenerConexion());
            SQLiteDataReader leer = comando.ExecuteReader();
            if (leer.Read()) { leer.Close(); return true; }
            else { leer.Close();  return false; }
        }
        public static int mayor()
        {
            int may = 0;
            if (haydatos())
            {
                SQLiteCommand comando = new SQLiteCommand(string.Format("select max(IdArticulo) from Articulo"),Conexion.ObtenerConexion());
                SQLiteDataReader leer = comando.ExecuteReader();
                while (leer.Read()) may = leer.GetInt32(0);
                leer.Close();                
                return may;
            }
            else return may;
        }
        public static Articulo obtenerArticulo(string articulo)
        {
            Articulo art = new Articulo();
            SQLiteCommand contar = new SQLiteCommand(string.Format("select * from Articulo where ANCb = '{0}'", articulo), Conexion.ObtenerConexion());
            SQLiteDataReader leer = contar.ExecuteReader();
            while (leer.Read())
            {                
                art.Id = leer.GetInt32(0);
                art.Nombre = leer.GetString(1);
                art.Descripcion = leer.GetString(2);
                art.Costo = leer.GetDouble(3);
                art.Precio = leer.GetDouble(4);
                art.Stock = leer.GetDouble(5);
                art.StockMin = leer.GetDouble(6);
                art.Unidad = leer.GetString(7);                
            }
            leer.Close();
            return art;
        }
        public static bool existe(string articulo)
        {
            int con = 0; 
            SQLiteCommand contar = new SQLiteCommand(string.Format("select * from articulo where ANCb = '{0}'", articulo), Conexion.ObtenerConexion());
            SQLiteDataReader leer = contar.ExecuteReader();
            while (leer.Read())
            {
                con++;
            }
            
            leer.Close();
            return con>0;
        }
        public static Articulo obtenerArticulo(int articulo)
        {
            Articulo art = new Articulo();
            SQLiteCommand contar = new SQLiteCommand(string.Format("select * from articulo where idArticulo = '{0}'", articulo), Conexion.ObtenerConexion());
            SQLiteDataReader leer = contar.ExecuteReader();
            while (leer.Read())
            {
                
                art.Id = leer.GetInt32(0);
                art.Nombre = leer.GetString(1);
                art.Descripcion = leer.GetString(2);
                art.Costo = leer.GetDouble(3);
                art.Precio = leer.GetDouble(4);
                art.Stock = leer.GetDouble(5);
                art.StockMin = leer.GetDouble(6);
                art.Unidad = leer.GetString(7);
                
            }
            leer.Close();
            return art;
        }        
        public static double mostrarStock(string id)
        {
            double s = 0;
            SQLiteCommand comando = new SQLiteCommand(string.Format("select AStock from Articulo where ANCb = '{0}'", id), Conexion.ObtenerConexion());
            SQLiteDataReader leer = comando.ExecuteReader();
            while (leer.Read())
            {
                s = leer.GetDouble(0);
            }            
            leer.Close();
            return s;
        }
        public static int actualizarStock(double stock,string id)
        {
            int r = 0;
            SQLiteCommand comando = new SQLiteCommand(string.Format("update Articulo set AStock = '{0}' where ANCb = '{1}'", stock,id),Conexion.ObtenerConexion());
            r = comando.ExecuteNonQuery();            
            return r;
        }
    }
}
