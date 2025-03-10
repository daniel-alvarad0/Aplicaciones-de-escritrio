using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_InefableMedia.Clases;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proyecto_InefableMedia.Repositorios
{
    class descripcion_ventaR : interfaz<descripcion_venta>
    {
        private static descripcion_ventaR instance = new descripcion_ventaR();

        public descripcion_ventaR() {

        }

        internal static descripcion_ventaR Instance
        {
            get
            { return instance; }

            set
            { instance = value; }
        }

        public bool borrar(descripcion_venta model)
        {
            throw new NotImplementedException();
        }

        public descripcion_venta find(int id)
        {
            throw new NotImplementedException();
        }

        public List<descripcion_venta> findAll()
        {
            throw new NotImplementedException();
        }

        public bool guardar(List<descripcion_venta> models)
        {
            foreach (descripcion_venta venta in models)
            {
                guardar(venta);
            }

            return true;
        }

        public bool guardar(descripcion_venta model)
        {
            var query = "insert into detalle_factura (id_producto,cantidad,factura,precio) values ";
            query += " (" + model.Producto + ", " + model.Cantidad + ", " + model.Venta + ", " + model.Precio.ToString().Replace(",", ".") + ")";

            return Conexion.getInstance().ejecutarQuery(query);
        }

        public bool actualizar(descripcion_venta model)
        {
            throw new NotImplementedException();
        }

        public int vendido(int producto)
        {
            int vendido = 0;
            var query = "select p.id_producto, sum(d.cantidad) as Existencia from producto p inner join detalle_factura d on p.id_producto = d.id_producto group by p.id_producto having p.id_producto =" + producto;
            SqlDataReader reader = Conexion.getInstance().ejecutarQueryLeer(query);

            while (reader.Read())
            {
                vendido = reader.GetInt32(1);
            }

            reader.Close();
            return vendido;
        }
    }
}
