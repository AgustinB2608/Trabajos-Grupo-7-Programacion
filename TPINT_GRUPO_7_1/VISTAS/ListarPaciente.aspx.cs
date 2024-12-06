using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NEGOCIOS;
using ENTIDADES;

namespace VISTAS
{
    public partial class ListarPaciente : System.Web.UI.Page
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

            if (IsPostBack == false)
            {
                
                btnAtras.Visible = false;
            }
            else
            {
                
                btnAtras.Visible = true;
            }
        }

        protected void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            NegocioPacientes negP = new NegocioPacientes();

            DataTable lista = negP.listarPacientes();

            if (lista != null && lista.Rows.Count > 0)
            {
                gvPaciente.DataSource = lista;
                gvPaciente.DataBind();
            }
            else
            {
                lblMensaje.Text = "No se encontraron registros de pacientes.";
            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            NegocioPacientes negP = new NegocioPacientes();

            if (txtListar.Text.Length != 8 || string.IsNullOrEmpty(txtListar.Text))
            {
                lblMensaje.Text = "El DNI es invalido";
                return;
            }
            string contenido = txtListar.Text.Trim();

            DataTable lista = negP.listarPacienteEspecificoDni(txtListar.Text);

            if (lista != null && lista.Rows.Count > 0)
            {
                gvPaciente.DataSource = lista;
                gvPaciente.DataBind();
            }
            else
            {
                lblMensaje.Text = "No se encontraron registros de pacientes.";
            }
        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {
            Response.Redirect("ABMLPacientes.aspx");
        }
    }
}