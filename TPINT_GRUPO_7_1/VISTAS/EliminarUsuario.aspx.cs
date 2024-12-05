using NEGOCIOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VISTAS
{
    public partial class EliminarUsuario : System.Web.UI.Page
    {
        NegocioUsuarios negU = new NegocioUsuarios();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string eliminarUsuario = txtCodigo.Text;

            // eliminar al médico
            bool exito = negU.eliminarUsuario(eliminarUsuario);

            if (exito)
            {
                // Si la eliminación fue exitosa
                lblMensaje.Text = "El usuario médico ha sido eliminado con éxito.";
                lblMensaje2.Text = string.Empty;

                // Limpiar el campo de texto
                txtCodigo.Text = string.Empty;
            }
            else
            {
                lblMensaje.Text = "No se pudo eliminar el usuario médico. Intente nuevamente.";
            }

        }
    }
}