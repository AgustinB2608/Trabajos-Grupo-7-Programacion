using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
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

                if (dt != null)
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
                int fila = Convert.ToInt32(e.CommandArgument);

                string producto = ((Label)gvProductos.Rows[fila].FindControl("lblIdProducto")).Text;
                string nombreProducto = ((Label)gvProductos.Rows[fila].FindControl("lblNombreProducto")).Text;
                string CantPorUnidad = ((Label)gvProductos.Rows[fila].FindControl("lblCantidadPorUnidad")).Text;
                string PrecioUnidad = ((Label)gvProductos.Rows[fila].FindControl("lblPrecioUnidad")).Text;

                lblMensaje.Text = "usted selecciono: " + producto + " / " + nombreProducto + " / " + CantPorUnidad + " / " + PrecioUnidad;
            }
        }
    }
}