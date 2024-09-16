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

            string idProducto = txtProducto.Text;
            string filtroProducto = ddlProducto.SelectedValue;

            string idCategoria = txtCategoria.Text;
            string filtroCategoria = ddlCategoria.SelectedValue;

            string consulta = "SELECT * FROM Productos WHERE 1=1"; // 1=1 para simplificar

            // Si se ingresa valor al textbox de producto lo filtro
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

            // Si se ingresa valor al textbox de categoria lo filtro
            if (!string.IsNullOrEmpty(idCategoria))
            {
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

            SqlDataAdapter cmd = new SqlDataAdapter(consulta, cn);
            if (!string.IsNullOrEmpty(idProducto))
            {
                cmd.SelectCommand.Parameters.AddWithValue("@IdProducto", idProducto);
            }
            if (!string.IsNullOrEmpty(idCategoria))
            {
                cmd.SelectCommand.Parameters.AddWithValue("@IdCategoría", idCategoria);
            }    

            cn.Close();

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
