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
    public partial class FormularioPrincipal : Form
    {
        public FormularioPrincipal()
        {
            InitializeComponent();
        }

        ///Metodo para mostrar un formulario y ocultar el actual
        private void ShowForm(Form form)
        {
            this.Hide();
            form.FormClosed += (s, args) => this.Show();
            form.Show();
        }
        //Formulario de Ejercicio 1
        private void BtnEjercicio1_Click(object sender, EventArgs e)
        {
            ShowForm(new Ejercicio1Form());
        }
        //Formulario de Ejercicio 2
        private void BtnEjercicio2_Click(object sender, EventArgs e)
        {
            ShowForm(new Ejercicio2Form());
        }
        //Formulario de Ejercicio 3
        private void BtnEjercicio3_Click(object sender, EventArgs e)
        {
            ShowForm(new Ejercicio3Form());
        }
    }
}
