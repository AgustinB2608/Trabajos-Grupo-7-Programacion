using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP6_GRUPO_7
{
    public partial class SeleccionarProductos : System.Web.UI.Page
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
                string query = "SELECT IdProducto, NombreProducto, CantidadPorUnidad, PrecioUnidad FROM Productos";
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

    }
}