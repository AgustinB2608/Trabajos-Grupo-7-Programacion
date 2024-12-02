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
            if (!IsPostBack)
            {
                // Validar si hay un código de médico en la sesión
                if (Session["CodMedico"] != null)
                {
                    string codmedico = Session["CodMedico"].ToString();
                    txtCodigoMedico.Text = codmedico; // Prellenar el campo con el valor de la sesión
                    txtCodigoMedico.Enabled = false; // Evitar que se modifique
                }
                else
                {
                    lblMensaje2.Visible = true;
                    lblMensaje2.CssClass = "mensaje-error";
                    lblMensaje2.Text = "No se encontró un código de médico en la sesión.";
                    btnGuardar.Enabled = false; // Deshabilitar el botón si no hay código
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string codmedico = txtCodigoMedico.Text.Trim();
            string contraseña = txtContraseña.Text.Trim();

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
            bool resultado = negocioUsuarios.RegistrarUsuario(contraseña, codmedico);

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