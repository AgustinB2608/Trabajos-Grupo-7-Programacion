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
    public partial class ListarMedico : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            // Verificar si el usuario está logueado y traer los datos de la sesión (Administrador)
            if (Session["UsuarioLegajo"] != null && Session["UsuarioTipo"] != null && Session["UsuarioTipo"].ToString() == "A")
            {
                string nombre = Session["UsuarioNombre"].ToString(); // Nombre
                string apellido = Session["UsuarioApellido"].ToString(); // Apellido
                string tipoUsuario = Session["UsuarioTipo"].ToString(); // Tipo de usuario

                lblUsuario.Text = $"{nombre} {apellido} ";
            }
            else
            {
                Response.Redirect("InicioLogin.aspx"); // Redirigir si no es un administrador logueado
            }

            if (IsPostBack == false)
            {
                lblMensaje1.Visible = false;
                btnVolver.Visible = false;
            }
            else
            {
                lblMensaje1.Visible = false;
                btnVolver.Visible = true;
            }
           
        }
        private void CargarMedicos()
        {
            try
            {
                // Crear una instancia de la clase NegocioMedico para acceder a sus metodos
                NegocioMedico negocioMedico = new NegocioMedico();

                // Llamar al metodo listarMedicos para obtener todos los medicos en un DataTable
                DataTable dt = negocioMedico.listarMedicos();

                // Asignar el DataTable como origen de datos de la grilla grvMedicos
                grvMedicos.DataSource = dt;

                // Actualizar la grilla para mostrar los datos de los medicos
                grvMedicos.DataBind();

                // Si el DataTable tiene filas limpiar el mensaje de lo contrario mostrar un mensaje
                lblMensaje.Text = dt.Rows.Count > 0
                    ? ""
                    : "No se encontraron médicos.";
            }
            catch (Exception)
            {
                // En caso de excepcion mostrar un mensaje de error
                lblMensaje.Text = "Ocurrió un error al cargar los médicos.";

            }
        }

        protected void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            NegocioMedico negMedico = new NegocioMedico();

            DataTable reg = negMedico.listarMedicos();


            if (reg != null && reg.Rows.Count > 0)
            {
                grvMedicos.DataSource = reg;
                grvMedicos.DataBind();

            }
            else
            {
                lblMensaje1.Visible = true;
                // Si no se encontraron registros
                lblMensaje1.Text = "No se encontraron resultados.";
            }
        }

        protected void btnFiltrar_Click1(object sender, EventArgs e)
        {
            // Verificar si el campo de texto está vacío o contiene solo espacios
            if (string.IsNullOrWhiteSpace(txtMedico.Text))
            {
                lblMensaje.Text = "Por favor, ingrese un Código de Médico o un DNI.";
                return;
            }

            // Determinar si es un DNI (numérico) o un Código de Médico
            string input = txtMedico.Text.Trim();
            bool esDni = int.TryParse(input, out int dni);

            try
            {
                // Crear instancia de la clase de negocio
                NegocioMedico negocioMedico = new NegocioMedico();
                DataTable dt;

                if (esDni)
                {
                    // Filtrar por DNI
                    dt = negocioMedico.listarMedicoEspecificoDni(input);
                }
                else
                {
                    // Filtrar por Código de Médico
                    dt = negocioMedico.listarMedicoEspecifico(input);
                }

                // Mostrar resultados en la grilla
                grvMedicos.DataSource = dt;
                grvMedicos.DataBind();

                // Mostrar mensaje según los resultados
                lblMensaje.Text = dt.Rows.Count > 0
                    ? ""
                    : "No se encontraron médicos con el Código o DNI ingresado.";
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción
                lblMensaje.Text = "Ocurrió un error al filtrar los médicos: " + ex.Message;
            }
            finally
            {
                // Limpiar el campo de texto
                txtMedico.Text = string.Empty;
            }
        }
    }
}