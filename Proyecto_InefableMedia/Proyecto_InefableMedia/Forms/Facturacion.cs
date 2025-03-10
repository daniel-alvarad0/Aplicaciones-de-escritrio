using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto_InefableMedia.Clases;
using Proyecto_InefableMedia.Repositorios;
using System.Drawing.Printing;


namespace Proyecto_InefableMedia.Forms
{
    public partial class Facturacion : Form
    {
     
       
        public Facturacion()
        {
            InitializeComponent();
        }

        private DateTime hoy = DateTime.Today; //capturando la fecha de hoy
        private int contador = 0;
        private int acum = 0;
        

        public void refrescar()
        {
            cm_cliente.Items.Clear();
            cm_producto.Items.Clear();
         //   cm_id_f.Items.Clear();

            foreach (venta venta in ventaR.Instancia.findAll()) //traer los datos del id de la factura, mediante la clase venta 
            {
              //  cm_id_f.Items.Add(venta.Numero_factura);
            }

            foreach (clientes cliente in clientesR.Instance.findAll()) //traer los datos del cliente, mediante la clase cliente
            {
                cm_cliente.Items.Add(cliente.Id_cliente);
            }

            foreach (productos producto in productosR.Instance.findAll()) //traer los datos del producto, mediante el id del producto de la clase producto
            {
                cm_producto.Items.Add(producto.Id_producto);
            }
        }

        private void limpiar() {
            cm_cliente.Text = "";
            txt_cliente.Text = "";
            cm_producto.Text = "";
            txt_cantidad.Text = "";
            txt_descripcion.Text = "";
            txt_producto.Text = "";
            cm_metodo.Text = "";
          //  txt_descuento.Text = "";
        }

        private void fac() {
            cm_cliente.Enabled = false;
            cm_producto.Enabled = false;
            txt_cantidad.ReadOnly = true;
            cm_metodo.Enabled = false;
            btn_facturar.Enabled = false;
            picture_guardar.Enabled = false;
            btn_agregar.Visible = false;
            btn_eliminar.Visible = false;
            picture_e.Visible = false;
            picture_n.Visible = false;
            picture_cancelar.Visible = false;
            lb_cancelar.Visible = false;
            btn_nuevo.Visible = true;
            picture_nuevafactura.Visible = true;
         txt_descuento.ReadOnly = true;
        }

        private void cm_cliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                clientes cliente = clientesR.Instance.find(int.Parse(cm_cliente.Text)); //mandamos a traer el nombre y el apellido del cliente mediante el metodo find
                txt_cliente.Text = cliente.Nombre_cliente + " " + cliente.Apellidos; 

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Facturacion_Load(object sender, EventArgs e)
        {
            refrescar();
            cm_metodo.Items.Clear();
            cm_metodo.Items.Add("Efectivo");
            cm_metodo.Items.Add("Tarjeta de crédito");
        }

