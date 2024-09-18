using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace TP4_Grupo_7
{
    public partial class Ejercicio2 : System.Web.UI.Page
    {
        private String rutaNeptunoSQL = "Data Source=localhost\\SQLEXPRESS02;Initial Catalog=Neptuno;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                CargarProductos();
                
            }
        }
        private void CargarProductos()
        {
            using (SqlConnection cn = new SqlConnection(rutaNeptunoSQL))
            {
                cn.Open();
                string consulta = "SELECT IdProducto, NombreProducto, IdCategoría, CantidadPorUnidad, PrecioUnidad FROM Productos";

                using (SqlCommand cmd = new SqlCommand(consulta, cn))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        GvProductos.DataSource = dr;
                        GvProductos.DataBind();
                    }
                }
            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            string idProducto = txtProducto.Text;
            string filtroProducto = ddlProducto.SelectedValue;
            string idCategoria = txtCategoria.Text;
            string filtroCategoria = ddlCategoria.SelectedValue;

            // Ajustar consulta para solo seleccionar columnas necesarias
            string consulta = "SELECT IdProducto, NombreProducto, IdCategoría, CantidadPorUnidad, PrecioUnidad FROM Productos WHERE 1=1"; 

            // Añadir filtros a la consulta según los valores ingresados
            if (!string.IsNullOrEmpty(idProducto))
            {
                switch (filtroProducto)
                {
                    case "1":  // Igual a
                        consulta += " AND IdProducto = @IdProducto";
                        break;
                    case "2":  // Mayor a
                        consulta += " AND IdProducto > @IdProducto";
                        break;
                    case "3":  // Menor a
                        consulta += " AND IdProducto < @IdProducto";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(idCategoria))
            {
                if (!consulta.Contains("WHERE"))
                {
                    consulta += " WHERE 1=1"; 
                }
                switch (filtroCategoria)
                {
                    case "1":  // Igual a
                        consulta += " AND IdCategoría = @IdCategoría";
                        break;
                    case "2":  // Mayor a
                        consulta += " AND IdCategoría > @IdCategoría";
                        break;
                    case "3":  // Menor a
                        consulta += " AND IdCategoría < @IdCategoría";
                        break;
                }
            }

            using (SqlConnection cn = new SqlConnection(rutaNeptunoSQL))
            {
                using (SqlDataAdapter cmd = new SqlDataAdapter(consulta, cn))
                {
                    if (!string.IsNullOrEmpty(idProducto))
                    {
                        cmd.SelectCommand.Parameters.AddWithValue("@IdProducto", idProducto);
                    }
                    if (!string.IsNullOrEmpty(idCategoria))
                    {
                        cmd.SelectCommand.Parameters.AddWithValue("@IdCategoría", idCategoria);
                    }

                    DataSet ds = new DataSet();
                    cmd.Fill(ds, "Productos");
                    GvProductos.DataSource = ds;
                    GvProductos.DataBind();
                }
            }

            // Limpiar los TextBox después de filtrar
            txtProducto.Text = "";
            txtCategoria.Text = "";
        }




        protected void btnQuitar_Click(object sender, EventArgs e)
        {
                // Limpiao los campos
                txtProducto.Text = "";
                txtCategoria.Text = "";
                ddlCategoria.SelectedIndex = 0;
                ddlProducto.SelectedIndex = 0;

                // cargamos prod
                CargarProductos();
            
        }

    }
}
