using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_InefableMedia.Clases
{
    class venta
    {
        public venta() {
                
        }

        private int id_factura;
        private int numero_factura;
        private int id_cliente;
        private int id_usuario;
        private DateTime fecha_facturacion;
        private decimal total;
        private decimal iva;
        private decimal subtotal;
        private decimal descuento;
        private string metodopago;

        public int Id_factura
        {
            get
            { return id_factura; }

            set
            { id_factura = value; }
        }

        public int Numero_factura
        {
            get
            { return numero_factura;
            }

            set
            { numero_factura = value;}
        }

        public int Id_Cliente
        {
            get
            { return id_cliente; }

            set
            { id_cliente = value;}
        }

        public int Id_Usuario
        {
            get
            { return id_usuario;  }

            set
            { id_usuario = value; }
        }


        public DateTime Fecha_facturacion
        {
            get
            { return fecha_facturacion; }

            set
            { fecha_facturacion = value; }
        }

        public decimal Total
        {
            get
            {  return total; }

            set
            { total = value; }
        }

        public decimal IVA
        {
            get
            { return iva; }

            set
            { iva = value; }
        }

        public decimal Subtotal
        {
            get
            { return subtotal; }

            set
            { subtotal = value;
            }
        }

        public decimal Descuento
        {
            get
            { return descuento; }

            set
            { descuento = value; }
        }

        public string MetodoPago {
            get { return metodopago; }
            set { metodopago = value; }
        }
    }
}
