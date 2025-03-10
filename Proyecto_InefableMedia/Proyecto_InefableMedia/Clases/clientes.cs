using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_InefableMedia.Clases
{
    class clientes
    {
        public clientes() {

        }
        //tabla clientes
        private int id_cliente;
        private string nombre_cliente;
        private string apellidos;
        private int num_telefono;
        private string direccion;
        private string dui;
        private string nit;
        private string correo;
        private string fecha;

        public int Id_cliente{
            get { return id_cliente; }
            set { id_cliente = value; }
        }

        public string Nombre_cliente {
            get { return nombre_cliente; }
            set { nombre_cliente = value; }
        }

        public string Apellidos {
            get { return apellidos; }
            set { apellidos = value; }
        }

        public int Num_telefono {
            get { return num_telefono; }
            set { num_telefono = value; }
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

        public string Correo {
            get { return correo; }
            set { correo = value; }
        }

        public string Fecha {
            get { return fecha; }
            set { fecha = value; }
        }
    }
}
