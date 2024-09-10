using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace TP4_Grupo_7
{
    public partial class Ejercicio1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                SqlConnection cn = new SqlConnection("Data Source=localhost\\sqlexpress;Initial Catalog=Viajes;Integrated Security=True");

                cn.Open();

                SqlDataAdapter adapt = new SqlDataAdapter("Select * From Provincias", cn); 

                DataSet ds = new DataSet();
                adapt.Fill(ds, "TablaProvincias");

                ddlProvincias.DataSource = ds.Tables[0]; // 0 = TablaProvincias
                ddlProvincias.DataTextField = "NombreProvincia";
                ddlProvincias.DataValueField = "idProvincia";

                ddlProvincias.DataBind();

                cn.Close();
            }   
        }
    }
}