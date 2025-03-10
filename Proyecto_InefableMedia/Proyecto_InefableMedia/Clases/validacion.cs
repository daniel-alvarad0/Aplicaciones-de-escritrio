using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_InefableMedia.Clases
{
    class validacion
    {
        public static void SoloLetras(KeyPressEventArgs V)
        {
            if (char.IsLetter(V.KeyChar))
            {
                V.Handled = false;
            }
            else if (char.IsSeparator(V.KeyChar))
            {
                V.Handled = false;
            }
            else if (char.IsControl(V.KeyChar))
            {
                V.Handled = false;
            }
            else
            {
                V.Handled = true;
                MessageBox.Show("¡Error, solo se admiten letras en este campo!", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public static void SoloNumeros(KeyPressEventArgs V)
        {
            if (char.IsDigit(V.KeyChar))
            {
                V.Handled = false;
            }
          
            else if (char.IsControl(V.KeyChar))
            {
                V.Handled = false;
            }

            else
            {
                V.Handled = true;
                MessageBox.Show("¡Error, solo se admiten números en este campo!", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
