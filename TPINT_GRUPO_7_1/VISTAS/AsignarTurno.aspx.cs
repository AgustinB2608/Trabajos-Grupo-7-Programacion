using NEGOCIOS;
using System.Web.UI.WebControls;
using System;
using System.Data.SqlClient;
using System.Data;

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
            ddlEspecialidad.DataTextField = "DescripcionEspecialidad";
            ddlEspecialidad.DataValueField = "Id_Especialidad";
            ddlEspecialidad.DataBind();
            ddlEspecialidad.Items.Insert(0, new ListItem("Seleccionar Especialidad", "0"));

            // Configuración de ddlHorario
            /*ddlHorario.DataSource = negH.ObtenerHorarios();
            ddlHorario.DataTextField = "Horario";
            ddlHorario.DataValueField = "IdHorario";
            ddlHorario.DataBind();*/
            ddlHorario.Items.Insert(0, new ListItem("Seleccionar Horario", "0"));

            /// Configuración de ddlMedico
            /// lo comente porq si no trae los nombres solos y trae todos, la idea es que traiga el nombre completo
            /// y segun la especialidad, queda lo mismo para los horarios, tiene que ser el disponible que tiene ese medico
            /*ddlMedico.DataSource = negM.listarMedicos();
            ddlMedico.DataTextField = "Nombre";
            ddlMedico.DataValueField = "CodigoMedico";
            ddlMedico.DataBind();*/
            ddlMedico.Items.Insert(0, new ListItem("Seleccionar Médico", "0"));

            /*para tomar el turno tiene que tener nombre, apellido y dni del paciente*/
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
            {//no conviene traer pacientes, son muchos, tomar turno con nombre, apellido, dni de paciente
                return; // Si alguna validación falla, no continuar
            }

            // Obtener valores seleccionados de los Dropdowns
            string especialidad = ddlEspecialidad.SelectedValue;
            string horario = ddlHorario.SelectedValue;
            string medico = ddlMedico.SelectedValue;
            ///string paciente = ddlPaciente.SelectedValue;


            ///MedicosSegunEspecialidad



            // Obtener valores de los campos de texto
            string duracionText = txtDuracion.Text.Trim();
            string fecha = txtFecha.Text.Trim();
            ///string estado = txtEstado.Text.Trim();
            //estado no hay que poner nada, por default queda en pendiente y la confirmacion la hace el medico cuando
            //lo atiende, tambien la cancelacion

            // Convertir la duración a int
            int duracion;
            if (!int.TryParse(duracionText, out duracion))
            {
                lblError.Text = "La duración debe ser un número válido.";
                return;
            }

            // Asignar el turno utilizando la lógica de negocio
            /// bool asignado = negT.agregarTurno (medico, especialidad, horario, paciente,  duracion, fecha, estado);

            /*if (asignado)
            {
                lblExito.Text = "Turno asignado correctamente.";
                LimpiarCampos();
            }
            else
            {
                lblError.Text = "Error al asignar el turno.";
            }*/


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


        /// el ultimo item que trae es repetido no tengo idea porq, ver eso
        
        protected void ddlEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            string especialidadSeleccionada = ddlEspecialidad.SelectedValue;

            ///ddlMedico.Items.Insert(0, new ListItem("Seleccionar Médico", "0"));

            // Verificar si la especialidad seleccionada es válida
            if (string.IsNullOrEmpty(especialidadSeleccionada) || especialidadSeleccionada == "0")
            {
                // Limpiar el DropDownList
                ddlMedico.Items.Clear();
                ddlMedico.Items.Add(new ListItem("Seleccionar Especialidad", "0"));
                return;
            }   
                try
                {
                    // Instancia del negocio de médicos
                    NegocioMedico negocioMedico = new NegocioMedico();

                    // Llamar al método MedicosSegunEspecialidad para obtener el DataTable con los médicos
                    DataTable medicos = negocioMedico.MedicosSegunEspecialidad(especialidadSeleccionada);

                    ddlMedico.Items.Clear();
                   

                // Verificar si el DataTable tiene filas
                if (medicos.Rows.Count > 0)
                    {
                    string nombreCompleto, idMedico, horarioAtencion, idhorarioAtencion;
                        foreach (DataRow row in medicos.Rows)
                        {
                        nombreCompleto = $"{row["Nombre"]} {row["Apellido"]}";
                        idMedico = row["CodigoMedico"].ToString();
                        horarioAtencion = row["Horarios de Atención"].ToString();
                        idhorarioAtencion = row["CodHorario"].ToString();

                        // Agregar el elemento al DropDownList de medico
                        ddlMedico.Items.Add(new ListItem(nombreCompleto, idMedico));
                        // horario
                        }

                    }
                    else
                    {
                        // Agregar un mensaje en caso de que no existan médicos
                        ddlMedico.Items.Add(new ListItem("No hay médicos disponibles", "0"));
                    }

                         ddlMedico.Items.Insert(0, new ListItem("Seleccionar Médico", "0"));
                }
                catch (Exception)
                {
                    // Manejo de errores
                    ddlMedico.Items.Clear();
                    ddlMedico.Items.Add(new ListItem("Error al cargar médicos", "0"));

                }


        }

        protected void ddlMedico_SelectedIndexChanged(object sender, EventArgs e)
        {
            string medicoSeleccionado = ddlMedico.SelectedValue;

            // Verificar si la especialidad seleccionada es válida
            if (string.IsNullOrEmpty(medicoSeleccionado) || medicoSeleccionado == "0")
            {
                // Limpiar el DropDownList
                ddlHorario.Items.Clear();
                ddlHorario.Items.Add(new ListItem("Seleccionar Horario", "0"));
                return;
            } 
                ddlHorario.Items.Clear();
            try
            {
                // Instancia del negocio de médicos
                NegocioMedico negocioMedico = new NegocioMedico();

                // Llamar al método MedicosSegunEspecialidad para obtener el DataTable con los médicos
                DataTable medicos = negocioMedico.listarMedicoEspecifico(medicoSeleccionado);

                // Verificar si el DataTable tiene filas
                if (medicos.Rows.Count > 0)
                {
                    string horarioAtencion, idhorarioAtencion;

                    foreach (DataRow row in medicos.Rows)
                    {
                        horarioAtencion = row["Horarios de Atención"].ToString();
                        idhorarioAtencion = row["CodHorario"].ToString();

                         ddlHorario.Items.Add(new ListItem(horarioAtencion, idhorarioAtencion));
                        
                    }

                }
                else
                {
                    // Agregar un mensaje en caso de que no existan médicos
                    ddlHorario.Items.Add(new ListItem("No hay horario disponible", "0"));
                }

                ///ddlHorario.Items.Insert(0, new ListItem("Seleccionar Horario", "0"));
            }
            catch (Exception)
            {
                // Manejo de errores
                ddlHorario.Items.Clear();
                ddlHorario.Items.Add(new ListItem("Error al cargar horarios", "0"));

            }

        }
    }
}
