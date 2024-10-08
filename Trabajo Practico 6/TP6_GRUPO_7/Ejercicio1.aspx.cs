using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            gvProductos.PageIndex = e.NewPageIndex;
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
            SqlParameter[] parametros = new SqlParameter[] { new SqlParameter("@IdProducto", idProducto) };

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

        private void ActualizarProducto(int idProducto, string nombreProducto, string cantPorUnidad, decimal precioUnidad)
        {
            Conexion conexion = new Conexion();
            string consultaSQL = "UPDATE Productos SET NombreProducto = @NombreProducto, CantidadPorUnidad = @CantidadPorUnidad, PrecioUnidad = @PrecioUnidad WHERE IdProducto = @IdProducto";
            SqlParameter[] parametros = new SqlParameter[] {
                new SqlParameter("@IdProducto", idProducto),
                new SqlParameter("@NombreProducto", nombreProducto),
                new SqlParameter("@CantidadPorUnidad", cantPorUnidad),
                new SqlParameter("@PrecioUnidad", precioUnidad)
            };

            int filasAfectadas = conexion.EjecutarConsultaSinRetorno(consultaSQL, parametros);

            if (filasAfectadas > 0)
            {
                lblMensaje.Text = "Producto actualizado correctamente.";
            }
            else
            {
                lblMensaje.Text = "No se encontró el producto para actualizar.";
            }
        }

        protected void gvProductos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                // Obtener el ID del producto de los DataKeys
                int idProducto = Convert.ToInt32(gvProductos.DataKeys[e.RowIndex].Value);

                // Obtener los controles
                TextBox txtNombreProducto = (TextBox)gvProductos.Rows[e.RowIndex].FindControl("txt_eit_NombreProducto");
                TextBox txtCantidadPorUnidad = (TextBox)gvProductos.Rows[e.RowIndex].FindControl("txt_eit_CantidadPorUnidad");
                TextBox txtPrecioUnidad = (TextBox)gvProductos.Rows[e.RowIndex].FindControl("txt_eit_PrecioUnidad");

                if (txtNombreProducto != null && txtPrecioUnidad != null && txtCantidadPorUnidad != null)
                {
                    string nombreProducto = txtNombreProducto.Text;
                    string cantPorUnidad = txtCantidadPorUnidad.Text;

                    if (decimal.TryParse(txtPrecioUnidad.Text, out decimal precioUnidad))
                    {
                        // Actualizar el producto
                        ActualizarProducto(idProducto, nombreProducto, cantPorUnidad, precioUnidad);
                    }
                    else
                    {
                        lblMensaje.Text = "El precio debe ser un número válido.";
                        return;
                    }
                }
                else
                {
                    lblMensaje.Text = "No se pudieron encontrar todos los controles necesarios.";
                    return;
                }

                gvProductos.EditIndex = -1;
                CargarDatos();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al actualizar el producto: " + ex.Message;
            }
        }
    }
}
