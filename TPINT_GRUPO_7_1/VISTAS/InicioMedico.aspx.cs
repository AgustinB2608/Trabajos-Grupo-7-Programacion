using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENTIDADES;
using NEGOCIOS;

namespace VISTAS
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Verificar si el usuario está logueado y traer los datos de la sesión
            if (Session["UsuarioLegajo"] != null && Session["UsuarioTipo"] != null)
            {
                string legajo = Session["UsuarioLegajo"].ToString(); // Legajo
                string nombre = Session["UsuarioNombre"].ToString(); // Nombre
                string apellido = Session["UsuarioApellido"].ToString(); // Apellido
                string tipoUsuario = Session["UsuarioTipo"].ToString(); // Tipo de usuario

                if (!string.IsNullOrEmpty(nombre) && !string.IsNullOrEmpty(apellido))
                {
                    lblInicio.Text = $"Bienvenido {nombre} {apellido} ({tipoUsuario})";
                }
                else
                {
                    lblInicio.Text = "Bienvenido, usuario desconocido.";
                }
            }
            else
            {
                Response.Redirect("InicioLogin.aspx");
            }
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear(); // Elimina todos los elementos de la sesión actual
            Session.Abandon(); // Marca la sesión como abandonada y lista para eliminación

            // Redirige al usuario a la página de inicio de sesión
            Response.Redirect("InicioLogin.aspx");
        }
    }
}