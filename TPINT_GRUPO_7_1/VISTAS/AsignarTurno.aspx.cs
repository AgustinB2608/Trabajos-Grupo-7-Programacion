using NEGOCIOS;
using System.Web.UI.WebControls;
using System;
using System.Data.SqlClient;

namespace VISTAS
{
    public partial class AsignarTurno : System.Web.UI.Page
    {
        NegocioEspecialidades negE = new NegocioEspecialidades();
        NegocioHorarios negH = new NegocioHorarios();
        NegocioPacientes negP = new NegocioPacientes();
        NegocioMedico negM = new NegocioMedico();
        NegocioTurnos negT = new NegocioTurnos();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Verificar si el usuario está logueado y es administrador
                if (Session["UsuarioLegajo"] != null && Session["UsuarioTipo"] != null && Session["UsuarioTipo"].ToString() == "A")
                {
                    string nombre = Session["UsuarioNombre"].ToString(); // Nombre
                    string apellido = Session["UsuarioApellido"].ToString(); // Apellido
                    string tipoUsuario = Session["UsuarioTipo"].ToString(); // Tipo de usuario

                    lblUsuario.Text = $"{nombre} {apellido}";
                }
                else
                {
                   // Response.Redirect("InicioLogin.aspx"); // Redirigir si no está logueado o no es admin
                }

                InicializarDropDownLists(); // Cargar los dropdowns
            }
        }

        private void InicializarDropDownLists()
        {
            // Configuración de ddlEspecialidad
            ddlEspecialidad.DataSource = negE.ObtenerNombresEspecialidades();
            ddlEspecialidad.DataTextField = "NombreEspecialidad_ES";
            ddlEspecialidad.DataValueField = "NombreEspecialidad_ES";
            ddlEspecialidad.DataBind();
            ddlEspecialidad.Items.Insert(0, new ListItem("Seleccione Especialidad", "0"));

            // Configuración de ddlHorario
            ddlHorario.DataSource = negH.ObtenerHorarios();
            ddlHorario.DataTextField = "Horario";
            ddlHorario.DataValueField = "IdHorario";
            ddlHorario.DataBind();
            ddlHorario.Items.Insert(0, new ListItem("Seleccione un horario para turno", "0"));

            // Configuración de ddlMedico
            ddlMedico.DataSource = negM.ObtenerMedico();
            ddlMedico.DataTextField = "Nombre";
            ddlMedico.DataValueField = "CodMedico";
            ddlMedico.DataBind();
            ddlMedico.Items.Insert(0, new ListItem("Seleccione un medico para asignar turno", "0"));

            // Configuración de ddlPaciente
            ddlPaciente.DataSource = negP.ObtenerPacientes();
            ddlPaciente.DataTextField = "Nombre";
            ddlPaciente.DataValueField = "CodPaciente";
            ddlPaciente.DataBind();
            ddlPaciente.Items.Insert(0, new ListItem("Seleccione un paciente para asignar turno", "0"));
        }

        protected void btnAsignar_Click(object sender, EventArgs e)
        {
            // Validación de campos vacíos
            if (!ValidarCamposVacios())
            {
                lblError.Text = "Todos los campos son obligatorios.";
                return;
            }

            // Validación de Dropdowns
            if (!ValidarSeleccionDropDown(ddlEspecialidad, "Debe seleccionar una especialidad.") ||
                !ValidarSeleccionDropDown(ddlHorario, "Debe seleccionar un horario.") ||
                !ValidarSeleccionDropDown(ddlMedico, "Debe seleccionar un médico.") ||
                !ValidarSeleccionDropDown(ddlPaciente, "Debe seleccionar un paciente."))
            {
                return; // Si alguna validación falla, no continuar
            }

            // Obtener valores seleccionados de los Dropdowns
            string especialidad = ddlEspecialidad.SelectedValue;
            string horario = ddlHorario.SelectedValue;
            string medico = ddlMedico.SelectedValue;
            string paciente = ddlPaciente.SelectedValue;

            // Obtener valores de los campos de texto
            string duracionText = txtDuracion.Text.Trim();
            string fecha = txtFecha.Text.Trim();
            string estado = txtEstado.Text.Trim();

            // Convertir la duración a int
            int duracion;
            if (!int.TryParse(duracionText, out duracion))
            {
                lblError.Text = "La duración debe ser un número válido.";
                return;
            }

            // Asignar el turno utilizando la lógica de negocio
            bool asignado = negT.agregarTurno(medico, especialidad, horario, paciente, duracion, fecha, estado);

            if (asignado)
            {
                lblExito.Text = "Turno asignado correctamente.";
                LimpiarCampos();
            }
            else
            {
                lblError.Text = "Error al asignar el turno.";
            }
        }



        // Función para validar que los campos no estén vacíos
        private bool ValidarCamposVacios()
        {
            return !(string.IsNullOrWhiteSpace(ddlEspecialidad.SelectedValue) ||
                     string.IsNullOrWhiteSpace(ddlHorario.SelectedValue) ||
                     string.IsNullOrWhiteSpace(ddlMedico.SelectedValue) ||
                     string.IsNullOrWhiteSpace(ddlPaciente.SelectedValue));
        }

        // Función para validar DropDownList
        private bool ValidarSeleccionDropDown(DropDownList ddl, string mensajeError)
        {
            if (ddl.SelectedValue == "0" || string.IsNullOrWhiteSpace(ddl.SelectedValue))
            {
                lblError.Text = mensajeError;
                return false;
            }
            return true;
        }

        // Limpiar campos después de asignar el turno
        private void LimpiarCampos()
        {
            ddlEspecialidad.SelectedIndex = 0;
            ddlHorario.SelectedIndex = 0;
            ddlMedico.SelectedIndex = 0;
            ddlPaciente.SelectedIndex = 0;
        }



    }
}