        private void cm_producto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                productos producto = productosR.Instance.find(int.Parse(cm_producto.Text)); //mandamos a traer el nombre del producto mediante su id, atraves del metodo find en el repositorio de productos
                txt_producto.Text = producto.Nombre; //nombre del producto
                txt_descripcion.Text = producto.Descripcion;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            if (cm_cliente.Text == "")
            {
                MessageBox.Show("Debe seleccionar un cliente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cm_cliente.Focus();
                return;
            }
            else if (cm_producto.Text == "") {
                MessageBox.Show("Debe seleccionar un producto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cm_producto.Focus();
                return;
            } else if (cm_metodo.Text == "" || txt_cantidad.Text == "") {
                MessageBox.Show("No puede dejar campos vacios", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else {
                cm_cliente.Enabled = false;
                try
                {
                    string metodo = cm_metodo.Text;
                    int entrada = inventarioR.Instance.findExistenciaByProducto(int.Parse(cm_producto.Text));//mandamos a traer el producto seleccionado 
                    int salida = descripcion_ventaR.Instance.vendido(int.Parse(cm_producto.Text)); //lo que entra menos la salida 
                    int existencia = entrada - salida; //calculo para disminuir el inventario dependiendo de la cantidad ingresada


                    if (existencia >= int.Parse(txt_cantidad.Text))
                    {
                        btn_facturar.Enabled = true;
                        picture_guardar.Enabled = true;
                        txt_descuento.ReadOnly = false;
                        productos producto = productosR.Instance.find(int.Parse(cm_producto.Text)); //encontrar el producto mediante su id

                        int cantidad = int.Parse(txt_cantidad.Text); //capturamos la cantidad ingresada
                        decimal total = cantidad * producto.Precio_venta; //calculo del precio 

                        grid_factura.Rows.Add(producto.Id_producto, producto.Nombre, producto.Descripcion, cantidad, producto.Precio_venta, total, metodo);//llenando el datagrid
                        cm_producto.Text = "";
                        txt_producto.Text = "";
                        txt_descripcion.Text = "";
                        cm_metodo.Text = "";
                        txt_cantidad.Text = "";
                    }
                    else
                    {
                        MessageBox.Show(this, "Lo siento, solo se encuentra " + existencia + " de " + txt_producto.Text, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_cantidad.Clear();
                        txt_cantidad.Focus();
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                sumar(); //metodo para caluclar los totales de la venta
            }
         
        }

        public void sumar() //metodo para sacar el total del datagrid
        {
            double subtotal = 0;

            for (int i = 0; i < grid_factura.Rows.Count; i++)
            {
                subtotal = subtotal + Convert.ToDouble(grid_factura.Rows[i].Cells[5].Value);
            }

            double descuento = 0;

            try
            {
                descuento = double.Parse(
                        (txt_descuento.Text == "") ? "0" : txt_descuento.Text
                    );
            }
            catch
            {
              MessageBox.Show("Revise que el descuento sea numerico");
            }

            double total = 0;
            double iva = Math.Round(subtotal * 0.13, 2);//subtotal por iva 0.13
            total = subtotal + iva - descuento; //calculo del total mas el iva, tambien restamos el descuento que se le puede hacer el cliente

            if (descuento > total)
            {
                MessageBox.Show("Error, el descuento no puede ser mayor o igual al total", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_descuento.Clear();
                txt_descuento.Focus();
                return;
            }
            else {

                txt_total.Text = total + "";
                txt_iva.Text = iva + "";
                txt_subtotal.Text = subtotal + "";
            }
             
               
            
           
        }

        private void txt_descuento_TextChanged(object sender, EventArgs e)
        {
            
            sumar();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < grid_factura.SelectedRows.Count; i++) //al momento de seleccionar una linea del datagrid se borra esa venta y se calcula otravez el total dependiendo de la cantidad de productos que hay
            {
                
                    grid_factura.Rows.Remove(grid_factura.SelectedRows[i]);
               
               
            }
            if (grid_factura.Rows.Count == 0) {
                btn_facturar.Enabled = false;
                picture_guardar.Enabled = false;
                txt_iva.Clear();
                txt_subtotal.Clear();
                txt_total.Clear();
                txt_descuento.ReadOnly = true;
            }
            sumar();
        }

        private List<descripcion_venta> descripciones()
        {
            List<descripcion_venta> ventas = new List<descripcion_venta>();//agregamos una lista de la clase descripcion de la venta
            for (int i = 0; i < grid_factura.Rows.Count; i++)
            {
                descripcion_venta venta = new descripcion_venta();//la invocamos

                venta.Producto = Convert.ToInt32(grid_factura.Rows[i].Cells[0].Value);
                venta.Cantidad = Convert.ToInt32(grid_factura.Rows[i].Cells[3].Value);
                venta.Precio = Convert.ToDecimal(grid_factura.Rows[i].Cells[4].Value);
               // venta.Venta = ventaR.Instancia.findByCodigo(Convert.ToInt32(cm_id_f.Text));
                ventas.Add(venta);
            }
            return ventas;
        }

        private void btn_facturar_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("¿Estas seguro que quieres realizar la venta?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                try
                {

                    for (int i = 0; i < 1; i++)
                    {
                        contador = contador + 1;
                    }
                    int cliente = int.Parse(cm_cliente.Text);
                    // int numero = int.Parse(cm_id_f.Text);
                    int usuario = 1;

                    decimal subtotal = 0;

                    for (int i = 0; i < grid_factura.Rows.Count; i++)
                    {
                        subtotal = subtotal + Convert.ToDecimal(grid_factura.Rows[i].Cells[5].Value);
                    }

                    decimal descuento = 0;

                    try
                    {
                        descuento = decimal.Parse(
                                (txt_descuento.Text == "") ? "0" : txt_descuento.Text
                            );
                    }
                    catch
                    {
                        MessageBox.Show("Revise que el descuento sea numerico");
                    }

                    decimal total = 0;
                    decimal iva = Math.Round(subtotal * (decimal)0.13, 2);
                    total = subtotal + iva - descuento;

                    txt_total.Text = total + "";
                    venta venta = new venta();

                    //    venta.Numero_factura = numero;
                    venta.Id_Cliente = cliente;
                    venta.Id_Usuario = usuario;

                    venta.Total = total;
                    venta.Subtotal = subtotal;
                    venta.IVA = iva;
                    venta.Descuento = descuento;



                    //try
                    //{
                    // ventaR.Instancia.guardar(venta);
                    descripcion_ventaR.Instance.guardar(descripciones());
                    MessageBox.Show("¡Venta realizada con exito!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lb_num_factura.Text = "IN00" + contador;
                    lb_fecha.Text = string.Format("{0:dddd, MMMM d, yyyy}", DateTime.Now);
                    lb_cliente.Text = txt_cliente.Text;
                    limpiar();
                    fac();
                    //try
                    //{

                    //}
                    //catch (Exception ex)
                    //{
                    //    MessageBox.Show(ex.Message);
                    //}
                    //}
                    //catch (Exception ex)
                    //{
                    //    MessageBox.Show(ex.Message);

                    //}

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
            else
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu men = new Menu();
            this.Hide();
            men.Show();
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            cm_cliente.Enabled = true;
            cm_producto.Enabled = true;
            txt_cantidad.ReadOnly = false;
            cm_metodo.Enabled = true;
            btn_agregar.Visible = true;
            btn_eliminar.Visible = true;
            btn_nuevo.Visible = false;
            picture_e.Visible = true;
            picture_n.Visible = true;
            picture_nuevafactura.Visible = false;
            picture_cancelar.Visible = true;
            lb_cancelar.Visible = true;
            lb_fecha.Text = "";
            lb_num_factura.Text = "";
            lb_cliente.Text = "";
            grid_factura.Rows.Clear();
            txt_iva.Clear();
            txt_subtotal.Clear();
            txt_total.Clear();
            txt_descuento.Clear();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            cm_producto.Text = "";
            txt_descripcion.Text = "";
            txt_cantidad.Text = "";
            cm_metodo.Text = "";
            txt_producto.Text = "";
        }

        private void picture_cancelar_Click(object sender, EventArgs e)
        {
            limpiar();
            cm_cliente.Enabled = false;
            cm_producto.Enabled = false;
            txt_cantidad.ReadOnly = true;
            cm_metodo.Enabled = false;
            grid_factura.Rows.Clear();
            btn_facturar.Enabled = false;
            picture_guardar.Enabled = false;
            btn_agregar.Visible = false;
            btn_eliminar.Visible = false;
            picture_e.Visible = false;
            picture_n.Visible = false;
            picture_cancelar.Visible = false;
            lb_cancelar.Visible = false;
            btn_nuevo.Visible = true;
            picture_nuevafactura.Visible = true;
            txt_descuento.ReadOnly = true;
        }

        private void picture_n_Click(object sender, EventArgs e)
        {

        }

        private void picture_nuevafactura_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Menu men = new Menu();
            this.Hide();
            men.Show();
        }

        public void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void txt_descuento_TextChanged_1(object sender, EventArgs e)
        {
            sumar();
        }

        private void cm_cliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloNumeros(e);
        }

        private void cm_producto_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloNumeros(e);
        }

        private void txt_cantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloNumeros(e);
        }

        private void cm_metodo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
          
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("¡Error, solo se admiten letras en este campo!", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txt_descuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }

            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if ((e.KeyChar == '.') && (!txt_descuento.Text.Contains(".")))
            {
                e.Handled = false;
            }

            else
            {
              
                e.Handled = true;
                MessageBox.Show("¡Error, no puede ingresar letras en este campo!", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

       
    }
    
    
}
