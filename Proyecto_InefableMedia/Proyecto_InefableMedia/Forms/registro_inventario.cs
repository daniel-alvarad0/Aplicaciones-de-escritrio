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

namespace Proyecto_InefableMedia.Forms
{
    public partial class registro_inventario : Form
    {
        List<inventario> inventarios = new List<inventario>();
        public registro_inventario()
        {
            InitializeComponent();
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            try
            {
                new Registro_productos().ShowDialog();
                productos producto = ventanas.Instance.Producto;
                cm_tipo.Text = producto.Tipo;
                txt_nombre_p.Text = producto.Nombre;
                cm_producto.Text = producto.Id_producto + "";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void limpiar()
        {
            cm_id.Text = "";
            cm_producto.Text ="";
            txt_nombre_p.Text = "";
            txt_cantidad.Clear();
           cm_tipo.Text = "";
        }

        private void solo()
        {
            txt_cantidad.ReadOnly = true;
            txt_nombre_p.ReadOnly = true;
            cm_tipo.Enabled = false;
            cm_producto.Enabled = false;
            cm_id.Enabled = false;
        }
        private void nuevo()
        {
            txt_cantidad.ReadOnly = false;
            cm_tipo.Enabled = false;
            cm_producto.Enabled = true;
        }

        private void consultar()
        {
            txt_cantidad.ReadOnly = false;
           cm_tipo.Enabled = false;
            cm_id.Enabled = true;
            cm_producto.Enabled = false;
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (txt_cantidad.Text == "" || txt_nombre_p.Text == "")
            {
                MessageBox.Show("No puede dejar campos vacios", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (cm_producto.Text == "")
            {
                MessageBox.Show("Debe ingresar un producto al inventario", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cm_producto.Focus();
                return;
            } else if (cm_tipo.Text == "") {
                MessageBox.Show("Debe seleccionar el tipo de inventario");
                cm_tipo.Focus();
                return;
            }
            else {

                try
                {
                    inventario inventario = new inventario();

                    inventario.Cantidad = int.Parse(txt_cantidad.Text);
                    inventario.Producto = int.Parse(cm_producto.Text);
                    inventario.Tipo = cm_tipo.Text;

                    inventarioR.Instance.guardar(inventario);
                    MessageBox.Show(this, "Agragado al inventario", txt_nombre_p.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refrescar();
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
                    MessageBox.Show(this, ex.Message, "Lo siento pero no se pudo registrar producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        

            
        }

        private void cm_producto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                productos producto = productosR.Instance.find(int.Parse(cm_producto.Text));
                cm_tipo.Text = producto.Tipo;
                txt_nombre_p.Text = producto.Nombre;
                cm_producto.Text = producto.Id_producto + "";

            }
            catch
            {

            }
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            if (txt_cantidad.Text == "")
            {
                MessageBox.Show("No puede dejar campos vacios", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (cm_id.Text == "")
            {
                MessageBox.Show("Debe seleccionar un inventario", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cm_id.Focus();
                return;
            } else if (cm_tipo.Text == "") {
                MessageBox.Show("Debe seleccionar el tipo de inventario");
                cm_tipo.Focus();
                return;
            }
            else {
                try
                {
                    inventario inventario = new inventario();

                    inventario.Id_inventario = int.Parse(cm_id.Text);
                    inventario.Cantidad = int.Parse(txt_cantidad.Text);
                    inventario.Producto = int.Parse(cm_producto.Text);
                    inventario.Tipo = cm_tipo.Text;

                    inventarioR.Instance.actualizar(inventario);
                    MessageBox.Show(this, "Inventario actualizado!!", txt_nombre_p.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refrescar();
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
                    MessageBox.Show(this, ex.Message, "Lo siento pero no se pudo registrar producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            
        }

        public void refrescar()
        {
            inventarios = inventarioR.Instance.findAll();

            grid_inventario.Rows.Clear();
            cm_id.Items.Clear();
            cm_producto.Items.Clear();
            grid_existencia.Rows.Clear();

            //foreach (String data in productosR.Instance.findTipo())
            //{
            //    cm_tipo.Items.Add(data);
            //}

            foreach (productos p in productosR.Instance.findAll())
            {
                cm_producto.Items.Add(p.Id_producto);
            }

            foreach (inventario inventario in inventarios)
            {
                cm_id.Items.Add(inventario.Id_inventario);
                grid_inventario.Rows.Add(inventario.Id_inventario, inventario.Producto,//llenando el grid del inventario con los datos del producto
                    productosR.Instance.find(inventario.Producto).Nombre,
                    inventario.Cantidad, inventario.Tipo, inventario.Fecha_inventario);
            }

            foreach (inventario inventario in inventarioR.Instance.findExistencia()) //grid de existencia en forms de inventario
            {
                productos p = productosR.Instance.find(inventario.Producto);
                int descripcion = descripcion_ventaR.Instance.vendido(p.Id_producto);
                int total = inventario.Cantidad - descripcion; //calculo de cuanto hay en inventario
              grid_existencia.Rows.Add(inventario.Producto, p.Id_producto, p.Nombre, p.Precio_compra, p.Precio_venta,
                                       p.Descripcion, p.Tipo, total);
            }
        }

        private void cm_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                inventario inventario = inventarioR.Instance.find(int.Parse(cm_id.Text));

                txt_cantidad.Text = Convert.ToString(inventario.Cantidad);
                cm_producto.Text = Convert.ToString(inventario.Producto);
                cm_tipo.Text = inventario.Tipo;
                // cm_empleado.Text = Convert.ToString(producto.Id_empleado);
                //cm_proveedor.Text = Convert.ToString(producto.Id_proveedor);

                ventanas.Instance.Inventario = inventario;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_regresar_Click(object sender, EventArgs e)
        {
            Menu men = new Menu();
            this.Hide();
            men.Show();
        }

        private void registro_inventario_Load(object sender, EventArgs e)
        {
            refrescar();
            cm_tipo.Items.Clear();
            cm_tipo.Items.Add("Lentes");
            cm_tipo.Items.Add("Limpiador de lentes");
            cm_tipo.Items.Add("Lentes de contacto");
            cm_tipo.Items.Add("Estuches");

        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (cm_id.Text == "")
            {
                MessageBox.Show("Debe seleccionar un inventario", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               cm_id.Focus();
                return;
            }
            else
            {

                if (MessageBox.Show(this, "¿Estas seguro que quieres eliminar este inventario?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) + "" == "Yes")
                {
                    try
                    {
                        inventario i = new inventario();
                        i.Id_inventario = int.Parse(cm_id.Text);
                        inventarioR.Instance.borrar(i);
                        MessageBox.Show(this, "Eliminado correctamente!!", "Borrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        refrescar();
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

        private void btn_consultar_Click(object sender, EventArgs e)
        {
            cm_id.Enabled = true;
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

        private void picture_cancelar_Click(object sender, EventArgs e)
        {
            limpiar();
            solo();
            cm_producto.Enabled = false;
            cm_id.Enabled = false;
            cm_producto.Enabled = false;
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Menu men = new Menu();
            this.Hide();
            men.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void cm_producto_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloNumeros(e);
        }

        private void txt_cantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloNumeros(e);
        }

        private void cm_tipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloLetras(e);
        }

        private void cm_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloNumeros(e);
        }

        private void picture_g_Click(object sender, EventArgs e)
        {

        }
    }
}
