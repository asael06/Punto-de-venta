using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Punto_de_venta.Clases;


namespace Punto_de_venta.Base_de_datos
{
    class BDCliente
    {
        public static int ClienteNuevo(Cliente c)
        {
            int r = 0;
            SQLiteCommand comando = new SQLiteCommand(string.Format("insert into Clientes values('{0}','{1}','{2}','{3}')",c.Id,c.Nombre,c.Direccion,c.Telefono),Conexion.ObtenerConexion());
            r = comando.ExecuteNonQuery();
            Conexion.ObtenerConexion().Close();
            return r;
        }
        public static int EditarCliente(Cliente c)
        {
            int r = 0;
            SQLiteCommand comando = new SQLiteCommand(string.Format("update Clientes set CNombre='{1}', CDireccion='{2}',CTelefono='{3}' where idCliente='{0}'",c.Id,c.Nombre,c.Direccion,c.Telefono),Conexion.ObtenerConexion());
            r = comando.ExecuteNonQuery();
            Conexion.ObtenerConexion().Close();
            return r;
        }
        public static int EliminarCliente(int id)
        {
            int r = 0;
            SQLiteCommand comando = new SQLiteCommand(string.Format("delete from Clientes where idCliente = '{0}'", id), Conexion.ObtenerConexion());
            r = comando.ExecuteNonQuery();
            Conexion.ObtenerConexion().Close();
            return r;
        }
        public static Cliente RetornaCliente(int id)
        {
            Cliente c = new Cliente();
            SQLiteCommand comando = new SQLiteCommand(string.Format("select * from Clientes where idCliente = '{0}'", id), Conexion.ObtenerConexion());
            SQLiteDataReader leer = comando.ExecuteReader();
            while (leer.Read())
            {
                c.Id = leer.GetInt32(0);
                c.Nombre = leer.GetString(1);
                c.Direccion = leer.GetString(2);
                c.Telefono = leer.GetString(3);
            }
            leer.Close();
            Conexion.ObtenerConexion().Close();
            return c;
        }
        public static List<Cliente> Tabla()
        {
            List<Cliente> lis = new List<Cliente>();
            SQLiteCommand contar = new SQLiteCommand(string.Format("select * from Clientes order by idCliente"), Conexion.ObtenerConexion());
            SQLiteDataReader leer = contar.ExecuteReader();
            while (leer.Read())
            {
                Cliente cl = new Cliente();
                cl.Id = leer.GetInt32(0);
                cl.Nombre = leer.GetString(1);
                cl.Direccion = leer.GetString(2);
                cl.Telefono = leer.GetString(3);
                lis.Add(cl);
            }
            leer.Close();
            return lis;
        }
        public static int mayor()
        {
            int m = 0;
            if (haydatos())
            {
                SQLiteCommand comando = new SQLiteCommand("SELECT  MAX(idCliente) FROM  Clientes", Conexion.ObtenerConexion());
                SQLiteDataReader leer = comando.ExecuteReader();
                while (leer.Read()) m = leer.GetInt32(0);
                return m;
            }return m;
            
        }
        public static bool haydatos()
        {
            SQLiteCommand comando = new SQLiteCommand(string.Format("select * from Clientes"), Conexion.ObtenerConexion());
            SQLiteDataReader leer = comando.ExecuteReader();
            if (leer.Read()) { leer.Close(); Conexion.ObtenerConexion().Close(); return true; }
            else { leer.Close(); Conexion.ObtenerConexion().Close(); return false; }
        }
    }
}