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
    class empleadosR : interfaz<usuarios>
    {
        private static empleadosR instancia = new empleadosR();

        private empleadosR() {

        }

      internal static empleadosR Instancia {
            get { return instancia; }
            set { instancia = value; }
        }

        public bool borrar(usuarios model)
        {
            string consulta = "delete from empleado where id_empleado=" + model.Id_Empleado;
            return Conexion.getInstance().ejecutarQuery(consulta);
        }

        public usuarios find(int id)
        {
            usuarios usuario = new usuarios();
            string consulta = "select * from empleado where id_empleado=" + id;
            SqlDataReader reader = Conexion.getInstance().ejecutarQueryLeer(consulta);
            while (reader.Read()) {
                usuario.Id_Empleado = reader.GetInt32(0);
                usuario.Nombre_Empleado = reader.GetString(1);
                usuario.Apellido_Empleado = reader.GetString(2);
                usuario.Telefono1 = reader.GetString(3);
                usuario.Telefono2 = reader.GetString(4);
                usuario.Fecha = reader.GetString(5);
                usuario.Correo = reader.GetString(6);
                usuario.Direccion = reader.GetString(7);
                usuario.DUI = reader.GetString(8);
                usuario.NIT = reader.GetString(9);
                usuario.AFP = reader.GetString(10);
                usuario.Num_afp = reader.GetInt64(11);
                usuario.ISSS = reader.GetInt32(12);
                usuario.Usuario = reader.GetString(13);
                usuario.Contraseña = reader.GetString(14);
                
            }
            reader.Close();
            return usuario;
        }

        public List<usuarios> findAll() {

            List<usuarios> usuarios = new List<usuarios>();
            string consulta = "select * from empleado";
            SqlDataReader reader = Conexion.getInstance().ejecutarQueryLeer(consulta);
            while (reader.Read()) {
                try
                {
                    usuarios usuario = new usuarios();
                    usuario.Id_Empleado = reader.GetInt32(0);
                    usuario.Nombre_Empleado = reader.GetString(1);
                    usuario.Apellido_Empleado = reader.GetString(2);
                    usuario.Telefono1 = reader.GetString(3);
                    usuario.Telefono2 = reader.GetString(4);
                    usuario.Fecha = reader.GetString(5);
                    usuario.Correo = reader.GetString(6);
                    usuario.Direccion = reader.GetString(7);
                    usuario.DUI = reader.GetString(8);
                    usuario.NIT = reader.GetString(9);
                    usuario.AFP = reader.GetString(10);
                    usuario.Num_afp = reader.GetInt64(11);
                    usuario.ISSS = reader.GetInt32(12);
                    usuario.Usuario = reader.GetString(13);
                    usuario.Contraseña = reader.GetString(14);
                    usuarios.Add(usuario);
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
            reader.Close();
            return usuarios;
        }

        public bool guardar(List<usuarios> models) {
            throw new NotImplementedException();
        }

        public bool guardar(usuarios model) {
            string consulta = "insert into empleado (nombre_empleado, apellidos, telefono_1, telefono_2, fecha_nacimiento, correo_electronico, direccion, dui, nit, AFP, Num_AFP, ISSS, usuario, contraseña) values('" + model.Nombre_Empleado + "', '" + model.Apellido_Empleado + "', '" + model.Telefono1 + "', '" + model.Telefono2 + "', '" + model.Fecha + "', '" + model.Correo + "', '" + model.Direccion + "', '" + model.DUI + "', '" + model.NIT + "', '" + model.AFP + "', '" + model.Num_afp + "', '" + model.ISSS + "', '" + model.Usuario + "', '" + model.Contraseña + "')";
            return Conexion.getInstance().ejecutarQuery(consulta);
        }

        public bool actualizar(usuarios model) {
            string consulta = "update empleado set nombre_empleado='" + model.Nombre_Empleado + "', apellidos='" + model.Apellido_Empleado + "', telefono_1='" + model.Telefono1 + "', telefono_2='" + model.Telefono2 + "', correo_electronico='" + model.Correo + "', direccion ='" + model.Direccion + "', dui='" + model.DUI + "', nit='" + model.NIT + "', AFP='" + model.AFP + "', Num_AFP='" + model.Num_afp + "', ISSS='" + model.ISSS + "', usuario= '" + model.Usuario + "', contraseña='" + model.Contraseña + "' where id_empleado=" + model.Id_Empleado;
            return Conexion.getInstance().ejecutarQuery(consulta);
        }

    }

   
}
