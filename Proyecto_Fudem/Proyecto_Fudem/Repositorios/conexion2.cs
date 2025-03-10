using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Proyecto_InefableMedia.Repositorios
{
    class conexion2
    {
        public string servidor, usuario, clave, db;
        public string cadena;
        private string sCn;
        public void conec()
        {
            servidor = "localhost";
            db = "BD_Inefable_POO";
            usuario = "sa";
            clave = "123456";
            cadena = "Data Source =" + servidor + "; Initial Catalog =" + db + "; Integrated Security = True";
        }
    }
}
