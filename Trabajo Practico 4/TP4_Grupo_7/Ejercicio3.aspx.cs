using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP4_Grupo_7
{
    public partial class Ejercicio3 : System.Web.UI.Page
    {
        private String ruta = "Data Source=localhost\\sqlexpress;Initial Catalog=Libreria;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTemas();
            }
        }

        private void CargarTemas()
        {
            SqlConnection cn = new SqlConnection(ruta);
            cn.Open();

            SqlCommand cmd = new SqlCommand("SELECT IdTema, Tema FROM Temas", cn);

            SqlDataReader dr = cmd.ExecuteReader();
          
            
            while (dr.Read())
            {
                string id = dr["IdTema"].ToString();
                string nombre = dr["Tema"].ToString();
                ddlTemas.Items.Add(new ListItem(nombre, id));
            }

        }

        protected void lnkVerLibros_Click(object sender, EventArgs e)
        {
            
        }
    }

}