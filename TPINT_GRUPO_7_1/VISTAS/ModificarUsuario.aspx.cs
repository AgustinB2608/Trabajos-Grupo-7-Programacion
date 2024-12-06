using ENTIDADES;
using NEGOCIOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VISTAS
{
    public partial class ModificarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Verificar si el usuario está logueado y traer los datos de la sesión (Administrador)
            if (Session["UsuarioLegajo"] != null && Session["UsuarioTipo"] != null && Session["UsuarioTipo"].ToString() == "A")
            {
                string nombre = Session["UsuarioNombre"].ToString(); // Nombre
                string apellido = Session["UsuarioApellido"].ToString(); // Apellido
                string tipoUsuario = Session["UsuarioTipo"].ToString(); // Tipo de usuario

                lblUsuario.Text = $"{nombre} {apellido} {tipoUsuario}";
            }
            else
            {
                Response.Redirect("InicioLogin.aspx"); // Redirigir si no es un administrador logueado
            }

            if (!IsPostBack)
            {
                // Validar si hay un código de médico en la sesión
                if (Session["CodMedico"] != null)
                {
                    string Legajo = Session["CodMedico"].ToString();
                    txtCodigo.Text = Legajo; // Prellenar el campo con el valor de la sesión
                    txtCodigo.Enabled = false; // Evitar que se modifique
                }
                else
                {
                    lblError.Visible = true;
                    lblError.CssClass = "mensaje-error";
                    lblError.Text = "No se encontró un legajo en la sesión. ";
                    btnAceptar.Enabled = false; // Deshabilitar el botón si no hay legajo
                    
                }
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            //Validacion por si se ingresa vacio
            if (string.IsNullOrWhiteSpace(txtContraseña.Text))
            {
                lblError.Text = "Por favor, complete todos los campos.";
                return;
            }

            NegocioUsuarios negU = new NegocioUsuarios();
            Usuarios usuario = new Usuarios();

            usuario.setLegajo(txtCodigo.Text.ToString());
            usuario.setContraseña(txtContraseña.Text.ToString());

            if (negU.modificarUsuario(usuario))
            {

                lblExito.Text = "Usuario modificado correctamente.";
                LimpiarCampos();
            }
            else
            {

                lblError.Text = "Error al modificar Usuario. ";
            }
        }


        protected void LimpiarCampos()
        {
            //TextBox
            txtCodigo.Text = "";
            txtContraseña.Text = "";
            lblError.Text = "";

        }

        protected void btnVolverAtras_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModificarMedico.aspx");
        }
    }
}