using System;
using NEGOCIO; 
using ENTIDADES; 

namespace VISTAS
{
    public partial class InicioLogin : System.Web.UI.Page
    {
        // Instancia de la clase de negocio
        private LoginNegocio loginNegocio;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Crear una instancia del negocio al cargar la página
            loginNegocio = new LoginNegocio();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Guardar los datos ingresados
            string legajo = txtLegajo.Text.Trim();
            string contrasena = txtPassword.Text.Trim();

            // Validacion de campos vacíos
            if (string.IsNullOrEmpty(legajo) || string.IsNullOrEmpty(contrasena))
            {
                lblError.Text = "Por favor ingrese su legajo y contraseña."; // Mostrar error
                return;
            }


            // Validar que el legajo tenga un máximo de 4 dígitos
            if (legajo.Length > 4)
            {
                lblError.Text = "El legajo no puede tener más de 4 dígitos."; // Mostrar error
                return;
            }

            // Validar los datos ingresados
            Login usuario = loginNegocio.ValidarLogin(legajo, contrasena);

            // Si las credenciales son correctas y se encontró un usuario
            if (usuario != null)
            {

                Session["UsuarioLegajo"] = usuario.Legajo;
                Session["UsuarioTipo"] = usuario.TipoUsuario;
                Session["UsuarioNombre"] = usuario.Nombre;
                Session["UsuarioApellido"] = usuario.Apellido;

                // Dependiendo del tipo de usuario, redirigir a la página correspondiente
                if (usuario.TipoUsuario == "A")
                {
                    // Redirigir a la página de administrador
                    Response.Redirect("InicioAdministrador.aspx");
                }
                else if (usuario.TipoUsuario == "M")
                {
                    // Redirigir a la página de médico
                    Response.Redirect("InicioMedico.aspx");
                }
            }
            else
            {
                // Si las credenciales son incorrectas
                lblError.Text = "Datos incorrectos. Por favor, intente nuevamente."; // Mostrar error
            }
        }
    }
}
