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
    public partial class listado_libros : Form
    {
        public listado_libros()
        {
            InitializeComponent();
        }

        private void listado_libros_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-O2EAJ87; database = DB_bibliotecaUDB; integrated security = true";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Libro where Estado= 'Prestado'"; //extraer todos los datos de la tabla para llenar el datagrid
            //cmd.CommandText = "select * from prestamo where Fecha_devolucion is null";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grid_regresados.DataSource = ds.Tables[0];

            cmd.CommandText = "select * from Libro where Estado= 'Disponible'"; //extraer todos los datos de la tabla para llenar el datagrid
           // cmd.CommandText = "select * from prestamo where Fecha_devolucion is not null"; //extraer todos los datos de la tabla para llenar el datagrid
            SqlDataAdapter da1 = new SqlDataAdapter(cmd);
            DataSet ds1 = new DataSet();
            da.Fill(ds1);
            grid_prestados.DataSource = ds1.Tables[0];
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            menu men = new menu();
            this.Hide();
            men.Show();
        }
    }
}
