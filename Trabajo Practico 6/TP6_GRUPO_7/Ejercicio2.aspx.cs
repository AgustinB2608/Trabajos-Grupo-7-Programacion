using System;
using System.Web.UI;

namespace TP6_GRUPO_7
{
    public partial class Ejercicio2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void LBEliminar_Click(object sender, EventArgs e)
        {
            // Eliminar los productos seleccionados de la sesión
            Session["ProductosSeleccionados"] = null;

            // Mostrar mensaje de confirmación
            lblMensaje.Text = "Productos seleccionados eliminados exitosamente.";
        }
    }
}
