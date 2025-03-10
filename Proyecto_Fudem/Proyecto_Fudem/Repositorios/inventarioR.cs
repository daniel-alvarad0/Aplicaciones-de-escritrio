using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_InefableMedia.Clases;
using System.Data.SqlClient;

namespace Proyecto_InefableMedia.Repositorios
{
    class inventarioR : interfaz<inventario>
    {
        private static inventarioR instance = new inventarioR();

        private inventarioR() {

        }

        internal static inventarioR Instance
        {
            get
            {
                return instance;
            }

            set
            {
                instance = value;
            }
        }

        public bool borrar(inventario model)
        {
            var query = "delete from inventario where id_inventario=" + model.Id_inventario;
            return Conexion.getInstance().ejecutarQuery(query);
        }

        public inventario find(int id)
        {
            inventario inventario = new inventario();
            var query = "select * from inventario where id_inventario=" + id;
            SqlDataReader reader = Conexion.getInstance().ejecutarQueryLeer(query);

            while (reader.Read())
            {
                inventario.Id_inventario = reader.GetInt32(0);
                inventario.Producto = reader.GetInt32(1);
                inventario.Cantidad = reader.GetInt32(2);
                inventario.Fecha_inventario = reader.GetDateTime(3);
                //inventario.Almacen = reader.GetInt16(4);
                inventario.Tipo = reader.GetString(4);
            }
            reader.Close();
            return inventario;
        }

        public List<inventario> findAll()
        {
            List<inventario> inventarios = new List<inventario>();
            var query = "select * from inventario ORDER BY Fecha_inventario desc";
            SqlDataReader reader = Conexion.getInstance().ejecutarQueryLeer(query);

            while (reader.Read())
            {
                inventario inventario = new inventario();
                inventario.Id_inventario = reader.GetInt32(0);
                inventario.Producto = reader.GetInt32(1);
                inventario.Cantidad = reader.GetInt32(2);
                inventario.Fecha_inventario = reader.GetDateTime(3);
                inventario.Tipo = reader.GetString(4);
                inventarios.Add(inventario);
            }
            reader.Close();
            return inventarios;
        }

        public bool guardar(inventario model)
        {
            var query = "insert into inventario (producto,cantidad,Fecha_inventario,tipo) values (" + model.Producto + "," + model.Cantidad + ",sysdatetime(),'" + model.Tipo + "')";
            return Conexion.getInstance().ejecutarQuery(query);
        }

        public bool actualizar(inventario model)
        {
            var query = "update inventario set cantidad='" + model.Cantidad  + "' where id_inventario=" + model.Id_inventario;
            return Conexion.getInstance().ejecutarQuery(query);
        }

        public List<inventario> findExistencia()//para llenar el grid de existencia
        {
            var query = "select p.id_producto, sum(i.cantidad) as Existencia from producto p inner join inventario i on p.id_producto = i.producto group by p.id_producto";
            List<inventario> inventarios = new List<inventario>();
            SqlDataReader reader = Conexion.getInstance().ejecutarQueryLeer(query);

            while (reader.Read())
            {
                inventario inventario = new inventario();

                inventario.Producto = reader.GetInt32(0);
                inventario.Cantidad = reader.GetInt32(1);

                inventarios.Add(inventario);
            }

            reader.Close();
            return inventarios;
        }

        public int findExistenciaByProducto(int p)
        {
            var query = "select p.id_producto, sum(i.cantidad) as Existencia from producto p inner join inventario i on p.id_producto = i.producto group by p.id_producto having p.id_producto=" + p;
            int inventarios = 0;
            SqlDataReader reader = Conexion.getInstance().ejecutarQueryLeer(query);

            while (reader.Read())
            {
                inventarios = reader.GetInt32(1);

            }
            reader.Close();
            return inventarios;
        }

        public bool guardar(List<inventario> models)
        {
            throw new NotImplementedException();
        }

    }
}
