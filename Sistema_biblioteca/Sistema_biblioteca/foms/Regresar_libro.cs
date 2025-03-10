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
    public partial class Regresar_libro : Form
    {
        private string nombre_libro, fecha_prestamo;
        private int id_fila;
        public Regresar_libro()
        {
            InitializeComponent();
        }

        private void limpiar() {
            txt_estudiante.Clear();
            txt_libro.Clear();
            txr_prestamo.Clear();
            grid_datos.DataSource = null;
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-O2EAJ87; database = DB_bibliotecaUDB; integrated security = true";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from prestamo where Carnet='" + txt_estudiante.Text + "' and Fecha_devolucion is null"; //extraer todos los datos de la tabla para llenar el datagrid
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0)
            {
                grid_datos.DataSource = ds.Tables[0]; //llenar grid con datos
            }
            else {
                MessageBox.Show("Número de carnet no registrado o no tiene ningún libro prestado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                limpiar();
                txt_estudiante.Focus();
            }
           
        }

        private void btn_regresar_Click(object sender, EventArgs e)
        {
            if (txt_libro.Text == "")
            {
                MessageBox.Show("Debe seleccionar el libro que se va a devolver", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else {

                if (MessageBox.Show("¿Quiere devolver este libro?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "data source = DESKTOP-O2EAJ87; database = DB_bibliotecaUDB; integrated security = true";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandText = "update prestamo set Fecha_devolucion= '" + Time_devolucion.Text + "' where Carnet = '" + txt_estudiante.Text + "' and id_prestamo = '" + id_fila + "'"; //actualizamos el campo Fecha_devolucion de la tabla prestamo

                    cmd.ExecuteNonQuery();
                    con.Close();

                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.Connection = con;
                    con.Open();
                    cmd1.CommandText = "update Libro set Estado= 'Disponible' where NombreLibro = '" + txt_libro.Text + "'";
                    cmd1.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("¡Libro devuelto!", "atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiar();
                }
                else
                {
                    //no pasa nada
                }
            }
           
            
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void txt_estudiante_KeyPress(object sender, KeyPressEventArgs e)
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

        private void Regresar_libro_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            menu men = new menu();
            this.Hide();
            men.Show();
        }

        private void grid_datos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grid_datos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null) {
                id_fila = int.Parse(grid_datos.Rows[e.RowIndex].Cells[0].Value.ToString());
                nombre_libro = grid_datos.Rows[e.RowIndex].Cells[8].Value.ToString();
                fecha_prestamo = grid_datos.Rows[e.RowIndex].Cells[9].Value.ToString();
            }
            txt_libro.Text = nombre_libro;
            txr_prestamo.Text = fecha_prestamo;
        }
    }
}
