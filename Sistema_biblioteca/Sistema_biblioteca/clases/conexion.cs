using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Sistema_biblioteca.clases
{
    class conexion
    {
        public string servidor, usuario, clave, db;
        public string cadena;

        public void Conexion() {
            servidor = "DESKTOP-O2EAJ87";
            db = "DB_bibliotecaUDB";
            usuario = "sa";
            clave = "123456";
            cadena = "server=" + servidor + ",uid=" + usuario + ",pwd=" + clave + ",database=" + db;
        }
    }
}
