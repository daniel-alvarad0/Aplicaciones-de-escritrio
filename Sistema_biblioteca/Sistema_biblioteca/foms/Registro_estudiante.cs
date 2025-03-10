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
    public partial class Registro_estudiante : Form
    {

       
        public Registro_estudiante()
        {
            InitializeComponent();
        }
     
        private void label3_Click(object sender, EventArgs e)
        {

        }

        public static bool validarDUI(string DUI)
        {
            string dui = "[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]-[0-9]";

            if (Regex.IsMatch(DUI, dui))
            {
                if (Regex.Replace(DUI, dui, string.Empty).Length == 0)
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

        public static bool validarCanet(string Carnet)
        {
            string carnet = "[A-Z][A-Z][0-9][0-9][0-9][0-9][0-9][0-9]";

            if (Regex.IsMatch(Carnet, carnet))
            {
                if (Regex.Replace(Carnet, carnet, string.Empty).Length == 0)
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

        private void limpiar() {
            txt_apellidos.Clear();
            txt_carnet.Clear();
            txt_correo.Clear();
            txt_nombres.Clear();
            txt_telefono.Clear();
            cm_facultad.Text = "";
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (txt_apellidos.Text == "" || txt_carnet.Text == "" || txt_correo.Text == "" || txt_nombres.Text == "" || txt_telefono.Text == "")
            {
                MessageBox.Show("No puedes dejar campos vacios", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            } else if (cm_facultad.Text == "") {
                MessageBox.Show("Debe selecionar la facultad a la que pertenece el estudiante", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cm_facultad.Focus();
                return;
            } else if (!validadEmail(txt_correo.Text)) {
                MessageBox.Show("Dirección de correo no valida");
                txt_correo.SelectAll();
            }
            else {
                if (validadEmail(txt_correo.Text))
                {
                    if (validarCanet(txt_carnet.Text))
                    {
                        try
                        {
                            string carnet = txt_carnet.Text; string nombre = txt_nombres.Text; string apellidos = txt_apellidos.Text; string facultad = cm_facultad.Text; int telefono = int.Parse(txt_telefono.Text); string correo = txt_correo.Text;

                            SqlConnection conexion = new SqlConnection();
                            conexion.ConnectionString = "data source=DESKTOP-O2EAJ87; database = DB_bibliotecaUDB; integrated security = true";
                            SqlCommand cmd = new SqlCommand();

                            cmd.Connection = conexion;

                            conexion.Open();

                            cmd.CommandText = "insert into Estudiante(Carnet, Nombres, Apellidos, Facultad, Fecha_registro, Numero_teléfono, correo_eléctronico) values('" + carnet + "','" + nombre + "','" + apellidos + "','" + facultad + "',sysdatetime(),'" + telefono + "','" + correo + "')";


                            cmd.ExecuteNonQuery();

                            conexion.Close();
                            MessageBox.Show("¡Estudiante registrado con exito!", "Excelente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            limpiar();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error, este numero de carnet ya esta registrado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txt_carnet.Clear();
                            txt_carnet.Focus();
                        }

                    }
                    else {
                        MessageBox.Show("Formato de carnet incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_carnet.Focus();
                        txt_carnet.Clear();
                    }
                }
                else {
                    MessageBox.Show("Dirección de correo eléctronico de válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_correo.Clear();
                    txt_correo.Focus();
                }

            }
            
        }

        private void Registro_estudiante_Load(object sender, EventArgs e)
        {
            cm_facultad.Items.Clear();
            cm_facultad.Items.Add("Facultad de ingenieria");
            cm_facultad.Items.Add("Facultad de ciencias y humanidades");
            cm_facultad.Items.Add("Facultad de ciencias económicas");
            cm_facultad.Items.Add("Facultad de ciencias de la rehabilitación");
            cm_facultad.Items.Add("Facultad de Aeronáutica");
        }

        private void txt_carnet_KeyPress(object sender, KeyPressEventArgs e)
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

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            menu men = new menu();
            this.Hide();
            men.Show();
        }
    }
}
