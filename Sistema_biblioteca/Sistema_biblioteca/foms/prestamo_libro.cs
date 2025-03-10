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
    public partial class prestamo_libro : Form
    {
        private int count;
        public prestamo_libro()
        {
            InitializeComponent();
        }

        private void limpiar() {
            txt_apellidos.Clear();
            txt_carnet.Clear();
            txt_correo.Clear();
            txt_facultad.Clear();
            txt_nombres.Clear();
            txt_telefon.Clear();
            txt_buscar.Clear();
            cm_libros.Text = "";
        }

        private void prestamo_libro_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-O2EAJ87; database = DB_bibliotecaUDB; integrated security = true";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();

            cmd = new SqlCommand("select Nombrelibro from Libro where Estado like 'Disponible'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) {
                for (int i = 0; i < dr.FieldCount; i++) {
                    cm_libros.Items.Add(dr.GetString(i));
                }
            }
            dr.Close();
            con.Close();
        }

       

        private void btn_buscar_estudiante_Click(object sender, EventArgs e)
        {
            if (txt_buscar.Text == "")
            {
                MessageBox.Show("Debes ingresar el carnet del estudiante", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_buscar.Focus();
            }
            else {
                btn_prestar.Enabled = true;
                cm_libros.Enabled = true;
                string carnet = txt_buscar.Text;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-O2EAJ87; database = DB_bibliotecaUDB; integrated security = true";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from Estudiante where Carnet='" + carnet + "'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                da.Fill(DS);
               /////
                cmd.CommandText = "select count(Carnet) from prestamo where Carnet='" + carnet + "' and Fecha_devolucion is null";
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataSet DS1 = new DataSet();
                da.Fill(DS1);
                //
                count = int.Parse(DS1.Tables[0].Rows[0][0].ToString());
                if (DS.Tables[0].Rows.Count != 0)
                {
                    txt_carnet.Text = DS.Tables[0].Rows[0][0].ToString();
                    txt_nombres.Text = DS.Tables[0].Rows[0][1].ToString();
                    txt_apellidos.Text = DS.Tables[0].Rows[0][2].ToString();
                    txt_facultad.Text = DS.Tables[0].Rows[0][3].ToString();
                    txt_telefon.Text = DS.Tables[0].Rows[0][5].ToString();
                    txt_correo.Text = DS.Tables[0].Rows[0][6].ToString();
                }
                else {
                    btn_prestar.Enabled = false;
                    cm_libros.Enabled = false;
                    MessageBox.Show("N° de carnet no registrado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    limpiar();
                    txt_buscar.Focus();
                }
            }
        }

        private void btn_prestar_Click(object sender, EventArgs e)
        {
            
            if (txt_nombres.Text != "") {
                if (cm_libros.SelectedIndex != -1 && count <= 2)
                {
                    string carnet = txt_carnet.Text;
                    string nombres = txt_nombres.Text;
                    string apellidos = txt_apellidos.Text;
                    string facultad = txt_facultad.Text;
                    int num_telefono = int.Parse(txt_telefon.Text);
                    string correo = txt_correo.Text;
                    string titulo = cm_libros.Text;
                    string fecha_prestamo = time_prestamo.Text;

                    string Carnet = txt_buscar.Text;
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "data source = DESKTOP-O2EAJ87; database = DB_bibliotecaUDB; integrated security = true";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandText = "insert into prestamo(Carnet,Nombres_estudiante, Apellidos_estudiante, Facultad_estudiante, Num_telefono_estudiante, Correo_estudiante, Titulo_libro, Fecha_prestamo) values('" + carnet + "','" + nombres + "','" + apellidos + "','" + facultad + "','" + num_telefono + "','" + correo + "','" + titulo + "','" + fecha_prestamo + "')";
                 
                    cmd.ExecuteNonQuery();
                    con.Close();

                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.Connection = con;
                    con.Open();
                    cmd1.CommandText = "update Libro set Estado= 'Prestado' where NombreLibro='" + cm_libros.Text + "'";
                    cmd1.ExecuteNonQuery();
                    con.Close();

                  
                    MessageBox.Show("Libro prestado", "Excelente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiar();
                  
                    //prestamo_libro_Load(this, null);
              
                    btn_prestar.Enabled = false;
                    cm_libros.Enabled = false;
                }
                else if (cm_libros.Text == "")
                {
                    MessageBox.Show("Debe seleccionar el libro que quiere prestar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cm_libros.Focus();
                }
                else {
                    MessageBox.Show("Este estudiante ya tiene 3 prestamos vigentes", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    limpiar();
                    btn_prestar.Enabled = false;
                    cm_libros.Enabled = false;
                }
            }
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            limpiar();
            btn_prestar.Enabled = false;
            cm_libros.Enabled = false;
        }

        private void txt_buscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsLetter(e.KeyChar))
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

        private void cm_libros_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            menu men = new menu();
            this.Hide();
            men.Show();
        }
    }
}
