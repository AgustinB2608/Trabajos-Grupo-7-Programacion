﻿using System;
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
        private NegocioUsuarios regU = new NegocioUsuarios();

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string legajo = txtLegajo.Text;
            string contraseña = txtContraseña.Text;
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;

            bool resultado = regU.RegistrarUsuario(legajo, contraseña, nombre, apellido);

            lblMensaje1.Visible = true;
            lblMensaje2.Visible = true;
            if (resultado)
            {
                lblMensaje1.Text = "Usuario registrado exitosamente.";
            }
            else
            {
                lblMensaje2.CssClass = "mensaje-error";
            }
        }
    }
}