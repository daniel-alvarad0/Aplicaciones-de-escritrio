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

namespace Sistema_biblioteca.foms
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void btn_ingresar_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = "data source=DESKTOP-O2EAJ87; database=DB_bibliotecaUDB;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexion;

            cmd.CommandText = "select * from usuario where usuario = '" + txt_usuario.Text + "' and contraseña='" + txt_contraseña.Text +"'";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count != 0)
            {
                MessageBox.Show("¡Credenciales correctas!", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                menu men = new menu();
                this.Hide();
                men.Show();
            }
            else {
                MessageBox.Show("Error, las credenciales ingresadas son incorrectas", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_usuario.Clear();
                txt_contraseña.Clear();
            }
        }

        private void txt_usuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar)) {
                e.Handled = false;
            }
            else if(char.IsLetter(e.KeyChar)){
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

        private void btn_registrar_Click(object sender, EventArgs e)
        {
            Registro_usuario usuario = new Registro_usuario();
            this.Hide();
            usuario.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Estas seguro que quieres salir del sistema?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                Application.Exit();
            }
            else {
                //no pasa nada
            }
        }
    }
}
