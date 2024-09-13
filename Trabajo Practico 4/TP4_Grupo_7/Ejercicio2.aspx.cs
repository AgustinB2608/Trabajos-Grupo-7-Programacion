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
        private String rutaNeptunoSQL = "Data Source=localhost\\sqlexpress;Initial Catalog=Neptuno;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                CargarProductos();
            }
        }
           private void CargarProductos()
           { 
            SqlConnection cn = new SqlConnection(rutaNeptunoSQL);
            cn.Open();
            
            SqlCommand cmd = new SqlCommand("Select * From Productos", cn);

            SqlDataReader dr = cmd.ExecuteReader();

            GvProductos.DataSource = dr;
            GvProductos.DataBind();
           }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(rutaNeptunoSQL);
            cn.Open();

            string consulta = "SELECT IdProducto, NombreProducto, IdCategoría, CantidadPorUnidad, PrecioUnidad FROM Productos ";

            string idProducto = txtProducto.Text;
            string filtroProducto = ddlProducto.SelectedValue;

            // Si se ingresa valor al textbox de producto lo filtro
            if (!string.IsNullOrEmpty(idProducto))
            {
                switch (filtroProducto)
                {
                    case "1":  // Igual a
                        consulta += " AND idProducto = @IdProducto";
                        break;
                    case "2":  // Mayor a
                        consulta += " AND idProducto > @IdProducto";
                        break;
                    case "3": // Menor a
                        consulta += " AND idProducto < @IdProducto";
                        break;
                }
       
                    GvProductos.DataSource = consulta;
                    GvProductos.DataBind();
            }
           
            
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
