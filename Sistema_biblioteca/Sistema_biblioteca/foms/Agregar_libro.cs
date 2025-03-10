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
using Sistema_biblioteca.clases;

namespace Sistema_biblioteca.foms
{
    public partial class Agregar_libro : Form
    {
        public Agregar_libro()
        {
            InitializeComponent();
        }

        private void limpiar() {
            cm_autor.Text = "";
           cm_editorial.Text = "";
            txt_nombre.Clear();
            txt_año.Clear();
            txt_isbn.Clear();
            txt_descripcion.Clear();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {

            if (cm_autor.Text == "" || cm_editorial.Text == "" || txt_nombre.Text == "" || txt_descripcion.Text == "" || txt_año.Text == "" || txt_isbn.Text == "")
            {
                MessageBox.Show("No puede dejar campos vacios", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else {
                try
                {
                    string libro = txt_nombre.Text; string autor = cm_autor.Text; string editorial = cm_editorial.Text; string isbn = txt_isbn.Text; string descripcion = txt_descripcion.Text; int año = int.Parse(txt_año.Text); string estado = "Disponible";
                    //conexion
                    SqlConnection conexion = new SqlConnection();
                    conexion.ConnectionString = "data source=DESKTOP-O2EAJ87; database = DB_bibliotecaUDB; integrated security = true";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conexion;

                    conexion.Open();
                    cmd.CommandText = "insert into Libro(NombreLibro, NombreAutor, Editorial, ISBN, Descripcion, Año_edicion, Fecha_ingreso, Estado) values('" + libro + "','" + autor + "','" + editorial + "','" + isbn + "','" + descripcion + "','" + año + "',sysdatetime(),'" + estado + "')";
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("¡Libro registrado con exito!", "Excelente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiar();
                }
                catch (Exception ex) {
                    MessageBox.Show("Ocurrio un error revise los datos ingresados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show("El año de edición debe estar en el rango [2000-2022]", "Sugerencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show("El ISBN ya existe", "Sugerencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_isbn.Clear();
                    txt_año.Clear();
                }
            }
            
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Estas seguro que quieres cancelar el registro de este libro?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                this.Hide();
            }
            else {
                //no pasa nada
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Agregar_libro_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-O2EAJ87; database = DB_bibliotecaUDB; integrated security = true";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();

            cmd = new SqlCommand("select Nombre_autor from Autor", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    cm_autor.Items.Add(dr.GetString(i));
                }
            }
            dr.Close();

            cmd = new SqlCommand("select Nombre_editorial from Editorial", con);
            SqlDataReader dr1 = cmd.ExecuteReader();
            while (dr1.Read())
            {
                for (int i = 0; i < dr1.FieldCount; i++)
                {
                    cm_editorial.Items.Add(dr1.GetString(i));
                }
            }
            dr1.Close();
            con.Close();
        }

        private void txt_isbn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '-')
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
                MessageBox.Show("¡Error, no se permiten espacios y letras!", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_año_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloNumeros(e);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            menu men = new menu();
            this.Hide();
            men.Show();
        }
    }
}
