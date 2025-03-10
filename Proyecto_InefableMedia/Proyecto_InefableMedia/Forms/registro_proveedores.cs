using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Proyecto_InefableMedia.Clases;
using Proyecto_InefableMedia.Repositorios;
using System.Text.RegularExpressions;

namespace Proyecto_InefableMedia.Forms
{
    public partial class registro_proveedores : Form
    {
        private List<proveedores> proveedores = new List<proveedores>();

        public registro_proveedores()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void Refrescar()//para rellenar el datagrid con los datos
        {
            proveedores = proveedoresR.Instance.findAll();
            cm_proveedor.Items.Clear();
            gridproveedores.Rows.Clear();
            foreach (proveedores pro in proveedores)
            {
                cm_proveedor.Items.Add(pro.Id_proveedor);
                gridproveedores.Rows.Add(pro.Id_proveedor, pro.Nombre_proveedor, pro.Direccion_proveedor, pro.Telefono_proveedor, pro.Correo, pro.Nombre_contacto, pro.Telefono_contacto);
            }
        }


        private void limpiar()
        {
            txt_contacto.Clear();
            txt_correo.Clear();
            txt_dirección.Clear();
            txt_nombre.Clear();
            txt_telefono_c.Clear();
            txt_telefono_p.Clear();
            cm_proveedor.Text = "";
        }

        private void nuevo()
        {
            txt_contacto.ReadOnly = false;
            txt_correo.ReadOnly = false;
            txt_dirección.ReadOnly = false;
            txt_nombre.ReadOnly = false;
            txt_telefono_c.ReadOnly = false;
            txt_telefono_p.ReadOnly = false;
        }

        private void consultar()
        {
            txt_contacto.ReadOnly = false;
            txt_correo.ReadOnly = false;
            txt_dirección.ReadOnly = false;
            txt_nombre.ReadOnly = false;
            txt_telefono_c.ReadOnly = false;
           txt_telefono_p.ReadOnly = false;
        }

        private void solo()
        {
            txt_contacto.ReadOnly = true;
            txt_correo.ReadOnly = true;
            txt_dirección.ReadOnly = true;
            txt_nombre.ReadOnly = true;
           txt_telefono_c.ReadOnly = true;
            txt_telefono_p.ReadOnly = true;
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

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (txt_contacto.Text == "" || txt_correo.Text == "" || txt_dirección.Text == "" || txt_nombre.Text == "" || txt_telefono_c.Text == "" || txt_telefono_p.Text == "")
            {
                MessageBox.Show("No puedes dejar campos vacios", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (!validaremail(txt_correo.Text))
            {
                MessageBox.Show("Dirección de correo no válida");
                txt_correo.SelectAll();
                return;
            }
            else
            {
                proveedores proveedor = new proveedores();

                proveedor.Nombre_proveedor = txt_nombre.Text;
                proveedor.Direccion_proveedor = txt_dirección.Text;
                proveedor.Telefono_proveedor = int.Parse(txt_telefono_p.Text);
                proveedor.Correo = txt_correo.Text;
                proveedor.Nombre_contacto = txt_contacto.Text;
                proveedor.Telefono_contacto = int.Parse(txt_telefono_c.Text);

                proveedoresR.Instance.guardar(proveedor);

                MessageBox.Show("Guardado correctamente!!");
                Refrescar();
                limpiar();
                btn_guardar.Visible = false;
                btn_nuevo.Visible = true;
                btn_consultar.Visible = true;
                picture_g.Visible = false;
                picture_n.Visible = true;
                picture_c.Visible = true;
                lb_c.Visible = false;
                picture_cancelar.Visible = false;
                solo();

            }
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            if (cm_proveedor.Text == "")
            {
                MessageBox.Show("Debe selecionar un proveedor", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cm_proveedor.Focus();
                return;
                
            }
            else if (txt_contacto.Text == "" || txt_correo.Text == "" || txt_dirección.Text == "" || txt_nombre.Text == "" || txt_telefono_c.Text == "" || txt_telefono_p.Text == "")
            {
                MessageBox.Show("No puede dejar campos vacios", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (!validaremail(txt_correo.Text))
            {
                MessageBox.Show("Dirección de correo no válida");
                txt_correo.SelectAll();
                return;
            }
            else {

                try
                {
                    proveedores proveedor = new proveedores();

                    proveedor.Id_proveedor = int.Parse(cm_proveedor.Text);
                    proveedor.Nombre_proveedor = txt_nombre.Text;
                    proveedor.Direccion_proveedor = txt_dirección.Text;
                    proveedor.Telefono_proveedor = int.Parse(txt_telefono_p.Text);
                    proveedor.Correo = txt_correo.Text;
                    proveedor.Nombre_contacto = txt_contacto.Text;
                    proveedor.Telefono_contacto = int.Parse(txt_telefono_c.Text);

                    proveedoresR.Instance.actualizar(proveedor);

                    MessageBox.Show("Actualizado correctamente!!");
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
                    cm_proveedor.Visible = false;
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

        private void cm_proveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                proveedores proveedor = proveedoresR.Instance.find(int.Parse(cm_proveedor.Text));

                txt_dirección.Text = proveedor.Direccion_proveedor;
                txt_nombre.Text = proveedor.Nombre_proveedor;
                txt_contacto.Text = proveedor.Nombre_contacto;
                txt_correo.Text = proveedor.Correo;
                txt_telefono_c.Text = Convert.ToString(proveedor.Telefono_contacto);
                txt_telefono_p.Text = Convert.ToString(proveedor.Telefono_proveedor);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            this.Hide();
            menu.Show();
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            nuevo();
            btn_guardar.Visible = true;
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
            cm_proveedor.Visible = true;
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
            cm_proveedor.Visible = false;
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

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            limpiar();
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

        private void cm_proveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloNumeros(e);
        }

        private void txt_nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            } else if (e.KeyChar == '-') {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("¡Error, solo se admiten letras en este campo!", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txt_telefono_p_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloNumeros(e);
        }

        private void txt_correo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_contacto_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_contacto_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloLetras(e);
        }

        private void txt_telefono_c_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloNumeros(e);
        }

        private void registro_proveedores_Load(object sender, EventArgs e)
        {
            Refrescar();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txt_telefono_p_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cm_proveedor.Text == "")
            {
                MessageBox.Show("Debe selecionar un proveedor", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cm_proveedor.Focus();
                return;
            }
            else {
                if (MessageBox.Show("¿Estas seguro que quieres eliminar este registro?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    try
                    {
                        proveedores proveedor = new proveedores();
                        proveedor.Id_proveedor = int.Parse(cm_proveedor.Text);
                        proveedoresR.Instance.borrar(proveedor);
                        MessageBox.Show(this, "Proveedor eliminado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        cm_proveedor.Visible = false;
                        lb_c.Visible = false;
                        picture_cancelar.Visible = false;
                        solo();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, "Error al eliminar el proveedor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Proveedor no eliminado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            
        }

        private void txt_telefono_c_TextChanged(object sender, EventArgs e)
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
    }
}
