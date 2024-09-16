using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace TP4_Grupo_7
{
    public partial class Ejercicio3b : System.Web.UI.Page
    {
        private String rutaLibreriaSQL = "Data Source=localhost\\sqlexpress;Initial Catalog=Libreria;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string IdTema = Request.QueryString["IdTema"];
                MostrarLibros(IdTema);
            }
        }
        private void MostrarLibros(string IdTema) {
            SqlConnection cn = new SqlConnection(rutaLibreriaSQL);
            cn.Open();

            string consulta = "SELECT * FROM Libros";

            SqlCommand cmd = new SqlCommand(consulta, cn);

            SqlDataReader dr = cmd.ExecuteReader();

            GvLibros.DataSource = dr;
            GvLibros.DataBind();
        }
        protected void lkbVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ejercicio3.aspx");
        }
    }
}