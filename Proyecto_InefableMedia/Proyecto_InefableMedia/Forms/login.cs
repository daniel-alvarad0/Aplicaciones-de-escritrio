using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using Proyecto_InefableMedia.Repositorios;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Proyecto_InefableMedia.Forms
{
    public partial class login : Form
    {
        private SqlConnection conect;
        OleDbConnection cnn = new OleDbConnection();
        private string Co;
        public login()
        {
            InitializeComponent();
            conexion2 cn = new conexion2();
            cn.conec();
            Co = cn.cadena;
            conect = new SqlConnection(Co);
            conect.Open();
            cnn.ConnectionString = "Provider=SQLOLEDB; Persist Security Info=False;Integrated Security=true;Initial Catalog=BD_Inefable;server=(local)";
            conexion2 cn1 = new
                conexion2();
            cn1.conec();
            Co = cn1.cadena;
            conect = new SqlConnection(Co);
        }

        private void btn_ingresar_Click(object sender, EventArgs e)
        {
            if (txt_usuario.Text == "")
            {
                MessageBox.Show("Debe ingresar su usuario", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_usuario.Focus();
                return;
            }
            else if (txt_contraseña.Text == "")
            {
                MessageBox.Show("Debe ingresar su contraseña", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_contraseña.Focus();
                return;
            }
            else
            {
                conect.Open();
                string consulta = "select usuario,contraseña from empleado where usuario='" + txt_usuario.Text + "' and contraseña='" + txt_contraseña.Text + "'";
                SqlCommand comando = new SqlCommand(consulta, conect);
                SqlDataReader lector = comando.ExecuteReader();


                if (lector.Read())
                {
                    MessageBox.Show("Ingresó Correctamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Menu Cambio = new Menu();
                    this.Hide();
                    Cambio.Show();
                    conect.Close();
                }
                else
                {
                    MessageBox.Show("Los datos que ha ingresado son incorrectos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_usuario.Clear();
                    txt_contraseña.Clear();
                    txt_usuario.Focus();
                    conect.Close();
                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Estas seguro que quieres salir del programa?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes) {
                Application.Exit();
            }
        }

        private void btn_registrar_Click(object sender, EventArgs e)
        {
            Registro_usuarios registro = new Registro_usuarios();
            this.Hide();
            registro.Show();
        }

        private void txt_usuario_KeyPress(object sender, KeyPressEventArgs e)
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        

        private void pbMostrar_Click(object sender, EventArgs e)
        {
            pbOcultar.BringToFront();
            txt_contraseña.PasswordChar = '\0';
        }

        private void pbOcultar_Click(object sender, EventArgs e)
        {
            pbMostrar.BringToFront();
            txt_contraseña.PasswordChar = '*';
        }
    }
}
