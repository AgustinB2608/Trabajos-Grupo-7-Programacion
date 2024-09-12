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

            GvProductos.DataSource =dr;
            GvProductos.DataBind();

        }
    }
    }
