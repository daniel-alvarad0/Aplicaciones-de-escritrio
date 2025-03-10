using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_InefableMedia.Clases
{
    class productos
    {
        //tabla productos
        private int id_producto;
        private int id_proveedor;
        private int id_empleado;
        private String nombre;
        private decimal precio_compra;
        private decimal precio_venta;
        private string descripcion;
        private DateTime fecha_producto;
        private String tipo;

        public int Id_producto
        {
            get
            {
                return id_producto;
            }

            set
            {
                id_producto = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }


        public string Tipo
        {
            get
            {
                return tipo;
            }

            set
            {
                tipo = value;
            }
        }

        public decimal Precio_compra
        {
            get
            {
                return precio_compra;
            }

            set
            {
                precio_compra = value;
            }
        }

        public decimal Precio_venta
        {
            get
            {
                return precio_venta;
            }

            set
            {
                precio_venta = value;
            }
        }

        public int Id_proveedor {
            get { return id_proveedor; }
            set { id_proveedor = value; }
        }

        public int Id_empleado
        {
            get { return id_empleado; }
            set { id_empleado = value; }
        }

        public string Descripcion {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public DateTime Fecha_producto {
            get { return fecha_producto; }
            set { fecha_producto = value; }
        }

       
    }
}
