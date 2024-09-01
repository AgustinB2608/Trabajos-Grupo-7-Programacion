using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP1_Grupo_7
{
    public partial class Ejercicio3Form : Form
    {
        public Ejercicio3Form()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Inicializa el texto del label
            lblMostrar.Text = "";
            lblMostrar.Text = "Usted seleccionó los siguientes elementos: ";

            // Verifica qué radio button está seleccionado en el grupo "Sexo"
            if (radioButton1.Checked)
            {
                lblMostrar.Text += "\n" + "Sexo: " + radioButton1.Text;
            }
            else if (radioButton2.Checked)
            {
                lblMostrar.Text += "\n" + "Sexo: "+ radioButton2.Text;
            }

            // Verifica qué radio button está seleccionado en el grupo "Estado Civil"
            if (radioButton3.Checked)
            {
                lblMostrar.Text += "\n" + "Estado civil: " + radioButton3.Text;
            }
            else if (radioButton4.Checked)
            {
                lblMostrar.Text += "\n" + "Estado civil: " + radioButton4.Text;
            }

            // Añade los elementos seleccionados del checkedListBox
            lblMostrar.Text += "\nOficio:";
            foreach (object item in checkedListBox1.CheckedItems)
            {
                lblMostrar.Text += "\n" + "  -" + item.ToString();
            }
        }


        private void Ejercicio3Form_Load(object sender, EventArgs e)
        {

        }
    }
}
