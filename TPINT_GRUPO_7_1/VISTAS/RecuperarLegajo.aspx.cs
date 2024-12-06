using NEGOCIOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VISTAS
{
    public partial class RecuperarLegajo : System.Web.UI.Page
    {
        NegocioUsuarios negU = new NegocioUsuarios();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRecuperar_Click(object sender, EventArgs e)
        {
            // Obtengo el DNI ingresado por el usuario
            string dni = txtDNI.Text.Trim();

            // Validación para asegurarse de que se ingresó el DNI
            if (string.IsNullOrEmpty(dni))
            {
                lblMensaje.Text = "Por favor, ingrese su DNI.";
                return;
            }

            // LLamo al método para recuperar el legajo desde el servicio
            string legajo = negU.recuperarLegajo(dni);

            if (!string.IsNullOrEmpty(legajo))
            {
                // Si se encuentra el legajo lo muestro
                txtLegajo.Text = legajo;
            }
            else
            {
                // Si no se encuentra muestro un mensaje de error
                lblMensaje.Text = "No se encontró un usuario con el DNI proporcionado.";
            }
        }
    }
}