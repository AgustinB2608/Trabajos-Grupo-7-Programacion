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
                lblMensaje.Text = "Este es un mensaje de prueba";
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

        protected void gvProductos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
           
            Label lblIdProducto = (Label)gvProductos.Rows[e.RowIndex].FindControl("lblIdProducto");

            if (lblIdProducto != null)
            {
               
                int idProducto = Convert.ToInt32(lblIdProducto.Text);

                
                EliminarProdBaseDeDatos(idProducto);

                
                CargarDatos();
            }
        }

      
        private void EliminarProdBaseDeDatos(int idProducto)
        {
            
            Conexion conexion = new Conexion();
            string consultaSQL = "DELETE FROM Productos WHERE IdProducto = @IdProducto";

            // Creo el parámetro necesario para el comando SQL
            SqlParameter[] parametros = new SqlParameter[]
            {
        new SqlParameter("@IdProducto", idProducto)
            };

           
             
                int filasAfectadas = conexion.EjecutarConsultaSinRetorno(consultaSQL, parametros);

                if (filasAfectadas > 0)
                {
                    lblMensaje.Text = "Producto eliminado correctamente.";
                }
                else
                {
                    lblMensaje.Text = "No se encontró el producto para eliminar.";
                }
            
            
        }

        // Cargo de nuevo los datos en la gridview
        private void CargarDatos()
        {
            Conexion conexion = new Conexion();
            DataTable dtProductos = conexion.EjecutarConsulta("SELECT * FROM Productos");
            gvProductos.DataSource = dtProductos;
            gvProductos.DataBind();
        }

        protected void gvProductos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvProductos.EditIndex = e.NewEditIndex;
            CargarDatos();
        }

        protected void gvProductos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvProductos.EditIndex = -1;
            CargarDatos();
        }
    }
}
