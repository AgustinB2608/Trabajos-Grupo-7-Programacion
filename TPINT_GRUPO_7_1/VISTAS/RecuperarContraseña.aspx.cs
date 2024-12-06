using NEGOCIOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VISTAS
{
    public partial class RecuperarContraseña : System.Web.UI.Page
    {
        NegocioUsuarios negU = new NegocioUsuarios();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRecuperar_Click(object sender, EventArgs e)
        {
            // Obtener valores ingresados por el usuario
            string dni = txtDNI.Text.Trim();
            string legajo = txtLegajo.Text.Trim();

            // Validar campos
            if (string.IsNullOrEmpty(dni) || string.IsNullOrEmpty(legajo))
            {
                lblMensaje.Text = "Por favor, complete ambos campos.";
                return;
            }

            if(txtDNI.Text.Length > 11)
            {
                lblMensaje.Text = "El dni tiene que tener 11 digitos";
            }

            // Llamar al servicio para recuperar la contraseña
            string contrasena = negU.recuperarContraseñaMedico(dni, legajo);

            if (!string.IsNullOrEmpty(contrasena))
            {
                // Mostrar la contraseña en el campo de texto
                txtContrasenaRecuperada.Text = contrasena;
                lblMensaje.Text = "Contraseña recuperada con éxito.";
            }
            else
            {
                // Mostrar un mensaje de error si no se encuentra
                lblMensaje.Text = "No se encontró un médico con los datos proporcionados.";
            }

            limpiarCampos();
        }
        void limpiarCampos()
        {
            txtDNI.Text = "";
            txtLegajo.Text = "";
        }
    }
}