using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Proyecto_InefableMedia.Clases;

namespace Proyecto_InefableMedia.Repositorios
{
    class productosR : interfaz<productos>
    {
        private static productosR instance = new productosR();
        private productosR() {

        }

        internal static productosR Instance {
            get { return instance; }
            set { instance = value; }
        }

        public bool borrar(productos model)
        {
            var consulta = "delete from producto where id_producto=" + model.Id_producto;
            return Conexion.getInstance().ejecutarQuery(consulta);
        }

        public productos find(int id)
        {
            productos producto = new productos();
            SqlDataReader reader = Conexion.getInstance().ejecutarQueryLeer("select * from producto where id_producto=" + id);

            while (reader.Read())
            {
                producto.Id_producto = reader.GetInt32(0);
                producto.Id_proveedor = reader.GetInt32(1);
                producto.Id_empleado = reader.GetInt32(2);
                producto.Nombre = reader.GetString(3);
                producto.Precio_compra = reader.GetDecimal(4);
                producto.Precio_venta = reader.GetDecimal(5);
                producto.Descripcion = reader.GetString(6);
                producto.Fecha_producto = reader.GetDateTime(7);    
                producto.Tipo = reader.GetString(8);
               
                
            }
            reader.Close();
            return producto;
        }

        public List<productos> findAll() //para llenar el datagrid de productos
        {
            List<productos> productos = new List<productos>();

            SqlDataReader reader = Conexion.getInstance().ejecutarQueryLeer("select * from producto");

            while (reader.Read())
            {
                productos producto = new productos();
                producto.Id_producto = reader.GetInt32(0);
                producto.Id_proveedor = reader.GetInt32(1);
                producto.Id_empleado = reader.GetInt32(2);
                producto.Nombre = reader.GetString(3);
                producto.Precio_compra = reader.GetDecimal(4);
                producto.Precio_venta = reader.GetDecimal(5);
                producto.Descripcion = reader.GetString(6);
                producto.Fecha_producto = reader.GetDateTime(7);
                producto.Tipo = reader.GetString(8);


                productos.Add(producto);
            }
            reader.Close();
            return productos;
        }

        public List<String> findTipo()
        {
            var query = "select tipo from producto group by tipo";
            List<String> tipos = new List<string>();

            SqlDataReader reader = Conexion.getInstance().ejecutarQueryLeer(query);

            while (reader.Read())
            {
                tipos.Add(reader.GetString(0));
            }
            reader.Close();
            return tipos;
        }


        public bool guardar(List<productos> models)
        {
            throw new NotImplementedException();
        }

        public bool guardar(productos model)
        {
            String query = "insert into producto (id_proveedor,id_empleado,nombre_producto,precio_compra,precio_venta,descripcion,fecha_producto, tipo) values('" + model.Id_proveedor + "','" + model.Id_empleado + "','" + model.Nombre + "','" + model.Precio_compra + "','" + model.Precio_venta + "','" + model.Descripcion + "',sysdatetime(),'" + model.Tipo + "')";

            return Conexion.getInstance().ejecutarQuery(query);
        }

        public bool actualizar(productos model)
        {
            String query = "update producto set nombre_producto='" + model.Nombre + "',precio_compra='" + model.Precio_compra + "',precio_venta='" + model.Precio_venta + "',descripcion='" + model.Descripcion + "',tipo='" + model.Tipo + "' where id_producto=" + model.Id_producto;
            return Conexion.getInstance().ejecutarQuery(query);
        }
    }
}
