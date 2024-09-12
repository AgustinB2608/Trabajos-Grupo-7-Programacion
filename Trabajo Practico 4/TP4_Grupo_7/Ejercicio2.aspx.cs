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
                CargarProducto();
            }
        }
           private void CargarProducto()
            {
            /*
                SqlConnection cn = new SqlConnection(rutaNeptunoSQL);
                cn.Open();

                SqlDataAdapter adapt = new SqlDataAdapter("Select IdProducto, NombreProducto From Productos", cn);
                DataSet ds = new DataSet();
                adapt.Fill(ds,"Productos");

            ddlProducto.DataSource = ds.Tables[0];
            ddlProducto.DataTextField = "NombreProducto";
            ddlProducto.DataValueField = "IdProducto";
            ddlProducto.DataBind();
            ddlProducto.Items.Insert(0, new ListItem("--Seleccionar--")); 
            */
        }
        }
    }
