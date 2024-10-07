﻿using System;
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


            Label lblIdProducto = (Label)row.FindControl("lblIdProducto");
            Label lblNombreProducto = (Label)row.FindControl("lblNombreProducto");
            Label lblCantidadPorUnidad = (Label)row.FindControl("lblCantidadPorUnidad");
            Label lblPrecioUnidad = (Label)row.FindControl("lblPrecioUnidad");

            int idProducto = Convert.ToInt32(lblIdProducto.Text);
            string nombreProducto = lblNombreProducto.Text;
            string cantidadPorUnidad = lblCantidadPorUnidad.Text;
            decimal precioUnidad = Convert.ToDecimal(lblPrecioUnidad.Text);

            // Crear un DataTable para almacenar la selección si no existe en la sesión
            DataTable dtProductosSeleccionados;

            if (Session["ProductosSeleccionados"] == null)
            {
                dtProductosSeleccionados = new DataTable();
                dtProductosSeleccionados.Columns.Add("IdProducto", typeof (int));
                dtProductosSeleccionados.Columns.Add("NombreProducto", typeof(string));
                dtProductosSeleccionados.Columns.Add("CantidadPorUnidad", typeof(string));
                dtProductosSeleccionados.Columns.Add("PrecioUnidad", typeof(decimal));
            }
            else
            {
                dtProductosSeleccionados = (DataTable)Session["ProductosSeleccionados"];
            }

            // Verificar si el producto ya está en el DataTable para evitar duplicados
            bool productoYaSeleccionado = dtProductosSeleccionados.AsEnumerable()
                .Any(r => r.Field<int>("IdProducto") == idProducto);

           

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

        protected void gvProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProductos.PageIndex = e.NewPageIndex;
            cargaProductos();
        }
    }
}