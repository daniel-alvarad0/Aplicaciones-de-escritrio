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
    public partial class Consultar_libros : Form
    {
        private Int64 idFila;
        public Consultar_libros()
        {
            InitializeComponent();
           

        }

        private void limpiar() {
            txt_autor.Clear();
            txt_estado.Clear();
            txt_editorial.Clear();
            txt_fecha.Clear();
            txt_nombre.Clear();
            txt_buscar.Clear();
            txt_isbn.Clear();
            txt_año.Clear();
            txt_descripcion.Clear();
        }

        private void on() {
            txt_nombre.ReadOnly = true;
            txt_editorial.ReadOnly = true;
            txt_autor.ReadOnly = true;
            txt_isbn.ReadOnly = true;
            txt_descripcion.ReadOnly = true;
            txt_año.ReadOnly = true;
        }

        private void Actualizar() {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-O2EAJ87; database = DB_bibliotecaUDB; integrated security = true";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Libro"; //extraer todos los datos de la tabla para llenar el datagrid
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grid_libros.DataSource = ds.Tables[0]; //llenar grid con datos
        }

        private void Consultar_libros_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-O2EAJ87; database = DB_bibliotecaUDB; integrated security = true";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Libro"; //extraer todos los datos de la tabla para llenar el datagrid
            SqlDataAdapter da= new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grid_libros.DataSource = ds.Tables[0]; //llenar grid con datos
        }

        private void grid_libros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private int ID;
        private void grid_libros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txt_nombre.ReadOnly = false;
                txt_editorial.ReadOnly = false;
                txt_autor.ReadOnly = false;
                txt_isbn.ReadOnly = false;
                txt_descripcion.ReadOnly = false;
                txt_año.ReadOnly = false;
                if (grid_libros.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    ID = int.Parse(grid_libros.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-O2EAJ87; database = DB_bibliotecaUDB; integrated security = true";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from Libro where Id_libro=" + ID + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                idFila = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                txt_nombre.Text = ds.Tables[0].Rows[0][1].ToString(); //para llenar los campos de abajo para ver su informacion general y cambiar o eliminar dicho libro
                txt_autor.Text = ds.Tables[0].Rows[0][2].ToString();
                txt_editorial.Text = ds.Tables[0].Rows[0][3].ToString();
                txt_isbn.Text = ds.Tables[0].Rows[0][4].ToString();
                txt_descripcion.Text = ds.Tables[0].Rows[0][5].ToString();
                txt_año.Text = ds.Tables[0].Rows[0][6].ToString();
                txt_fecha.Text = ds.Tables[0].Rows[0][7].ToString();
                txt_estado.Text = ds.Tables[0].Rows[0][8].ToString();
            }
            catch (Exception ex) {
                MessageBox.Show("Error");
                on();
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            limpiar();
            on();
        }
        
        private void btn_buscar_Click(object sender, EventArgs e) //buscar un libro por su nombre o ID
        {
           

               if (txt_buscar.Text != "")
               {
                btn_buscar.Visible = false;
                btn_volver.Visible = true;
           
                  // busqueda por Nombre del libro
                   SqlConnection con = new SqlConnection();
                  con.ConnectionString = "data source = DESKTOP-O2EAJ87; database = DB_bibliotecaUDB; integrated security = true";
                   SqlCommand cmd = new SqlCommand();
                   cmd.Connection = con;
                   cmd.CommandText = "select * from Libro where Id_libro =" + txt_buscar.Text;
                   SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                grid_libros.DataSource = ds.Tables[0]; //llenar grid con datos 
                limpiar();
            }
               else
               {
                  MessageBox.Show("Debes ingresar el ID del libro que desea buscar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_buscar.Focus();
                  SqlConnection con = new SqlConnection();
                  con.ConnectionString = "data source = DESKTOP-O2EAJ87; database = DB_bibliotecaUDB; integrated security = true";
                   SqlCommand cmd = new SqlCommand();
                 cmd.Connection = con;
                 cmd.CommandText = "select * from Libro"; //extraer todos los datos de la tabla para llenar el datagrid
                  SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                  da.Fill(ds);
                  grid_libros.DataSource = ds.Tables[0]; //llenar grid con datos

               }

            }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            on();
            btn_volver.Visible = false;
            btn_buscar.Visible = true;
          
            txt_buscar.Clear();
            limpiar();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-O2EAJ87; database = DB_bibliotecaUDB; integrated security = true";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Libro"; //extraer todos los datos de la tabla para llenar el datagrid
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grid_libros.DataSource = ds.Tables[0]; //llenar grid con datos
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            if (txt_autor.Text == ""  || txt_editorial.Text == "" || txt_nombre.Text == "" || txt_descripcion.Text == "" || txt_año.Text == "")
            {
                MessageBox.Show("No puedes dejar campos vacios", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else {
                try
                {
                    if (MessageBox.Show("¿Estas seguro que quieres actualizar este registro?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        string libro = txt_nombre.Text; string autor = txt_autor.Text; string editorial = txt_editorial.Text; string descripcion = txt_descripcion.Text; int año = int.Parse(txt_año.Text); string isbn = txt_isbn.Text;
                        SqlConnection con = new SqlConnection();
                        con.ConnectionString = "data source= DESKTOP-O2EAJ87; database=  DB_bibliotecaUDB; integrated security=true";
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;

                        cmd.CommandText = "update Libro set NombreLibro='" + libro + "',NombreAutor='" + autor + "',Editorial='" + editorial + "',ISBN='" + isbn + "',Descripcion='" + descripcion + "',Año_edicion='" + año + "'where Id_libro='" + idFila + "'";
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        MessageBox.Show("Registro actualizado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiar();
                        Actualizar();
                        on();
                    }
                    else
                    {
                        //no pasa nada
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show("Ocurrio un error revise los datos ingresados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_isbn.SelectAll();
                    txt_isbn.Focus();
                    txt_año.SelectAll();
                    txt_año.Focus();
                }
            }
            
            
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (txt_nombre.Text == "")
            {
                MessageBox.Show("Debe seleccionar que libro va a eliminar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else {
                if (MessageBox.Show("¿Estas seguro que quieres eliminar este registro?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {

                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "data source= DESKTOP-O2EAJ87; database=  DB_bibliotecaUDB; integrated security=true";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    cmd.CommandText = "delete from Libro where Id_libro=" + idFila + "";
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    MessageBox.Show("Registro eliminado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiar();
                    Actualizar();
                    on();
                }
                else
                {
                    //no pasa nada
                }
            }
            
        }

        private void txt_buscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloNumeros(e);
        }

        private void txt_nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloLetras(e);
        }

        private void txt_autor_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloLetras(e);
        }

        private void txt_editorial_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloLetras(e);
        }

        private void txt_cantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloNumeros(e);
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

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            menu men = new menu();
            this.Hide();
            men.Show();
        }
    }
    }

