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
using System.Text.RegularExpressions;

namespace Proyecto_InefableMedia.Forms
{
    public partial class Registro_clientes : Form
    {

        private DateTime hoy = DateTime.Today; //capturando la fecha de hoy
        private List<clientes> clientes = new List<clientes>();

        public Registro_clientes()
        {
            InitializeComponent();
        }

        private void ClienteVista_Load(object sender, EventArgs e)
        {
            Refrescar();
        }

        public static bool validarDUI(string DUI)
        {
            string dui = "[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]-[0-9]";

            if (Regex.IsMatch(DUI, dui))
            {
                if (Regex.Replace(DUI, dui, string.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }

        public void Refrescar()
        {
            clientes = clientesR.Instance.findAll();
            cm_cliente.Items.Clear();
            dataCliente.Rows.Clear();
            foreach (clientes cl in clientes)
            {
                cm_cliente.Items.Add(cl.Id_cliente);
                dataCliente.Rows.Add(cl.Id_cliente, cl.Nombre_cliente, cl.Apellidos, cl.Num_telefono, cl.Direccion, cl.DUI, cl.NIT, cl.Correo, cl.Fecha);
            }
        }

        private void limpiar()
        {
            txt_nombre.Clear();
            txt_apellido.Clear();
           txt_correo.Clear();
            txt_direccion.Clear();
            txt_dui.Clear();
           txt_nit.Clear();
            txt_telefono.Clear();
            cm_cliente.Text = "";
        }

        private void solo()
        {
            txt_apellido.ReadOnly = true;
            txt_correo.ReadOnly = true;
            txt_direccion.ReadOnly = true;
            txt_dui.ReadOnly = true;
            txt_nit.ReadOnly = true;
            txt_nombre.ReadOnly = true;
            txt_telefono.ReadOnly = true;
        }

        private void nuevo()
        {
            txt_apellido.ReadOnly = false;
            txt_correo.ReadOnly = false;
            txt_direccion.ReadOnly = false;
            txt_dui.ReadOnly = false;
            txt_nit.ReadOnly = false;
            txt_nombre.ReadOnly = false;
            txt_telefono.ReadOnly = false;
        }

        private void consultar()
        {
            txt_apellido.ReadOnly = false;
            txt_correo.ReadOnly = false;
            txt_direccion.ReadOnly = false;
            txt_dui.ReadOnly = true;
            txt_nit.ReadOnly = true;
            txt_nombre.ReadOnly = false;
            txt_telefono.ReadOnly = false;
        }

        public static bool validaremail(string email)
        {
            string expresion = "^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:.[a-zA-Z0-9-]+)*$";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, string.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool validarNIT(string NIT)
        {
            string nit = "[0-9][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9][0-9][0-9]-[0-9][0-9][0-9]-[0-9]";

            if (Regex.IsMatch(NIT, nit))
            {
                if (Regex.Replace(NIT, nit, string.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_apellido.Text == "" || txt_correo.Text == "" || txt_direccion.Text == "" || txt_dui.Text == "" || txt_nit.Text == "" || txt_nombre.Text == "" || txt_telefono.Text == "")
            {
                MessageBox.Show("No puede dejar campos vacios", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            } else if (validaremail(txt_correo.Text)) {
                try
                {
                    
                    clientes cliente = new clientes();

                    cliente.Nombre_cliente = txt_nombre.Text;
                    cliente.Apellidos = txt_apellido.Text;
                    cliente.Num_telefono = int.Parse(txt_telefono.Text);
                    cliente.Direccion = txt_direccion.Text;
                    cliente.DUI = txt_dui.Text;
                    cliente.NIT = txt_nit.Text;
                    cliente.Correo = txt_correo.Text;
                    cliente.Fecha = Convert.ToString(hoy);
                    clientesR.Instance.guardar(cliente);
                    MessageBox.Show("¡Cliente registrado con exito!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Refrescar();
                    limpiar();
                    solo();
                    button1.Visible = false;
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
                    MessageBox.Show(this, ex.Message, "Error al insertar el cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else {
                MessageBox.Show("Dirección de correo no válida");
                txt_correo.SelectAll();
            }
          
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            if (txt_apellido.Text == "" || txt_correo.Text == "" || txt_direccion.Text == "" || txt_dui.Text == "" || txt_nit.Text == "" || txt_nombre.Text == "" || txt_telefono.Text == "")
            {
                MessageBox.Show("No puede dejar campos vacios", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            } else if (cm_cliente.Text == "") {
                MessageBox.Show("Debe seleccionar un cliente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cm_cliente.Focus();
                return;
            } else if (validaremail(txt_correo.Text)) {

                try
                {
                    clientes cliente = new clientes();
                    cliente.Id_cliente = int.Parse(cm_cliente.Text);
                    cliente.Nombre_cliente = txt_nombre.Text;
                    cliente.Direccion = txt_direccion.Text;
                    cliente.Apellidos = txt_apellido.Text;
                    cliente.Num_telefono = int.Parse(txt_telefono.Text);
                    cliente.DUI = txt_dui.Text;
                    cliente.NIT = txt_nit.Text;
                    cliente.Correo = txt_correo.Text;
                    clientesR.Instance.actualizar(cliente);
                    MessageBox.Show(this, "¡Cliente actualizado correctamente!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    cm_cliente.Visible = false;
                    picture_cancelar.Visible = false;
                    lb_c.Visible = false;
                    solo();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "Error al actualizar el cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else {
                MessageBox.Show("Dirección de correo no válida");
                txt_correo.SelectAll();
            }
        
        }

        private void Registro_clientes_Load(object sender, EventArgs e)
        {
            Refrescar();
        }

        private void cm_cliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                clientes cliente = clientesR.Instance.find(int.Parse(cm_cliente.Text));

                txt_apellido.Text = cliente.Apellidos;
                txt_correo.Text = cliente.Correo;
                txt_direccion.Text = cliente.Direccion;
                txt_dui.Text = cliente.DUI;
                txt_nit.Text = cliente.NIT;
                txt_nombre.Text = cliente.Nombre_cliente;
                txt_telefono.Text = Convert.ToString(cliente.Num_telefono);
                ventanas.Instance.Cliente = cliente;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (cm_cliente.Text == "")
            {
                MessageBox.Show("Debe seleccionar un cliente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cm_cliente.Focus();
                return;
            }
            else {
                if (MessageBox.Show("¿Estas seguro que quieres eliminar este cliente?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    try
                    {
                        clientes cliente = new clientes();
                        cliente.Id_cliente = int.Parse(cm_cliente.Text);
                        clientesR.Instance.borrar(cliente);
                        MessageBox.Show(this, "Cliente eliminado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        cm_cliente.Visible = false;
                        lb_c.Visible = false;
                        picture_cancelar.Visible = false;
                        solo();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, "Error al eliminar el cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else {
                    MessageBox.Show("Cliente no eliminado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            nuevo();
            button1.Visible = true;
            btn_nuevo.Visible = false;
            btn_consultar.Visible = false;
            picture_n.Visible = false;
            picture_c.Visible = false;
            picture_g.Visible = true;
            lb_c.Visible = true;
            picture_cancelar.Visible = true;
        }

        private void btn_consultar_Click(object sender, EventArgs e)
        {
            cm_cliente.Visible = true;
            consultar();
            btn_consultar.Visible = false;
            btn_nuevo.Visible = false;
            button1.Visible = false;
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
            cm_cliente.Visible = false;
            lb_c.Visible = false;
            picture_cancelar.Visible = false;
            btn_consultar.Visible = true;
            picture_c.Visible = true;
            btn_nuevo.Visible = true;
            picture_n.Visible = true;
            button1.Visible = false;
            picture_g.Visible = false;
            btn_actualizar.Visible = false;
            picture_a.Visible = false;
            btn_eliminar.Visible = false;
            picture_e.Visible = false;
        }

        private void cm_cliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloNumeros(e);
        }

        private void txt_nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloLetras(e);
        }

        private void txt_apellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloLetras(e);
        }

        private void txt_telefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloNumeros(e);
        }

        private void txt_direccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txt_correo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if ((e.KeyChar == '.') && (!txt_correo.Text.Contains(".")))
            {
                e.Handled = false;
            }
            else if ((e.KeyChar == '@') && (!txt_correo.Text.Contains("@")))
            {
                e.Handled = false;
            }
            else
            {
                MessageBox.Show("Error, verifique los datos que esta ingresando", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
        }

        private void txt_correo_Leave(object sender, EventArgs e)
        {
            if (validaremail(txt_correo.Text))
            {

            }
            else
            {
                MessageBox.Show("Dirección de correo no válida");
                txt_correo.SelectAll();

            }
        }

        private void txt_dui_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }

            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if ((e.KeyChar == '-') && (!txt_dui.Text.Contains("-")))
            {
                e.Handled = false;
            }

            else
            {
                e.Handled = true;
                MessageBox.Show("¡Error, no puede ingresar letras en este campo!", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txt_nit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }

            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '-')
            {
                e.Handled = false;
            }

            else
            {
                e.Handled = true;
                MessageBox.Show("¡Error, no puede ingresar letras en este campo!", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Menu men = new Menu();
            this.Hide();
            men.Show();
        }

        private void txt_dui_Leave(object sender, EventArgs e)
        {
            if (validarDUI(txt_dui.Text))
            {

            }
            else
            {
                MessageBox.Show("Formato de dui, incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_dui.SelectAll();
                txt_dui.Clear();
            }
        }

        private void txt_nit_Leave(object sender, EventArgs e)
        {
            if (validarNIT(txt_nit.Text))
            {

            }
            else
            {
                MessageBox.Show("Formato de nit, incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_nit.SelectAll();
                txt_nit.Clear();
            }
        }
    }
}
