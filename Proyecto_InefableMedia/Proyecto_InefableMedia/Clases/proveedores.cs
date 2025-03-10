using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_InefableMedia.Clases
{
    class proveedores
    {
        public proveedores() {

        }

        //tabla proveedores
        private int id_proveedor;
        private string nombre_proveedor;
        private int telefono_proveedor;
        private string direccion_proveedor;
        private string nombre_contacto;
        private int telefono_contacto;
        private string correo;

        public int Id_proveedor {
            get { return id_proveedor; }
            set { id_proveedor = value; }
        }

        public string Nombre_proveedor {
            get { return nombre_proveedor; }
            set { nombre_proveedor = value; }
        }

        public int Telefono_proveedor {
            get { return telefono_proveedor; }
            set { telefono_proveedor = value; }
        }

        public string Direccion_proveedor {
            get { return direccion_proveedor; }
            set { direccion_proveedor = value; }
        }

        public string Nombre_contacto {
            get { return nombre_contacto; }
            set { nombre_contacto = value; }
        }

        public int Telefono_contacto
        {
            get { return telefono_contacto; }
            set { telefono_contacto = value; }

        }

        public string Correo {
            get { return correo; }
            set { correo = value; } 
        }
    }
}
