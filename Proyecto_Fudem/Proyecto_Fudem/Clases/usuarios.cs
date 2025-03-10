using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_InefableMedia.Clases
{
    //tabla empleado/usuario
    class usuarios
    {

        public usuarios() {

        }
        private string nombre_empleado;
        private int id_empleado;
        private string apellido_empleado;
        private string telefono1;
        private string telefono2;
        private string fecha;
        private string correo;
        private string direccion;
        private string dui;
        private string nit;
        private string afp;
        private Int64 num_afp;
        private int isss;
        private string usuario;
        private string contraseña;

        public string Nombre_Empleado {
            get { return nombre_empleado; }
            set { nombre_empleado = value; }
        }

        public int Id_Empleado {
            get { return id_empleado; }
            set { id_empleado = value; }
        }

        public string Apellido_Empleado {
            get { return apellido_empleado; }
            set { apellido_empleado = value; }
        }

        public string Telefono1 {
            get { return telefono1; }
            set { telefono1 = value; }
        }

        public string Telefono2 {
            get { return telefono2; }
            set { telefono2 = value; }
        }

        public string Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }

        public string Direccion {
            get { return direccion; }
            set { direccion = value; }
        }

        public string DUI {
            get { return dui; }
            set { dui = value; }
        }

        public string NIT {
            get { return nit; }
            set { nit = value; }
        }

        public string AFP {
            get { return afp; }
            set { afp = value; }
        }

        public Int64 Num_afp {
            get { return num_afp; }
            set { num_afp = value; }
        }

        public int ISSS {
            get { return isss; }
            set { isss = value; }
        }

        public string Usuario {
            get { return usuario; }
            set { usuario = value; }
        }

        public string Contraseña {
            get { return contraseña; }
            set { contraseña = value; }
        }
    }
}
