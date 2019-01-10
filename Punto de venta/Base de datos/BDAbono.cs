using Punto_de_venta.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite; 

namespace Punto_de_venta.Base_de_datos
{
    class BDAbono
    {
        public static int AbonoNuevo(Abono a)
        {
            int r = 0;
            SQLiteCommand comando = new SQLiteCommand(string.Format("insert into Abono values('{0}','{1}','{2}')",a.Id,a.Monto,a.Fecha),Conexion.ObtenerConexion());
            r = comando.ExecuteNonQuery();
            Conexion.ObtenerConexion().Close();
            return r;
        }
        public static int AbonoEliminar(int id)
        {
            int r = 0;
            SQLiteCommand comando = new SQLiteCommand(string.Format("delete from Abono where idAbono_idCliente = '{0}'",id), Conexion.ObtenerConexion());
            r = comando.ExecuteNonQuery();
            Conexion.ObtenerConexion().Close();
            return r;
        }
        public static List<Abono> AbonoRetorna(int id)
        {
            List<Abono> lista = new List<Abono>();
            SQLiteCommand comando = new SQLiteCommand(string.Format("select * from Abono where idAbono_idCliente = '{0}'",id),Conexion.ObtenerConexion());
            SQLiteDataReader leer = comando.ExecuteReader();
            while (leer.Read())
            {
                Abono cad = new Abono();
                cad.Id = leer.GetInt32(0);
                cad.Monto = leer.GetDouble(1);
                cad.Fecha = Convert.ToDateTime(leer.GetString(2)).ToString("dd-MM-yyyy");
                lista.Add(cad);
            }
            leer.Close();
            Conexion.ObtenerConexion().Close();
            return lista;
        }

    }
}
