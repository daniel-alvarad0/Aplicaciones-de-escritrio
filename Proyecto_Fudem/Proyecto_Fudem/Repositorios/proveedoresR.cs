using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_InefableMedia.Clases;
using System.Data.SqlClient;


namespace Proyecto_InefableMedia.Repositorios
{
    class proveedoresR : interfaz<proveedores>
    {
        private static proveedoresR instance = new proveedoresR();

        private proveedoresR() {
            
        }

        internal static proveedoresR Instance
        {
            get
            { return instance;}

            set{ instance = value; }
        }

        public bool borrar(proveedores model)
        {
            var consulta = "delete from proveedor where id_proveedor=" + model.Id_proveedor;
            return Conexion.getInstance().ejecutarQuery(consulta);
        }

        public proveedores find(int id)
        {
           proveedores proveedor = new proveedores();
            var consulta = "select * from proveedor where id_proveedor =" + id;
            SqlDataReader reader = Conexion.getInstance().ejecutarQueryLeer(consulta);

            while (reader.Read())
            {
                proveedor.Id_proveedor = reader.GetInt32(0);
                proveedor.Nombre_proveedor = reader.GetString(1);
                proveedor.Direccion_proveedor = reader.GetString(2);
                proveedor.Telefono_proveedor = reader.GetInt32(3);
                proveedor.Correo = reader.GetString(4);
                proveedor.Nombre_contacto = reader.GetString(5);
                proveedor.Telefono_contacto = reader.GetInt32(6);
            }
            reader.Close();
            return proveedor;
        }

        public List<proveedores> findAll()//uso para el datagridview
        {
            List<proveedores> proveedores = new List<proveedores>();//nueva lista

            var consulta = "select * from proveedor";
            SqlDataReader reader = Conexion.getInstance().ejecutarQueryLeer(consulta);
            while (reader.Read())
            {
                proveedores proveedor = new proveedores();

                proveedor.Id_proveedor = reader.GetInt32(0);
                proveedor.Nombre_proveedor = reader.GetString(1);
                proveedor.Direccion_proveedor = reader.GetString(2);
                proveedor.Telefono_proveedor = reader.GetInt32(3);
                proveedor.Correo = reader.GetString(4);
                proveedor.Nombre_contacto = reader.GetString(5);
                proveedor.Telefono_contacto = reader.GetInt32(6);

                proveedores.Add(proveedor);
            }
            reader.Close();
            return proveedores;
        }

        public bool guardar(List<proveedores> models)
        {
            throw new NotImplementedException();
        }

        public bool guardar(proveedores model)
        {
            var consulta = "insert into proveedor (nombre_proveedor, direccion, telefono_proveedor, correo_electronico, contacto, telefono_contacto) values ";
           consulta = consulta + " ('" + model.Nombre_proveedor + "','" + model.Direccion_proveedor + "','" + model.Telefono_proveedor + "','" + model.Correo + "','" + model.Nombre_contacto + "','" + model.Telefono_contacto + "')";
            return Conexion.getInstance().ejecutarQuery(consulta);
        }

        public bool actualizar(proveedores model)
        {
            var consulta = "update proveedor set nombre_proveedor='" + model.Nombre_proveedor + "',direccion='" + model.Direccion_proveedor + "',telefono_proveedor='" + model.Telefono_proveedor + "',correo_electronico='" + model.Correo + "',contacto='" + model.Nombre_contacto + "',telefono_contacto='" + model.Telefono_contacto + "' where id_proveedor=" + model.Id_proveedor;
            return Conexion.getInstance().ejecutarQuery(consulta);
        }
    }
}
