using NEGOCIOS;
using System.Web.UI.WebControls;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using ENTIDADES;

namespace VISTAS
{
    public partial class AsignarTurno : System.Web.UI.Page
    {
        NegocioEspecialidades negE = new NegocioEspecialidades();
        NegocioHorarios negH = new NegocioHorarios();
        NegocioPacientes negP = new NegocioPacientes();
        NegocioMedico negM = new NegocioMedico();
        NegocioTurnos negT = new NegocioTurnos();
        
        /// **********************************
        /// funciona perfecto, faltaria un verificar turno, con el proced. ya hecho, para ver si ese turno ya esta ocupado
        /// pensé en algun boton de verificar disponibilidad, porque metiendolo dentro del codigo no funciona, probe de todo
        /// **********************************
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

                    lblUsuario.Text = $"{nombre} {apellido}{tipoUsuario}";
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


            ddlMedico.Items.Add(new ListItem("Seleccionar Médico", "0"));
            ddlHoraAsignada.Items.Add(new ListItem("Turnos Disponibles", "0"));
           
            /*para tomar el turno tiene que tener nombre, apellido y dni del paciente*/
        }

        protected void btnAsignar_Click(object sender, EventArgs e)
        {
            // Validación de campos vacíos
            if (!ValidarCamposVacios())
            {
                lblMensaje.Text = "Todos los campos son obligatorios.";
                return;
            }

            // Validación de Dropdowns
            if (!ValidarCamposVacios()) return;

            // Obtener valores seleccionados de los Dropdowns
            //obj turnos
            TimeSpan horario = TimeSpan.Parse(ddlHoraAsignada.SelectedValue);
            Turnos turno = new Turnos(ddlEspecialidad.Text, ddlMedico.SelectedValue, txtNombrePaciente.Text, txtApellidoPaciente.Text,
                txtDniPaciente.Text, txtFecha.Text.ToString(), horario);
           
            // Asignar el turno utilizando la lógica de negocio
            bool asignado = negT.agregarTurno(turno);

            if (asignado)
            {
                lblTurnoOcupado.Text = "";
                lblMensaje.ForeColor = System.Drawing.Color.Green;
                lblMensaje.Text = "Turno asignado correctamente.";
                LimpiarCampos();
            }
            else
            {
                lblMensaje.Text = "Error al asignar el turno. Recuerde que el paciente debe estar previamente registrado";
            }


        }



        // Función para validar que los campos no estén vacíos
        private bool ValidarCamposVacios()
        {
            if (ddlEspecialidad.SelectedValue == "0" ||
                ddlMedico.SelectedValue == "0" ||
                ddlHoraAsignada.SelectedValue == "0" ||
                string.IsNullOrWhiteSpace(txtNombrePaciente.Text) ||
                string.IsNullOrWhiteSpace(txtApellidoPaciente.Text) ||
                string.IsNullOrWhiteSpace(txtDniPaciente.Text) ||
                string.IsNullOrWhiteSpace(txtHorario.Text) ||
                string.IsNullOrWhiteSpace(txtFecha.Text))
            {
                lblMensaje.Text = "Debe completar todos los campos obligatorios.";
                return false;
            }
            return true;
        }


        // Función para validar DropDownList
        private bool ValidarSeleccionDropDown(DropDownList ddl, string mensajeError)
        {
            if (ddl.SelectedValue == "0" || string.IsNullOrWhiteSpace(ddl.SelectedValue))
            {
                lblMensaje.Text = mensajeError;
                return false;
            }
            return true;
        }

        // Limpiar campos después de asignar el turno
        private void LimpiarCampos()
        {
            ddlEspecialidad.Items.Clear();
            ddlEspecialidad.Items.Add(new ListItem("Seleccionar Especialidad", "0"));
            ddlHoraAsignada.Items.Clear();
            ddlHoraAsignada.Items.Add(new ListItem("Turnos Disponibles", "0"));
            ddlMedico.Items.Clear();
            ddlMedico.Items.Add(new ListItem("Seleccionar Médico", "0"));
            txtHorario.Text = "";
            txtNombrePaciente.Text = "";
            txtApellidoPaciente.Text = "";
            txtDniPaciente.Text = "";
            txtFecha.Text = "";
        }



        /// el ultimo item que trae es repetido no tengo idea porq, ver eso

        protected void ddlEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            string especialidadSeleccionada = ddlEspecialidad.SelectedValue;
            txtHorario.Text = "";
            ddlHoraAsignada.Items.Clear();
            ddlHoraAsignada.Items.Add(new ListItem("Turnos Disponibles", "0"));

