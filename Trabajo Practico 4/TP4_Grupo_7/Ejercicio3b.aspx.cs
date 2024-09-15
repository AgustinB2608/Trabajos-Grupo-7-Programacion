using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP4_Grupo_7
{
    public partial class Ejercicio3b : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string IdTema = Request.QueryString["IdTema"];
                MostrarLibros(IdTema);
            }
        }
        private void MostrarLibros(string IdTema) { 
            //CONECTAR A LA BASE DE DATOS SELECCIONAR * DONDE IdTema = @IdTema y mostrarlo
        }
        protected void lkbVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ejercicio3.aspx");
        }
    }
}