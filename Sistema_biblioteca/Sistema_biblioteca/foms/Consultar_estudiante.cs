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
using System.Text.RegularExpressions;

namespace Sistema_biblioteca.foms
{
    public partial class Consultar_estudiante : Form
    {
        public Consultar_estudiante()
        {
            InitializeComponent();
        }

        private string CarnetFila;

        private void limpiar()
        {
           txt_apellidos.Clear();
            txt_carnet.Clear();
            txt_buscar.Clear();
            txt_correo.Clear();
            txt_facultad.Clear();
           txt_fecha.Clear();
            txt_nombres.Clear();
            txt_telefono.Clear();
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

        private void Actualizar()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-O2EAJ87; database = DB_bibliotecaUDB; integrated security = true";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Estudiante"; //extraer todos los datos de la tabla para llenar el datagrid
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
           grid_datos.DataSource = ds.Tables[0]; //llenar grid con datos
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            try {
                if (txt_buscar.Text == "")
                {
                    MessageBox.Show("Debe ingresar el carnet del estudiante para buscarlo", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_buscar.Focus();
                }
                else {
                    btn_buscar.Visible = false;
                    btn_volver.Visible = true;
        
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "data source = DESKTOP-O2EAJ87; database = DB_bibliotecaUDB; integrated security = true";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select * from Estudiante where Carnet like '" + txt_buscar.Text + "'"; //extraer todos los datos de la tabla para llenar el datagrid
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    grid_datos.DataSource = ds.Tables[0]; //llenar grid con datos
                    txt_apellidos.Clear();
                    txt_carnet.Clear();
                    txt_correo.Clear();
                    txt_facultad.Clear();
                    txt_fecha.Clear();
                    txt_nombres.Clear();
                    txt_telefono.Clear();
                }
                
            }
            catch (Exception ex) {

            }
        }

        private void Consultar_estudiante_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-O2EAJ87; database = DB_bibliotecaUDB; integrated security = true";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Estudiante"; //extraer todos los datos de la tabla para llenar el datagrid
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grid_datos.DataSource = ds.Tables[0]; //llenar grid con datos
        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            btn_volver.Visible = false;
     
            btn_buscar.Visible = true;
            txt_apellidos.ReadOnly = true;
            txt_correo.ReadOnly = true;
            txt_nombres.ReadOnly = true;
            txt_telefono.ReadOnly = true;
            txt_buscar.Clear();
            limpiar();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-O2EAJ87; database = DB_bibliotecaUDB; integrated security = true";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Estudiante"; //extraer todos los datos de la tabla para llenar el datagrid
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grid_datos.DataSource = ds.Tables[0]; //llenar grid con datos
        }
        private string Carnet;
        private void grid_datos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_apellidos.ReadOnly = false;
            txt_correo.ReadOnly = false;
            txt_nombres.ReadOnly = false;
            txt_telefono.ReadOnly = false;
            if (grid_datos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                Carnet = grid_datos.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
      
            SqlConnection con = new SqlConnection();
           con.ConnectionString = "data source = DESKTOP-O2EAJ87; database = DB_bibliotecaUDB; integrated security = true";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Estudiante where Carnet='" + Carnet + "'";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            CarnetFila = ds.Tables[0].Rows[0][0].ToString(); //capturar carnet de esa fila para luego usarla en actualizar datos
            txt_carnet.Text = ds.Tables[0].Rows[0][0].ToString(); //para llenar los campos de abajo para ver su informacion general y cambiar o eliminar dicho libro
            txt_nombres.Text = ds.Tables[0].Rows[0][1].ToString();
            txt_apellidos.Text = ds.Tables[0].Rows[0][2].ToString();
           txt_facultad.Text = ds.Tables[0].Rows[0][3].ToString();
            txt_fecha.Text = ds.Tables[0].Rows[0][4].ToString();
            txt_telefono.Text = ds.Tables[0].Rows[0][5].ToString();
            txt_correo.Text = ds.Tables[0].Rows[0][6].ToString();
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            if (txt_carnet.Text == "") {
                MessageBox.Show("Debe selecionar un registro para actualizar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            } else if (txt_apellidos.Text == "" || txt_correo.Text == "" || txt_nombres.Text == "" || txt_telefono.Text == "")
            {
                MessageBox.Show("No puedes dejar campos vacios", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            } else if (!validaremail(txt_correo.Text)) {
                MessageBox.Show("Dirección de correo no válida");
                txt_correo.SelectAll();
            }
            else
            {
                if (MessageBox.Show("¿Estas seguro que quieres actualizar este registro?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    string nombre = txt_nombres.Text; string apellido = txt_apellidos.Text; string correo = txt_correo.Text; int telefono = int.Parse(txt_telefono.Text);
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "data source= DESKTOP-O2EAJ87; database=  DB_bibliotecaUDB; integrated security=true";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    cmd.CommandText = "update Estudiante set Nombres='" + nombre + "',Apellidos='" + apellido + "',correo_eléctronico='" + correo + "',Numero_teléfono=" + telefono + "where Carnet='" + CarnetFila + "'";
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    MessageBox.Show("Registro actualizado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiar();
                    Actualizar();
                    txt_apellidos.ReadOnly = true;
                    txt_correo.ReadOnly = true;
                    txt_nombres.ReadOnly = true;
                    txt_telefono.ReadOnly = true;
                }
                else
                {
                    //no pasa nada
                }

            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            txt_apellidos.ReadOnly = true;
            txt_correo.ReadOnly = true;
            txt_nombres.ReadOnly = true;
            txt_telefono.ReadOnly = true;
            limpiar();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (txt_carnet.Text == "")
            {
                MessageBox.Show("Debe selecionar un registro para eliminar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                if (MessageBox.Show("¿Estas seguro que quieres eliminar este registro?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                  //  string nombre = txt_nombres.Text; string apellido = txt_apellidos.Text; string correo = txt_correo.Text; int telefono = int.Parse(txt_telefono.Text);
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "data source= DESKTOP-O2EAJ87; database=  DB_bibliotecaUDB; integrated security=true";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    cmd.CommandText = "delete from Estudiante where Carnet='" + CarnetFila + "'";
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    MessageBox.Show("Registro eliminado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiar();
                    Actualizar();
                    txt_apellidos.ReadOnly = true;
                    txt_correo.ReadOnly = true;
                    txt_nombres.ReadOnly = true;
                    txt_telefono.ReadOnly = true;
                }
                else
                {
                    //no pasa nada
                }

            }
        }

        private void txt_buscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            } else if (char.IsLetter(e.KeyChar)) {
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

        private void txt_nombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloLetras(e);
        }

        private void txt_apellidos_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloLetras(e);
        }

        private void txt_telefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloNumeros(e);
        }

        private void txt_correo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            menu menu = new menu();
            this.Hide();
            menu.Show();
        }
    }
}
