using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Punto_de_venta.Clases;
using System.Data.SQLite;

namespace Punto_de_venta.Base_de_datos
{
    class BDUsuario
    {
        public static int UsuarioNuevo(Usuario user)
        {
            int n = 0;
            SQLiteCommand comando = new SQLiteCommand(string.Format(
            "insert into Usuarios values('{0}','{1}','{2}','{3}','{4}')",
            user.id, user.Nombre,user.Telefono,user.Contrasena,user.Rol), Conexion.ObtenerConexion());
            n = comando.ExecuteNonQuery();            
            return n;
        }
        public static int UsuarioActualizar(Usuario user)
        {
            int n = 0;
            SQLiteCommand comando = new SQLiteCommand(string.Format(
            "update Usuarios set UNombre = '{1}',UTelefono = '{2}',UContrasena = '{3}',URol = '{4}' where idUsuarios = '{0}'",
            user.id, user.Nombre,user.Telefono, user.Contrasena, user.Rol), Conexion.ObtenerConexion());
            n = comando.ExecuteNonQuery();
            
            return n;
        }
        public static int UsuarioEliminar(int id)
        {
            int r = 0;
            SQLiteCommand comando = new SQLiteCommand(string.Format("delete from Usuarios where idUsuarios = '{0}'", id), Conexion.ObtenerConexion());
            r = comando.ExecuteNonQuery();
            
            return r;
        }        
        public static Usuario ObtenerUsuario(int nombre)
        {
            Usuario clt = new Usuario();
            SQLiteCommand comando = new SQLiteCommand(string.Format("select * from Usuarios where idUsuarios = '{0}'",
                nombre), Conexion.ObtenerConexion());
            SQLiteDataReader leer = comando.ExecuteReader();
            while (leer.Read())
            {                
                clt.id = leer.GetInt32(0);
                clt.Nombre = leer.GetString(1);
                clt.Telefono = leer.GetString(2);                
                clt.Contrasena = leer.GetString(3);                
                clt.Rol = leer.GetString(4);                
            }
            leer.Close();            
            return clt;
        }
        public static List<Usuario> UsuariosTabla()
        {
            List<Usuario> lista = new List<Usuario>();

            SQLiteCommand comando = new SQLiteCommand(string.Format("select * from Usuarios"), Conexion.ObtenerConexion());
            SQLiteDataReader leer = comando.ExecuteReader();
            while (leer.Read())
            {
                Usuario clt = new Usuario();
                clt.id = leer.GetInt32(0);
                clt.Nombre = leer.GetString(1);
                clt.Telefono = leer.GetString(2);
                clt.Contrasena = leer.GetString(3);
                clt.Rol = leer.GetString(4);
                lista.Add(clt);
            }
            leer.Close();            
            return lista;
        }
        public static List<string> NombreUsuario()
        {
            List<string> lista = new List<string>();            
            SQLiteCommand comando = new SQLiteCommand(string.Format("select UNombre from usuarios"), Conexion.ObtenerConexion());
            SQLiteDataReader leer = comando.ExecuteReader();
            while (leer.Read())
            {
                string nombre;
                nombre = leer.GetString(0);
                lista.Add(nombre);
            }
            leer.Close();            
            return lista;
        }       
        public static bool haydatos()
        {
            SQLiteCommand comando = new SQLiteCommand(string.Format("select * from Usuarios"), Conexion.ObtenerConexion());
            SQLiteDataReader leer = comando.ExecuteReader();
            if (leer.Read()) { leer.Close();  return true; }
            else { leer.Close();  return false; }
        }
        public static int mayor()
        {
            int may = 0;
            if (haydatos())
            {
                SQLiteCommand comando = new SQLiteCommand(string.Format("select max(idUsuarios) from Usuarios"), Conexion.ObtenerConexion());
                SQLiteDataReader leer = comando.ExecuteReader();
                while (leer.Read()) may = leer.GetInt32(0);
                leer.Close();                
                return may;
            }
            else return may;
        }
        public static int Autentificar(String name, String pass)
        {
            int resultado = -1;
            SQLiteConnection Con = Conexion.ObtenerConexion();

            SQLiteCommand comando = new SQLiteCommand(String.Format("select UNombre,UContrasena from usuarios  where UNombre = '{0}' and UContrasena = '{1}'", name, pass), Con);
            SQLiteDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                resultado = 50;
            }
            Con.Close();
            return resultado;
        }
        public static string rol(string nombre,string contrasena)
        {
            string ro = "";
            SQLiteCommand comando = new SQLiteCommand(string.Format("select URol from usuarios where unombre = '{0}' and ucontrasena = '{1}'", nombre, contrasena), Conexion.ObtenerConexion());
            SQLiteDataReader leer = comando.ExecuteReader();
            while (leer.Read())
            {
                ro = leer.GetString(0);
            }            
            leer.Close();
            return ro;
        }

    }
}
