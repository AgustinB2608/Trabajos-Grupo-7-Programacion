using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NEGOCIOS;
using ENTIDADES;
using System.Data;

namespace VISTAS
{
    public partial class EliminarPaciente : System.Web.UI.Page
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
            btnConfirmarEliminar.Visible = false;
        }



        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            NegocioPacientes negocioPaciente = new NegocioPacientes();

            if (string.IsNullOrWhiteSpace(txtEliminar.Text))
            {
                // si el TextBox esta vacío o solo tiene espacios en blanco
                lblMensaje.Text = "Por favor, ingrese un Dni.";
            }
            else if (txtEliminar.Text.Length == 8)
            {
                string dniN = txtEliminar.Text;

                DataTable reg = negocioPaciente.listarPacienteEspecificoDni(dniN);

                if (reg != null && reg.Rows.Count > 0)
                {
                    gvPacienteInfo.DataSource = reg;
                    gvPacienteInfo.DataBind();

                    lblMensaje.Text = "¿Está seguro de que desea eliminar este paciente?";

                    btnConfirmarEliminar.Visible = true;

                }
                else
                {
                    lblMensaje.Text = "No se encontraron resultados para el paciente.";
                    txtEliminar.Text = "";
                }


            }
            else
            {
                lblMensaje.Text = "Por favor, ingrese un Dni válido.";
                txtEliminar.Text = "";
            }

            
        }
        protected void btnConfirmarEliminar_Click(object sender, EventArgs e)
        {
            NegocioPacientes neg = new NegocioPacientes();
            string dniN = txtEliminar.Text;


            ///avisos sobre si se pudo o no eliminar
            if (neg.eliminarPaciente(dniN))
            {
                lblMensaje.ForeColor = System.Drawing.Color.Green;
                lblMensaje.Text = "Paciente eliminado correctamente";
                gvPacienteInfo.DataSource = null;
                gvPacienteInfo.DataBind();
                txtEliminar.Text = "";
            }
            else
            {
                lblMensaje.Text = "";
                lblMensaje.Text = "Hubo un error al intentar eliminar el paciente.";
                txtEliminar.Text = "";
                gvPacienteInfo.DataSource = null;
                gvPacienteInfo.DataBind();

            }
            // Oculta el boton de confirmacion y limpia el mensaje
           
            btnConfirmarEliminar.Visible = false;
        }
    }
}