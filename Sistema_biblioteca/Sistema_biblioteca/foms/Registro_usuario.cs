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
using System.Text.RegularExpressions;
using Sistema_biblioteca.clases;

namespace Sistema_biblioteca.foms
{
    public partial class Registro_usuario : Form
    {
        public Registro_usuario()
        {
            InitializeComponent();
        }

        private void limpiar() {
            txt_apellido.Clear();
            txt_contraseña.Clear();
            txt_direccion.Clear();
            txt_email.Clear();
            txt_nombre.Clear();
            txt_telefono.Clear();
            txt_usuario.Clear();
        }

        public static bool validadEmail(string Email)
        {
            string expresion = "^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:.[a-zA-Z0-9-]+)*$";

            if (Regex.IsMatch(Email, expresion))
            {
                if (Regex.Replace(Email, expresion, string.Empty).Length == 0)
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

        private void btn_registrar_Click(object sender, EventArgs e)
        {

            if (txt_apellido.Text == "" || txt_contraseña.Text == "" || txt_direccion.Text == "" || txt_email.Text == "" || txt_nombre.Text == "" || txt_telefono.Text == "" || txt_usuario.Text == "")
            {
                MessageBox.Show("No puede dejar campos vacios", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            } else if (!validadEmail(txt_email.Text)) {
                MessageBox.Show("Dirección de correo no válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_email.SelectAll();
                txt_email.Clear();
                txt_email.Focus();
            }
            else
            {
                try
                {
                    string nombre = txt_nombre.Text; string apellido = txt_apellido.Text; string direccion = txt_direccion.Text; int telefono = int.Parse(txt_telefono.Text); string email = txt_email.Text; string usuario = txt_usuario.Text; string contraseña = txt_contraseña.Text;
                    //conexion
                    SqlConnection conexion = new SqlConnection();
                    conexion.ConnectionString = "data source=DESKTOP-O2EAJ87; database = DB_bibliotecaUDB; integrated security = true";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conexion;

                    conexion.Open();
                    cmd.CommandText = "insert into usuario(Nombres, Apellidos, Dirección, Teléfono, Email, usuario, contraseña) values('" + nombre + "','" + apellido + "','" + direccion + "','" + telefono + "','" + email + "','" + usuario + "','" + contraseña + "')";
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("¡Registro exisoso!", "Excelente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiar();
                    login log = new login();
                    this.Hide();
                    log.Show();
                }
                catch (Exception ex)
                {

                }
            }
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

        private void txt_email_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '@')
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.')
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
                MessageBox.Show("¡Error, no se permiten espacios!", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_contraseña_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            menu men = new menu();
            this.Hide();
            men.Show();
        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            login log = new login();
            this.Hide();
            log.Show();
        }
    }
}
