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
        private string ruta = "Data Source=localhost\\SQLEXPRESS02;Initial Catalog=Libreria;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string idTema = Request.QueryString["IdTema"];
                if (!string.IsNullOrEmpty(idTema))
                {
                    CargarLibros(idTema);
                }
            }
        }

        private void CargarLibros(string idTema)
        {
            using (SqlConnection cn = new SqlConnection(ruta))
            {
                cn.Open();

                // modifico la consulta para los valores del pdf
                SqlCommand cmd = new SqlCommand("SELECT IdLibro, IdTema, Titulo, Precio, Autor FROM Libros WHERE IdTema = @IdTema", cn);
                cmd.Parameters.AddWithValue("@IdTema", idTema);

                SqlDataReader dr = cmd.ExecuteReader();
                GvLibros.DataSource = dr;
                GvLibros.DataBind();
            }
        }

        protected void lkbVolver_Click(object sender, EventArgs e)
        {
            //Boton para volver a la pagina anterior y elegir otro tema si se quisiera
            Response.Redirect("Ejercicio3.aspx");
        }
    }
}
