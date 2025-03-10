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
using Proyecto_InefableMedia;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace Proyecto_InefableMedia.Forms
{
    public partial class Registro_productos : Form
    {
        
        private List<productos> productos = new List<productos>();
  
        private DateTime hoy = DateTime.Today; //capturando la fecha de hoy

        public Registro_productos()
        {
            InitializeComponent();
        }

        private void Refrescar()
        {
            productos =  productosR.Instance.findAll();
            grid_productos.Rows.Clear();
            cm_producto.Items.Clear();
            grid_existencia.Rows.Clear();

            foreach (productos p in productos)
            {
               
                cm_producto.Items.Add(p.Id_producto);
                grid_productos.Rows.Add(p.Id_producto, p.Id_proveedor, p.Id_empleado, p.Nombre, p.Precio_compra, p.Precio_venta, p.Descripcion, p.Fecha_producto, p.Tipo);
            }

            foreach (proveedores p in proveedoresR.Instance.findAll())//para traer los datos del proveedor
            {
                cm_proveedor.Items.Add(p.Id_proveedor);
            }

            foreach (usuarios u in empleadosR.Instancia.findAll())//para traer los datos del empleado
            {
                cm_empleado.Items.Add(u.Id_Empleado);
            }

            foreach (inventario inventario in inventarioR.Instance.findExistencia())
            {
                productos p = productosR.Instance.find(inventario.Producto);
                int descripcion = descripcion_ventaR.Instance.vendido(p.Id_producto);
                int total = inventario.Cantidad - descripcion; //calculo del inventario
                grid_existencia.Rows.Add(inventario.Producto, p.Id_proveedor, p.Id_empleado, p.Nombre, p.Precio_compra,
                                        p.Precio_venta, p.Descripcion, p.Tipo, total);
            }
        }

        private void consultar()
        {
            txt_descripcion.ReadOnly = false;
            txt_nombre.ReadOnly = false;
            txt_precio_c.ReadOnly = false;
            txt_precio_v.ReadOnly = false;
            cm_tipo.Enabled = false;
            cm_proveedor.Enabled = false;
            cm_empleado.Enabled = false;
        }

        private void nuevo()
        {
            txt_descripcion.ReadOnly = false;
            txt_precio_c.ReadOnly = false;
            txt_precio_v.ReadOnly = false;
            cm_tipo.Enabled = true;
            txt_nombre.ReadOnly = false;
            cm_proveedor.Enabled = true;
            cm_empleado.Enabled = true;
        }

        private void limpiar()
        {
            txt_nombre.Clear();
            txt_descripcion.Clear();
            txt_empleado.Text = "";
            txt_precio_c.Clear();
            txt_precio_v.Clear();
            txt_proveedor.Text = "";
            cm_tipo.Text = "";
            cm_empleado.Text = "";
            cm_proveedor.Text = "";
            cm_producto.Text = "";
        }

        private void solo()
        {
            txt_descripcion.ReadOnly = true;
            txt_empleado.ReadOnly = true;
            txt_nombre.ReadOnly = true;
            txt_precio_c.ReadOnly = true;
            txt_precio_v.ReadOnly = true;
            txt_proveedor.ReadOnly = true;
            cm_tipo.Enabled = false;
            cm_empleado.Enabled = false;
            cm_proveedor.Enabled = false;
        }
        //private void consultar()
        //{
        //    txt_apellido.ReadOnly = false;
        //    txt_correo.ReadOnly = false;
        //    txt_direccion.ReadOnly = false;
        //    txt_dui.ReadOnly = true;
        //    txt_nit.ReadOnly = true;
        //    txt_nombre.ReadOnly = false;
        //    txt_telefono.ReadOnly = false;
        //}


        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                productos producto = productosR.Instance.find(int.Parse(cm_producto.Text));

                txt_nombre.Text = producto.Nombre;
                txt_precio_c.Text = Convert.ToString(producto.Precio_compra);
                txt_precio_v.Text = Convert.ToString(producto.Precio_venta);
                txt_descripcion.Text = producto.Descripcion;
                cm_tipo.Text = producto.Tipo;
               // cm_empleado.Text = Convert.ToString(producto.Id_empleado);
                //cm_proveedor.Text = Convert.ToString(producto.Id_proveedor);

                ventanas.Instance.Producto = producto;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (txt_descripcion.Text == "" || txt_empleado.Text == "" || txt_nombre.Text == "" || txt_precio_c.Text == "" || txt_precio_v.Text == "" || txt_proveedor.Text == "")
            {
                MessageBox.Show("No puede dejar campos vacios", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (cm_empleado.Text == "")
            {
                MessageBox.Show("Debe ingresar el empleado que recibio el producto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cm_empleado.Focus();
                return;
            }
            else if (cm_proveedor.Text == "")
            {
                MessageBox.Show("Debe ingresar el proveedor del producto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cm_proveedor.Focus();
                return;
            } else if (cm_tipo.Text == "") {
                MessageBox.Show("Debe seleccionar el tipo de producto que es", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cm_tipo.Focus();
                return;
            }
            else {

                try
                {

                    productos p = new productos();


                    p.Nombre = txt_nombre.Text;
                    p.Precio_compra = decimal.Parse(txt_precio_c.Text);
                    p.Precio_venta = decimal.Parse(txt_precio_v.Text);
                    p.Tipo = cm_tipo.Text;
                    p.Id_proveedor = int.Parse(cm_proveedor.Text);
                    p.Id_empleado = int.Parse(cm_empleado.Text);
                    p.Descripcion = txt_descripcion.Text;

                    productosR.Instance.guardar(p);

                    MessageBox.Show(this, "Producto agregado", "Excelente");
                    Refrescar();
                    limpiar();
                    solo();
                    btn_guardar.Visible = false;
                    btn_nuevo.Visible = true;
                    btn_consultar.Visible = true;
                    picture_g.Visible = false;
                    picture_n.Visible = true;
                    picture_c.Visible = true;
                    lb_c.Visible = false;
                    picture_cancelar.Visible = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        private void Registro_productos_Load(object sender, EventArgs e)
        {
            cm_empleado.Text = "";
            Refrescar();
            cm_tipo.Items.Clear();
            cm_tipo.Items.Add("Lentes");
            cm_tipo.Items.Add("Limpiador de lentes");
            cm_tipo.Items.Add("Lentes de contacto");
            cm_tipo.Items.Add("Estuches");
        }

            

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            if (txt_descripcion.Text == "" || txt_nombre.Text == "" || txt_precio_c.Text == "" || txt_precio_v.Text == "")
            {
                MessageBox.Show("No puede dejar campos vacios", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (cm_producto.Text == "")
            {
                MessageBox.Show("Debe seleccionar un producto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cm_producto.Focus();
                return;
            } 
            else {
                try
                {
                    productos p = new productos();

                    p.Id_producto = int.Parse(cm_producto.Text);
                    p.Nombre = txt_nombre.Text;
                    p.Precio_compra = decimal.Parse(txt_precio_c.Text);
                    p.Precio_venta = decimal.Parse(txt_precio_v.Text);
                    p.Tipo = cm_tipo.Text;
                    p.Descripcion = txt_descripcion.Text;
                    //  p.Id_empleado = int.Parse(cm_empleado.Text);
                    // p.Id_proveedor = int.Parse(cm_proveedor.Text);

                    productosR.Instance.actualizar(p);

                    MessageBox.Show(this, "Producto actualzado", "Excelente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Refrescar();
                    limpiar();
                    btn_actualizar.Visible = false;
                    picture_a.Visible = false;
                    btn_eliminar.Visible = false;
                    picture_e.Visible = false;
                    btn_consultar.Visible = true;
                    picture_c.Visible = true;
                    btn_nuevo.Visible = true;
                    picture_n.Visible = true;
                    cm_producto.Enabled = false;
                    picture_cancelar.Visible = false;
                    lb_c.Visible = false;
                    solo();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (cm_producto.Text == "")
            {
                MessageBox.Show("Debe seleccionar un producto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cm_producto.Focus();
                return;
            }
            else {

                if (MessageBox.Show(this, "¿Estas seguro que quieres eliminar este producto?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) + "" == "Yes")
                {
                    try
                    {
                        productos p = new productos();
                        p.Id_producto = int.Parse(cm_producto.Text);
                        productosR.Instance.borrar(p);
                        MessageBox.Show(this, "Eliminado correctamente!!", "Borrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Refrescar();
                        limpiar();
                        btn_actualizar.Visible = false;
                        picture_a.Visible = false;
                        btn_eliminar.Visible = false;
                        picture_e.Visible = false;
                        btn_consultar.Visible = true;
                        picture_c.Visible = true;
                        btn_nuevo.Visible = true;
                        picture_n.Visible = true;
                        cm_producto.Enabled = false;
                        lb_c.Visible = false;
                        picture_cancelar.Visible = false;
                        solo();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, ex.Message, "Lo siento hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            
            
        }

        private void cm_proveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //proveedores proveedor = proveedoresR.Instance.find(int.Parse(cm_proveedor.Text));
              //  txt_nombre_proveedor.Text = proveedor.Nombre_proveedor;
                //cm_proveedor.Text = proveedor.Id_proveedor + "";

            }
            catch
            {

            }
        }

        private void cm_empleado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_buscar_proveedor_Click(object sender, EventArgs e)
        {
            try
            {
                new registro_proveedores().ShowDialog();
                proveedores proveedor = ventanas.Instance.Proveedor;
             //   txt_nombre_proveedor.Text = proveedor.Nombre_proveedor;
               // cm_proveedor.Text = proveedor.Id_proveedor + "";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_venta_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_regresar_Click(object sender, EventArgs e)
        {
            Menu men = new Menu();
            this.Hide();
            men.Show();
        }

        private void btn_buscar_p_Click(object sender, EventArgs e)
        {

        }

        private void cm_proveedor_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                proveedores proveedor = proveedoresR.Instance.find(int.Parse(cm_proveedor.Text));
                txt_proveedor.Text = proveedor.Nombre_proveedor;
                cm_proveedor.Text = proveedor.Id_proveedor + "";

            }
            catch
            {

            }
        }

        private void cm_empleado_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                usuarios usuario = empleadosR.Instancia.find(int.Parse(cm_empleado.Text));
                txt_empleado.Text = usuario.Nombre_Empleado;
                cm_empleado.Text = usuario.Id_Empleado + "";

            }
            catch
            {

            }
        }

        private void btn_consultar_Click(object sender, EventArgs e)
        {
            cm_producto.Enabled = true;
            consultar();
            btn_consultar.Visible = false;
            btn_nuevo.Visible = false;
          btn_guardar.Visible = false;
            btn_actualizar.Visible = true;
            btn_eliminar.Visible = true;
           picture_n.Visible = false;
            picture_c.Visible = false;
            picture_a.Visible = true;
            picture_e.Visible = true;
            lb_c.Visible = true;
            picture_cancelar.Visible = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Menu men = new Menu();
            this.Hide();
            men.Show();
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            nuevo();
            btn_guardar.Visible = true;
            btn_nuevo.Visible = false;
            btn_consultar.Visible = false;
            picture_n.Visible = false;
            picture_cancelar.Visible = false;
            picture_g.Visible = true;
            picture_c.Visible = false;
            lb_c.Visible = true;
            picture_cancelar.Visible = true;
        }

        private void picture_cancelar_Click(object sender, EventArgs e)
        {
            limpiar();
            solo();
            cm_producto.Enabled = false;
            cm_proveedor.Enabled = false;
            cm_empleado.Enabled = false;
            cm_tipo.Enabled = false;
            lb_c.Visible = false;
            picture_cancelar.Visible = false;
            btn_consultar.Visible = true;
            picture_c.Visible = true;
            btn_nuevo.Visible = true;
            picture_n.Visible = true;
            btn_guardar.Visible = false;
            picture_g.Visible = false;
            btn_actualizar.Visible = false;
            picture_a.Visible = false;
            btn_eliminar.Visible = false;
            picture_e.Visible = false;
        }

        private void cm_producto_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloNumeros(e);
        }

        private void cm_proveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloNumeros(e);
        }

        private void cm_empleado_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloNumeros(e);
        }

        private void txt_nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloLetras(e);
        }

        private void txt_precio_c_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }

            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if ((e.KeyChar == '.') && (!txt_precio_c.Text.Contains(".")))
            {
                e.Handled = false;
            }

            else
            {
                e.Handled = true;
                MessageBox.Show("¡Error, no puede ingresar letras en este campo!", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txt_precio_v_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }

            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if ((e.KeyChar == '.') && (!txt_precio_v.Text.Contains(".")))
            {
                e.Handled = false;
            }

            else
            {
                e.Handled = true;
                MessageBox.Show("¡Error, no puede ingresar letras en este campo!", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txt_descripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloLetras(e);
        }

        private void txt_tipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloLetras(e);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            this.Hide();
            menu.Show();
        }

        private void cm_tipo_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
