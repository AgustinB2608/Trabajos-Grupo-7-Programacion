using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP6_GRUPO_7
{
    public partial class MostrarProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarProductosSeleccionados();
            }
        }

        protected void cargarProductosSeleccionados()
        {
            // Verificar si hay productos seleccionados en la sesión
            if (Session["ProductosSeleccionados"] != null)
            {
                DataTable dtProductosSeleccionados = (DataTable)Session["ProductosSeleccionados"];

                if (dtProductosSeleccionados.Rows.Count > 0)
                {
                    GridView1.DataSource = dtProductosSeleccionados;
                    GridView1.DataBind();
                }
                else
                {
                    lblMensaje.Text = "No hay productos seleccionados.";
                }
            }
            else
            {
                lblMensaje.Text = "No se han seleccionado productos.";
            }
        }
    }
}
