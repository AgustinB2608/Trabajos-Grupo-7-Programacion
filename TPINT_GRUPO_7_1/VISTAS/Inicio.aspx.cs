using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VISTAS
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Verificar si el usuario está logueado y traer los datos de la session
            if (Session["UsuarioLegajo"] != null && Session["UsuarioTipo"] != null)
            {
                string legajo = Session["UsuarioLegajo"].ToString();//Legajo
                string nombre = Session["UsuarioNombre"].ToString();//Nombre
                string apellido = Session["UsuarioApellido"].ToString();//Apellido
                string tipoUsuario = Session["UsuarioTipo"].ToString();//Tipo de usuario

                //lblInicio.Text = $"Bienvenido {nombre} {apellido} {tipoUsuario}";
            }
            else
            {
                // Si la session es null o sea no hay nadie registrado devolver al Login.
                Response.Redirect("InicioLogin.aspx");
            }
        }


    }
}