using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VISTAS
{
    public partial class RealizarInformes : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioLegajo"] != null && Session["UsuarioTipo"] != null && Session["UsuarioTipo"].ToString() == "A")
            {
                string nombre = Session["UsuarioNombre"].ToString(); // Nombre
                string apellido = Session["UsuarioApellido"].ToString(); // Apellido
                string tipoUsuario = Session["UsuarioTipo"].ToString(); // Tipo de usuario

                lblUsuario.Text = $"{nombre} {apellido}";
            }
            else
            {
                Response.Redirect("InicioLogin.aspx"); // Redirigir si no es un administrador logueado
            }

        }

    }
}