            // Verificar si la especialidad seleccionada es válida
            if (string.IsNullOrEmpty(especialidadSeleccionada) || especialidadSeleccionada == "0")
            {
                // Limpiar el DropDownList de médicos
                ddlMedico.Items.Clear();
                ddlMedico.Items.Add(new ListItem("Seleccionar Médico", "0"));
                return;
            }
            
            try
            {
                // Instancia de la clase de negocios
                NegocioMedico negocioMedico = new NegocioMedico();

                // Llamar al método que obtiene los médicos y horarios por especialidad
                DataTable medicos = negocioMedico.MedicosSegunEspecialidad(especialidadSeleccionada);

                // Limpiar el DropDownList de médicos
                ddlMedico.Items.Clear();
                ddlMedico.Items.Add(new ListItem("Seleccionar Médico", "0"));

                if (medicos.Rows.Count > 0)
                {
                    string nombreMedico, codigoMedico, horarioAtencion, idHorarioAtencion, DiasAtencion;

                    foreach (DataRow row in medicos.Rows)
                    {
                        nombreMedico = row["NombreMedico"].ToString();
                        codigoMedico = row["CodigoMedico"].ToString();
                        horarioAtencion = row["HorarioAtencion"].ToString();
                        idHorarioAtencion = row["CodHorario"].ToString();
                        DiasAtencion = row["DiasAtencion"].ToString(); 

                        // Agregar médicos al DropDownList
                        ddlMedico.Items.Add(new ListItem(nombreMedico, codigoMedico));
                        
                    }
                }
                else
                {
                    ddlMedico.Items.Add(new ListItem("No hay médicos disponibles", "0"));
                }
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
            txtHorario.Text = "";
            ddlHoraAsignada.Items.Clear();
            ddlHoraAsignada.Items.Add(new ListItem ("Turnos Disponibles","0"));

            // Verificar si el médico seleccionado es válido
            if (string.IsNullOrEmpty(medicoSeleccionado) || medicoSeleccionado == "0")
            {
                // Limpiar el DropDownList de horarios
                
                return;
            }

            try
            {
                // Llamar al método para obtener los horarios de atención según el médico
                DataTable medicos = negM.HorarioSegunMedico(medicoSeleccionado);

                if (medicos.Rows.Count > 0)
                {
                    string horarioAtencion, DiasAtencion, desde, hasta;

                    foreach (DataRow row in medicos.Rows)
                    {
                        horarioAtencion = row["HorarioAtencion"].ToString();
                        DiasAtencion = row["DiasAtencion"].ToString();
                        desde = row["Desde"].ToString();
                        hasta = row["Hasta"].ToString();

                        txtHorario.Text = horarioAtencion + " | " + DiasAtencion;

                        // Convierte las cadenas a TimeSpan
                        TimeSpan desdeHs = TimeSpan.Parse(desde);
                        TimeSpan hastaHs = TimeSpan.Parse(hasta);
                       
                        for (TimeSpan hora = desdeHs; hora <= hastaHs; hora = hora.Add(TimeSpan.FromMinutes(60)))
                        {
                            string horaFinal = hora.ToString(@"hh\:mm"); // Formatea la hora como hh:mm
                            ddlHoraAsignada.Items.Add(new ListItem(horaFinal, horaFinal));
                        }
                    }
                }
                else
                {
                    txtHorario.Text = "No hay horarios disponibles";
                }
            }
            catch (Exception)
            {
                // Manejo de errores
                txtHorario.Text = "";
                txtHorario.Text = "Error al cargar horarios";
            }
        }

        protected void ddlHoraAsignada_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fecha = txtFecha.Text.Trim();
            TimeSpan horarioSeleccionado = TimeSpan.Parse(ddlHoraAsignada.SelectedValue);
            string medico = ddlMedico.SelectedValue;
            string especialidad = ddlEspecialidad.SelectedValue;
            DateTime fechaSeleccionada;
            DateTime.TryParse(fecha, out fechaSeleccionada);

            if (negH.EncontrarTurno(horarioSeleccionado, fechaSeleccionada, especialidad, medico))
            {
                lblTurnoOcupado.Text = "El turno seleccionado se encuentra ocupado.";
            }
            else
            {
                lblTurnoOcupado.ForeColor = System.Drawing.Color.Green;
                lblTurnoOcupado.Text = "Turno Disponible.";
            }

        }
    }
}
