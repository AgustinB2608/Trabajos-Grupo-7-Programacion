using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace TP1_Grupo_7
{
    public partial class Ejercicio2Form : Form
    {
        public Ejercicio2Form()
        {
            InitializeComponent();
        }

        private void GpbNombreYApellido_Enter(object sender, EventArgs e)
        {

        }

        private void TxtNombre_TextChanged(object sender, EventArgs e)
        {
          
        }

        private HashSet<string> nombresSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            // Combina nombre y apellido en una sola cadena
            string nombreCompleto = $"{TxtNombre.Text.Trim()} {TxtApellido.Text.Trim()}";

            // Validar que ambos campos no estén vacíos
            if (string.IsNullOrWhiteSpace(TxtNombre.Text) || string.IsNullOrWhiteSpace(TxtApellido.Text))
            {
                MessageBox.Show("Debe ingresar nombre y apellido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Salir del método si los campos están vacíos
            }

            // Verificar si el nombre completo ya está en el HashSet
            if (nombresSet.Contains(nombreCompleto))
            {
                MessageBox.Show("No se puede agregar nombres repetidos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Agregar el nombre completo a la lista y al HashSet
                listBox1.Items.Add(nombreCompleto);
                nombresSet.Add(nombreCompleto);
            }

            // Limpiar los campos de texto
            TxtNombre.Clear();
            TxtApellido.Clear();
        }



        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            // Verifica si hay un elemento seleccionado en el ListBox
            if (listBox1.SelectedItem != null)
            {
                // Elimina el elemento seleccionado del ListBox
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
            else
            {
                // Muestra un mensaje de advertencia si no se ha seleccionado ningún elemento
                MessageBox.Show("Debe seleccionar un elemento para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
