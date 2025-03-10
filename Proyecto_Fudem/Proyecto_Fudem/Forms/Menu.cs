using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto_InefableMedia.Clases;
using System.Data.SqlClient;

namespace Proyecto_InefableMedia.Forms
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Estas seguro que quieres cerrar sesión?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes) {
                login log = new login();
                this.Hide();
                log.Show();
            }
        }

        private void btn_clientes_Click(object sender, EventArgs e)
        {
            
        }
   
        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void btn_inventario_Click(object sender, EventArgs e)
        {
            // new registro_inventario().ShowDialog();
            registro_inventario inventario = new registro_inventario();
            this.Hide();
            inventario.Show();
        }

        private void btn_proveedor_Click(object sender, EventArgs e)
        {
        
        }

        private void btn_producto_Click(object sender, EventArgs e)
        {
            Registro_productos producto = new Registro_productos();
            this.Hide();
            producto.Show();
           // new Registro_productos().ShowDialog();
        }

        private void btn_venta_Click(object sender, EventArgs e)
        {
            Facturacion fac = new Facturacion();
            this.Hide();
            fac.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }
    }
}
