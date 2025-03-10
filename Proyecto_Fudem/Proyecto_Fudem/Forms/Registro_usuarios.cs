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
    public partial class Registro_usuarios : Form
    {
        private DateTime hoy = DateTime.Today;
        private List<usuarios> usuarios = new List<usuarios>();
        public Registro_usuarios()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Refrescar()
        {
            usuarios = empleadosR.Instancia.findAll();
            cm_id.Items.Clear();
            grid_usuarios.Rows.Clear();
            foreach (usuarios us in usuarios)
            {
                cm_id.Items.Add(us.Id_Empleado);
                grid_usuarios.Rows.Add(us.Id_Empleado, us.Nombre_Empleado, us.Apellido_Empleado, us.Telefono1, us.Telefono2, us.Fecha, us.Correo, us.Direccion, us.DUI, us.NIT, us.AFP, us.Num_afp, us.ISSS, us.Usuario, us.Contraseña);
            }
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

        private void limpiar() {
            txt_apellidos.Clear();
            txt_contraseña.Clear();
            txt_correo.Clear();
            dtFecha.Text = "";
            txt_direccion.Clear();
            txt_dui.Clear();
            txt_nit.Clear();
            txt_nombres.Clear();
            cm_afp.Text = "";
            txt_numafp.Clear();
            txt_isss.Clear();
            txt_telefono1.Clear();
            txt_telefono2.Clear();
            txt_usuario.Clear();
            cm_id.Text = "";
        }

        private void nuevo() {
            txt_apellidos.ReadOnly = false;
            txt_contraseña.ReadOnly = false;
            txt_correo.ReadOnly = false;
            txt_direccion.ReadOnly = false;
            dtFecha.Visible = true;
            txt_dui.ReadOnly = false;
            txt_nit.ReadOnly = false;
            txt_nombres.ReadOnly = false;
            cm_afp.Enabled = true;
            txt_numafp.ReadOnly = false;
            txt_isss.ReadOnly = false;
            txt_telefono1.ReadOnly = false;
            txt_telefono2.ReadOnly = false;
            txt_usuario.ReadOnly = false;
        }

        private void consultar() {
            txt_apellidos.ReadOnly = false;
            txt_contraseña.ReadOnly = false;
            txt_correo.ReadOnly = false;
            txt_direccion.ReadOnly = false;
            dtFecha.Visible = false;
            txt_dui.ReadOnly = true;
            txt_nit.ReadOnly = true;
            txt_nombres.ReadOnly = false;
            cm_afp.Enabled = false;
            txt_numafp.ReadOnly = true;
            txt_isss.ReadOnly = true;
            txt_telefono1.ReadOnly = false;
            txt_telefono2.ReadOnly = false;
            txt_usuario.ReadOnly = false;
        }

        private void solo() {
            txt_apellidos.ReadOnly = true;
            txt_contraseña.ReadOnly = true;
            txt_correo.ReadOnly = true;
            txt_direccion.ReadOnly = true;
            dtFecha.Visible = false;
            txt_dui.ReadOnly = true;
            txt_nit.ReadOnly = true;
            txt_nombres.ReadOnly = true;
            cm_afp.Enabled = false;
            txt_isss.ReadOnly = true;
            txt_numafp.ReadOnly = true;
            txt_telefono1.ReadOnly = true;
            txt_telefono2.ReadOnly = true;
            txt_usuario.ReadOnly = true;
        }

        public static bool validaremail(string email){
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
            else {
                return false;
            }
        }
        private void btn_guardar_Click(object sender, EventArgs e)
        {

            if (txt_apellidos.Text == "" || txt_contraseña.Text == "" || txt_correo.Text == "" || txt_direccion.Text == "" || txt_dui.Text == "" || txt_nit.Text == "" || txt_nombres.Text == "" || cm_afp.Text == "" || txt_telefono1.Text == "" || txt_telefono2.Text == "" || txt_usuario.Text == "" || dtFecha.Text == "" || txt_numafp.Text == "" || txt_isss.Text == "")
            {
                MessageBox.Show("No puede dejar campos vacios", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            } else if (dtFecha.Value.Date >= hoy) {

                MessageBox.Show("Error, verifica la fecha selecionada", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtFecha.Focus();
                return;
            } else if (!validaremail(txt_correo.Text)) {
                MessageBox.Show("Dirección de correo no válida");
                txt_correo.SelectAll();
                return;
            } else if (!validarDUI(txt_dui.Text)) {
                MessageBox.Show("Formato de dui, incorrecto");
                txt_dui.SelectAll();
                return;
            } else if (!validarNIT(txt_nit.Text)) {
                MessageBox.Show("Formato de nit, incorrecto");
                txt_nit.SelectAll();
                return;
            } else if (dtFecha.Value.Date.AddYears(18) <= hoy) {

                try
                {
                    usuarios usuario = new usuarios();
                    usuario.Nombre_Empleado = txt_nombres.Text;
                    usuario.Apellido_Empleado = txt_apellidos.Text;
                    usuario.Telefono1 = txt_telefono1.Text;
                    usuario.Telefono2 = txt_telefono2.Text;
                    usuario.Fecha = dtFecha.Text;
                    usuario.Correo = txt_correo.Text;
                    usuario.Direccion = txt_direccion.Text;
                    usuario.DUI = txt_dui.Text;
                    usuario.NIT = txt_nit.Text;
                    usuario.AFP = cm_afp.Text;
                    usuario.Num_afp = Int64.Parse(txt_numafp.Text);
                    usuario.ISSS = int.Parse(txt_isss.Text);
                    usuario.Usuario = txt_usuario.Text;
                    usuario.Contraseña = txt_contraseña.Text;
                    empleadosR.Instancia.guardar(usuario);
                    MessageBox.Show("¡Empleado registrado con exito!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Refrescar();
                    limpiar();
                    btn_guardar.Visible = false;
                    btn_nuevo.Visible = true;
                    btn_consultar.Visible = true;
                    pictura_g.Visible = false;
                    picture_n.Visible = true;
                    picture_c.Visible = true;
                    lb_c.Visible = false;
                    picture_cancelar.Visible = false;
                    solo();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else {
                MessageBox.Show("Error, esta persona es menor de edad, verifique su fecha", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtFecha.Focus();
                return;
            }

        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            if (txt_apellidos.Text == "" || txt_contraseña.Text == "" || txt_correo.Text == "" || txt_direccion.Text == "" || txt_dui.Text == "" || txt_nit.Text == "" || txt_nombres.Text == "" || cm_afp.Text == "" || txt_telefono1.Text == "" || txt_telefono2.Text == "" || txt_usuario.Text == "" || txt_isss.Text == "" || txt_numafp.Text == "")
            {
                MessageBox.Show("No puede dejar campos vacios", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            } else if (cm_id.Text == "") {
                MessageBox.Show("Debe seleccionar un empleado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cm_id.Focus();
                return;
            } else if (!validaremail(txt_correo.Text)) {
                MessageBox.Show("Dirección de correo no válida");
                txt_correo.SelectAll();
                return;
            }
            else {
                try
                {
                    usuarios usuario = new usuarios();
                    usuario.Id_Empleado = int.Parse(cm_id.Text);
                    usuario.Nombre_Empleado = txt_nombres.Text;
                    usuario.Apellido_Empleado = txt_apellidos.Text;
                    usuario.Telefono1 = txt_telefono1.Text;
                    usuario.Telefono2 = txt_telefono2.Text;
                    usuario.Correo = txt_correo.Text;
                    usuario.Direccion = txt_direccion.Text;
                    usuario.DUI = txt_dui.Text;
                    usuario.NIT = txt_nit.Text;
                    usuario.AFP = cm_afp.Text;
                    usuario.Num_afp = int.Parse(txt_numafp.Text);
                    usuario.ISSS = int.Parse(txt_isss.Text);
                    usuario.Usuario = txt_usuario.Text;
                    usuario.Contraseña = txt_contraseña.Text;
                    empleadosR.Instancia.actualizar(usuario);
                    MessageBox.Show("¡Registro actualizado correctamente!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    cm_id.Visible = false;
                    picture_cancelar.Visible = false;
                    lb_c.Visible = false;
                    solo();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        private void Registro_usuarios_Load(object sender, EventArgs e)
        {
            Refrescar();

            //llenando el combobox con los afp
            cm_afp.Items.Clear();
            cm_afp.Items.Add("AFP CONFIA");
            cm_afp.Items.Add("AFP CRECER");
        }

        private void cm_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            usuarios usuario = usuarios.Where(u => u.Id_Empleado == int.Parse(cm_id.Text)).ToList<usuarios>().First<usuarios>();
            txt_nombres.Text = usuario.Nombre_Empleado;
            txt_apellidos.Text = usuario.Apellido_Empleado;
            txt_telefono1.Text = usuario.Telefono1;
            txt_telefono2.Text = usuario.Telefono2;
            txt_correo.Text = usuario.Correo;
            txt_direccion.Text = usuario.Direccion;
            txt_dui.Text = usuario.DUI;
            txt_nit.Text = usuario.NIT;
            txt_usuario.Text = usuario.Usuario;
            txt_contraseña.Text = usuario.Contraseña;
            cm_afp.Text = usuario.AFP;
            txt_numafp.Text = Convert.ToString(usuario.Num_afp);
            txt_isss.Text = Convert.ToString(usuario.ISSS);
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (cm_id.Text == "")
            {
                MessageBox.Show("Debe seleccionar un empleado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cm_id.Focus();
                return;
            }
            else {
                if (MessageBox.Show("¿Estas seguro que quieres eliminar este registro?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    try
                    {
                        usuarios usuario = new usuarios();
                        usuario.Id_Empleado = int.Parse(cm_id.Text);
                        empleadosR.Instancia.borrar(usuario);
                        MessageBox.Show("¡Registro eliminado correctamente!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        cm_id.Visible = false;
                        lb_c.Visible = false;
                        picture_cancelar.Visible = false;
                        solo();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else {
                    MessageBox.Show("Registro no eliminado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
               
            }
           
        }

        private void grid_usuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show(e.ColumnIndex + "");
        }

        private void txt_direccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_contraseña_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            nuevo();
            btn_guardar.Visible = true;
            btn_nuevo.Visible = false;
            btn_consultar.Visible = false;
            picture_n.Visible = false;
            picture_c.Visible = false;
            pictura_g.Visible = true;
            lb_c.Visible = true;
            picture_cancelar.Visible = true;
        }

        private void btn_consultar_Click(object sender, EventArgs e)
        {
            cm_id.Visible = true;
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
            cm_id.Visible = false;
            lb_c.Visible = false;
            picture_cancelar.Visible = false;
            btn_consultar.Visible = true;
            picture_c.Visible = true;
            btn_nuevo.Visible = true;
            picture_n.Visible = true;
            btn_guardar.Visible = false;
            pictura_g.Visible = false;
            btn_actualizar.Visible = false;
            picture_a.Visible = false;
            btn_eliminar.Visible = false;
            picture_e.Visible = false;
        }

        private void cm_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloNumeros(e);
        }

        private void txt_nombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloLetras(e);
        }

        private void txt_apellidos_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloLetras(e);
        }

        private void txt_telefono1_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloNumeros(e);
        }

        private void txt_telefono2_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloNumeros(e);
        }

        private void txt_salario_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (char.IsDigit(e.KeyChar))
            //{
            //    e.Handled = false;
            //}

            //else if (char.IsControl(e.KeyChar))
            //{
            //    e.Handled = false;
            //}
            //else if ((e.KeyChar == '.') && (!txt_salario.Text.Contains(".")))
            //{
            //    e.Handled = false;
            //}

            //else
            //{
            //    e.Handled = true;
            //    MessageBox.Show("¡Error, solo se admiten números en este campo!", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
        }

        private void txt_correo_Leave(object sender, EventArgs e)
        {
            if (validaremail(txt_correo.Text))
            {

            }
            else {
                MessageBox.Show("Dirección de correo no válida");
                txt_correo.SelectAll();
                
            }
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            login log = new login();
            this.Hide();
            log.Show();
        }

        private void txt_telefono1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_numafp_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloNumeros(e);
        }

        private void txt_isss_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloNumeros(e);
        }

        private void cm_afp_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloLetras(e);
        }

        private void txt_isss_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_contraseña_KeyPress(object sender, KeyPressEventArgs e)
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
            else
            {
                e.Handled = true;
                MessageBox.Show("¡Error, no se permiten espacios en este campo!", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txt_dui_Leave(object sender, EventArgs e)
        {
            if (validarDUI(txt_dui.Text))
            {

            }
            else {
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
            else {
                MessageBox.Show("Formato de nit, incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_nit.SelectAll();
                txt_nit.Clear();
            }
        }

        private void lb_c_Click(object sender, EventArgs e)
        {

        }
    }
}
