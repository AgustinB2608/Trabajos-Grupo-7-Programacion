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

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            lblErrorBusqueda.Text = "";
            lblError.Text = "";
            //Validacion por si se ingresa vacio
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                lblErrorBusqueda.Text = "Por favor, ingrese un Codigo.";
                return;
            }
            //Si la longitud es 4, busca por CODIGO MEDICO
            if (txtBuscar.Text.Length == 4)
            {
                CargarDatosUsuarioPorCodigo();
            }
            //Si no cumple ninguna de las condiciones anteriores, muestra un mensaje de error
            else
            {
                lblErrorBusqueda.Text = "Por favor, ingrese un Codigo de Usuario.";
            }

            txtBuscar.Text = "";
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("InicioAdministrador.aspx");
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

            usuario.setCodUsuario(txtCodigo.Text.ToString());
            usuario.setContrasñea(txtContraseña.Text.ToString());

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

        private void CargarDatosUsuarioPorCodigo()
        {
            NegocioUsuarios negU = new NegocioUsuarios();
            Usuarios reg = new Usuarios();
            if (txtBuscar.Text.Length == 4)
            {
                DataTable usuario = negU.listarUsuarioEspecifico(txtBuscar.Text);

                if (usuario.Rows.Count > 0) //Validad que hayan datos para mostrar
                {
                    reg.CodUsuario = usuario.Rows[0]["CodigoUsuario"].ToString(); //Asigna el codigo del usuario buscado a codUsuario
                    reg.Contraseña = usuario.Rows[0]["Contraseña"].ToString(); //Asigna la contraseña del usuario buscado a contraseña

                    // Asignar valores a los TextBox y ddl
                    txtCodigo.Text = reg.CodUsuario;
                    txtContraseña.Text = reg.Contraseña;


                }
                else
                {
                    // Error
                    lblErrorBusqueda.Text = "No se encontró el Usuario.";
                }
            }
        }

        protected void LimpiarCampos()
        {
            //TextBox
            txtCodigo.Text = "";
            txtContraseña.Text = "";
            lblError.Text = "";
            lblErrorBusqueda.Text = "";

        }

        
    }
}