using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_InefableMedia.Clases;
using System.Data.SqlClient;
using System.Windows.Forms;
//utilizamos la carpeta clases para poder utilizarlas
namespace Proyecto_InefableMedia.Repositorios
{
    class ventaR : interfaz<venta>//clase venta
    {
        private static ventaR instancia = new ventaR();

        public ventaR() {

        }

        internal static ventaR Instancia {

            get { return instancia; }
            set { instancia = value; }
        }

        public bool borrar(venta model)
        {
            String query = "delete from factura where id_factura=" + model.Id_factura;
            return Conexion.getInstance().ejecutarQuery(query);
        }

        public int findByCodigo(int codigo) //encontrar por codigo
        {
            int numero = 0;
            string query = "select id_factura from factura where num_factura=" + codigo;
            SqlDataReader reader = Conexion.getInstance().ejecutarQueryLeer(query);
            while (reader.Read())
            {
                numero = reader.GetInt32(0);

            }
            reader.Close();
            return numero;
        }

        public venta find(int id) //encontrar
        {
            venta venta = new venta(); //invocacion de la clase venta
            string query = "select * from factura where id_empleado=" + id;
            SqlDataReader reader = Conexion.getInstance().ejecutarQueryLeer(query);
            while (reader.Read())
            {
                venta.Id_factura = reader.GetInt32(0);
                venta.Numero_factura = reader.GetInt32(1);
                venta.Id_Cliente = reader.GetInt32(2);
                venta.Id_Usuario = reader.GetInt32(3);
                venta.Fecha_facturacion = reader.GetDateTime(4);
                venta.Total = reader.GetDecimal(5);
                venta.Subtotal = reader.GetDecimal(6);
                venta.IVA = reader.GetDecimal(7);
                venta.Descuento = reader.GetDecimal(8);

            }
            reader.Close();
            return venta;
        }

        public List<venta> findAll() //encontrar todo mediente la clase venta
        {
            List<venta> ventas = new List<venta>();
            string query = "select * from factura";
            SqlDataReader reader = Conexion.getInstance().ejecutarQueryLeer(query);
            while (reader.Read())
            {
                venta venta = new venta(); //invocacion de la clase venta
                venta.Id_factura = reader.GetInt32(0);
                venta.Numero_factura = reader.GetInt32(1);
                venta.Id_Cliente = reader.GetInt32(2);
                venta.Id_Usuario = reader.GetInt32(3);
                venta.Fecha_facturacion = reader.GetDateTime(4);
                venta.Total = reader.GetDecimal(5);
                venta.Subtotal = reader.GetDecimal(6);
                venta.IVA = reader.GetDecimal(7);
                venta.Descuento = reader.GetDecimal(8);
                ventas.Add(venta);
            }
            reader.Close();
            return ventas;
        }

        public bool guardar(List<venta> models)
        {
            throw new NotImplementedException();
        }

        public bool guardar(venta model)
        {
            String query = "insert into factura (num_factura, id_cliente, id_empleado, fecha_facturacion, total, sub_total, IVA, descuento) values('" + model.Numero_factura + "','" + model.Id_Cliente + "','" + model.Id_Usuario + "',sysdatetime(),'"  + "','" + model.Total + "','" + model.Subtotal + "','" + model.IVA + "','" + model.Descuento + "')";
           // MessageBox.Show(query);
           // 
            return Conexion.getInstance().ejecutarQuery(query);
        }

        public bool actualizar(venta model)
        {
            String query = "update factura set num_factura=" + model.Numero_factura + ", id_cliente=" + model.Id_Cliente + ", id_empleado=" + model.Id_Usuario + ", fecha_facturacion='" + model.Fecha_facturacion.ToString("dd-MM-yy") + "', metodoPago='" + model.MetodoPago + "', total='" + model.Total + "', sub_total='" + model.Subtotal + "', IVA='" + model.IVA + "', descuento='" + model.Descuento + "' where id_factura=" + model.Id_factura;
            return Conexion.getInstance().ejecutarQuery(query);
        }
    }
}
