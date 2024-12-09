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
    public partial class UsuarioMedico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
              /*  if (Session["CodMedico"] != null)
                {
                    string codmedico = Session["CodMedico"].ToString();
                    txtCodigoMedico.Text = codmedico; // Prellenar el campo con el valor de la sesión
                    txtCodigoMedico.Enabled = false; // Evitar que se modifique

                    if (Session["Nombre"] != null)
                    {
                        txtNombre.Text = Session["Nombre"].ToString();
                        txtNombre.Enabled = false;
                    }

                    if (Session["Apellido"] != null)
                    {
                        txtApellido.Text = Session["Apellido"].ToString();
                        txtApellido.Enabled = false;
                    }
                }
                else
                {
                    lblMensaje2.Visible = true;
                    lblMensaje2.CssClass = "mensaje-error";
                    lblMensaje2.Text = "No se encontró un código de médico en la sesión.";
                    btnGuardar.Enabled = false; // Deshabilitar el botón si no hay código
                }
              */
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string codmedico = txtCodigoMedico.Text.Trim();
            string contraseña = txtContraseña.Text.Trim();
            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();

            lblMensaje1.Visible = true;
            lblMensaje2.Visible = true;

            // Validación de campos
            if (string.IsNullOrWhiteSpace(contraseña))
            {
                lblMensaje2.CssClass = "mensaje-error";
                lblMensaje2.Text = "Todos los campos son obligatorios.";
                return;
            }

            // Llamada a la capa de negocio
            NegocioUsuarios negocioUsuarios = new NegocioUsuarios();
            bool resultado = negocioUsuarios.InsertarUsuario(codmedico, nombre, apellido, contraseña);

            // Mensajes de retroalimentación
            if (resultado)
            {
                lblMensaje1.Text = "Usuario registrado exitosamente.";
                lblMensaje2.Visible = false;
            }
            else
            {
                lblMensaje2.CssClass = "mensaje-error";
                lblMensaje2.Text = "Error al registrar el usuario. Intenta nuevamente.";
            }
        }


    }
}