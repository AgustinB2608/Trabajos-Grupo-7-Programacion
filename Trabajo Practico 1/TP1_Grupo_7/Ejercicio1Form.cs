using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TP1_Grupo_7
{
    public partial class Ejercicio1Form : Form
    {
        public Ejercicio1Form()
        {
            InitializeComponent();
        }

        private void btnACEPTAR_Click(object sender, EventArgs e)
        {
            
                // Obtener el texto del TextBox y convertirlo a minúsculas
                string nombre = txtNOMBRE.Text.Trim().ToLower();

                // Validar que el nombre no esté vacío
                if (string.IsNullOrWhiteSpace(nombre))
                {
                    MessageBox.Show("Por favor, ingresa un nombre válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar que el nombre no esté ya en la lista (comparando en minúsculas)
                bool nombreRepetido = lbNombres.Items.Cast<string>().Any(item => item.ToLower() == nombre);

                if (nombreRepetido)
                {
                    MessageBox.Show("El nombre ya ha sido ingresado.", "Nombre duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    lbNombres.Items.Add(txtNOMBRE.Text.Trim()); // Agregar el nombre tal como está en el TextBox
                    txtNOMBRE.Clear(); // Limpiar el TextBox después de agregar
                }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Verificar si hay un ítem seleccionado en el primer ListBox
            if (lbNombres.SelectedItem != null)
            {
                // Obtener el ítem seleccionado
                string nombreSeleccionado = lbNombres.SelectedItem.ToString();

                // Agregar el ítem al segundo ListBox

                if (listBox2.Items.Contains(nombreSeleccionado))
                {
                    MessageBox.Show("El nombre que desea mover ya existente en esta lista", "Atencion");
                }
                else
                {
                    listBox2.Items.Add(nombreSeleccionado);
                }
                // Eliminar el ítem del primer ListBox
                lbNombres.Items.Remove(nombreSeleccionado);
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un ítem de la lista para mover.", "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnPasarTodos_Click(object sender, EventArgs e)
        {
            foreach (string nombres in lbNombres.Items)
            {
                listBox2.Text = nombres;
                if (listBox2.Items.Contains(nombres))
                {
                    MessageBox.Show("El nombre " + nombres + " que desea mover ya existente en esta lista", "Atencion");
                    listBox2.Items.Remove(nombres);
                    listBox2.Items.Add(nombres);

                }
                else
                    listBox2.Items.Add(nombres);
            }
            lbNombres.Items.Clear();
        }

        private void txtNOMBRE_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
