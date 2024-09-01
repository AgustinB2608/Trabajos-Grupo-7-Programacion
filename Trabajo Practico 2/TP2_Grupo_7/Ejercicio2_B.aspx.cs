using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP2_Grupo_7
{
    public partial class Ejercicio2_B : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Obtener los controles del primer formulario
                TextBox txtNombre = (TextBox)PreviousPage.FindControl("TextBox1");
                TextBox txtApellido = (TextBox)PreviousPage.FindControl("TextBox2");
                DropDownList ddlCiudad = (DropDownList)PreviousPage.FindControl("ddlCiudades");
                CheckBoxList cblTemas = (CheckBoxList)PreviousPage.FindControl("cblTemas");

                if (txtNombre != null && txtApellido != null && ddlCiudad != null && cblTemas != null)
                {
                    lblNombre.Text = txtNombre.Text;
                    lblApellido.Text = txtApellido.Text;

                    // Mostrar el valor de la zona seleccionada
                    lblResumen.Text = ddlCiudad.SelectedValue;

                    // Mostrar los temas marcados en la dropdownlist
                    // 
                    string temasSeleccionados = string.Join("<br />", cblTemas.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Text));
                    lblTemas.Text = temasSeleccionados;

                }
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            // Redirigir de vuelta al primer formulario
            Response.Redirect("Ejercicio2_A.aspx");
        }
    }
}
