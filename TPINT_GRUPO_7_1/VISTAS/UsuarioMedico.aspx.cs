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

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            // Obtener datos del formulario
            string contraseña = txtContraseña.Text.Trim();
            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string tipousuario = "M";
            string codmedico = txtCodigoMedico.Text.Trim();

            lblMensaje1.Visible = true;
            lblMensaje2.Visible = true;

            // Validación de campos
            if (string.IsNullOrWhiteSpace(contraseña) || string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido))
            {
                lblMensaje2.CssClass = "mensaje-error";
                lblMensaje2.Text = "Todos los campos son obligatorios.";
                return;
            }

            // Llamada a la capa de negocio
            NegocioUsuarios negocioUsuarios = new NegocioUsuarios();
            bool resultado = negocioUsuarios.RegistrarUsuario(contraseña, tipousuario, codmedico, nombre, apellido);

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