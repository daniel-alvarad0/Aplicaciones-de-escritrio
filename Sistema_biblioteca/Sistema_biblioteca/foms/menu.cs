using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Transitions;


namespace Sistema_biblioteca.foms
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void agregarLibroToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Estas seguro que quieres cerrar sesión?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                login log = new login();
                this.Hide();
                log.Show();
            }
            else {
                //no pasa nada
            }
        }

        private void agregarUnLibroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Agregar_libro agregar = new Agregar_libro();
            this.Hide();
            agregar.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //Transition t = new Transition(new TransitionType_EaseInEaseOut(500));
            //t.add(pictureBox1, "Left", -300);
            //t.add(pictureBox4, "left", 202);
            //t.run();
            pictureBox4.Visible = true;
            pictureBox3.Visible = false;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox5.Visible = true;
            pictureBox4.Visible = false;
       
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            pictureBox6.Visible = true;
            pictureBox5.Visible = false;
           
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            pictureBox7.Visible = true;
            pictureBox6.Visible = false;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            pictureBox3.Visible = true;
            pictureBox7.Visible = false;
        }

        private void consultarUnLibroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consultar_libros con = new Consultar_libros();
            this.Hide();
            con.Show();
        }

        private void registrarUnEstudianteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registro_estudiante estudiante = new Registro_estudiante();
            this.Hide();
            estudiante.Show();
        }

        private void consultarUnEstudianteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consultar_estudiante consultar = new Consultar_estudiante();
            this.Hide();
            consultar.Show();
        }

        private void consultarLibrosPrestadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            prestamo_libro libro = new prestamo_libro();
            this.Hide();
            libro.Show();
        }

        private void regresarUnLibroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Regresar_libro libro = new Regresar_libro();
            this.Hide();
            libro.Show();
        }

        private void consultarListadoDeLibrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
        }

        private void informaciónGeneralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listado_libros libros = new listado_libros();
            this.Hide();
            libros.Show();
        }
    }
}
