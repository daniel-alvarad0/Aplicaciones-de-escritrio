using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_InefableMedia.Clases;
using System.Data.SqlClient;

namespace Proyecto_InefableMedia.Repositorios
{
    class clientesR : interfaz<clientes>
    {
        private static clientesR instance = new clientesR();
        public clientesR() {

        }

        internal static clientesR Instance
        {
            get{ return instance; }
            set{ instance = value; }
        }

        public bool borrar(clientes model)
        {
            var consulta = "delete from cliente where id_cliente=" + model.Id_cliente;
            return Conexion.getInstance().ejecutarQuery(consulta);
        }

        public clientes find(int id)
        {
            var consulta = "select * from cliente where id_cliente=" + id;
            clientes cliente = new clientes();
            SqlDataReader reader = Conexion.getInstance().ejecutarQueryLeer(consulta);

            while (reader.Read())
            {
                cliente.Id_cliente = reader.GetInt32(0);
                cliente.Nombre_cliente = reader.GetString(1);
                cliente.Apellidos = reader.GetString(2);
                cliente.Num_telefono = reader.GetInt32(3);
                cliente.Direccion = reader.GetString(4);
                cliente.DUI = reader.GetString(5);
                cliente.NIT = reader.GetString(6);
                cliente.Correo = reader.GetString(7);
                cliente.Fecha = reader.GetString(8);
            }

            reader.Close();
            return cliente;
        }

        public List<clientes> findAll()
        {
            List<clientes> clientes = new List<clientes>();
            var consulta = "select * from cliente";
            SqlDataReader reader = Conexion.getInstance().ejecutarQueryLeer(consulta);

            while (reader.Read())
            {
                clientes cliente = new clientes();
                cliente.Id_cliente = reader.GetInt32(0);
                cliente.Nombre_cliente = reader.GetString(1);
                cliente.Apellidos = reader.GetString(2);
                cliente.Num_telefono = reader.GetInt32(3);
                cliente.Direccion = reader.GetString(4);
                cliente.DUI = reader.GetString(5);
                cliente.NIT = reader.GetString(6);
                cliente.Correo = reader.GetString(7);
                cliente.Fecha = reader.GetString(8);

                clientes.Add(cliente);
            }
            reader.Close();
            return clientes;
        }

        public bool guardar(List<clientes> models)
        {
            throw new NotImplementedException();
        }

        public bool guardar(clientes model)
        {
            var consulta = "insert into cliente (nombre_cliente,apellidos,num_telefono,direccion,dui,nit,correo_electronico,fecha_afiliacion) values ";
            consulta += "('" + model.Nombre_cliente + "', '" + model.Apellidos + "','" + model.Num_telefono + "', '" + model.Direccion + "','" + model.DUI +"','" + model.NIT + "','" + model.Correo + "','" + model.Fecha + "')";
            return Conexion.getInstance().ejecutarQuery(consulta);
        }

        public bool actualizar(clientes model)
        {
            var consulta = "update cliente set nombre_cliente='" + model.Nombre_cliente + "', apellidos='" + model.Apellidos + "', num_telefono='" + model.Num_telefono + "', direccion='" + model.Direccion + "', dui='" + model.DUI + "', nit='" + model.NIT + "', correo_electronico='" + model.Correo + "' where id_cliente=" + model.Id_cliente;
            return Conexion.getInstance().ejecutarQuery(consulta);
        }


    }
}
