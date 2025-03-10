using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proyecto_InefableMedia.Repositorios
{
    class Conexion
    {
      //  public string servidor, usuario, clave, db;
        //public string cadena;
        private string sCn;
       // public void conec()
        //{
          //  servidor = "localhost";
           // db = "inefable2";
           // usuario = "sa";
           // clave = "123456";
            //cadena = "Data Source =" + servidor + "; Initial Catalog =" + db + "; Integrated Security = True";
       // }

        private SqlConnection conexion;
        private static Conexion instancia = new Conexion();

        
       private Conexion() {
            conexion2 cnn = new conexion2();
            cnn.conec();
            sCn = cnn.cadena;
            conexion = new SqlConnection(sCn);
            conexion.Open();
        }

        public static Conexion getInstance()
        {
            return instancia;
        }

        public bool ejecutarQuery(String query)
        {

            bool ret = false;
            try
            {
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.ExecuteNonQuery();
                ret = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return ret;
        }

        public SqlDataReader ejecutarQueryLeer(String query)
        {
            SqlDataReader dataReader = null;
            try
            {
                SqlCommand cmd = new SqlCommand(query, conexion);
                dataReader = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return dataReader;
        }

    }
}
