using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_InefableMedia.Clases;

namespace Proyecto_InefableMedia
{
    class ventanas
    {
        private ventanas()
        {

        }


        private static ventanas instance = new ventanas();
        
        public static ventanas Instance
        {
            get
            { return instance; }

            set{ instance = value; }
        }

        private clientes cliente;
        private usuarios empleado;
        private inventario inventario;
        //private Venta venta;
        private productos producto;
        private proveedores proveedor;

        public clientes Cliente {
            get { return cliente; }
            set { cliente = value; }
        }

        public usuarios Usuario {
            get { return empleado; }
            set { empleado = value; }
        }

        public productos Producto
        {
            get
            { return producto;}

            set
            { producto = value;}
        }

        public proveedores Proveedor
        {
            get
            { return proveedor; }

            set
            {  proveedor = value;}
        }

        public inventario Inventario {
            get { return inventario; }
            set { inventario = value; }
        }
    }
}
