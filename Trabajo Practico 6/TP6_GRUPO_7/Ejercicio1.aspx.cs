using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.EnterpriseServices;

namespace TP6_GRUPO_7
{
    public partial class Ejercicio1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargaProductos();
            }
        }

        protected void cargaProductos()
        {
            try
            {
                Conexion conexion = new Conexion();
                string query = "SELECT * FROM Productos";
                DataTable dt = conexion.EjecutarConsulta(query);

                if (dt != null && dt.Rows.Count > 0)
                {
                    gvProductos.DataSource = dt;
                    gvProductos.DataBind();
                }
                else
                {
                    lblMensaje.Text = "No se encontraron productos.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al cargar productos: " + ex.Message;
            }
        }

        protected void gvProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EventoEdit")
            {
                // Obtener el índice de la fila seleccionada
                int fila = Convert.ToInt32(e.CommandArgument);

                // Obtener los valores de los controles de la fila seleccionada
                string producto = ((Label)gvProductos.Rows[fila].FindControl("lblIdProducto")).Text;
                string nombreProducto = ((Label)gvProductos.Rows[fila].FindControl("lblNombreProducto")).Text;
                string cantPorUnidad = ((Label)gvProductos.Rows[fila].FindControl("lblCantidadPorUnidad")).Text;
                string precioUnidad = ((Label)gvProductos.Rows[fila].FindControl("lblPrecioUnidad")).Text;

                // Mostrar el mensaje con los datos seleccionados
                lblMensaje.Text = $"Usted seleccionó: {producto} / {nombreProducto} / {cantPorUnidad} / {precioUnidad}";
            }
        }

        protected void gvProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // Cambiar la página actual del GridView
            gvProductos.PageIndex = e.NewPageIndex;

            // Volver a cargar los productos para que el GridView se actualice con la nueva página
            cargaProductos();
        }
    }
}
