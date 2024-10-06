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

        protected void gvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            GridViewRow row = gvProductos.SelectedRow;

            // Extraer información del producto
            string idProducto = row.Cells[1].Text; 
            string nombreProducto = row.Cells[2].Text; 
            string cantidadPorUnidad = row.Cells[3].Text;
            string precioUnidad = row.Cells[4].Text; 

            // Crear un DataTable para almacenar la selección si no existe en la sesión
            DataTable dtProductosSeleccionados;
            if (Session["ProductosSeleccionados"] == null)
            {
                dtProductosSeleccionados = new DataTable();
                dtProductosSeleccionados.Columns.Add("IdProducto");
                dtProductosSeleccionados.Columns.Add("NombreProducto");
                dtProductosSeleccionados.Columns.Add("CantidadPorUnidad");
                dtProductosSeleccionados.Columns.Add("PrecioUnidad");
            }
            else
            {
                dtProductosSeleccionados = (DataTable)Session["ProductosSeleccionados"];
            }

            // Verificar si el producto ya está en el DataTable para evitar duplicados
            bool productoYaSeleccionado = dtProductosSeleccionados.AsEnumerable()
                .Any(r => r.Field<string>("IdProducto") == idProducto);

            if (!productoYaSeleccionado)
            {
                // Añadir la selección al DataTable
                DataRow dr = dtProductosSeleccionados.NewRow();
                dr["IdProducto"] = idProducto;
                dr["NombreProducto"] = nombreProducto;
                dr["CantidadPorUnidad"] = cantidadPorUnidad;
                dr["PrecioUnidad"] = precioUnidad;
                dtProductosSeleccionados.Rows.Add(dr);

                // Guardar el DataTable en la sesión
                Session["ProductosSeleccionados"] = dtProductosSeleccionados;

                lblMensaje.Text = "Producto agregado: " + nombreProducto;
            }
            else
            {
                lblMensaje.Text = "El producto ya ha sido seleccionado.";
            }
        }
    }
}