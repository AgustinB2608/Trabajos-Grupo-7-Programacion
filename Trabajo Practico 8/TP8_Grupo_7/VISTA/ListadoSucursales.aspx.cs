using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using NEGOCIO;

namespace VISTA
{
    public partial class ListadoSucursales : System.Web.UI.Page
    {
        private NegocioSucursal negocioSucursal = new NegocioSucursal(); // Instancia global

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarSucursales();
            }
        }

        // Método para cargar las sucursales
        private void CargarSucursales()
        {
            try
            {
                DataTable dt = negocioSucursal.getTabla();
                grvSucursales.DataSource = dt;
                grvSucursales.DataBind();
                lblMensaje.Text = dt.Rows.Count > 0
                    ? ""
                    : "No se encontraron sucursales.";
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Ocurrió un error al cargar las sucursales.";
                // Log del error si es necesario: Console.WriteLine(ex.Message);
            }
        }

        // Evento del botón "Filtrar"
        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSucursal.Text))
            {
                lblMensaje.Text = "Por favor, ingrese un ID de sucursal.";
                return;
            }

            if (int.TryParse(txtSucursal.Text, out int sucursalId))
            {
                try
                {
                    DataTable dt = negocioSucursal.getSucursalPorId(sucursalId);
                    grvSucursales.DataSource = dt;
                    grvSucursales.DataBind();

                    lblMensaje.Text = dt.Rows.Count > 0
                        ? ""
                        : "No se encontraron sucursales con ese ID.";
                }
                catch (Exception ex)
                {
                    lblMensaje.Text = "Ocurrió un error al filtrar la sucursal.";
                    // Log del error: Console.WriteLine(ex.Message);
                }
            }
            else
            {
                lblMensaje.Text = "El ID ingresado debe ser un número entero.";
            }
        }

        // Evento del botón "Mostrar Todos"
        protected void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            CargarSucursales();
        }
    }
}
